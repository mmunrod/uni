using ManteHos.Entities;
using ManteHos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestExtra
{
    [TestClass]
    public class AssignWorkOrder: BaseTest
    {
        [TestMethod]
        public void getAcceptedIncidents_Test()
        {
            //Creamos un master que pueda comprobar que se pueden hacer listas
            Master m1 = new Master("Sara Aitikhlef", "head", "try");
            Employee.LoggedEmployee = m1;

            Employee e1 = new Employee("JJ", "empleado", "porfa que funcione");

            //Creamos areas todas le pertenecen al master
            Area area1 = new Area("Mantenimiento", m1);

            // Insertar en BD
            dal.Insert(m1);
            dal.Insert(e1);
            dal.Insert(area1);

            //Creamos incidentes 
            //Constructor de incidentes public Incident(String dp, String ds, DateTime dt, Employee rp)
            Incident i1 = new Incident("Quirofano", "Lampara rota", DateTime.Now, e1);
            i1.Status = Status.Accepted;
            i1.Area = area1;

            Incident i2 = new Incident("Urgencias", "Se ha roto una puerta", DateTime.Now, e1);
            i2.Status = Status.Accepted;
            i2.Area = area1;

            Incident i3 = new Incident("Pediatria", "No funcionan bien los ordenadores", DateTime.Now, e1);
            i3.Status = Status.Accepted;

            //Ahora incidentes que no van a salir en la lista
            Incident i4 = new Incident("Medicina", "Hemos perdido las llaves", DateTime.Now, e1);
            i4.Status = Status.Rejected;
            
            Incident i5 = new Incident("Oftalmología", "El aire acondicionado no funciona", DateTime.Now, e1);
            i5.Status = Status.Created;

            Incident i6 = new Incident("Administracion", "Pintar las paredes", DateTime.Now, e1);
            i6.Status = Status.InProgress;
            i6.Area = area1;

            Incident i7 = new Incident("General", "Se ha ido la luz en todo el hospital", DateTime.Now, e1);
            i7.Status = Status.Completed;
            i7.Area = area1;

            dal.Insert(i1);
            dal.Insert(i2);
            dal.Insert(i3);
            dal.Insert(i4);
            dal.Insert(i5);
            dal.Insert(i6);
            dal.Insert(i7);
            dal.Commit();

            //Como en los forms creamos una llamada a mantehos 

            ManteHosService mantehos = new ManteHosService(dal);
            var aux = mantehos.GetAcceptedIncidents();

            //Apartir de aqui empieza el código de la prueba

            //Comprobar que la lista no es nula
            //primer parametro la lista, dos lo que dirá la excepción 
            Assert.IsNotNull(aux, "La lista de incidentes no debería ser nula");

            //Comprobar que han entrado los tres incidentes marcados como creados
            //primer parametro el número de elementos, segundo los que calcula el método, tres el mensaje de error
            Assert.AreEqual(2, aux.Count, "La lista debería contener solo los incidentes con estado 'Accepted'");

            //Comprobar que los tres incidentes creados están en la lista
            Assert.IsTrue(aux.Contains(i1), "La lista debería contener el incidente i1");
            Assert.IsTrue(aux.Contains(i2), "La lista debería contener el incidente i2");
            Assert.IsFalse(aux.Contains(i3), "La lista no debería contener el incidente i3");
            Assert.IsFalse(aux.Contains(i4), "La lista no debería contener el incidente i4");
            Assert.IsFalse(aux.Contains(i5), "La lista no debería contener el incidente i5");
            Assert.IsFalse(aux.Contains(i6), "La lista no debería contener el incidente i6");
            Assert.IsFalse(aux.Contains(i7), "La lista no debería contener el incidente i7");

        }
    }
}
