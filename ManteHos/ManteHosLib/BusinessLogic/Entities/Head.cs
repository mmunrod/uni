using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManteHos.Entities
{
    public partial class Head
    {
        public Head() { 
        }

        public Head(string fullnm, string id, string pswd):base(fullnm, id, pswd) //employee attributes
        { 
        //no other attributes or links
        }
        
    }
}
