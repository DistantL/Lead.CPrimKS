using Lead.CPrim.Interfaces;
using Lead.CPrim.ProxyTools;
using System.Diagnostics;

namespace Lead.CPrim.View
{
    /// <summary>
    /// 启动过程耗时日志。
    /// </summary>
    internal static class StartupDiagnostics
    {
        private static readonly Stopwatch TotalStopwatch = new Stopwatch();

        /// <summary>
        /// 启动总计时开始。
        /// </summary>
        public static void Start()
        {
            TotalStopwatch.Restart();
            Mark("程序入口");
        }

        /// <summary>
        /// 记录启动阶段开始，并返回该阶段计时器。
        /// </summary>
        public static Stopwatch StartStage(string stage, string detail = null)
        {
            Mark($"{stage}开始", detail);
            return Stopwatch.StartNew();
        }

        /// <summary>
        /// 记录启动阶段完成。
        /// </summary>
        public static void CompleteStage(string stage, Stopwatch stageStopwatch, string detail = null)
        {
            stageStopwatch?.Stop();
            long elapsedMilliseconds = stageStopwatch?.ElapsedMilliseconds ?? 0;
            string message = $"{stage}完成 | elapsed={elapsedMilliseconds}ms";
            Mark(message, detail);
        }

        /// <summary>
        /// 记录启动过程中的普通节点。
        /// </summary>
        public static void Mark(string message, string detail = null)
        {
            string detailText = string.IsNullOrWhiteSpace(detail) ? string.Empty : $" | {detail}";
            LogHelper.LogAdd(
                LogLevel.Info,
                $"[Startup] {message} | total={TotalStopwatch.ElapsedMilliseconds}ms{detailText}",
                PrimLogId.View.ToString(),
                LogClassification.Other);
        }
    }
}
