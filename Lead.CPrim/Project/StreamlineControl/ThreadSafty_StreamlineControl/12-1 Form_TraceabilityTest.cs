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
    public partial class Form_TraceabilityTest : Form
    {
        private Traceability _traceability;
        private TraceabilityConfig _config;
        private BindingList<FaiItem> fais;
        public ProductionInfo productionInfo { get; set; }
        public Form_TraceabilityTest(TraceabilityConfig config)
        {
            _config = config;
            InitializeComponent();

            fais = new BindingList<FaiItem>();
            productionInfo = new ProductionInfo();

            pg_config.SelectedObject = config;
            cb_cmd.Items.Add("用ucSN获取绑定的sn");
            cb_cmd.Items.Add("检测sn是否可以过站");
            cb_cmd.Items.Add("上传数据");
            cb_cmd.Items.Add("本站Pass");
            cb_cmd.Items.Add("通过LotNO获取LotNO计数");
            cb_cmd.SelectedIndex = 0;

            pg_SendObj.SelectedObject = productionInfo;
            dgv_fai.DataSource = fais;
        }


        private void bt_UpData_Click(object sender, EventArgs e)
        {
            switch (cb_cmd.Text)
            {
                case "用ucSN获取绑定的sn":
                    _traceability = new Traceability(_config);
                    _traceability.log -= _traceability_log;
                    _traceability.log += _traceability_log;
                    string data = _traceability.GetSN_withUCSN(productionInfo.Sn);
                    if (!string.IsNullOrEmpty(data))
                    {
                        MessageBox.Show("获取sn成功:" + data);
                    }
                    else
                    {
                        MessageBox.Show("获取sn失败");
                    }
                    break;
                case "检测sn是否可以过站":
                    _traceability = new Traceability(_config);
                    _traceability.log -= _traceability_log;
                    _traceability.log += _traceability_log;
                    if (_traceability.CheckSN_withSN(productionInfo.Sn))
                    {
                        MessageBox.Show("检测sn[" + productionInfo.Sn + "]可以在本站加工");
                    }
                    else
                    {
                        MessageBox.Show("检测sn[" + productionInfo.Sn + "]不能在本站加工");
                    }
                    break;
                case "上传数据":
                    _traceability = new Traceability(_config);
                    _traceability.log -= _traceability_log;
                    _traceability.log += _traceability_log;
                    if (_traceability.UpData(productionInfo, fais.ToList()))
                    {
                        MessageBox.Show("上传数据成功");
                    }
                    else
                    {
                        MessageBox.Show("上传数据失败");
                    }
                    break;
                case "本站Pass":
                    _traceability = new Traceability(_config);
                    _traceability.log -= _traceability_log;
                    _traceability.log += _traceability_log;
                    if (_traceability.GoPass(productionInfo.FixtureID, productionInfo.Sn))
                    {
                        MessageBox.Show("sn[" + productionInfo.Sn + "]Pass成功");
                    }
                    else
                    {
                        MessageBox.Show("sn[" + productionInfo.Sn + "]Pass失败");
                    }
                    break;
                case "通过LotNO获取LotNO计数":
                    _traceability = new Traceability(_config);
                    _traceability.log -= _traceability_log;
                    _traceability.log += _traceability_log;
                    data = _traceability.GetLotNoCount_withLotNOSN(productionInfo.LotNoSN);
                    if (!string.IsNullOrEmpty(data))
                    {
                        MessageBox.Show("获取sn成功:" + data);
                    }
                    else
                    {
                        MessageBox.Show("获取sn失败");
                    }
                    break;
                default:
                    break;
            }
        }

        private void _traceability_log(string obj)
        {
            rtb_log.Text += obj + Environment.NewLine;
            if (rtb_log.Text.Length > 500000)
            {
                rtb_log.Text = "";
            }
        }
    }
}
