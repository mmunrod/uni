using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class UsedPart
    {
    //empty constructor
        public UsedPart() { }
    //constructor
        public UsedPart(int q, Part p) { 
            this.Quantity = q;
            this.Part = p;
            if (p.MinimunQuantity < p.CurrentQuantity - q) {
                Needed = false;
                p.CurrentQuantity -= q;
            }
            else { Needed = true; 

           
            }
        }

        
     }
}
