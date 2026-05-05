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
    public partial class Incident
    {
        //constructors of the class
        public float CostOfUsedParts { get; set; }

        
        public String Department { get; set; }

        public String Description { get; set; }

        public int Id { get; set; }

        public Priority Priority { get; set; }

        public String RejectionReason { get; set; }

        public DateTime ReportDate { get; set; }

        public Status Status { get; set; }

        //idea para interfaz
        public static Incident UsedIncident {get; set;}
        //linked classes
        public virtual Area Area { get; set; }

        [Required] 
        public virtual Employee Reporter { get; set; }

        public virtual WorkOrder WorkOrder { get; set; }
      

    }
}
