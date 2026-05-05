using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            ReportedIncidents = new List<Incident>();
        }

        public Employee(String fullnm, String id, String pswd)
        {
            this.FullName = fullnm;
            this.Id = id;
            this.Password = pswd;

            //collection
            ReportedIncidents = new List<Incident>();

        }

    }
}