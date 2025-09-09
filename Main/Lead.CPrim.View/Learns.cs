/******************************************************************************
 * CPrim
 * CopyRight (C) 2020-2030.
 * FileName: Learns.cs
 * Author: Victor
 * Description: 教程UI，用于显示常见问题的解决方案
 * CreateTime: 2022-09-22
 * 
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 版本迭代说明&修改记录
 * <3.3.22.0904><Victor><20220922>
 * 1、初版1.0
******************************************************************************/

using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Sunny.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace Lead.CPrim.View
{
    public partial class Learns : UIForm
    {
        #region Field
        /// <summary>教程根目录</summary>
        string pathLearns = Application.StartupPath + @"\Learns";
        /// <summary>私有对象</summary>
        private static readonly Learns _instance = new Learns();
        #endregion



        #region Prop
        /// <summary>对象</summary>
        public static Learns Instance => _instance;
        #endregion



        #region Ctor
        private Learns()
        {
            InitializeComponent();
            tlpMain.SetDoubleBuffered();
        }
        #endregion



        #region System_Event
        private void Learns_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        } 
        #endregion



        #region Button_Event
        private void btnPdcaConnect_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(pathLearns, @"PDCA\PDCA.docx");
            ProcessHelper.ProcessStart(path);
        }
        private void btnYiSaiTongClear_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(pathLearns, @"LeadSafe\LeadSafe.docx");
            ProcessHelper.ProcessStart(path);
        }
        private void btnLiXunData_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(pathLearns, @"LiXunData\立讯数据流简介.pptx");
            ProcessHelper.ProcessStart(path);
        }
        private void btnLiXunMesWeb_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(pathLearns, @"LiXunMes\Mes_WebService.pptx");
            ProcessHelper.ProcessStart(path);
        }
        #endregion
    }
}
