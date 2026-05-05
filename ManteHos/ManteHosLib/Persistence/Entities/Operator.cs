using ManteHos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManteHos.Entities
{
    public partial class Operator : Employee
    {
       
        public Shift Shift { get; set; }

        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
