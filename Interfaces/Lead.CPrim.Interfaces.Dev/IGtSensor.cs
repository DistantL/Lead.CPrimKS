namespace Lead.CPrim.Interfaces.Dev
{
    public interface IGtSensor
    {
        double GetHeight();

        void SendCmd(string cmd);
    }
}