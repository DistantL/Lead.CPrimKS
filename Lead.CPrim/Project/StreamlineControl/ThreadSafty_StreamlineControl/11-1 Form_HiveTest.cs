using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafty_StreamlineControl
{
    public partial class Form_HiveTest : Form
    { 
        private Hive _hive;
        private HiveConfig _config;
        private BindingList<FaiItem> fais;
        private ProductionInfo productionInfo;
        public short LastHiveState = 1;
        public Hive.ErrorData errorData { get; set; } = new Hive.ErrorData();
        public Hive.Data_Running data_Running { get; set; } = new Hive.Data_Running();
        public Hive.Data_Idle data_Idle { get; set; } = new Hive.Data_Idle();
        public Hive.Data_Engineering data_Engineering { get; set; } = new Hive.Data_Engineering();
        public Hive.Data_PlanedDowntime data_PlanedDowntime { get; set; } = new Hive.Data_PlanedDowntime();
        public Hive.Data_Downtime data_Downtime { get; set; } = new Hive.Data_Downtime();
        public Form_HiveTest(HiveConfig config)
        {
            _config = config;
            InitializeComponent();

            fais = new BindingList<FaiItem>();
            productionInfo = new ProductionInfo();

            pg_config.SelectedObject = config;
            cb_cmd.Items.Add("设置Running状态");
            cb_cmd.Items.Add("设置Idle状态");
            cb_cmd.Items.Add("设置Engineering状态");
            cb_cmd.Items.Add("设置PlanedDowntime状态");
            cb_cmd.Items.Add("设置Downtime状态");
            cb_cmd.Items.Add("上传报警信息");
            cb_cmd.Items.Add("上传带图片的数据");
            cb_cmd.SelectedIndex = 0;

            cb_HiveState.SelectedIndex = 0;
            pg_SendObj.SelectedObject = productionInfo;
            dgv_fai.DataSource = fais;
        }

        private void bt_UpData_Click(object sender, EventArgs e)
        {
            LastHiveState = (short)(cb_HiveState.SelectedIndex + 1);

            switch (cb_cmd.Text)
            {
                case "设置Running状态":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataMachineState_Running(data_Running,DateTime.Now, string.Empty))
                    {
                        MessageBox.Show("设置Running状态成功");
                    }
                    else
                    {
                        MessageBox.Show("设置Running状态失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "设置Idle状态":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataMachineState_Idle(data_Idle, DateTime.Now, string.Empty))
                    {
                        MessageBox.Show("设置Idle状态成功");
                    }
                    else
                    {
                        MessageBox.Show("设置Idle状态失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "设置Engineering状态":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataMachineState_Engineering(data_Engineering, DateTime.Now, string.Empty))
                    {
                        MessageBox.Show("设置Engineering状态成功");
                    }
                    else
                    {
                        MessageBox.Show("设置Engineering状态失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "设置PlanedDowntime状态":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataMachineState_PlanedDowntime(data_PlanedDowntime, DateTime.Now, string.Empty))
                    {
                        MessageBox.Show("设置Engineering状态成功");
                    }
                    else
                    {
                        MessageBox.Show("设置Engineering状态失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "设置Downtime状态":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataMachineState_Downtime(data_Downtime, DateTime.Now, string.Empty))
                    {
                        MessageBox.Show("设置Downtime状态成功");
                    }
                    else
                    {
                        MessageBox.Show("设置Downtime状态失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "上传报警信息":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;
                    if (_hive.UpDataErrorData(errorData))
                    {
                        MessageBox.Show("上传报警信息成功");
                    }
                    else
                    {
                        MessageBox.Show("上传报警信息失败");
                    }
                    _hive.log -= _hive_log;

                    break;
                case "上传带图片的数据":
                    _hive = new Hive(_config);
                    _hive.log -= _hive_log;
                    _hive.log += _hive_log;

                    if (_hive.UpDataMachineDataWithImage(productionInfo,null,null,fais.ToList(),null))
                    {
                        MessageBox.Show("上传带图片的数据成功");
                    }
                    else
                    {
                        MessageBox.Show("上传带图片的数据失败");
                    }

                    break;
                default:
                    break;
            }
        }

        private void _hive_log(string obj)
        {
            rtb_log.Text += obj + Environment.NewLine;
            if (rtb_log.Text.Length > 500000)
            {
                rtb_log.Text = "";
            }
        }

        private void cb_cmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                switch (cb_cmd.Text)
                {
                    case "设置Running状态":
                        pg_data.SelectedObject = data_Running;
                        break;
                    case "设置Idle状态":
                        pg_data.SelectedObject = data_Idle;
                        break;
                    case "设置Engineering状态":
                        pg_data.SelectedObject = data_Engineering;
                        break;
                    case "设置PlanedDowntime状态":
                        pg_data.SelectedObject = data_PlanedDowntime;
                        break;
                    case "设置Downtime状态":
                        pg_data.SelectedObject = data_Downtime;
                        break;
                    case "上传报警信息":
                        pg_data.SelectedObject = errorData;
                        break;
                    case "上传带图片的数据":
                        pg_data.SelectedObject = new  {   };
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
