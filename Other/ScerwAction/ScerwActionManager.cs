using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using ScerwActionHelper.Common;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScerwActionHelper
{
    /// <summary>
    /// 打螺丝工艺管理类
    /// </summary>
    public class ScerwActionManager
    {
        private readonly static ScerwActionManager instance = new ScerwActionManager();
        private List<SingleScrewActionCfg> _screwActionCfgs = new List<SingleScrewActionCfg>();
        public static ScerwActionManager Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 添加螺丝任务动作配置（放在初始化中执行）
        /// </summary>
        /// <param name="screwActionCfg"></param>
        public void AddScrewActionCfg(SingleScrewActionCfg screwActionCfg)
        {
            if (screwActionCfg == null)
            {
                return;
            }
            var singleScrewCfg = _screwActionCfgs.FirstOrDefault(x => x.ScrewTaskName == screwActionCfg.ScrewTaskName);
            if (singleScrewCfg != null)
            {
                _screwActionCfgs.Remove(singleScrewCfg);
            }
            _screwActionCfgs.Add(screwActionCfg);
        }

        private int InterpolationMov(string strInterpolationName, Pos pos, ITask task, int timeout)
        {
            /*执行插补，走对应的螺丝任务点位*/
            int iRet = 0;
            if (string.IsNullOrEmpty(strInterpolationName))
            {
                return 0;
            }
            var interPolationCfg = CmpTrigManager.Instance.CurrentProduct.InterpolationDatas.FirstOrDefault(p => p.Value.Name == strInterpolationName).Value;
            if (interPolationCfg != null)
            {
                var eleCartesian = (IEleCartesian)ElesManager.Instance.GetEleByName(interPolationCfg.EleName);
                List<InterPolationPos> interPolationPos = interPolationCfg.InterPolationPoses;

                if (pos != null)
                {
                    var tempInterPolationPos = ScerwCommon.InterPolationPosClone(interPolationPos);
                    tempInterPolationPos.ForEach(p =>
                    {
                        p.Pos.X = pos.X;
                        p.Pos.Y = pos.Y;
                    });
                    interPolationCfg.InterPolationPoses = tempInterPolationPos;
                }

                if (interPolationCfg.Move(eleCartesian, timeout, false, task, "", "", null, false) != 0)
                {
                    iRet = -7;//运动失败
                }
                interPolationCfg.InterPolationPoses = interPolationPos;
            }
            else
            {
                iRet = -6;//未找到对应的插补表
            }
            return iRet;

        }
        /// <summary>
        /// 执行打螺丝任务
        /// </summary>
        /// <param name="screwTaskName">螺丝任务名称</param>
        /// <param name="pos">视觉引导点位，（如果没有可为null，执行表中的点位XYZ）</param>
        /// <returns>0:成功；
        /// -1：螺丝枪结果反馈NG；
        /// -2：未找到对应的螺丝任务；
        /// -3：未找到螺丝枪对象
        /// -4：启动螺丝枪任务位失败
        /// -5：启动螺丝枪任务后等待螺丝枪BUYS超时
        /// -6:未找到对应的插补表
        /// -7：插补运动失败
        /// -8：运动完成等待螺丝枪BUYS超时
        /// </returns>
        public int ExecuteRun(string screwTaskName, Pos pos=null)
        {
            var screwActionCfg = _screwActionCfgs.FirstOrDefault(x => x.ScrewTaskName == screwTaskName);
            if (screwActionCfg == null)
            {
                return -2;//未找到对应的螺丝任务
            }
            if (screwActionCfg.Screwobject == null)
            {
                return -3;//未找到螺丝枪对象
            }
            if (screwActionCfg.Screwobject is ScerwXYD)
            {
                return ExecuteScerwXYD(screwActionCfg, pos);
            }

            return -99;
        }
        private int ExecuteScerwXYD(SingleScrewActionCfg screwActionCfg, Pos pos)
        {
            /*发送螺丝任务*/
            if (SetXYDTaskIndex(screwActionCfg) != 0)
            {
                return -4;//设置螺丝枪任务位失败
            }
            var xYD = screwActionCfg.Screwobject as ScerwXYD;
            /*等待BUSY信号*/
            if (!SpinWait.SpinUntil(() =>
            {
                Thread.Sleep(50);
                return ScerwCommon.GetDi(xYD.Di_螺丝枪Busy) == false;
            }, screwActionCfg.Timeout))
            {
                return -5;//螺丝枪忙碌超时
            }
            ScerwCommon.SetDo(xYD.Do_螺丝枪启动, true);
            /*判断有无轴动作，有执行轴动作*/
            if (!string.IsNullOrWhiteSpace(screwActionCfg.StrInterpolationName))
            {
                int iRet = InterpolationMov(screwActionCfg.StrInterpolationName, pos, xYD.Task, screwActionCfg.Timeout);
                if (iRet != 0)
                {
                    return iRet;
                }
            }
            else
            {
                Thread.Sleep(100);
            }
            /*等待BUSY信号*/
            if (!SpinWait.SpinUntil(() =>
            {
                Thread.Sleep(50);
                return ScerwCommon.GetDi(xYD.Di_螺丝枪Busy) == false;
            }, 5000))
            {
                return -8;//螺丝枪忙碌超时
            }

            Thread.Sleep(20);
            ScerwCommon.SetDo(xYD.Do_螺丝枪启动, false);

            if (ScerwCommon.GetDi(xYD.Di_结果反馈) == true)
            {
                return 0;
            }
            else
            {
                return -1;
            }


            return 0;
        }
        private int SetXYDTaskIndex(SingleScrewActionCfg screwActionCfg)
        {
            var xYD = screwActionCfg.Screwobject as ScerwXYD;
            var flag = ScerwCommon.GetDo(xYD.Do_螺丝枪启动);
            if (flag == null)
            {
                return -1;
            }
            if (flag == true)
            {
                ScerwCommon.SetDo(xYD.Do_螺丝枪启动, false);
                Thread.Sleep(200);
            }
            for (int i = 0; i < xYD.Do_螺丝枪任务位.Length; i++)
            {
                ScerwCommon.SetDo(xYD.Do_螺丝枪任务位[i], false);
            }
            Thread.Sleep(50);
            for (int i = 0; i < xYD.Do_螺丝枪任务位.Length; i++)
            {
                ScerwCommon.SetDo(xYD.Do_螺丝枪任务位[i], screwActionCfg.ScrewActionCmd[i]);
            }
            return 0;
        }

        /// <summary>
        /// 初始化（只需要放在一个TASK任中的Init执行）
        /// </summary>
        public void Itialization()
        {
            _screwActionCfgs.Clear();
            ScerwCommon.IniDiDoDictionary();
        }
    }
}
