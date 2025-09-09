namespace Lead.CPrim.Interfaces
{
    public delegate void HttpMsgReved(string send, object context);

    public interface IHttpClient
    {
        string DstIp { set; get; }

        string Port { set; get; }

        int ReconnectCnt { set; get; }

        string HeartInfo { set; get; }

        int HeartInfoCycleTime { set; get; }

        bool HeartFlag { set; get; }

        int SendQueueCnt { set; get; }

        int RevQueueCnt { set; get; }

        string NetName { set; get; }

        event HttpMsgReved OnHttpMsgReved;

        int SetSendQueueCnt(int num);

        int RegNotifyInfo(string regInfo);

        int SetNetName(string name);

        int SetFilterInfo(string filterInfo);
        int SetHeartInfo(string heart, int cycleTime);

        string SendInfo(string rev, object context);
        string SendFai(string json);
    }
}