using AstoreLibrary.DataLayer.Master;
using AstoreLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoreLibrary.BusinessLayer.Master
{
    public class AccountGroupBL
    {
        AccountGroupDL dll = new AccountGroupDL();
        public ResultType GetAcGroupList()
        {
            return dll.GetAcGroupList();
        }
    }
}
