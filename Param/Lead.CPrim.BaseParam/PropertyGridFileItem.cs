using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Lead.CPrim.BaseParam
{
	public class PropertyGridFileItem : UITypeEditor
	{
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (edSvc != null)
			{
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.AddExtension = false;
				if (value != null && Directory.Exists(Path.GetDirectoryName(value.ToString())))
				{
					dialog.InitialDirectory = Path.GetDirectoryName(value.ToString());
				}
				if (dialog.ShowDialog().Equals(DialogResult.OK))
				{
					return dialog.FileName;
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
