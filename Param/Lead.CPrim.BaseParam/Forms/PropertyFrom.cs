using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lead.CPrim.BaseParam
{
	public partial class PropertyFrom : UIForm
	{
        #region Field

        public object obj;

        #endregion



        #region Ctor
        public PropertyFrom()
		{
			InitializeComponent();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}
        #endregion



        #region Event_System

        private void PropertyFrom_Load(object sender, EventArgs e)
        {
            PropertyManageCls Pmc_St = new PropertyManageCls();
            List<Property> Propertys = (List<Property>)obj;
            foreach (Property p in Propertys)
            {
                p.ReadOnly = false;
                Pmc_St.Add(p);
            }
            propertyGrid1.SelectedObject = Pmc_St;
            OnLanguageChanged();
        }

        public void OnLanguageChanged()
        {
            Text = NLocalizer.Property;
        }
        #endregion
    }
}
