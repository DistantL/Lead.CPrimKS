using System.ComponentModel;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.Register
{
    public partial class SuperPermissions : Form
    {
        public SuperPermissions()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK && txtSecret.Text.Trim() == Properties.Resources.secret)
            {
                RegistrationCode code = new RegistrationCode();
                code.StartPosition = FormStartPosition.CenterScreen;
                code.ShowDialog();
            }
            base.OnClosing(e);
        }
    }
}
