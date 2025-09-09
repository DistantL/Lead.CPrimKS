using System.Windows.Forms;

namespace Lead.CPrim.StationCommon
{
	/// <summary>更新主界面三个按钮</summary>
	public delegate void Del_UpdateMainBtn();

	/// <summary>主界面三个按钮点击时发生</summary>
	/// <param name="btnText">按钮名称</param>
	public delegate void ButtonPressEventHandle(string btnText);

	/// <summary>更新主界面</summary>
	public delegate void Del_UpdateStationForm();
}
