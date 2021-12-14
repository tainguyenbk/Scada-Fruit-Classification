using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_APP
{
    public class PLCRead
    {
        protected PLCRead()
        {

        }
        private static PLCRead _instance;
        public static PLCRead Instance()
        {
            if (_instance == null)
            {
                _instance = new PLCRead();
            }
            return _instance;
        }
        public bool Light_Start { get; set; }
        public bool Light_Alarm { get; set; }
        public bool Process { get; set; }
        public bool Conveyor { get; set; }
        public short Quanity_Red { get; set; }
        public short Quanity_Orange { get; set; }
        public short Quanity_Green { get; set; }
        public short Quanity_Error { get; set; }
        public short Quanity_Total { get; set; }
        public short Quanity_Box1 { get; set; }
        public short Quanity_Box2 { get; set; }
        public short Quanity_Box3 { get; set; }
        public short Quanity_Box4 { get; set; }
        public short Quanity_Box_Total { get; set; }
        public short Quanity_Type1 { get; set; }
        public short Quanity_Type2 { get; set; }
        public short Quanity_Type3 { get; set; }
        public short Quanity_Type4 { get; set; }
        public short Quanity_Type_Total { get; set; }

    }
}
