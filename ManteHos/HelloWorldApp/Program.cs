using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldApp
{
    internal class Program
    {
        static List<string> nationalities;
        static void initList()
        {
            nationalities = new List<string>()
        {
        "Australia",
        "Mongolian",
        "Russian",
        "Austrian",
        "Brazilian"
        };
        }
        static void Main(string[] args)
        {
            initList();
            nationalities.Sort();
            foreach (string nationality in nationalities)
            {
                Console.WriteLine(nationality);

            
            }
        }
    }
}
