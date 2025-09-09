using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lead.CPrim.BaseParam
{
	public class PropertyGridDirItem : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc != null)
			{
				FolderBrowserDialog dialog = new FolderBrowserDialog();
				dialog.ShowNewFolderButton = true;
				if (value != null && Directory.Exists(Path.GetDirectoryName(value.ToString())))
				{
					dialog.SelectedPath = Path.GetDirectoryName(value.ToString());
				}
				if (dialog.ShowDialog().Equals(DialogResult.OK))
				{
					return dialog.SelectedPath;
				}
			}
			return value;
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
