using System.Messaging;

namespace Lead.CPrim.Interfaces
{
    public delegate void MsmqRcved(string send, object context);

    public interface IPrimMSMQ
    {
        bool EnableRcvEvent { get; set; }
        MessageQueue RcvQueue { get; set; }
        string RcvQueueIpAdr { get; set; }
        bool RcvQueueIsRemote { get; set; }
        string RcvQueueName { get; set; }
        int RcvQueueNum { get; }
        MessageQueue SendQueue { get; set; }
        string SendQueueIpAdr { get; set; }
        bool SendQueueIsRemote { get; set; }
        string SendQueueName { get; set; }
        event MsmqRcved OnMessageRcved;

        void ClrRcvEvent();

        void ClrRcvQueue();

        int RcvMsg<T>(ref T rcvObj, int waitTims = 0);

        void SendMsg<T>(T msg);
    }
}