using System.ComponentModel;

namespace Lead.CPrim.FaiHelper.ComplexFais
{
	public enum AglType
	{
		[Description("常规算法")]
		None,
		[Description("Max(1:n)-Min(1:n)")]
		Parallelism,
		[Description("2*MAX(ABS(K-ABS(1:n))")]
		Profile,
		[Description("Max(1:n)-Min(1:n)")]
		Flatness,
		[Description("ABS(Fai1-Fai2)")]
		Distance
	}
}
