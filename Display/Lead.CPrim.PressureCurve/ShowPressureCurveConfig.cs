using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lead.CPrim.PressureCurve
{
    /// <summary>压力曲线配置</summary>
    public class ShowPressureCurveConfig
    {
        #region Ctor无参
        public ShowPressureCurveConfig()
        {
            PressVisible1 = true;
            PressVisible2 = true;
            PressVisible3 = true;
            PressVisible4 = true;

            PressName1 = "保压1";
            PressName2 = "保压2";
            PressName3 = "保压3";
            PressName4 = "保压4";

            ID1 = 1;
            ID2 = 2;
            ID3 = 3;
            ID4 = 4;
        } 
        #endregion



        #region Define
        public bool PressVisible1 { get; set; }
        public string PressName1 { get; set; }
        public int ID1 { get; set; }
        public bool PressVisible2 { get; set; }
        public string PressName2 { get; set; }
        public int ID2 { get; set; }
        public bool PressVisible3 { get; set; }
        public string PressName3 { get; set; }
        public int ID3 { get; set; }
        public bool PressVisible4 { get; set; }
        public string PressName4 { get; set; }
        public int ID4 { get; set; }
        public string ImagePath { get; set; }
        #endregion



        #region Override IPrim
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShowTypeName { get; set; }
        public bool Enable { get; set; }
        public string Version { get; set; } 
        #endregion
    }
}
