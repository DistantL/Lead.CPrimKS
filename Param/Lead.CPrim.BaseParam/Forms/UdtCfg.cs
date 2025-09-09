using Lead.CPrim.BaseParam;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lead.CPrim.BaseParam
{
	public partial class UdtCfg : UIForm
	{
		public sealed override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		public UdtCfg()
		{
			this.InitializeComponent();
		}

		public UdtCfg(string udtPath)
		{
			this.InitializeComponent();
			this.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_UserDefinedDataType", "自定义类型") +"-" + Path.GetFileNameWithoutExtension(udtPath);
			try
			{
				this.xel = XElement.Load(udtPath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			this.CurParaPath = udtPath;
			this.UpdateUi();

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		private void ParamCfg_Load(object sender, EventArgs e)
		{
			string curParaPath = this.CurParaPath;
			string dirProductsPath = (curParaPath != null) ? curParaPath.Substring(0, this.CurParaPath.LastIndexOf("\\")) : null;
			string dynamicParamPath = (dirProductsPath != null) ? dirProductsPath.Substring(0, dirProductsPath.LastIndexOf("\\")) : null;
			this.UserDefinePath = Path.Combine(dynamicParamPath, "\\UserDefineStruct");
		}

		private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UpdateParam();
			this.xel.Save(this.CurParaPath);
		}

		private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Pmc_St.Clear();
			this.propertyGrid1.SelectedObject = null;
		}

		private void 删除属性ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(propertyGrid1.SelectedGridItem.PropertyDescriptor != null)
            {
				string ValName = this.propertyGrid1.SelectedGridItem.PropertyDescriptor.Name;
				bool flag = ValName != null 
					&& MessageBox.Show(				
					string.Format(NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_Tip_ConfirmToDeleteProperty", "确认删除[{0}]属性?"), ValName)
					, "", MessageBoxButtons.YesNo) == DialogResult.Yes && this.Pmc_St.Remove(ValName) != 0;
				if (flag)
				{
					MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_ErrMsg_DeletePropertyFail", "删除属性失败！"));
				}
				this.propertyGrid1.SelectedObject = this.Pmc_St;
			}
		}

		private void 添加属性ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewProperty frm = new NewProperty();
			frm.UserDefinePath = this.UserDefinePath;
			foreach (Property item in Pmc_St)
			{
				if (!this.Groups.Exists((string x) => x == item.Category))
				{
					this.Groups.Add(item.Category);
				}
			}
			frm.groups = this.Groups;
			frm.ShowDialog();
			bool addPropertApply = frm.AddPropertApply;
			if (addPropertApply)
			{
				this.Pmc_St.Add(frm.newProperty);
				this.propertyGrid1.SelectedObject = this.Pmc_St;
			}
		}

		/// <summary>
		/// 刷新Param数值
		/// </summary>
		public void UpdateParam()
		{
			this.xel = new XElement("Para", "");
			foreach (object obj in this.Pmc_St)
			{
				Property p = (Property)obj;
				this.xel.Add(p.PropToXElment());
			}
		}

		/// <summary>
		/// 刷新属性表显示
		/// </summary>
		public void UpdateUi()
		{
			if (!(xel == null))
			{
				List<XElement> xmlist = this.xel.Elements().ToList<XElement>();
				this.Pmc_St.Clear();
				foreach (XElement a in xmlist)
				{
					this.Pmc_St.Add((Property)a);
				}
				this.propertyGrid1.SelectedObject = this.Pmc_St;
			}
		}

		private List<string> Groups = new List<string>();

		private PropertyManageCls Pmc_St = new PropertyManageCls();

		private XElement xel = new XElement("Para", "");

		public string CurParaPath;

		public string UserDefinePath;

		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_Title", "参数配置");
			文件ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_Save", "保存");
			清空ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_UdtCfg_Clear", "清空");
		}
	}
}
