using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.Authority;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>软件信息</summary>
    public partial class SoftWareInfo : UIPage
    {
        #region Field
        /// <summary>软件信息对象</summary>
        private static SoftWareInfo _instance = new SoftWareInfo();
        #endregion



        #region Prop
        /// <summary>软件信息对象</summary>
        public static SoftWareInfo Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        private SoftWareInfo()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(211, 211, 211);
            pnlMain.SetStyle(Color.FromArgb(211, 211, 211), Color.FromArgb(92, 92, 92));
            pnlSite.SetStyle();
            pnlVendor.SetStyle();
            pnlSWVersion.SetStyle();
            pnlMainSW.SetStyle();
            pnlHash.SetStyle();
            btnMachineLog.SetStyle(Colors.PrimaryBackColor128);
            btnHiveLog.SetStyle(Colors.PrimaryBackColor128);
            tlpInfoAll.SetDoubleBuffered();
            tlpInfoUp.SetDoubleBuffered();
            lblMainSWPathValue.Text = Application.ExecutablePath;
            lblSWVersionValue.Text = UIGlobal.Version; //SwManager.Instance.SwName
            lblHashValue.Text = SwManager.Instance.SoftWareHashCode;
            InstanceRemoteQualificationEnable(SwManager.Instance.RemoteQualificationEnable);

            SwManager.Instance.OnChangeRemoteQualificationEnable += InstanceRemoteQualificationEnable;
            SwManager.Instance.OnChangeRemoteQualificationEnable += AuthorityManager.Instance.ChangeRemoteQualificationEnable;
            SwManager.Instance.OnChangeHashCode += InstanceChangeHashCode;

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }
        #endregion


        private void lblMainSWPathValue_Click(object sender, EventArgs e)
        {
            string openFolderPath = Application.StartupPath;
            if (!Directory.Exists(openFolderPath))
            {
                Directory.CreateDirectory(openFolderPath);
            }
            System.Diagnostics.Process.Start("explorer.exe", openFolderPath);
        }

        private void btnMachineLog_Click(object sender, EventArgs e)
        {
            string openFolderPath = @"D:\CPrimlog\Machine Log\";
            if (!Directory.Exists(openFolderPath))
            {
                Directory.CreateDirectory(openFolderPath);
            }
            System.Diagnostics.Process.Start("explorer.exe", openFolderPath);
        }

        private void btnHiveLog_Click(object sender, EventArgs e)
        {
            string openFolderPath = @"D:\CPrimlog\HIVE Log\";
            if (!Directory.Exists(openFolderPath))
            {
                Directory.CreateDirectory(openFolderPath);
            }
            System.Diagnostics.Process.Start("explorer.exe", openFolderPath);
        }

        #region Method_Instance
        /// <summary>响应更新Hash码</summary>
        /// <param name="name"></param>
        private void InstanceRemoteQualificationEnable(bool enable)
        {
            tlpInfoAll.BackColor = enable ? Color.FromArgb(255, 143, 0) : Color.LightGray;
            pnlMain.FillColor = enable ? Color.FromArgb(255, 143, 0) : Color.LightGray;
        }

        /// <summary>响应更新Hash码</summary>
        /// <param name="name"></param>
        private void InstanceChangeHashCode(string name)
        {
            lblHashValue.Text = name;
        }
        #endregion

        #region Method_ExternalUsing
        /// <summary>Station设置</summary>
        /// <param name="name"></param>
        public void SetStation(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetStation), new object[1] { name });
                return;
            }
            lblStation.Text = name;
        }

        /// <summary>Site设置</summary>
        public void SetSite(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetSite), new object[1] { name });
                return;
            }
            lblSiteValue.Text = name;
        }

        /// <summary>Hash设置</summary>
        /// <param name="name"></param>
        public void SetHash(string name)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetHash), new object[1] { name });
                return;
            }
            lblHash.Text = name;
        }

        /// <summary>
        /// 设置Hive状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        public void SetHive(bool state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetHive), new object[1] { state });
                return;
            }
            else
            {
                lblHiveState.TagString = state ? "HIVE_CONNECTED" : "HIVE_DISCONNECT";
                lblHiveState.Text = lblHiveState.TagString == "HIVE_CONNECTED"
                                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_HIVE_CONNECTED", "HIVE 连接")
                                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_HIVE_DISCONNECT", "HIVE 断开");
                lblHiveState.ForeColor = state ? Color.FromArgb(0, 249, 0) : Color.FromArgb(236, 93, 87);
            }
        }

        /// <summary>
        /// 设置Mes状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        public void SetMes(bool state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetMes), new object[1] { state });
                return;
            }
            else
            {
                lblMesState.TagString = state ? "MES_CONNECTED" : "MES_DISCONNECT";
                lblMesState.Text = lblMesState.TagString == "MES_CONNECTED"
                                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MES_CONNECTED", "MES 连接")
                                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MES_DISCONNECT", "MES 断开");
                lblMesState.ForeColor = state ? Color.FromArgb(0, 249, 0) : Color.FromArgb(236, 93, 87);
            }
        }

        /// <summary>
        /// 设置PDCA状态（true：连接成功；false：连接失败；）
        /// </summary>
        /// <param name="state"></param>
        public void SetPDCA(bool state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<bool>(SetPDCA), new object[1] { state });
                return;
            }
            else
            {
                lblPDCAState.TagString = state ? "PDCA_CONNECTED" : "PDCA_DISCONNECT";
                lblPDCAState.Text = lblPDCAState.TagString == "PDCA_CONNECTED"
                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_PDCA_CONNECTED", "PDCA 连接")
                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_PDCA_DISCONNECT", "PDCA 断开");
                lblPDCAState.ForeColor = state ? Color.FromArgb(0, 249, 0) : Color.FromArgb(236, 93, 87);
            }
        }
        #endregion

        public void OnLanguageChanged()
        {
            lblSite.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_Site", "工厂:");
            lblVendor.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_Vendor", "供应商:");
            lblSWVersion.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_SWVersion", "软件版本:");
            lblMainSWPath.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MainSWPath", "软件路径:");
            lblHash.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_Hash", "软件Hash:");
            if (!string.IsNullOrWhiteSpace(lblHiveState.TagString))
            {
                lblHiveState.Text = lblHiveState.TagString == "HIVE_CONNECTED"
                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_HIVE_CONNECTED", "HIVE 连接")
                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_HIVE_DISCONNECT", "HIVE 断开");
            }
            if (!string.IsNullOrWhiteSpace(lblMesState.TagString))
            {
                lblMesState.Text = lblMesState.TagString == "MES_CONNECTED"
                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MES_CONNECTED", "MES 连接")
                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MES_DISCONNECT", "MES 断开");
            }
            if (!string.IsNullOrWhiteSpace(lblPDCAState.TagString))
            {
                lblPDCAState.Text = lblPDCAState.TagString == "PDCA_CONNECTED"
                    ? NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_PDCA_CONNECTED", "PDCA 连接")
                    : NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_PDCA_DISCONNECT", "PDCA 断开");
            }
            btnMachineLog.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_MachineLog", "设备日志");
            btnHiveLog.Text = NLocalizer.GetString("Lead_CPrim_Controls_SoftWareInfo_HiveLog", "HIVE日志");
        }
    }
}
