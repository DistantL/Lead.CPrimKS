using System.Drawing;
using System.Resources;
using Lead.CPrim.Interfaces;
using Lead.CPrim.ShowErrorCode.Properties;

namespace Lead.CPrim.ShowErrorCode
{
    /// <summary>AQCIœ‘ æ Ù–‘</summary>
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "ErrorCode";
        public string DisplayName => "ErrorCode";
        public string Description => "Show for ErrorCode";
        public Image Icon
        {
            get
            {
                var manager = new ResourceManager(typeof(Resources));
                return (Image)manager.GetObject("errorCode1");
            }
        }
        public string DisplayGroup => "PAX";
        public string Group => "PAX";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}