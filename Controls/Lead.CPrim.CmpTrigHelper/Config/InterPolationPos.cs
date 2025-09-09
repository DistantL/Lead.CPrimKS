using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.CmpTrigHelper.ConfigClass
{
	public class InterPolationPos
	{
		public int Id { get; set; }

		public int offsetType { get; set; } = -1;


		public Pos Pos { get; set; }

		public double Vm { get; set; }

		public InterPolationPos()
		{
		}

		public InterPolationPos(Pos pos, double vm, int id, int type = -1)
		{
			Pos = pos;
			Vm = vm;
			Id = id;
			offsetType = type;
		}
	}
}
