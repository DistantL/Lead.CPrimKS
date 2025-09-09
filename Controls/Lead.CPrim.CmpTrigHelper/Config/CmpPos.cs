using Lead.CPrim.Interfaces.Ele;

namespace Lead.CPrim.Global
{
    public class CmpPos
    {
        #region Prop

        public Pos Pos { get; set; }

        public Vel Vel { get; set; }
        #endregion



        #region Ctor
        public CmpPos()
        {
            Pos = new Pos();
            Vel = new Vel();
        }

        public CmpPos(string posName)
        {
            Pos = new Pos(posName);
            Vel = new Vel();
        }
        #endregion
    }
}
