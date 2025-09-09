using Lead.CPrim.Interfaces;

namespace Lead.CPrim.StationCommon
{
	public delegate void Del_ChangeEleItemType(IEle ele, EleMemberType oldType = EleMemberType.Other, EleMemberType newType = EleMemberType.Other);
}
