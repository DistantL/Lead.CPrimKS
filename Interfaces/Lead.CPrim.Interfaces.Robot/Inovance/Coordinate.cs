using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.Interfaces.Robot
{
    /// <summary>
    /// 坐标系
    /// </summary>
    public enum Coordinate
    {
        Other = 0,
        关节坐标系 = 1,
        基坐标系,
        工具坐标系,
        工件坐标系,
        世界坐标系,
    }
}
