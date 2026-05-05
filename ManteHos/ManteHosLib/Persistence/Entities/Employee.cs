using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManteHos.Entities
{
    public partial class Employee
    {
        public String FullName { get; set; }

        public String Id { get; set; }

        public String Password { get; set; }

        public static Employee LoggedEmployee { get; set; }

        //link
        public virtual ICollection<Incident>ReportedIncidents { get; set; }
        
    }
}
