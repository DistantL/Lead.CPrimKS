namespace Lead.CPrim.Interfaces
{
    public interface IEtherCAT
    {
        int GetOdData(int slaveNo, int odIndex, ref uint value);

        int SetOdData(int slaveNo, int odIndex, uint value);
    }
}