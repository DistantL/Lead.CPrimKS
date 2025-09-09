using Lead.CPrim.Global;
using Lead.CPrim.ProxyTools.Common;
using Lead.CPrim.ProxyTools.SunnyUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.ProxyTools.SunnyUI
{
    public partial class HashKeyInfo : UIPage
    {
        private static readonly HashKeyInfo _hashKeyInfo1 = new HashKeyInfo();

        private static readonly HashKeyInfo _hashKeyInfo2 = new HashKeyInfo();

        public HashKeyInfo()
        {
            InitializeComponent();
        }

        public static HashKeyInfo GetInstance(int index)
        {
            return index switch
            {
                0 => _hashKeyInfo1,
                1 => _hashKeyInfo2,
                _ => _hashKeyInfo1,
            };
        }

        public void SetStyle(bool isVision, int rowCount) 
        {
            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_HashKey);
                row.Cells[0].Value = isVision ? $"VL{i + 1}_SHA1" : i == 0 ? $"CD_SHA1" : $"CD{i + 1}_SHA1";
                row.Cells[1].Value = string.Empty;
                row.Cells[2].Value = isVision ? $"VR{i + 1}_SHA1" : $"CD{rowCount + i + 1}_SHA1";
                row.Cells[3].Value = string.Empty;
                dgv_HashKey.Rows.Add(row);
            }
        }

        public void SetHashKeyInfos(bool isRefresh, ref List<HashKeyInfos> hashKeyInfos)
        {
            foreach (DataGridViewRow row in dgv_HashKey.Rows)
            {
                int index = hashKeyInfos.FindIndex(p => row.Cells[0].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1)
                {
                    row.Cells[1].Value = isRefresh ? hashKeyInfos[index].ItemValue = AudioSwVersion.Instance.GetSHA1InFile(hashKeyInfos[index].ItemPath) : hashKeyInfos[index].ItemValue;
                }
                index = hashKeyInfos.FindIndex(p => row.Cells[2].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1)
                {
                    row.Cells[3].Value = isRefresh ? hashKeyInfos[index].ItemValue = AudioSwVersion.Instance.GetSHA1InFile(hashKeyInfos[index].ItemPath) : hashKeyInfos[index].ItemValue;
                }
            }
        }

        public void GetHashKeyInfos(ref List<HashKeyInfos> hashKeyInfos)
        {
            foreach (DataGridViewRow row in dgv_HashKey.Rows) 
            {
                int index = hashKeyInfos.FindIndex(p => row.Cells[0].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1) 
                {
                    hashKeyInfos[index].ItemValue = row.Cells[1].Value.ToString();
                }
                index = hashKeyInfos.FindIndex(p => row.Cells[2].Value.ToString().Replace("_SHA1", "").Trim() == p.ItemName);
                if (index > -1)
                {
                    hashKeyInfos[index].ItemValue = row.Cells[3].Value.ToString();
                }
            }
        }
    }
}
