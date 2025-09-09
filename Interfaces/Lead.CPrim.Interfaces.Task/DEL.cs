namespace Lead.CPrim.Interfaces.Task
{
    /// <summary>任务选择委托</summary>
    /// <param name="task">ITask</param>
    /// <returns></returns>
    public delegate int TaskSelected(ITask task);

    public delegate void ProductData(int taskId, object msg);
}
