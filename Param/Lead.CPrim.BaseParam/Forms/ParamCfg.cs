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
	public partial class ParamCfg : UIForm
	{
		/// <summary>Ctor无参</summary>
		public ParamCfg()
		{
			this.InitializeComponent();

			OnLanguageChanged();
			NLocalizer.LanguageChanged += OnLanguageChanged;
		}

		/// <summary>Ctor有1个参数</summary>
		/// <param name="path">目录</param>
		public ParamCfg(string path)
		{
			this.InitializeComponent();
			this.Text = Path.GetFileNameWithoutExtension(path);
			try
			{
				this.xel = XElement.Load(path);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
			this.CurParaPath = path;
			this.UpdateUi();

            OnLanguageChanged();
            NLocalizer.LanguageChanged += OnLanguageChanged;
        }

		/// <summary>Load事件</summary>
		private void ParamCfg_Load(object sender, EventArgs e)
		{
			string curParaPath = this.CurParaPath;
			string dirProductsPath = (curParaPath != null) ? curParaPath.Substring(0, this.CurParaPath.LastIndexOf("\\")) : null;
			string text = (dirProductsPath != null) ? dirProductsPath.Substring(0, dirProductsPath.LastIndexOf("\\")) : null;
			this.UserDefinePath = Path.Combine(dirProductsPath, "UserDefineStruct");
		}

		/// <summary>右键添加属性</summary>
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

		/// <summary>右键删除属性</summary>
		private void 删除属性ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string ValName = this.propertyGrid1.SelectedGridItem.PropertyDescriptor.Name;
			if (ValName == "运行模式") 
			{
                MessageBox.Show("运行模式不可删除");
				return;
            }

			bool flag = ValName != null && MessageBox.Show(
				string.Format(NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_Tip_ConfirmToDeleteProperty", "确认删除[{0}]属性?"),ValName)
				, "Tip", MessageBoxButtons.YesNo) == DialogResult.Yes && this.Pmc_St.Remove(ValName) == 0;
			if (!flag)
			{
                MessageBox.Show(NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_ErrMsg_DeletePropertyFail", "删除属性失败！"));
			}
            this.propertyGrid1.SelectedObject = this.Pmc_St;
        }

        private void 修改属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Property property = null;
            foreach (Property item in Pmc_St)
            {
				if (item.Name == propertyGrid1.SelectedGridItem.PropertyDescriptor.Name) 
				{
					property = item;
                }
                if (!this.Groups.Exists((string x) => x == item.Category))
                {
                    this.Groups.Add(item.Category);
                }
            }
            NewProperty frm = new NewProperty(property)
            {
                UserDefinePath = this.UserDefinePath,
                groups = this.Groups
            };
            frm.ShowDialog();

            bool addPropertApply = frm.AddPropertApply;
            if (addPropertApply)
            {
				if (this.Pmc_St.Updata(property, frm.newProperty) != 0)
				{
                    MessageBox.Show("修改属性失败");
                }

                this.propertyGrid1.SelectedObject = this.Pmc_St;
            }
        }

        /// <summary>保存</summary>
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.UpdateParam();
			this.xel.Save(this.CurParaPath);
		}

		/// <summary>保存下拉框_加载参数</summary>
		private void 加载参数ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog fd = new OpenFileDialog
			{
				InitialDirectory = Path.Combine(this.CurSysDir, "Configs\\ParamData\\ProductCfg"),
				Filter = "(Product Param)|*.para",
				Multiselect = false
			};
			if (fd.ShowDialog() == DialogResult.OK)
			{
				string ParaPath = fd.FileName.Replace(Directory.GetCurrentDirectory(), ".");
				this.xel = XElement.Load(ParaPath);
				this.UpdateUi();
				this.CurParaPath = ParaPath;
			}
		}

		/// <summary>清空</summary>
		private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Pmc_St.Clear();
			this.propertyGrid1.SelectedObject = null;
		}

		/// <summary>保存为UDT</summary>
		private void 保存为UDTToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog
			{
				InitialDirectory = this.UserDefinePath,
				Filter = "(Measure Project)|*.udt|(All Files)|*.*"
			};
			bool flag = sfd.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.UpdateParam();
				this.xel.Save(sfd.FileName);
			}
		}

		/// <summary>刷新属性表显示</summary>
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

		/// <summary>刷新Param数值</summary>
		public void UpdateParam()
		{
			this.xel = new XElement("Para", "");
			foreach (object obj in this.Pmc_St)
			{
				Property p = (Property)obj;
				this.xel.Add(p.PropToXElment());
			}
		}

		/// <summary>XML元素</summary>
		private XElement xel = new XElement("Para", "");

		/// <summary>全局参数全路径</summary>
		public string CurParaPath;

		/// <summary>属性绑定源</summary>
		private PropertyManageCls Pmc_St = new PropertyManageCls();

		/// <summary>自定义类型文件夹地址</summary>
		public string UserDefinePath;

		/// <summary>属性分组</summary>
		private List<string> Groups = new List<string>();

		public string CurSysDir;

		public void OnLanguageChanged()
		{
			this.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_Title", "参数配置");
			文件ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_Save", "保存");
			加载参数ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_LoadParam", "加载参数");
			清空ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_Clear", "清空");
			保存为UDTToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_SaveToUDT", "保存为UDT");
			导出ToolStripMenuItem.Text = NLocalizer.GetString("Lead_CPrim_CommonParam_ParamCfg_Export", "导出");
		}

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var saveDir = new FolderBrowserDialog();
			if (saveDir.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			if (!Directory.Exists(saveDir.SelectedPath))
			{
				Directory.CreateDirectory(saveDir.SelectedPath);
			}

			using (StreamWriter sw = new StreamWriter(saveDir.SelectedPath + "\\CommonParam_DisplayName.txt"))
            {
				foreach (Property item in Pmc_St)
				{
					sw.WriteLine(item.DisplayName);
				}
			}

			List<string> list = new List<string>();
			using (StreamWriter sw = new StreamWriter(saveDir.SelectedPath + "\\CommonParam_Category.txt"))
			{
				foreach (Property item in Pmc_St)
				{
					if(!list.Contains(item.Category))
                    {
						list.Add(item.Category);
						sw.WriteLine(item.Category);
					}
				}
			}
		}
    }
}
