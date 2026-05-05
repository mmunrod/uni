using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManteHos.Entities
{
    public partial class UsedPart
    {
        //Constructors of the class

        public int Id { get; set; }
        
        public int Quantity { get; set; }
        
        public Boolean Needed { get; set; }

        //linked classes
        
        [Required]
        public virtual Part Part { get; set; }
        //public virtual WorkOrder WorkOrder { get; set; }
    }
}
