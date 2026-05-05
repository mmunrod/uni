using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Operator : Employee
    {

        public Operator() {
        WorkOrders = new List<WorkOrder>();
        }

        public Operator(string fullnm, string id, string pswd, Shift sh) : base(fullnm, id, pswd) 
        //employee attributes
        {
            //parameter set by default
            this.Shift = sh;
            //collection
            WorkOrders = new List<WorkOrder>();
        }
    }
}
