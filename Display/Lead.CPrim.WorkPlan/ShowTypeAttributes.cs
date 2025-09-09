using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;
using Lead.CPrim.WorkPlan.Properties;

namespace Lead.CPrim.WorkPlan
{
    public class ShowTypeAttributes : IShowTypeAttributes
    {
        public string Name => "WorkPlan";
        public string DisplayName => "WorkPlan";
        public string Description => "Show for WorkPlan";
        public Image Icon
        {
            get
            {
                return Resources.Default;
            }
        }
        public string DisplayGroup => "PAX";
        public string Group => "PAX";
        public byte MajorVersion => 1;
        public byte MinorVersion => 0;
    }
}
