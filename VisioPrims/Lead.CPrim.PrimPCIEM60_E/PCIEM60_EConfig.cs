using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lead.CPrim.Interfaces;

namespace Lead.CPrim.PrimPCIEM60_E
{
    public class PCIEM60_EConfig
    {
        #region Override IMotionCard's property
        public string ConfigFilePath { get; set; }

        public int DevIndex { get; set; }

        public string IOInfosFilePath { get; set; }

        public string EBusConfigFilePath { get; set; }
        #endregion



        #region Override IPrim
        public Guid Id { set; get; }
        public string Name { set; get; }
        public bool PrimEnable { set; get; }
        public string PrimTypeName { set; get; }
        public int CurrentImageIndex { get; set; }
        #endregion
    }
}
