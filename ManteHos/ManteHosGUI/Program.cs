using ManteHos.Persistence;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //del chapter 7 
            IManteHosService manteHosService = new ManteHosService(new EntityFrameworkDAL(new ManteHosDbContext()));

            //declaramos las aplicaciones
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManteHosApp(manteHosService));
        }
    }
}
