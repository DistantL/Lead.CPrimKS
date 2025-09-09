using Lead.CPrim.CmpTrigHelper.ConfigClass;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Ele;
using Lead.CPrim.Interfaces.IMotionCard;
using Lead.CPrim.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Lead.CPrim.ProxyTools;
using System.Threading.Tasks;

namespace Lead.CPrim.CmpTrigHelper
{
    public partial class TriggerPort : UserControl
    {
        #region Field
        private IEleAxis _axis;

        /// <summary>
        /// 轴组元件
        /// </summary>
        private IEle _ele;

        /// <summary>
        /// 运动基元
        /// </summary>
        private IPrim _primMove;

        /// <summary>
        /// 触发基元
        /// </summary>
        private IPrim _primTrigger;



        private TriggerPortData _triggerData;
        #endregion



        #region Ctor

        public TriggerPort()
        {
            InitializeComponent();

            BackColor = Colors.PrimaryBackColor236;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

        public TriggerPort(TriggerPortData triggerData) : this()
        {
            _triggerData = triggerData;
        }
        #endregion



        #region Event_System

        private void TriggerConfigControl_Load(object sender, EventArgs e)
        {
            TbCmbInit(_triggerData);
            FindTables(_triggerData);
            FindPrimAndEle(_triggerData);
        }

        private void TriggerConfigControl_DoubleClick(object sender, EventArgs e)
        {
            _triggerData.IsSelected = !_triggerData.IsSelected;
        }

        private void OnLanguageChanged()
        {
            lblTrigName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigName", "触发名称:");
            lblEleName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Element", "元件关联:");
            lblTrigChannel.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigChannel", "触发通道:");
            lblTrigPulse.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigPulse", "触发脉冲:");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Enable", "使能");
            lblPrimType.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_DeviceType", "设备类型:");
            lblAxisName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_AxisIndex", "轴名称:");
            lblTrigMode.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigMode", "触发模式:");
            lblTrigTable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigTable", "触发表:");
            lblMoveMode.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_PulseDir", "运动模式:");
            btnSet.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Setting", "设置");
            lblPrimMove.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_DevicePrim", "基元关联:");
            lblPosSource.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_PosSource", "位置源:");
            lblLogicDir.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Logic", "电平方向:");
            lblMoveTable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrajTable", "轨迹表:");
            lblMoveDir.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Direction", "行进方向:");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Apply", "应用");
            btnTestTrig.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TestTrig", "测试");
        }
        #endregion



        #region Event_Button
        /// <summary>
        /// 基元类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPrimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbPrimType.SelectedIndex;
            if (index == 0)
            {
                lblPrimTrigger.Enabled = false;
                cmbPrimTrigger.SelectedIndex = -1;
                cmbPrimTrigger.Enabled = false;
            }
            else if (index == 1)
            {
                lblPrimTrigger.Enabled = true;
                cmbPrimTrigger.Enabled = true;
                lblPrimTrigger_Click(null, null);
            }
        }

        /// <summary>
        /// 运动基元
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbDevicePrim_Click(object sender, EventArgs e)
        {
            UpdatePrims();
        }

        /// <summary>
        /// 触发基元
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPrimTrigger_Click(object sender, EventArgs e)
        {
            var prims = PrimsManagerTransfer.GetAllIPrim();
            if (prims.IsNullOrEmpty())
            {
                return;
            }

            cmbPrimTrigger.SelectedIndex = -1;
            cmbPrimTrigger.Items.Clear();
            prims.ForEach(delegate (IPrim prim)
            {
                if (prim is IMotionCard || prim is ICmpTrig)
                {
                    cmbPrimTrigger.Items.Add(prim.Name);
                }
            });
        }

        /// <summary>
        /// 关联元件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbElementName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cmbElementName.SelectedItem?.ToString();
            if (!name.IsNullOrEmpty())
            {
                _ele = ElesManagerTransfer.GetEleByName(name);
                UpdateAxises();
            }
        }

        /// <summary>
        /// 触发通道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTrigChannel_Click(object sender, EventArgs e)
        {
            ICmpTrig val = (ICmpTrig)_primTrigger;
            if (val != null)
            {
                val.SetManualTrig(cmbTrigChannel.SelectedIndex, int.Parse(txtPulseWidth.Text) * 1000);
            }
        }

        /// <summary>
        /// 触发模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTrigMode_Click(object sender, EventArgs e)
        {
            int index = cmbTrigMode.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            ICmpTrig val = (ICmpTrig)_primTrigger;
            if (val != null)
            {
                val.SetTriggerChannelMode(cmbTrigChannel.SelectedIndex, index);
            }
        }

        /// <summary>
        /// 触发模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTrigMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbTrigMode.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            if (index == 4 || index == 5 || index == 6)
            {
                lblTrigTable_Click(null, null);
            }
        }

        /// <summary>
        /// 触发表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTrigTable_Click(object sender, EventArgs e)
        {
            //队列、线性
            if (cmbTrigMode.SelectedIndex == 4 || cmbTrigMode.SelectedIndex == 5)
            {
                UpdateTrigTable();
            }
            //多队列
            else if (cmbTrigMode.SelectedIndex == 6)
            {
                UpdateTrigTable2();
            }
        }

        /// <summary>
        /// 电平方向
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbLogic_Click(object sender, EventArgs e)
        {
            ICmpTrig val = (ICmpTrig)_primTrigger;
            if (val != null)
            {
                val.SetTrigOutputLogic(cmbTrigChannel.SelectedIndex, cmbLogicDir.SelectedIndex);
            }
        }

        /// <summary>
        /// 脉冲宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbPulseWidth_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPulseWidth.Text, out var result))
            {
                ICmpTrig val = (ICmpTrig)_primTrigger;
                if (val != null)
                {
                    val.SetTrigOutputPulseWidth(cmbTrigChannel.SelectedIndex, result);
                }
            }
        }

        /// <summary>
        /// 运动模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMoveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbMoveMode.SelectedIndex;
            if (index < 0)
            {
                return;
            }

            lblMoveTable_Click(null, null);
        }

        /// <summary>
        /// 轨迹表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblMoveTable_Click(object sender, EventArgs e)
        {
            UpdateTrajTable();
        }

        /// <summary>
        /// 关联元件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEleName_Click(object sender, EventArgs e)
        {
            UpdateEles();
        }

        /// <summary>
        /// 使能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            _triggerData.Enable = chkEnable.Checked;
        }

        /// <summary>
        /// 应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _triggerData.Name = txtTrigName.Text;
            _triggerData.PrimType = cmbPrimType.SelectedIndex;
            _triggerData.PrimMoveName = cmbPrimMove.SelectedItem?.ToString();
            _triggerData.PrimTriggerName = cmbPrimTrigger.SelectedItem?.ToString();
            _triggerData.TrigPulse = txtTrigPulse.Text.ToDouble();

            _triggerData.TrigChannel = cmbTrigChannel.SelectedIndex;
            _triggerData.TrigMode = cmbTrigMode.SelectedIndex;
            _triggerData.TrigTableName = cmbTrigTable.SelectedItem?.ToString();
            _triggerData.LogicDir = cmbLogicDir.SelectedIndex;
            _triggerData.PulseWidth = txtPulseWidth.Text.ToDouble();

            _triggerData.MoveMode = cmbMoveMode.SelectedIndex;
            _triggerData.TrajName = cmbMoveTable.SelectedItem?.ToString();
            _triggerData.EleName = cmbElementName.SelectedItem?.ToString();
            _triggerData.AxisName = cmbAxisName.SelectedItem?.ToString();
            _triggerData.MoveDir = ((cmbMoveDir.SelectedIndex == -1) ? 2 : cmbMoveDir.SelectedIndex);

            _triggerData.CmpSource = cmbPosSource.SelectedIndex;
            _triggerData.Enable = chkEnable.Checked;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                _triggerData.Set(null);
                Notification.ShowInfo(NLocalizer.SetSuccess);
            }
            catch (Exception ex)
            {
                Notification.ShowWarn($"{NLocalizer.SetError}：{ex.Message}");
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestTrig_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                try
                {
                    UIWaitFormService.ShowWaitForm(NLocalizer.PleaseWait);
                    int ret = _triggerData.Instance.CmpTrigRun(_triggerData.Name, out var cmpCount, _triggerData.Instance.CurrentProductName);
                    UIWaitFormService.HideWaitForm();
                    if(ret == 0)
                    {
                        Notification.ShowInfo($"{NLocalizer.TriggerSuccess} -> {cmpCount}");
                    }
                    else
                    {
                        Notification.ShowError($"{NLocalizer.TriggerError} -> {cmpCount}");
                    }
                }
                catch (Exception ex)
                {
                    Notification.ShowWarn($"{NLocalizer.TestError}：{ex.Message}");
                }
            });
        }

        #endregion



        #region Method_InternalUsing
        /// <summary>
        /// Load_1<br/>
        /// 界面初始化
        /// </summary>
        /// <param name="triggerData"></param>
        private void TbCmbInit(TriggerPortData triggerData)
        {
            //获取基元
            UpdatePrims();
            //获取元件
            UpdateEles();
            //更新运动模式
            UpdateMoveMode();
            //获取运动表
            UpdateTrajTable();
            //获取触发表
            UpdateTrigTable();

            txtTrigName.Text = triggerData.Name;
            cmbPrimType.SelectedIndex = triggerData.PrimType;
            //运动基元
            //触发基元
            txtTrigPulse.Text = triggerData.TrigPulse.ToString();
            cmbTrigChannel.SelectedIndex = triggerData.TrigChannel;
            cmbTrigMode.SelectedIndex = triggerData.TrigMode;
            //触发表
            cmbLogicDir.SelectedIndex = triggerData.LogicDir;
            txtPulseWidth.Text = triggerData.PulseWidth.ToString();
            cmbMoveMode.SelectedIndex = triggerData.MoveMode;
            //轨迹表
            //元件关联
            //轴名称
            cmbMoveDir.SelectedIndex = triggerData.MoveDir;
            cmbPosSource.SelectedIndex = triggerData.CmpSource;
            chkEnable.Checked = triggerData.Enable;
        }

        /// <summary>
        /// Load_2<br/>
        /// 触发表、轨迹表初始化
        /// </summary>
        /// <param name="triggerData"></param>
        private void FindTables(TriggerPortData triggerData)
        {
            if (!string.IsNullOrEmpty(triggerData.TrigTableName))
            {
                if (!cmbTrigTable.Items.Contains(triggerData.TrigTableName))
                {
                    cmbTrigTable.Items.Add(triggerData.TrigTableName);
                }
                cmbTrigTable.SelectedItem = triggerData.TrigTableName;
            }

            if (!string.IsNullOrEmpty(triggerData.TrajName))
            {
                if (!cmbMoveTable.Items.Contains(triggerData.TrajName))
                {
                    cmbMoveTable.Items.Add(triggerData.TrajName);
                }
                cmbMoveTable.SelectedItem = triggerData.TrajName;
            }
        }

        /// <summary>
        /// Load_3<br/>
        /// 触发表、轨迹表初始化
        /// </summary>
        /// <param name="triggerData"></param>
        private void FindPrimAndEle(TriggerPortData triggerData)
        {
            if (triggerData.PrimType == 0)
            {
                cmbPrimType.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(triggerData.PrimMoveName))
                {
                    if (!cmbPrimMove.Items.Contains(triggerData.PrimMoveName))
                    {
                        cmbPrimMove.Items.Add(triggerData.PrimMoveName);
                    }
                    cmbPrimMove.SelectedItem = triggerData.PrimMoveName;
                    _primMove = PrimsManagerTransfer.GetPrimByName(triggerData.PrimMoveName);
                    _primTrigger = PrimsManagerTransfer.GetPrimByName(triggerData.PrimMoveName);
                }
            }
            else if (triggerData.PrimType == 1)
            {
                cmbPrimType.SelectedIndex = 1;
                if (!string.IsNullOrEmpty(triggerData.PrimMoveName))
                {
                    if (!cmbPrimMove.Items.Contains(triggerData.PrimMoveName))
                    {
                        cmbPrimMove.Items.Add(triggerData.PrimMoveName);
                    }
                    cmbPrimMove.SelectedItem = triggerData.PrimMoveName;
                    _primMove = PrimsManagerTransfer.GetPrimByName(triggerData.PrimMoveName);
                }
                if (!string.IsNullOrEmpty(triggerData.PrimTriggerName))
                {
                    if (!cmbPrimTrigger.Items.Contains(triggerData.PrimTriggerName))
                    {
                        cmbPrimTrigger.Items.Add(triggerData.PrimTriggerName);
                    }
                    cmbPrimTrigger.SelectedItem = triggerData.PrimTriggerName;
                    _primTrigger = PrimsManagerTransfer.GetPrimByName(triggerData.PrimTriggerName);
                }
            }

            if (string.IsNullOrEmpty(triggerData.EleName))
            {
                return;
            }
            if (!cmbElementName.Items.Contains(triggerData.EleName))
            {
                cmbElementName.Items.Add(triggerData.EleName);
            }
            cmbElementName.SelectedItem = triggerData.EleName;
            _ele = ElesManagerTransfer.GetEleByName(triggerData.EleName);

            UpdateAxises();
            if (!string.IsNullOrEmpty(triggerData.AxisName))
            {
                if (!cmbAxisName.Items.Contains(triggerData.AxisName))
                {
                    cmbAxisName.Items.Add(triggerData.AxisName);
                }
                cmbAxisName.SelectedItem = triggerData.AxisName;
                if (_ele != null)
                {
                    _axis = ((IEleCartesian)_ele).GetAxisByName(triggerData.AxisName);
                }
            }
        }

        /// <summary>
        /// 获取基元
        /// </summary>
        private void UpdatePrims()
        {
            var prims = PrimsManagerTransfer.GetAllIPrim();
            if (prims.IsNullOrEmpty())
            {
                return;
            }

            cmbPrimMove.SelectedIndex = -1;
            cmbPrimMove.Items.Clear();
            prims.ForEach(delegate (IPrim prim)
            {
                if (prim is IMotionCard || prim is ICmpTrig)
                {
                    cmbPrimMove.Items.Add(prim.Name);
                }
            });
        }

        /// <summary>
        /// 获取轴组名称
        /// </summary>
        private void UpdateEles()
        {
            List<IEle> eles = ElesManagerTransfer.GetAllIEle();
            if (eles.IsNullOrEmpty())
            {
                return;
            }

            cmbElementName.SelectedIndex = -1;
            cmbElementName.Items.Clear();
            eles.ForEach(delegate (IEle ele)
            {
                if (ele is IEleCartesian)
                {
                    cmbElementName.Items.Add(ele.Name);
                }
            });
        }

        /// <summary>
        /// 更新运动模式
        /// </summary>
        private void UpdateMoveMode()
        {
            cmbMoveMode.DataSource = new MoveMode[] { MoveMode.轨迹表, MoveMode.插补表, MoveMode.复杂插补 };
        }

        /// <summary>
        /// 获取运动表
        /// </summary>
        private void UpdateTrajTable()
        {
            try
            {
                //触发表
                cmbMoveTable.Items.Clear();
                cmbMoveTable.SelectedIndex = -1;
                //未选择运动模式
                if (cmbMoveMode.SelectedItem == null)
                {
                    return;
                }

                string name = cmbMoveMode.SelectedItem?.ToString();
                if (Enum.TryParse(name, out MoveMode mode))
                {
                    switch (mode)
                    {
                        case MoveMode.轨迹表:
                            _triggerData.Instance.CurrentProduct?.TrajDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, TriggerTrackData> p)
                            {
                                cmbMoveTable.Items.Add(p.Value.Name);
                            });
                            break;

                        case MoveMode.插补表:
                            _triggerData.Instance.CurrentProduct?.InterpolationDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, InterPolationCfg> p)
                            {
                                cmbMoveTable.Items.Add(p.Value.Name);
                            });
                            break;

                        case MoveMode.复杂插补:
                            _triggerData.Instance.CurrentProduct?.ComplexInterPolationDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, ComplexInterPolationCfg> p)
                            {
                                cmbMoveTable.Items.Add(p.Value.Name);
                            });
                            break;

                        default:
                            throw new Exception(nameof(MoveMode));
                    }
                }
                else
                {
                    throw new Exception($"{nameof(MoveMode)}{NLocalizer.ConvertAbnormal}");
                }
            }
            catch (Exception ex)
            {
                Notification.ShowWarn($"UpdateTrajTable：{ex.Message}");
            }
        }

        /// <summary>
        /// 获取触发表
        /// </summary>
        private void UpdateTrigTable()
        {
            cmbTrigTable.Items.Clear();
            cmbTrigTable.SelectedIndex = -1;
            if (cmbTrigMode.SelectedItem == null)
            {
                return;
            }

            //队列
            if (cmbTrigMode.SelectedIndex == 4)
            {
                _triggerData.Instance.CurrentProduct?.TableTrigDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, TriggerTableData> p)
                {
                    cmbTrigTable.Items.Add(p.Value.Name);
                });
            }

            //线性
            if (cmbTrigMode.SelectedIndex == 5)
            {
                _triggerData.Instance.CurrentProduct?.LinearTrigDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, LinearTrigData> p)
                {
                    cmbTrigTable.Items.Add(p.Value.Name);
                });
            }
        }

        /// <summary>
        /// 获取多队列触发表
        /// </summary>
        private void UpdateTrigTable2()
        {
            if (cmbTrigMode.SelectedItem != null)
            {
                cmbTrigTable.Items.Clear();
                cmbTrigTable.SelectedIndex = -1;
                _triggerData.Instance.CurrentProduct?.TrigTabMangerDatas.ToList().ForEach(delegate (KeyValuePair<Guid, TrigTabMangerData> p)
                {
                    cmbTrigTable.Items.Add(p.Value.Name);
                });
            }
        }

        /// <summary>
        /// 获取轴组内所有轴名称
        /// </summary>
        private void UpdateAxises()
        {
            if (_ele != null)
            {
                cmbAxisName.SelectedIndex = -1;
                cmbAxisName.Items.Clear();
                var eleCartesian = (IEleCartesian)_ele;
                eleCartesian.Axises.ToList().ForEach(delegate (KeyValuePair<int, IEleAxis> axis)
                {
                    cmbAxisName.Items.Add(axis.Value.Name);
                });
            }
        }
        #endregion
    }

    /// <summary>
    /// 运动模式
    /// </summary>
    public enum MoveMode
    {
        轨迹表,
        插补表,
        复杂插补,
    }
}
