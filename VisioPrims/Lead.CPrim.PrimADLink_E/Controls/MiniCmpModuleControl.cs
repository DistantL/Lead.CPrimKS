using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lead.CPrim.PrimADLink_E.Controls
{
    public partial class MiniCmpModuleControl : UserControl
    {
        private PrimADLink_E _prim;
        private MiniCmp _module;
        private int _miniModuleIndex;
        private int _firstAxisId;
        
        
        public MiniCmpModuleControl()
        {
            InitializeComponent();
        }

        public MiniCmpModuleControl(PrimADLink_E prim, int miniModuleIndex)
        {
            InitializeComponent();
            _prim = prim;
            _module = _prim.MiniCmpModules[miniModuleIndex];
            _miniModuleIndex = miniModuleIndex;
            _firstAxisId = 5000 + miniModuleIndex * 4;
        }

        private void btnClrCnt_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 4; i++)
            {
                _prim.SetAxisPositionAndFeedbackPulse(_firstAxisId + i, 0);
                _prim.ResetTriggerCount(_miniModuleIndex + 4 * i);
            }
        }

        private void btnSet0_Click(object sender, EventArgs e)
        {
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(_prim.DevIndex, _module.SlaveNo, 1);
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(_prim.DevIndex, _module.SlaveNo, 0, (int)Num_PulseWidth0.Value);
            uint Line_mask = Convert.ToUInt32(LP00.Checked) | Convert.ToUInt32(LP01.Checked) * 2 | Convert.ToUInt32(LP02.Checked) * 4 | Convert.ToUInt32(LP03.Checked) * 8
                             | Convert.ToUInt32(LP04.Checked) * 16 | Convert.ToUInt32(LP05.Checked) * 32 | Convert.ToUInt32(LP06.Checked) * 64 | Convert.ToUInt32(LP07.Checked) * 128
                             | Convert.ToUInt32(LP08.Checked) * 256 | Convert.ToUInt32(LP09.Checked) * 512;
            uint Pre_mask = Convert.ToUInt32(TP00.Checked) | Convert.ToUInt32(TP01.Checked) * 2 | Convert.ToUInt32(TP02.Checked) * 4 | Convert.ToUInt32(TP03.Checked) * 8;
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(_prim.DevIndex, _module.SlaveNo, 0, Line_mask, Pre_mask, (uint)Num_Polarity0.Value);
        }

        private void btnSet1_Click(object sender, EventArgs e)
        {
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(_prim.DevIndex, _module.SlaveNo, 1);
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(_prim.DevIndex, _module.SlaveNo, 1, (int)Num_PulseWidth1.Value);
            uint Line_mask = Convert.ToUInt32(LP10.Checked) | Convert.ToUInt32(LP11.Checked) * 2 | Convert.ToUInt32(LP12.Checked) * 4 | Convert.ToUInt32(LP13.Checked) * 8
                             | Convert.ToUInt32(LP14.Checked) * 16 | Convert.ToUInt32(LP15.Checked) * 32 | Convert.ToUInt32(LP16.Checked) * 64 | Convert.ToUInt32(LP17.Checked) * 128
                             | Convert.ToUInt32(LP18.Checked) * 256 | Convert.ToUInt32(LP19.Checked) * 512;
            uint Pre_mask = Convert.ToUInt32(TP10.Checked) | Convert.ToUInt32(TP11.Checked) * 2 | Convert.ToUInt32(TP12.Checked) * 4 | Convert.ToUInt32(TP13.Checked) * 8;
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(_prim.DevIndex, _module.SlaveNo, 1, Line_mask, Pre_mask, (uint)Num_Polarity1.Value);
        }

        private void btnSet2_Click(object sender, EventArgs e)
        {
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(_prim.DevIndex, _module.SlaveNo, 2);
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(_prim.DevIndex, _module.SlaveNo, 2, (int)Num_PulseWidth2.Value);
            uint Line_mask = Convert.ToUInt32(LP20.Checked) | Convert.ToUInt32(LP21.Checked) * 2 | Convert.ToUInt32(LP22.Checked) * 4 | Convert.ToUInt32(LP23.Checked) * 8
                             | Convert.ToUInt32(LP24.Checked) * 16 | Convert.ToUInt32(LP25.Checked) * 32 | Convert.ToUInt32(LP26.Checked) * 64 | Convert.ToUInt32(LP27.Checked) * 128
                             | Convert.ToUInt32(LP28.Checked) * 256 | Convert.ToUInt32(LP29.Checked) * 512;
            uint Pre_mask = Convert.ToUInt32(TP20.Checked) | Convert.ToUInt32(TP21.Checked) * 2 | Convert.ToUInt32(TP22.Checked) * 4 | Convert.ToUInt32(TP23.Checked) * 8;
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(_prim.DevIndex, _module.SlaveNo, 2, Line_mask, Pre_mask, (uint)Num_Polarity2.Value);
        }

        private void btnSet3_Click(object sender, EventArgs e)
        {
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetOutMode(_prim.DevIndex, _module.SlaveNo, 3);
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetPulseWidth(_prim.DevIndex, _module.SlaveNo, 3, (int)Num_PulseWidth3.Value);
            uint Line_mask = Convert.ToUInt32(LP30.Checked) | Convert.ToUInt32(LP31.Checked) * 2 | Convert.ToUInt32(LP32.Checked) * 4 | Convert.ToUInt32(LP33.Checked) * 8
                             | Convert.ToUInt32(LP34.Checked) * 16 | Convert.ToUInt32(LP35.Checked) * 32 | Convert.ToUInt32(LP36.Checked) * 64 | Convert.ToUInt32(LP37.Checked) * 128
                             | Convert.ToUInt32(LP38.Checked) * 256 | Convert.ToUInt32(LP39.Checked) * 512;
            uint Pre_mask = Convert.ToUInt32(TP30.Checked) | Convert.ToUInt32(TP31.Checked) * 2 | Convert.ToUInt32(TP32.Checked) * 4 | Convert.ToUInt32(TP33.Checked) * 8;
            lct_mini.Mini_Cmp_Lib.TriggerOut_SetParam(_prim.DevIndex, _module.SlaveNo, 3, Line_mask, Pre_mask, (uint)Num_Polarity3.Value);
        }

        private void numSlave_ValueChanged(object sender, EventArgs e)
        {
            _module.SlaveNo = Convert.ToInt32(numSlave.Value);
        }

        private void MiniCmpModuleControl_Load(object sender, EventArgs e)
        {
            numSlave.Value = _module.SlaveNo;
        }

        private void btnSetLineCmpParam_Click(object sender, EventArgs e)
        {
            lct_mini.Mini_Cmp_Lib.LineCmp_BingdingEncoder(_prim.DevIndex, _module.SlaveNo, (int)Num_TrgEncoderNo.Value, (int)Num_LineCompareNo.Value);
            lct_mini.Mini_Cmp_Lib.LineCmp_SetTriggerData(_prim.DevIndex, _module.SlaveNo, (int)Num_LineCompareNo.Value,
                (int)Num_LineTrigStartPos.Value, (int)Num_LineTrigEndPos.Value, (int)Num_LineTrigInterval.Value);
        }

        private void btnStartLineCmp_Click(object sender, EventArgs e)
        {
            //lct_mini.Mini_Cmp_Lib.Compare_SetEnable(_prim.DevIndex, _module.SlaveNo, 0, 0);
            //lct_mini.Mini_Cmp_Lib.Compare_SetEnable(_prim.DevIndex, _module.SlaveNo, 1023, 0);
        }

        private void btnStopLineCmp_Click(object sender, EventArgs e)
        {
            //lct_mini.Mini_Cmp_Lib.Compare_SetEnable(_prim.DevIndex, _module.SlaveNo, 0, 0);
        }

        private void btnSetPreCmp_Click(object sender, EventArgs e)
        {
            int[] position = new int[] { (int)pos0.Value,(int) pos1.Value, (int)pos2.Value , (int)pos3.Value ,
                (int)pos4.Value,(int)pos5.Value,(int)pos6.Value,(int)pos7.Value,(int)pos8.Value,
                (int)pos9.Value,(int)pos10.Value,(int)pos11.Value};
            lct_mini.Mini_Cmp_Lib.PreCmp_BindingEncoder(_prim.DevIndex, _module.SlaveNo, (int)Num_TirgEncoderNo2.Value, (int)Num_PreCompareNo.Value);
            lct_mini.Mini_Cmp_Lib.PreCmp_ResetTrigData(_prim.DevIndex, _module.SlaveNo, (int)Num_PreCompareNo.Value);
            lct_mini.Mini_Cmp_Lib.PreCmp_SetTrigData(_prim.DevIndex, _module.SlaveNo, (int)Num_PreCompareNo.Value, position);
            lct_mini.Mini_Cmp_Lib.PreCmp_SetTrigDir(_prim.DevIndex, _module.SlaveNo, (int)Num_PreCompareNo.Value, (int)cmbTrigDir.SelectedIndex);
        }

        private void btnStartPreCmp_Click(object sender, EventArgs e)
        {
            //lct_mini.Mini_Cmp_Lib.PreCmp_SetEnable(_prim.DevIndex, _module.SlaveNo, , 0);
            //lct_mini.Mini_Cmp_Lib.Compare_SetEnable(_prim.DevIndex, _module.SlaveNo, 0, 15);
        }

        private void btnStopPreCmp_Click(object sender, EventArgs e)
        {
            //lct_mini.Mini_Cmp_Lib.Compare_SetEnable(_prim.DevIndex, _module.SlaveNo, 0, 0);
        }

        private void btnManual0_Click(object sender, EventArgs e)
        {
            _prim.SetManualTrig(_miniModuleIndex * 4);
        }

        private void btnManual1_Click(object sender, EventArgs e)
        {
            _prim.SetManualTrig(_miniModuleIndex * 4 + 1);
        }

        private void btnManual2_Click(object sender, EventArgs e)
        {
            _prim.SetManualTrig(_miniModuleIndex * 4 + 2);
        }

        private void btnManual3_Click(object sender, EventArgs e)
        {
            _prim.SetManualTrig(_miniModuleIndex * 4 + 3);
        }
    }
}
