using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;

namespace SCADA_APP
{
    public class PLC
    {
        Plc _plc = new Plc(CpuType.S71200, "192.168.0.24", 0, 0);
        public bool PLC_connected = false;
        protected PLC()
        {

        }
        private static PLC _intance;
        public static PLC Instance()
        {
            if (_intance == null)
            {
                _intance = new PLC();
            }
            return _intance;
        }
        public bool Open()
        {
            if (_plc.Open() == ErrorCode.NoError)
            {
                PLC_connected = true;
                return true;
            }
            else
            {
                PLC_connected = false;
                return false;
            }
        }
        public void Close()
        {
            PLC_connected = false;
            _plc.Close();
        }
        public void SetBit(string Address)
        {
            if (PLC_connected)
            {
                _plc.Write(Address, 1);
            }
        }
        
        public void ResetBit(string Address)
        {
            if (PLC_connected)
            {
                _plc.Write(Address, 0);
            }
        }
        public void ReadClass(object cl, int DB)
        {
            if (PLC_connected)
            {
                _plc.ReadClass(cl, DB);
            }
        }
        public void WriteClass(object cl, int DB)
        {
            if (PLC_connected)
            {
                _plc.WriteClass(cl, DB);
            }
        }
        public void ReadData(string Address)
        {
            if (PLC_connected)
            {
                _plc.Read(Address).ToString();
            }
        }
    }
}
