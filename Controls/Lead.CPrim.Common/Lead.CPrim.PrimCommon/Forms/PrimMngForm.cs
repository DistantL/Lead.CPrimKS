using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Windows.Forms;

namespace Lead.CPrim.PrimCommon
{
    public partial class PrimMngForm : UIPage
	{
        #region Define_Event_未使用
        //public event PrimAdd OnDevAdd;
        //public event PrimRemove OnDevRemove; 
        #endregion



        #region Ctor
		/// <summary>Ctor无参</summary>
        public PrimMngForm()
        {
            InitializeComponent();
            InitializeUI();
        }
        #endregion



        #region Method_ExternalUsing

        public void PrimAdd(string group, string type, string primName, Guid primID)
        {
            int cntGroup = treePrimMng.Nodes.Count;
            bool haveGroup = false;
            int idxGroup = -1;
            bool haveType = false;
            int idxType = -1;
            bool haveDev = false;
            for (int i = 0; i < cntGroup; i++)
            {
                if (treePrimMng.Nodes[i].Text == group)
                {
                    haveGroup = true;
                    idxGroup = i;
                    break;
                }
            }
            if (!haveGroup)
            {
                TreeNode tn3 = new TreeNode(group);
                treePrimMng.Nodes.Add(tn3);
                idxGroup = cntGroup;
            }
            int cntType = treePrimMng.Nodes[idxGroup].Nodes.Count;
            for (int j = 0; j < cntType; j++)
            {
                if (treePrimMng.Nodes[idxGroup].Nodes[j].Text == type)
                {
                    haveType = true;
                    idxType = j;
                    break;
                }
            }
            if (!haveType)
            {
                TreeNode tn2 = new TreeNode(type);
                treePrimMng.Nodes[idxGroup].Nodes.Add(tn2);
                idxType = cntType;
            }
            int cntDev = treePrimMng.Nodes[idxGroup].Nodes[idxType].Nodes.Count;
            for (int k = 0; k < cntDev; k++)
            {
                if (treePrimMng.Nodes[idxGroup].Nodes[idxType].Nodes[k].Text == primName)
                {
                    haveDev = true;
                    break;
                }
            }
            if (!haveDev)
            {
                TreeNode tn = new TreeNode(primName);
                tn.Tag = primID;
                treePrimMng.Nodes[idxGroup].Nodes[idxType].Nodes.Add(tn);
            }
        }

        public void PrimNameChange(Guid primID, string dstName)
        {
            int cntGroup = treePrimMng.Nodes.Count;
            if (cntGroup < 1)
            {
                return;
            }
            for (int i = 0; i < cntGroup; i++)
            {
                int cntType = treePrimMng.Nodes[i].Nodes.Count;
                if (cntType < 1)
                {
                    continue;
                }
                for (int j = 0; j < cntType; j++)
                {
                    int cntDev = treePrimMng.Nodes[i].Nodes[j].Nodes.Count;
                    if (cntDev < 1)
                    {
                        continue;
                    }
                    for (int k = 0; k < cntDev; k++)
                    {
                        if ((Guid)treePrimMng.Nodes[i].Nodes[j].Nodes[k].Tag == primID)
                        {
                            treePrimMng.Nodes[i].Nodes[j].Nodes[k].Text = dstName;
                            return;
                        }
                    }
                }
            }
        }

        public void PrimRemove(string group, string type, string devName, Guid primID)
        {
        }

        public void PrimRemove(Guid primID)
        {
            int cntGroup = treePrimMng.Nodes.Count;
            if (cntGroup < 1)
            {
                return;
            }
            for (int i = 0; i < cntGroup; i++)
            {
                int cntType = treePrimMng.Nodes[i].Nodes.Count;
                if (cntType < 1)
                {
                    continue;
                }
                for (int j = 0; j < cntType; j++)
                {
                    int cntDev = treePrimMng.Nodes[i].Nodes[j].Nodes.Count;
                    if (cntDev < 1)
                    {
                        continue;
                    }
                    for (int k = 0; k < cntDev; k++)
                    {
                        if ((Guid)treePrimMng.Nodes[i].Nodes[j].Nodes[k].Tag == primID)
                        {
                            treePrimMng.Nodes[i].Nodes[j].Nodes.RemoveAt(k);
                            return;
                        }
                    }
                }
            }
        }
        #endregion



        #region Method_InternalUsing
        /// <summary>中英互译</summary>
        private void InitializeUI()
        {
            //this.TabText = ProxyTools.NLocalizer.GetString("PrimCommon_PrimMng_FormText", "PrimMng");
        }

        private void treePrimMng_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //DoDragDrop(e.Item, DragDropEffects.Copy);
        }
        #endregion
    }
}
