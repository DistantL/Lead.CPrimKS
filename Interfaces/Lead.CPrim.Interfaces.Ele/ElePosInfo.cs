namespace Lead.CPrim.Interfaces
{
    public class ElePosInfo
    {
        public ElePosInfo(int axisNum)
        {
            Index = -1;
            Name = "";
            Description = "";
            Position = new double[axisNum];
            Velocity = new double[axisNum];
            Acceleration = new double[axisNum];
            Deceleration = new double[axisNum];
            MinVelocity = new double[axisNum];
            AccTime = new double[axisNum];
            DecTime = new double[axisNum];
        }

        public double[] Acceleration { set; get; }
        public double[] AccTime { set; get; }
        public double[] Deceleration { set; get; }
        public double[] DecTime { set; get; }
        public string Description { set; get; }
        public int Index { set; get; }
        public double[] MinVelocity { set; get; }
        public string Name { set; get; }
        public double[] Position { set; get; }
        public double[] Velocity { set; get; }
    }
}