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

namespace Lead.CPrim.CmpTrigHelper.CmpTrigUIs
{
    public partial class TriggerConfigControl : UserControl
    {
        #region Field
        private IEleAxis _axis;

        /// <summary>
        /// 轴组元件
        /// </summary>
        private IEle _ele;

        private IPrim _prim;

        private TriggerData _triggerData;
        #endregion



        #region Ctor

        public TriggerConfigControl()
        {
            InitializeComponent();
        }

        public TriggerConfigControl(TriggerData triggerData) : this()
        {
            _triggerData = triggerData;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
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
        #endregion



        #region Event_Button
        /// <summary>
        /// 关联元件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbElement_Click(object sender, EventArgs e)
        {
            UpdateEles();
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
            ICmpTrig val = (ICmpTrig)_prim;
            if (val != null)
            {
                val.SetManualTrig(cmbTrigChannel.SelectedIndex, int.Parse(tbPulseWidth.Text) * 1000);
            }
        }

        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            _triggerData.Name = tbTrigName.Text;
            _triggerData.Enable = chkEnable.Checked;
            _triggerData.PrimType = cmbPrimType.SelectedIndex;
            _triggerData.PrimName = cmbPrimName.SelectedItem?.ToString();
            _triggerData.EleName = cmbElementName.SelectedItem?.ToString();
            _triggerData.AxisName = cmbAxisName.SelectedItem?.ToString();
            _triggerData.CmpSource = cmbPosSource.SelectedIndex;
            _triggerData.TrigChannel = cmbTrigChannel.SelectedIndex;
            _triggerData.TrigMode = cmbTrigMode.SelectedIndex;
            _triggerData.LogicDir = cmbLogicDir.SelectedIndex;
            _triggerData.TrigPulse = Convert.ToDouble(tbTrigPulse.Text);
            _triggerData.TrajName = cmbTrajTable.SelectedItem?.ToString();
            _triggerData.TrigTableName = cmbTrigTable.SelectedItem?.ToString();
            _triggerData.PulseWidth = Convert.ToDouble(tbPulseWidth.Text);
            _triggerData.MoveMode = cmbMoveMode.SelectedIndex;
            _triggerData.MoveDir = ((cmbMoveDir.SelectedIndex == -1) ? 2 : cmbMoveDir.SelectedIndex);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show((_triggerData.Set(null) == 0)
                ? NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigSettingPass", "触发通道设置成功")
                : NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigSettingFail", "触发通道设置失败"));
        }

        private void btnTestTrig_Click(object sender, EventArgs e)
        {
            MessageBox.Show((_triggerData.Instance.CmpTrigRun(_triggerData.Name, out var cmpCount, _triggerData.Instance.CurrentProductName) == 0)
                ? string.Format(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TriggerPass", "触发动作测试完成，触发个数：{0}"), cmpCount)
                : string.Format(NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TriggerFail", "触发动作测试失败，触发个数：{0}"), cmpCount));
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            _triggerData.Enable = chkEnable.Checked;
        }

        private void FindPrimAndEle(TriggerData triggerData)
        {
            //IL_0185: Unknown result type (might be due to invalid IL or missing references)
            if (triggerData.PrimType == 0)
            {
                cmbPrimType.SelectedIndex = 0;
                if (!string.IsNullOrEmpty(triggerData.PrimName))
                {
                    if (!cmbPrimName.Items.Contains(triggerData.PrimName))
                    {
                        cmbPrimName.Items.Add(triggerData.PrimName);
                    }
                    cmbPrimName.SelectedItem = triggerData.PrimName;
                    _prim = PrimsManagerTransfer.GetPrimByName(triggerData.PrimName);
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

        private void FindTables(TriggerData triggerData)
        {
            if (!string.IsNullOrEmpty(triggerData.TrajName))
            {
                if (!cmbTrajTable.Items.Contains(triggerData.TrajName))
                {
                    cmbTrajTable.Items.Add(triggerData.TrajName);
                }
                cmbTrajTable.SelectedItem = triggerData.TrajName;
            }
            if (!string.IsNullOrEmpty(triggerData.TrigTableName))
            {
                if (!cmbTrigTable.Items.Contains(triggerData.TrigTableName))
                {
                    cmbTrigTable.Items.Add(triggerData.TrigTableName);
                }
                cmbTrigTable.SelectedItem = triggerData.TrigTableName;
            }
        }

        private void lbDevicePrim_Click(object sender, EventArgs e)
        {
            UpdatePrims();
        }

        private void lbLogic_Click(object sender, EventArgs e)
        {
            ICmpTrig val = (ICmpTrig)_prim;
            if (val != null)
            {
                val.SetTrigOutputLogic(cmbTrigChannel.SelectedIndex, cmbLogicDir.SelectedIndex);
            }
        }

        private void lbPulseWidth_Click(object sender, EventArgs e)
        {
            if (double.TryParse(tbPulseWidth.Text, out var result))
            {
                ICmpTrig val = (ICmpTrig)_prim;
                if (val != null)
                {
                    val.SetTrigOutputPulseWidth(cmbTrigChannel.SelectedIndex, result);
                }
            }
        }

        private void lbTrajTable_Click(object sender, EventArgs e)
        {
            UpdateTrajTable();
        }

        private void lbTrigMode_Click(object sender, EventArgs e)
        {
            ICmpTrig val = (ICmpTrig)_prim;
            if (val != null)
            {
                val.SetTriggerChannelMode(cmbTrigChannel.SelectedIndex, cmbTrigMode.SelectedIndex);
            }
        }

        private void lbTrigMode_DoubleClick(object sender, EventArgs e)
        {
            ICmpTrig val = (ICmpTrig)_prim;
            if (val != null)
            {
                val.SetTriggerChannelMode(cmbTrigChannel.SelectedIndex, 0);
            }
        }

        private void lbTrigTable_Click(object sender, EventArgs e)
        {
            if (cmbTrigMode.SelectedIndex == 4 || cmbTrigMode.SelectedIndex == 5)
            {
                UpdateTrigTable();
            }
            else if (cmbTrigMode.SelectedIndex == 6)
            {
                UpdateTrigTable2();
            }
        }

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

        public void OnLanguageChanged()
        {
            lbTrigName.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigName", "触发名称:");
            lbElement.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Element", "元件关联:");
            lbTrigChannel.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigChannel", "触发通道:");
            lbTrigPulse.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigPulse", "触发脉冲:");
            chkEnable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Enable", "使能");
            lbDeviceType.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_DeviceType", "设备类型:");
            lbAxisIndex.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_AxisIndex", "轴名称:");
            lbTrigMode.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigMode", "触发模式:");
            lbTrigTable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrigTable", "触发表:");
            lbPulseDir.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_PulseDir", "运动模式:");
            btnSet.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Setting", "设置");
            lbDevicePrim.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_DevicePrim", "基元关联:");
            lbPosSource.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_PosSource", "位置源:");
            lbLogic.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Logic", "电平方向:");
            lbTrajTable.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TrajTable", "轨迹表:");
            lb_Direction.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Direction", "行进方向:");
            btnApply.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_Apply", "应用");
            btnTestTrig.Text = NLocalizer.GetString("Lead_CPrim_CmpTrigHelper_CmpTrigUIs_TriggerConfigControl_TestTrig", "测试");
        }



        #region Method_InternalUsing
        /// <summary>
        /// Load_1<br/>
        /// 界面初始化
        /// </summary>
        /// <param name="triggerData"></param>
        private void TbCmbInit(TriggerData triggerData)
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

            tbTrigName.Text = triggerData.Name;
            cmbPrimType.SelectedIndex = triggerData.PrimType;
            cmbPosSource.SelectedIndex = triggerData.CmpSource;
            cmbTrigChannel.SelectedIndex = triggerData.TrigChannel;
            cmbTrigMode.SelectedIndex = triggerData.TrigMode;
            cmbLogicDir.SelectedIndex = triggerData.LogicDir;
            tbTrigPulse.Text = triggerData.TrigPulse.ToString();
            tbPulseWidth.Text = triggerData.PulseWidth.ToString();
            cmbMoveMode.SelectedIndex = triggerData.MoveMode;
            chkEnable.Checked = triggerData.Enable;
            cmbMoveDir.SelectedIndex = triggerData.MoveDir;
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

            cmbPrimName.SelectedIndex = -1;
            cmbPrimName.Items.Clear();
            prims.ForEach(delegate (IPrim prim)
            {
                if (prim is IMotionCard || prim is ICmpTrig)
                {
                    cmbPrimName.Items.Add(prim.Name);
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
                cmbTrajTable.Items.Clear();
                cmbTrajTable.SelectedIndex = -1;
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
                            _triggerData.Instance.CurrentProduct?.TrajDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, TrajData> p)
                            {
                                cmbTrajTable.Items.Add(p.Value.Name);
                            });
                            break;

                        case MoveMode.插补表:
                            _triggerData.Instance.CurrentProduct?.InterpolationDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, InterPolationCfg> p)
                            {
                                cmbTrajTable.Items.Add(p.Value.Name);
                            });
                            break;

                        case MoveMode.复杂插补:
                            _triggerData.Instance.CurrentProduct?.ComplexInterPolationDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, ComplexInterPolationCfg> p)
                            {
                                cmbTrajTable.Items.Add(p.Value.Name);
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
                _triggerData.Instance.CurrentProduct?.TableTrigDatas?.ToList().ForEach(delegate (KeyValuePair<Guid, TableTrigData> p)
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
