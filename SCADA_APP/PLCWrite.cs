using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_APP
{
    public class PLCWrite
    {
        private static PLCWrite _instance;
        public static PLCWrite Instance()
        {
            if (_instance == null)
            {
                _instance = new PLCWrite();
            }
            return _instance;
        }

        public short Quanity_Type1 { get; set; }
        public short Quanity_Type2 { get; set; }
        public short Quanity_Type3 { get; set; }
        public short Quanity_Type4 { get; set; }


    }
    public static class PLCSetStatic
    {
        public static short Quanity_Type1 { get; set; }
        public static short Quanity_Type2 { get; set; }
        public static short Quanity_Type3 { get; set; }
        public static short Quanity_Type4 { get; set; }
    }
}
