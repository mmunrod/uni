using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Area
    {
        public Area() //empty
        {
            //collection
            Incidents = new List<Incident>();
        
        }  

        public Area(String name, Master master) :this(){
         //EF handles the int Id attribute
        this.Name = name;

        //becasuse cardinality 1
        this.Master = master;

         //collection
         //Incidents = new List<Incident>();
        }
    }
}
