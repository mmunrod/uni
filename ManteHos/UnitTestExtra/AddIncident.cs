using ManteHos.Services;
using ManteHos.Entities;
using ManteHos.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestExtra
{
    [TestClass]
    public class AddIncident : BaseTest
    {
        [TestMethod]
        public void AddIncident_Test()
        {
            ManteHosService mantehos = new ManteHosService(dal);
            String nombre = "Maria Zakutyan";
            String id = "e1";
            String password = "va funciona";
            Employee e1 = new Employee(nombre,id, password);

            dal.Insert<Employee>(e1);
            dal.Commit();

            String dp = "Informatica";
            String ds = "El UnitTest no funciona";
            DateTime dt = DateTime.Now;

            //Añadimos el incidente a la base de datos através del método que estamos probando
            mantehos.addIncident(dp, ds, dt, e1);
            Incident i = dal.GetWhere<Incident>(o =>
                            o.Department == dp &&
                            o.Description == ds &&
                            o.Reporter.Id == e1.Id).FirstOrDefault();

            //Comprobamos que el incidente se ha añadido
            Assert. IsNotNull(i, "El incidente no se ha añadido a la base de datos");

            //Comprobamos que se haya añadido bien 
            Assert.AreEqual(dp, i.Department, "El departamento no coincide");
            Assert.AreEqual(ds, i.Description, "La descripción no coincide");
            Assert.AreEqual(e1.Id, i.Reporter.Id, "El nombre del empleado no coincide");
            Assert.AreEqual(dt, i.ReportDate, "La fecha no coincide");
        }
    }
}
