using Lead.CPrim.Global;
using Lead.CPrim.Interfaces;
using Lead.CPrim.Interfaces.Display;
using Lead.CPrim.ProductInfoHelper;
using Lead.CPrim.ProxyTools;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using Lead.CPrim.StationCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Lead.CPrim.Controls
{
    /// <summary>
    /// 软件测试
    /// </summary>
    public partial class Test : UIForm
    {
        #region Field
        Stopwatch sw = new Stopwatch();
        IWorkPlan workPlan;

        /// <summary>
        /// 软件测试对象
        /// </summary>
        private static Test _instance = new Test();
        #endregion



        #region Prop
        /// <summary>
        /// 软件测试对象
        /// </summary>
        public static Test Instance { get => _instance; set => _instance = value; }
        #endregion



        #region Ctor
        private Test()
        {
            InitializeComponent();

            #region TaskStateMachine
            #endregion

            {
                var frm = new GDIFrm();
                frm.Dock = DockStyle.Fill;
                frm.Margin = new Padding(0);
                frm.Padding = new Padding(0);
                frm.Show();
                flpGDI.Controls.Add(frm);
                flpGDI.AutoScroll = true;
            }

            {
                var frm = new CustomChartFrm();
                frm.Dock = DockStyle.Fill;
                frm.Margin = new Padding(0);
                frm.Padding = new Padding(0);
                frm.Show();
                flpCustomChart.Controls.Add(frm);
                flpCustomChart.AutoScroll = true;
            }

            {
                var frm = new UIInputDialogFrm();
                frm.Dock = DockStyle.Fill;
                frm.Margin = new Padding(0);
                frm.Padding = new Padding(0);
                frm.Show();
                flpUIInputDialog.Controls.Add(frm);
                flpUIInputDialog.AutoScroll = true;
            }
        }
        #endregion



        #region MongoDB
        Stopwatch stopwatch = new Stopwatch();
        string collection = "mongodbTest";
        #region 增
        private void btnInsertOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbName.Text.Trim()) || string.IsNullOrEmpty(tbAge.Text.Trim()) || string.IsNullOrEmpty(tbTel.Text.Trim()))
                {
                    throw new Exception("参数为空");
                }
                stopwatch.Reset();
                stopwatch.Start();
                MongoDBTest dBTest = new MongoDBTest() { dateTime = DateTime.Now, Name = tbName.Text.Trim(), Age = int.Parse(tbAge.Text.Trim()), Tel = tbTel.Text.Trim() };
                int ret = MongodbHelper.InsertOne<MongoDBTest>(dBTest, collection);
                if (ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
                stopwatch.Stop();
                Notification.ShowInfo($"插入成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("插入失败：" + ex.Message);
            }
        }

        private async void btnInsertOneAsync_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbName.Text.Trim()) || string.IsNullOrEmpty(tbAge.Text.Trim()) || string.IsNullOrEmpty(tbTel.Text.Trim()))
                {
                    throw new Exception("参数为空");
                }
                stopwatch.Reset();
                stopwatch.Start();
                MongoDBTest dBTest = new MongoDBTest() { dateTime = DateTime.Now, Name = tbName.Text.Trim(), Age = int.Parse(tbAge.Text.Trim()), Tel = tbTel.Text.Trim() };
                int ret = await MongodbHelper.InsertOneAsync<MongoDBTest>(dBTest, collection);
                if (ret != 0)
                {
                    throw new Exception(((Interfaces.SoftWareAlarm)ret).ToString());
                }
                stopwatch.Stop();
                Notification.ShowInfo($"插入成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("插入失败：" + ex.Message);
            }
        }

        private void btnInsertMany_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                List<MongoDBTest> listMongoDB = new List<MongoDBTest>();
                Random rd = new Random();
                for (int i = 100000; i < 1000000; i++)
                {
                    MongoDBTest dBTest = new MongoDBTest() { dateTime = DateTime.Now, Name = "张三" + i.ToString(), Age = rd.Next(0, 100), Tel = rd.Next(0, 10000).ToString() };
                    listMongoDB.Add(dBTest);
                }
                int ret = MongodbHelper.InsertMany<MongoDBTest>(listMongoDB, collection);
                if (ret != 0)
                {
                    throw new Exception(((SoftWareAlarm)ret).ToString());
                }
                stopwatch.Stop();
                Notification.ShowInfo($"插入成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("插入失败：" + ex.Message);
            }
        }

        private async void btnInsertManyAsync_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                List<MongoDBTest> listMongoDB = new List<MongoDBTest>();
                Random rd = new Random();
                for (int i = 100000; i < 1000000; i++)
                {
                    MongoDBTest dBTest = new MongoDBTest() { dateTime = DateTime.Now, Name = "张三" + i.ToString(), Age = rd.Next(0, 100), Tel = rd.Next(0, 10000).ToString() };
                    listMongoDB.Add(dBTest);
                }
                int ret = await MongodbHelper.InsertManyAsync<MongoDBTest>(listMongoDB, collection);
                if (ret != 0)
                {
                    throw new Exception(((Interfaces.SoftWareAlarm)ret).ToString());
                }
                stopwatch.Stop();
                Notification.ShowInfo($"插入成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("插入失败：" + ex.Message);
            }
        }
        #endregion

        #region 改
        private void btnReplaceOne_Click(object sender, EventArgs e)
        {

        }

        private void btnReplaceOneAsync_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateMany_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateManyAsync_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateOne_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateOneAsync_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 删
        private void btnDeleteOne_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                MongodbHelper.DeleteOne<MongoDBTest>("Name", tbName.Text.Trim(), collection, null);
                stopwatch.Stop();
                Notification.ShowInfo($"删除成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("删除失败：" + ex.Message);
            }
        }

        private void btnDeleteOneAsync_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                _ = MongodbHelper.DeleteOneAsync<MongoDBTest>("Name", tbName.Text.Trim(), collection, null);
                stopwatch.Stop();
                Notification.ShowInfo($"删除成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("删除失败：" + ex.Message);
            }
        }

        private void btnDeleteMany_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                MongodbHelper.DeleteMany<MongoDBTest>("Name", tbName.Text.Trim(), collection, null);
                stopwatch.Stop();
                Notification.ShowInfo($"删除成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("删除失败：" + ex.Message);
            }
        }

        private void btnDeleteManyAsync_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                _ = MongodbHelper.DeleteManyAsync<MongoDBTest>("Name", tbName.Text.Trim(), collection, null);
                stopwatch.Stop();
                Notification.ShowInfo($"删除成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("删除失败：" + ex.Message);
            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Reset();
                stopwatch.Start();
                int ret = 0;
                ret = await MongodbHelper.DeleteAllAsync<MongoDBTest>(collection);
                if (ret != 0)
                {
                    throw new Exception(((Interfaces.SoftWareAlarm)ret).ToString());
                }
                stopwatch.Stop();
                Notification.ShowInfo($"删除成功，合计耗时：{stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Notification.ShowError("删除失败：" + ex.Message);
            }

        }
        #endregion

        #endregion



        #region AQCI
        Random rd;
        private void btnAddProInfo_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                rd = new Random();
                if (!int.TryParse(txtPcs.Text, out count) && count > 0)
                {
                    throw new Exception("插入条数值无效");
                }
                sw.Restart();

                //IShow show = ShowManager.Instance.GetShowByName("AQCI0");
                //ProductInfo product = new ProductInfo()
                //{
                //    ID = "111",
                //    CreateTime = DateTime.Now,
                //    EndTime = DateTime.Now.AddMilliseconds(1000),
                //    Result = "OK",
                //};
                //product.Fai.Add("X", 1.5);
                //product.Fai.Add("Y", 1);
                //product.Fai.Add("Z", 0);
                //((IAShowCommon)show).AddProInfo(product, true, "", true, null);

                //IShow show = ShowManager.Instance.GetShowByName("CapacityOfProduction0");
                //for (int i = 0; i < count; i++)
                //{
                //    ProductInfo product = new ProductInfo()
                //    {
                //        ID = "111",
                //        CreateTime = DateTime.Now.AddSeconds(i),
                //        EndTime = DateTime.Now.AddSeconds(15 + i),
                //        Result = txtResult.Text,
                //    };
                //    product.Fai.Add("X", rd.NextDouble() * 10);
                //    product.Fai.Add("Y", rd.NextDouble() * 5);
                //    product.Fai.Add("Z", rd.NextDouble() * 3);
                //    ((IShowCapacityOfProduction)show).AddProInfo(product, true, "", true, null);
                //    StationManager.Instance.CurrentStation.AddRtData(product, false, "", null);
                //}

                IShow show = ShowManagerTransfer.GetShowByName("Audio0");
                for (int i = 0; i < count; i++)
                {
                    ProductInfo product = new ProductInfo()
                    {
                        Sn = "KS1E3FFFD5",
                        CreateTime = DateTime.Now.AddSeconds(i),
                        EndTime = DateTime.Now.AddSeconds(15 + i),
                        Result = txtResult.Text,
                    };
                    product.Fai.Add("Torque_Value1", 0.562);
                    ((IShowAudio)show).AddProInfo(product, true);
                }
                sw.Stop();
                Notification.ShowInfo("AddProInfo成功: " + sw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                Notification.ShowError("AddProInfo失败: " + ex.Message);
            }
            finally
            {
                sw.Stop();
            }
        }
        #endregion



        #region Log
        private void btnLog_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < int.MaxValue; i++)
            {

            }
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds / 1000);
        }
        private void btnCycle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                ProxyTools.LogHelper.LogAdd(LogLevel.Info, "日志测试", "测试", LogClassification.Other, 12345678);
                Thread.Sleep(20);
            }
        }
        #endregion



        #region TaskStateMachine

        #endregion



        #region MyRegion
        private void btnOKIncrease_Click(object sender, EventArgs e)
        {
            workPlan.OKIncrease();
        }
        private void btnNGIncrease_Click(object sender, EventArgs e)
        {
            workPlan.NGIncrease();
        }
        #endregion



        #region 气缸UI
        string nameCylinder = "S3B侧组装顶升气缸";
        IEle eleCylinder;
        #endregion



        #region Load事件
        private void Test_Load(object sender, EventArgs e)
        {
            IShow primWorkPlan = ShowManagerTransfer.GetShowByName("WorkPlan0");
            workPlan = (IWorkPlan)primWorkPlan;

            eleCylinder = ElesManagerTransfer.GetEleByName(nameCylinder);
            if(eleCylinder != null)
            {
                eleCylinder.IEleInit();
                flpCylinderMain.Controls.Add(eleCylinder.EleDebugUI);
            }
        }
        #endregion

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (eleCylinder != null)
            {
                eleCylinder.IEleUiRefresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class MongoDBTest
    {
        public DateTime dateTime { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Tel { get; set; }
    }
}
