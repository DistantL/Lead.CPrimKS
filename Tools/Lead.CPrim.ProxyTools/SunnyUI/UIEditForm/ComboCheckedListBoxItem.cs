using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.ProxyTools
{
    public class ComboCheckedListBoxItem
    {
        public bool Checked;
        public string Text;



        public ComboCheckedListBoxItem()
        {

        }
        public ComboCheckedListBoxItem(string text, bool isChecked)
        {
            Checked = isChecked;
            Text = text;
        }
    }
}
