using Lead.CPrim.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSafty_StreamlineControl
{
    public partial class Form_PdcaTest : Form
    {
        private PDCA _pdca;
        private PDCAconfig _config;
        private BindingList<FaiItem> fais;
        public ProductionInfo productionInfo { get; set; }
        private ISktClient _client;

        public Form_PdcaTest(ISktClient client, PDCAconfig config)
        {
            _client = client;
            _config = config;
            InitializeComponent();

            fais = new BindingList<FaiItem>();
            productionInfo = new ProductionInfo();

            pg_config.SelectedObject = config;
            cb_cmd.Items.Add("上传数据");
            cb_cmd.SelectedIndex = 0;

            pg_SendObj.SelectedObject = productionInfo;
            dgv_fai.DataSource = fais;
        }


        private void bt_UpData_Click(object sender, EventArgs e)
        {
            switch (cb_cmd.Text)
            {
                case "上传数据":
                    _pdca = new PDCA(_client, _config);
                    _pdca.log -= _pdca_log;
                    _pdca.log += _pdca_log;
                    if (_pdca.UpData(productionInfo,fais.ToList(), productionInfo.LogFilePath, new CancellationTokenSource().Token))
                    {
                        MessageBox.Show("PDCA上传数据成功:");
                    }
                    else
                    {
                        MessageBox.Show("PDCA上传数据失败");
                    }
                    break;
                default:
                    break;
            }

        }

        private void _pdca_log(string obj)
        {
            rtb_log.Text += obj + Environment.NewLine;
            if (rtb_log.Text.Length > 500000)
            {
                rtb_log.Text = "";
            }
        }
    }
}

