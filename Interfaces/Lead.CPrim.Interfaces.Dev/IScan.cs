namespace Lead.CPrim.Interfaces.Dev
{
    public delegate void ReaderRec(string msg);

    public interface IScan
    {
        event ReaderRec RcvBarcodeEvent;

        void ReadBarCode();

        void SendCmd(string cmd);
    }
}