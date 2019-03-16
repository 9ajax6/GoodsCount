using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoreLibrary.Models.Master
{
    public class AccountGroup
    {
        public string Ac_GrpCode { get; set; }
        public string Ac_Desc { get; set; }
        public string Ac_Type { get; set; }
        public string BP_Type { get; set; }
        public string Source_Module { get; set; }
        public string MainGroup { get; set; }
        public string Action_Date { get; set; }
        public DateTime Action_Time { get; set; }
        public DateTime Action_Miti { get; set; }
        public string Action { get; set; }
        public string Ac_Schedul { get; set; }
    }
}
