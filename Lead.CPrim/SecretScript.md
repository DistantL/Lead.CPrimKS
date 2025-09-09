# DataGridView

1、DataGridViewComboBoxColumn首次必须点击2次才可弹出

```
private void dgvEbusInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
{
    if (dgvEbusInfo.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex != -1)
        SendKeys.Send("{F4}");
}
```

2、DataGridViewCheckBoxColumn必须按Enter键才生效

```
private void dgvFaisConfig_CurrentCellDirtyStateChanged(object sender, EventArgs e)
{
    if (dgvFaisConfig.IsCurrentCellDirty)
    {
        dgvFaisConfig.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
}
```



# UI

1、容器类控件添加UserControl时，可以直接添加控件；添加Form时，需要将Form的TopMost属性及TopLevel属性设置成false，同时需要执行Show方法后再进行添加



# Event

1、事件由多类订阅时，每个类只能进行订阅，不能进行取消，否则会发生异常



# 问题点

## 问题一：CPU、内存数据无法显示

```
问题：System.InvalidOperationException:“无法加载计数器名称数据，因为从注册表读取的索引无效。”
方案：Windows + R(打开的时候以管理员身份运行) ，输入LODCTR/R，然后稍等几秒钟即可。显示下面 成功地从系统备份存储中重建性能计数器设置后，说明修复成功。
```

