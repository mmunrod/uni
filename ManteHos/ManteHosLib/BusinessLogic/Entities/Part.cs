using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Part
    {
        public Part(){
            UsedParts = new List<UsedPart>();
        }
        public Part(String c,int cq, String d, int mq, String um,float up):this()
        {
            this.Code = c;
            this.CurrentQuantity = cq;  
            this.Description = d;
            this.MinimunQuantity = mq;
            this.UnitPrice = up;
            this.UnitOfMeasure = um;


        }
    }
}
