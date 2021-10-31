using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDashboard.BL.Helper
{
    public class Respons
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Msg { get; set; }

        public Respons(string code, string status, string msg)
        {
            Code = code;
            Status = status;
            Msg = msg;
        }
    }
}
