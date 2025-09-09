using Lead.CPrim.Interfaces;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Threading;
using Opc.Ua;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.CSharp;
using Lead.CPrim.ProxyTools;

namespace Lead.CPrim.PrimOPC
{
    public partial class PrimConfigControl : UserControl
    {
        private readonly PrimOPC _opc;
        public PrimConfigControl()
        {
            InitializeComponent();
        }
        public PrimConfigControl(PrimOPC opc)
        {
            _opc = opc;
            InitializeComponent();
        }

        private void btnApply_Click_1(object sender, System.EventArgs e)
        {
            _opc.Name = tbPrimName.Text;
            _opc.LoginMethod = cmbLoginMode.SelectedIndex <= 0 ? 0 : cmbLoginMode.SelectedIndex;
            _opc.UserName = tbUserName.Text;
            _opc.Password = tbPassword.Text;
            _opc.CertificateFilePath = tbCertificateFilePath.Text;
            _opc.ServerAddress = tbServerAddress.Text;
            _opc.NodeConfigPath = tbNodeConfigPath.Text;
            ExportNodeConfig();
        }

        private void PrimConfigControl_Load(object sender, System.EventArgs e)
        {
            tbPrimName.Text = _opc.Name;
            cmbLoginMode.SelectedIndex = _opc.LoginMethod;
            tbUserName.Text = _opc.UserName;
            tbPassword.Text = _opc.Password;
            tbCertificateFilePath.Text = _opc.CertificateFilePath;
            tbSecretKey.Text = _opc.SecretKey;
            tbServerAddress.Text = _opc.ServerAddress;
            tbNodeConfigPath.Text = _opc.NodeConfigPath;
            ImportNodeConfig();
            try
            {
                
                SetPrimConnState(_opc.PrimConnStat);
                SetPrimRunState(_opc.PrimRunStat);
            }
            catch 
            {

                
            }
            
        }

        private void btnOpenCertFile_Click(object sender, System.EventArgs e)
        {
            string file = null;
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                file = fileDialog.FileName;
                tbCertificateFilePath.Text = file;
            }
        }

        public void SetPrimConnState(PrimConnState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (tbConnState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimConnState>(SetPrimConnState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimConnState.UnConnected:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                    case PrimConnState.Connected:
                        tbConnState.BackColor = Color.LightGreen;
                        tbConnState.Text = "Connected";
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        break;
                    case PrimConnState.Other:
                        tbConnState.BackColor = Color.Khaki;
                        tbConnState.Text = "UnConnected";
                        btnInit.BackColor = Color.SkyBlue;
                        btnRun.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnRun.Enabled = true;
                        break;
                }
            }
        }

        public void SetPrimRunState(PrimRunState state)
        {
            if (!Created || !IsHandleCreated)
            {
                return;
            }
            if (tbRunState.InvokeRequired)
            {
                BeginInvoke(new Action<PrimRunState>(SetPrimRunState), state);
            }
            else
            {
                switch (state)
                {
                    case PrimRunState.Idle:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        break;
                    case PrimRunState.Running:
                        tbRunState.BackColor = Color.LightGreen;
                        tbRunState.Text = "Running";
                        btnRun.BackColor = Color.Gray;
                        btnRun.Enabled = false;
                        btnInit.BackColor = Color.Gray;
                        btnInit.Enabled = false;
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Stop:
                        tbRunState.BackColor = Color.Brown;
                        tbRunState.Text = "Stop";
                        btnRun.BackColor = Color.LightGreen;
                        btnRun.Enabled = true;
                        btnInit.BackColor = Color.LightGreen;
                        btnInit.Enabled = true;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                    case PrimRunState.Err:
                        tbRunState.BackColor = Color.SandyBrown;
                        tbRunState.Text = "Err";
                        btnStop.Enabled = true;
                        btnStop.BackColor = Color.SandyBrown;
                        break;
                    case PrimRunState.Other:
                        tbRunState.BackColor = Color.Khaki;
                        tbRunState.Text = "Idle";
                        btnRun.Enabled = false;
                        btnRun.BackColor = Color.Gray;
                        btnStop.Enabled = false;
                        btnStop.BackColor = Color.Gray;
                        break;
                }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_opc == null)
            {
                return;
            }
            _opc.IPrimInit();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (_opc == null)
            {
                return;
            }
            var connRet = "";
            _opc.ServerAddress = tbServerAddress.Text;
            _opc.IPrimConnect(ref connRet);
            _opc.IPrimStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_opc == null)
            {
                return;
            }
            _opc.IPrimStop();
            Thread.Sleep(50);
            _opc.IPrimDispose();
        }

        private void RefreshNode_Click(object sender, EventArgs e)
        {
            if (_opc.PrimConnStat != PrimConnState.Connected || _opc.PrimRunStat != PrimRunState.Running)
            {
                MessageBox.Show($@"当前基元状态未连接，无法刷新OPC节点数据，请先连接基元");
                return;
            }
            PopulateBranch(ObjectIds.ObjectsFolder, tViewNodeList.Nodes);
        }

        private async void PopulateBranch(NodeId sourceId, TreeNodeCollection nodes)
        {
            nodes.Clear();
            nodes.Add(new TreeNode("Browsering...", 7, 7));
            // fetch references from the server.
            TreeNode[] listNode = await Task.Run(() =>
            {
                ReferenceDescriptionCollection references = GetReferenceDescriptionCollection(sourceId);
                List<TreeNode> list = new List<TreeNode>();
                if (references != null)
                {
                    // process results.
                    for (int ii = 0; ii < references.Count; ii++)
                    {
                        ReferenceDescription target = references[ii];
                        TreeNode child = new TreeNode(Utils.Format("{0}", target));

                        child.Tag = target;
                        string key = GetImageKeyFromDescription(target, sourceId);
                        child.ImageKey = key;
                        child.SelectedImageKey = key;
                        if (GetReferenceDescriptionCollection((NodeId)target.NodeId).Count > 0)
                        {
                            child.Nodes.Add(new TreeNode());
                        }
                        list.Add(child);
                    }
                }
                return list.ToArray();
            });
            // update the attributes display.
            // DisplayAttributes(sourceId);
            nodes.Clear();
            nodes.AddRange(listNode.ToArray());
        }

        private ReferenceDescriptionCollection GetReferenceDescriptionCollection(NodeId sourceId)
        {
            TaskCompletionSource<ReferenceDescriptionCollection> task = new TaskCompletionSource<ReferenceDescriptionCollection>();

            // find all of the components of the node.
            BrowseDescription nodeToBrowse1 = new BrowseDescription();

            nodeToBrowse1.NodeId = sourceId;
            nodeToBrowse1.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse1.ReferenceTypeId = ReferenceTypeIds.Aggregates;
            nodeToBrowse1.IncludeSubtypes = true;
            nodeToBrowse1.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method | NodeClass.ReferenceType | NodeClass.ObjectType | NodeClass.View | NodeClass.VariableType | NodeClass.DataType);
            nodeToBrowse1.ResultMask = (uint)BrowseResultMask.All;

            // find all nodes organized by the node.
            BrowseDescription nodeToBrowse2 = new BrowseDescription();

            nodeToBrowse2.NodeId = sourceId;
            nodeToBrowse2.BrowseDirection = BrowseDirection.Forward;
            nodeToBrowse2.ReferenceTypeId = ReferenceTypeIds.Organizes;
            nodeToBrowse2.IncludeSubtypes = true;
            nodeToBrowse2.NodeClassMask = (uint)(NodeClass.Object | NodeClass.Variable | NodeClass.Method | NodeClass.View | NodeClass.ReferenceType | NodeClass.ObjectType | NodeClass.VariableType | NodeClass.DataType);
            nodeToBrowse2.ResultMask = (uint)BrowseResultMask.All;

            BrowseDescriptionCollection nodesToBrowse = new BrowseDescriptionCollection();
            nodesToBrowse.Add(nodeToBrowse1);
            nodesToBrowse.Add(nodeToBrowse2);

            // fetch references from the server.
            ReferenceDescriptionCollection references = FormUtils.Browse(_opc.OPCSession, nodesToBrowse, false);
            return references;
        }

        private string GetImageKeyFromDescription(ReferenceDescription target, NodeId sourceId)
        {
            if (target.NodeClass == NodeClass.Variable)
            {
                DataValue dataValue = _opc.Read((NodeId)target.NodeId);

                if (dataValue.WrappedValue.TypeInfo != null)
                {
                    if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.Scalar)
                    {
                        return "Enum_582.png";
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.OneDimension)
                    {
                        return "brackets.png";
                    }
                    else if (dataValue.WrappedValue.TypeInfo.ValueRank == ValueRanks.TwoDimensions)
                    {
                        return "Module_648.png";
                    }
                    else
                    {
                        return "ClassIcon.png";
                    }
                }
                else
                {
                    return "ClassIcon.png";
                }
            }
            else if (target.NodeClass == NodeClass.Object)
            {
                if (sourceId == ObjectIds.ObjectsFolder)
                {
                    return "VirtualMachine.png";
                }
                else
                {
                    return "ClassIcon.png";
                }
            }
            else if (target.NodeClass == NodeClass.Method)
            {
                return "Method_636.png";
            }
            else
            {
                return "ClassIcon.png";
            }
        }

        private void tViewNodeList_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                // check if node has already been expanded once.
                if (e.Node.Nodes.Count != 1)
                {
                    return;
                }
                if (e.Node.Nodes.Count > 0)
                {
                    if (e.Node.Nodes[0].Text != String.Empty)
                    {
                        return;
                    }
                }
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    e.Cancel = true;
                    return;
                }
                // populate children.
                PopulateBranch((NodeId)reference.NodeId, e.Node.Nodes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void tViewNodeList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tn = tViewNodeList.GetNodeAt(e.X, e.Y);
                if (tn != null)
                {
                    tViewNodeList.SelectedNode = tn;
                }
            }
        }

        private void tViewNodeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                // get the source for the node.
                ReferenceDescription reference = e.Node.Tag as ReferenceDescription;
                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }
                // populate children.
                ShowMember((NodeId)reference.NodeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ClientUtils.HandleException(Text, exception);
            }
        }
        private async void ShowMember(NodeId sourceId)
        {
            dgvNodeConfig.Rows.Clear();
            int index = 0;
            ReferenceDescriptionCollection references;
            try
            {
                references = await Task.Run(() =>
                {
                    return GetReferenceDescriptionCollection(sourceId);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ClientUtils.HandleException(Text, exception);
                return;
            }
            if (references?.Count > 0)
            {
                // 获取所有要读取的子节点
                List<NodeId> nodeIds = new List<NodeId>();
                for (int i = 0; i < references.Count; i++)
                {
                    ReferenceDescription target = references[i];
                    nodeIds.Add((NodeId)target.NodeId);
                }
                // 显示
                while (nodeIds.Count > dgvNodeConfig.Rows.Count)
                {
                    dgvNodeConfig.Rows.Add();
                }
                for (int y = 0; y < nodeIds.Count; y++)
                {
                    dgvNodeConfig.Rows[y].Cells[0].Value = index;
                    var dataValue = _opc.Read(nodeIds[index]);
                    dgvNodeConfig.Rows[y].Cells[1].Value = Utils.Format("{0}", references[index]);
                    dgvNodeConfig.Rows[y].Cells[1].ReadOnly = true;
                    dgvNodeConfig.Rows[y].Cells[2].Value = dataValue.Value.ToString();
                    dgvNodeConfig.Rows[y].Cells[3].Value = dataValue.WrappedValue.TypeInfo.BuiltInType;
                    dgvNodeConfig.Rows[y].Cells[3].ReadOnly = true;
                    dgvNodeConfig.Rows[y].Cells[4].Value = nodeIds[index].ToString();
                    dgvNodeConfig.Rows[y].Cells[4].ReadOnly = true;
                    index++;
                }
            }
           
        }

        private void btnOpenNodeConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNodeConfigPath.Text))
            {
                if (saveFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    tbNodeConfigPath.Text = saveFileDialogConfig.FileName;
                    _opc.NodeConfigPath = tbNodeConfigPath.Text;
                }
            }
            else
            {
                openFileDialogConfig.InitialDirectory = Path.GetDirectoryName(tbNodeConfigPath.Text);
                if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    tbNodeConfigPath.Text = openFileDialogConfig.FileName;
                    if (string.IsNullOrEmpty(tbNodeConfigPath.Text))
                    {
                        return;
                    }
                    if (!File.Exists(tbNodeConfigPath.Text))
                    {
                        MessageBox.Show($@"文件{tbNodeConfigPath.Text}不存在");
                        return;
                    }
                    _opc.NodeConfigPath = tbNodeConfigPath.Text;
                }
            }
            /*
            openFileDialogConfig.Multiselect = false;
            openFileDialogConfig.Title = "请选择文件";
            openFileDialogConfig.Filter = "所有文件(*.*)|*.*";
            if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
            {
                tbNodeConfigPath.Text = openFileDialogConfig.FileName;
            }
            */
        }

        private void ExportNodeConfig()
        {
            if (_opc.NodeConfigPath == null)
            {
                return;
            }
            if (_opc.ListNodeConfig!=null)
            {
                _opc.ListNodeConfig.Clear();
            }
            
            foreach (DataGridViewRow item in dgvNodeConfig.Rows)
            {
                NodeConfig config = new NodeConfig();
                config.NodeNum = Convert.ToInt32(item.Cells[0].Value);
                config.NodeKey = item.Cells[1].Value.ToString();
                config.NodeName = item.Cells[2].Value.ToString();
                _opc.ListNodeConfig.Add(config);
            }
            JsonHelper.SerializeObjectToFile(_opc.ListNodeConfig, _opc.NodeConfigPath);
        }

        private void ImportNodeConfig()
        {
            if (_opc.ListNodeConfig != null)
            {
                dgvNodeConfig.Rows.Clear();
                while (_opc.ListNodeConfig.Count > dgvNodeConfig.Rows.Count)
                {
                    dgvNodeConfig.Rows.Add();
                }
                for (int y = 0; y < _opc.ListNodeConfig.Count; y++)
                {
                    dgvNodeConfig.Rows[y].Cells[0].Value = _opc.ListNodeConfig[y].NodeNum;
                    dgvNodeConfig.Rows[y].Cells[1].Value = _opc.ListNodeConfig[y].NodeKey;
                    dgvNodeConfig.Rows[y].Cells[2].Value = _opc.ListNodeConfig[y].NodeName;
                }
            }
        }

        private void dgvNodeConfig_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetDataObject(this.dgvNodeConfig.GetClipboardContent());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewToCSV(this.dgvNodeConfig);
            

             
        }
        public static int dataGridViewToCSV(DataGridView dataGridView)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.FileName = null;
            saveFileDialog.Title = "保存";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = saveFileDialog.OpenFile();
                StreamWriter sw = new StreamWriter(stream, System.Text.Encoding.GetEncoding(-0));
                string strLine = "";
                try
                {
                    //表头
                    for (int i = 0; i < dataGridView.ColumnCount; i++)
                    {
                        if (i > 0)
                            strLine += ",";
                        strLine += dataGridView.Columns[i].HeaderText;
                    }
                    strLine.Remove(strLine.Length - 1);
                    sw.WriteLine(strLine);
                    strLine = "";
                    //表的内容
                    for (int j = 0; j < dataGridView.Rows.Count; j++)
                    {
                        strLine = "";
                        int colCount = dataGridView.Columns.Count;
                        for (int k = 0; k < colCount; k++)
                        {
                            if (k > 0 && k < colCount)
                                strLine += ",";
                            if (dataGridView.Rows[j].Cells[k].Value == null)
                                strLine += "";
                            else
                            {
                                string cell = dataGridView.Rows[j].Cells[k].Value.ToString().Trim();
                                //防止里面含有特殊符号
                                cell = cell.Replace("\"", "\"\"");
                                //cell = "\"" + cell + "\""; //每个元素值用引号包括
                                strLine += cell;
                            }
                        }
                        sw.WriteLine(strLine);
                    }
                    sw.Close();
                    stream.Close();
                    MessageBox.Show("数据被导出到：" + saveFileDialog.FileName.ToString(), "导出完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
            }
            return 0;
        }

        private void dgvNodeConfig_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNodeConfig.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value is BuiltInType builtInType)
            {
                dynamic value = null;
                if (dgvNodeConfig.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value is string)
                {
                   
                        // 节点
                        try
                        {
                            value = GetValueFromString(dgvNodeConfig.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), builtInType);
                        }
                        catch
                        {
                            MessageBox.Show("Invalid Input Value");
                            return;
                        }

                        if (!_opc.Write(dgvNodeConfig.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].Value.ToString(), value))
                        {
                            MessageBox.Show("Failed to write value");
                        }
                    
                    
                }
                else
                {
                    // 点击了数组修改
                    IList<string> list = new List<string>();

                    for (int jj = 0; jj < dgvNodeConfig.RowCount; jj++)
                    {
                        list.Add(dgvNodeConfig.Rows[jj].Cells[e.ColumnIndex].Value.ToString());
                    }

                    try
                    {
                        value = GetArrayValueFromString(list, builtInType);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Input Value: " + ex.Message);
                        return;
                    }

                   /* if (!_opc.WriteNode(textBox_nodeId.Text, value))
                    {
                        MessageBox.Show("Failed to write value");
                    }
                   */
                }
            }
            else
            {
                MessageBox.Show("Invalid data type");
            }
        }

        private dynamic GetValueFromString(string value, BuiltInType builtInType)
        {
            switch (builtInType)
            {
                case BuiltInType.Boolean:
                    {
                        return bool.Parse(value);
                    }
                case BuiltInType.Byte:
                    {
                        return byte.Parse(value);
                    }
                case BuiltInType.DateTime:
                    {
                        return DateTime.Parse(value);
                    }
                case BuiltInType.Double:
                    {
                        return double.Parse(value);
                    }
                case BuiltInType.Float:
                    {
                        return float.Parse(value);
                    }
                case BuiltInType.Guid:
                    {
                        return Guid.Parse(value);
                    }
                case BuiltInType.Int16:
                    {
                        return short.Parse(value);
                    }
                case BuiltInType.Int32:
                    {
                        return int.Parse(value);
                    }
                case BuiltInType.Int64:
                    {
                        return long.Parse(value);
                    }
                case BuiltInType.Integer:
                    {
                        return int.Parse(value);
                    }
                case BuiltInType.LocalizedText:
                    {
                        return value;
                    }
                case BuiltInType.SByte:
                    {
                        return sbyte.Parse(value);
                    }
                case BuiltInType.String:
                    {
                        return value;
                    }
                case BuiltInType.UInt16:
                    {
                        return ushort.Parse(value);
                    }
                case BuiltInType.UInt32:
                    {
                        return uint.Parse(value);
                    }
                case BuiltInType.UInt64:
                    {
                        return ulong.Parse(value);
                    }
                case BuiltInType.UInteger:
                    {
                        return uint.Parse(value);
                    }
                default: throw new Exception("Not supported data type");
            }
        }


        private dynamic GetArrayValueFromString(IList<string> values, BuiltInType builtInType)
        {
            switch (builtInType)
            {
                case BuiltInType.Boolean:
                    {
                        bool[] result = new bool[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = bool.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Byte:
                    {
                        byte[] result = new byte[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = byte.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.DateTime:
                    {
                        DateTime[] result = new DateTime[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = DateTime.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Double:
                    {
                        double[] result = new double[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = double.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Float:
                    {
                        float[] result = new float[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = float.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Guid:
                    {
                        Guid[] result = new Guid[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = Guid.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int16:
                    {
                        short[] result = new short[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = short.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int32:
                    {
                        int[] result = new int[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = int.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Int64:
                    {
                        long[] result = new long[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = long.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.Integer:
                    {
                        int[] result = new int[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = int.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.LocalizedText:
                    {
                        return values.ToArray();
                    }
                case BuiltInType.SByte:
                    {
                        sbyte[] result = new sbyte[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = sbyte.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.String:
                    {
                        return values.ToArray();
                    }
                case BuiltInType.UInt16:
                    {
                        ushort[] result = new ushort[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = ushort.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInt32:
                    {
                        uint[] result = new uint[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = uint.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInt64:
                    {
                        ulong[] result = new ulong[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = ulong.Parse(values[i]);
                        }
                        return result;
                    }
                case BuiltInType.UInteger:
                    {
                        uint[] result = new uint[values.Count];
                        for (int i = 0; i < values.Count; i++)
                        {
                            result[i] = uint.Parse(values[i]);
                        }
                        return result;
                    }
                default: throw new Exception("Not supported data type");
            }
        }
    }
}