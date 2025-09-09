using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.ProxyTools.SunnyUI.Style;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>
    /// 关于
    /// </summary>
    public partial class VersionForm : UIForm
    {
        #region Field
        private static VersionForm _instance = new VersionForm();
        #endregion



        #region Prop
        public static VersionForm Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        private VersionForm()
        {
            InitializeComponent();
            Style = UIStyle.Gray;
            BackColor = Color.FromArgb(236, 236, 236);
            txtInfo.SetStyle();
            txtInfo.RectColor = Color.Transparent;
            txtInfo.WordWarp = true;
            txtInfo.ShowScrollBar = true;
        }
        #endregion



        #region System_Event
        private void VersionForm_Load(object sender, System.EventArgs e)
        {
            
        }

        private void VersionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        #endregion



        #region Method_ExternalUsing
        /// <summary>
        /// 设置消息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="primType"></param>
        /// <param name="primManufacture"></param>
        /// <param name="info"></param>
        public void SetInfo(string name, string primType, string primManufacture, string info)
        {
            Text = name;
            lblPrimType.Text = primType;
            lblPrimManufacture.Text = primManufacture;
            txtInfo.Text = info;
            txtInfo.ReadOnly = true;
        }
        #endregion
    }
}
