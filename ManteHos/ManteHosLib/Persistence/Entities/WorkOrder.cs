    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        //attributes
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public String RepairReport { get; set; }
        public virtual ICollection<Operator> Operators { get; set; }

        //para facilitar la interfaz
        public static WorkOrder UsedWorder {  get; set; }
        //linked classes
        [Required]
        public virtual Incident Incident { get; set; }
        public virtual ICollection<UsedPart> UsedParts { get; set; }
    }
}
