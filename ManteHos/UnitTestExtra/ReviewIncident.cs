using ManteHos.Entities;
using ManteHos.Persistence;
using ManteHos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestExtra
{
    [TestClass]
    public class ReviewIncident : BaseTest
    {
        //Probar que getIncidentList devuelve solo los incidentes creados
        [TestMethod]
        public void getAcceptedIncidents_Test()
        {
            //Creamos un head que pueda comprobar que se pueden hacer listas
            Head h1 = new Head("Ana Maria Becerra","head", "try");
            Employee.LoggedEmployee = h1;

            Employee e1 = new Employee("JJ", "empleado", "porfa que funcione");

            //Creamos incidentes 
            //Constructor de incidentes public Incident(String dp, String ds, DateTime dt, Employee rp)
            Incident i1 = new Incident("Quirofano", "Lampara rota", DateTime.Now, e1);
            i1.Status = Status.Created;

            Incident i2 = new Incident("Urgencias", "Se ha roto una puerta", DateTime.Now, e1);
            i2.Status = Status.Created; 

            Incident i3 = new Incident("Pediatria", "No funcionan bien los ordenadores", DateTime.Now, e1);
            i3.Status = Status.Created; 

            //Ahora incidentes que no van a salir en la lista
            Incident i4 = new Incident("Medicina", "Hemos perdido las llaves", DateTime.Now, e1);
            i4.Status = Status.Rejected;

            Incident i5 = new Incident("Oftalmología", "El aire acondicionado no funciona", DateTime.Now, e1);
            i5.Status = Status.Accepted;

            Incident i6 = new Incident("Administracion","Pintar las paredes", DateTime.Now, e1);
            i6.Status = Status.InProgress;

            Incident i7 = new Incident("General","Se ha ido la luz en todo el hospital", DateTime.Now, e1);
            i7.Status = Status.Completed;

            dal.Insert(h1);
            dal.Insert(e1);
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
            var aux = mantehos.getIncidentList();

            //Apartir de aqui empieza el código de la prueba

            //Comprobar que la lista no es nula
            //primer parametro la lista, dos lo que dirá la excepción 
            Assert.IsNotNull(aux, "La lista de incidentes no debería ser nula");

            //Comprobar que han entrado los tres incidentes marcados como creados
            //primer parametro el número de elementos, segundo los que calcula el método, tres el mensaje de error
            Assert.AreEqual(3, aux.Count, "La lista debería contener solo los incidentes con estado 'Created'");

            //Comprobar que los tres incidentes creados están en la lista
            Assert.IsTrue(aux.Contains(i1), "La lista debería contener el incidente i1");
            Assert.IsTrue(aux.Contains(i2), "La lista debería contener el incidente i2");
            Assert.IsTrue(aux.Contains(i3), "La lista debería contener el incidente i3");

            Assert.IsFalse(aux.Contains(i4), "La lista no debería contener el incidente i4");
            Assert.IsFalse(aux.Contains(i5), "La lista no debería contener el incidente i5");
            Assert.IsFalse(aux.Contains(i6), "La lista no debería contener el incidente i6");
            Assert.IsFalse(aux.Contains(i7), "La lista no debería contener el incidente i7");

            //Solo por si acaso, compruebo que el primer estado es created 
            Assert.AreEqual(Status.Created, aux.First().Status, "El estado del primer incidente en la lista debería ser 'Created'");
        }

        [TestMethod]
        public void AcceptIncident_Test()
        {
            //Crear un head para aceptar el incidente
            Head h1 = new Head("Ana Maria Becerra", "head", "try");
            Employee.LoggedEmployee = h1;

            Master m1 = new Master("JJ", "empleado", "porfa que funcione");
            //Crear un incidente
            Incident i1 = new Incident("Quirofano", "Lampara rota", DateTime.Now, h1);
            i1.Status = Status.Created;
            Area area = new Area("Mantenimiento General", m1);

            dal.Insert(h1);
            dal.Insert(m1);
            dal.Insert(i1);
            dal.Insert(area);
            dal.Commit();
            //Llamar al servicio para aceptar el incidente
            ManteHosService mantehos = new ManteHosService(dal);
            mantehos.AcceptIncident(i1,area, Priority.Medium);

            //Recuperar el incidente de la base de datos para comprobar su estado
            Incident i = dal.GetAll<Incident>().FirstOrDefault(inc => inc.Id == i1.Id);
            //Comprobar que el estado del incidente es Accepted
            Assert.IsNotNull(i, "El incidente debería existir en la base de datos");
            Assert.AreEqual(Status.Accepted, i.Status, "El estado del incidente debería ser 'Accepted' después de aceptarlo");
        }

        [TestMethod]
        public void RejectIncident_Test()
        {
            //Crear un head para rechazar el incidente
            Head h1 = new Head("Ana Maria Becerra", "head", "try");
            Employee.LoggedEmployee = h1;
            //Crear un incidente
            Incident i1 = new Incident("Quirofano", "Lampara rota", DateTime.Now, h1);
            i1.Status = Status.Created;

            String rejectionReason = "El problema no es urgente";
            dal.Insert(h1);
            dal.Insert(i1);
            dal.Commit();
            //Llamar al servicio para rechazar el incidente
            ManteHosService mantehos = new ManteHosService(dal);
            mantehos.RejectIncident(i1,rejectionReason);
            //Recuperar el incidente de la base de datos para comprobar su estado
            Incident i = dal.GetAll<Incident>().FirstOrDefault(inc => inc.Id == i1.Id);
            //Comprobar que el estado del incidente es Rejected
            Assert.IsNotNull(i, "El incidente debería existir en la base de datos");
            Assert.AreEqual(Status.Rejected, i.Status, "El estado del incidente debería ser 'Rejected' después de rechazarlo");
        }

        [TestMethod]
        public void getPriorities_Test()
        {
            //Llamar al servicio para obtener las prioridades
            ManteHosService mantehos = new ManteHosService(dal);
            var priorities = mantehos.getPriorityList();
            //Comprobar que la lista no es nula
            Assert.IsNotNull(priorities, "La lista de prioridades no debería ser nula");
            //Comprobar que la lista contiene las prioridades correctas
            Assert.AreEqual(3, priorities.Count, "La lista debería contener tres prioridades");
            Assert.IsTrue(priorities.Contains(Priority.Low), "La lista debería contener la prioridad 'Low'");
            Assert.IsTrue(priorities.Contains(Priority.Medium), "La lista debería contener la prioridad 'Medium'");
            Assert.IsTrue(priorities.Contains(Priority.High), "La lista debería contener la prioridad 'High'");
        }
    }
}
