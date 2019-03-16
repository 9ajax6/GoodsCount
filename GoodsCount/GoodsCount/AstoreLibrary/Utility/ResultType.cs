using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstoreLibrary.Utility
{
    public class ResultType
    {
        public string Message { get; set;} 
        //1 for alert message and 0 for normal message
        public bool AlertType { get; set;}
        public object Data { get; set; } 
    }
}
