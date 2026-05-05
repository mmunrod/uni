using ManteHos.Entities;
using ManteHos.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestExtra
{
    [TestClass]
    public class CloseWorkOrder : BaseTest
    {
        [TestMethod]
        public void getAssignedWorkOrders_Test()
        {
            //Creamos un operator que pueda comprobar que se pueden hacer listas
            Operator op1 = new Operator("Sara Aitikhlef", "head", "try", Shift.Morning);
            Employee.LoggedEmployee = op1;

            Employee e1 = new Employee("JJ", "empleado", "porfa que funcione");

            //Creamos incidentes y sus workorders 
            //Constructor de incidentes public Incident(String dp, String ds, DateTime dt, Employee rp)
            Incident i1 = new Incident("Quirofano", "Lampara rota", DateTime.Now, e1);
            i1.Status = Status.Accepted;
            WorkOrder w1 = new WorkOrder(DateTime.Now, i1);
            w1.AddOperatorToWorkOrder(op1);

            Incident i2 = new Incident("Urgencias", "Se ha roto una puerta", DateTime.Now, e1);
            i2.Status = Status.Accepted;
            WorkOrder w2 = new WorkOrder(DateTime.Now, i2);
            w2.AddOperatorToWorkOrder(op1);

            Incident i3 = new Incident("Pediatria", "No funcionan bien los ordenadores", DateTime.Now, e1);
            i3.Status = Status.Accepted;    
            WorkOrder w3 = new WorkOrder(DateTime.Now, i3);

            //Ahora incidentes que no van a salir en la lista
            Incident i4 = new Incident("Medicina", "Hemos perdido las llaves", DateTime.Now, e1);
            i4.Status = Status.InProgress;
            WorkOrder w4 = new WorkOrder(DateTime.Now, i4);

            Incident i6 = new Incident("Administracion", "Pintar las paredes", DateTime.Now, e1);
            i6.Status = Status.InProgress;
            WorkOrder w6 = new WorkOrder(DateTime.Now, i6);
            w6.AddOperatorToWorkOrder(op1);

            Incident i7 = new Incident("General", "Se ha ido la luz en todo el hospital", DateTime.Now, e1);
            i7.Status = Status.Completed;
            WorkOrder w7 = new WorkOrder(DateTime.Now, i7);

            //Este no tiene que estar dentro porque está completado
            Incident i8 = new Incident("Limpieza", "Una estanteria se ha roto", DateTime.Now, e1);
            i8.Status = Status.Completed;
            WorkOrder w8 = new WorkOrder(DateTime.Now, i8);
            w8.AddOperatorToWorkOrder(op1);

            dal.Insert(op1);
            dal.Insert(e1);
            dal.Insert(i1);
            dal.Insert(i2);
            dal.Insert(i3);
            dal.Insert(i4);
            dal.Insert(i6);
            dal.Insert(i7);
            dal.Insert(i8);
            dal.Insert(w1);
            dal.Insert(w2);
            dal.Insert(w3);
            dal.Insert(w4);
            dal.Insert(w6);
            dal.Insert(w7);
            dal.Insert(w8);
            dal.Commit();

            //Como en los forms creamos una llamada a mantehos 

            ManteHosService mantehos = new ManteHosService(dal);
            var aux = mantehos.GetAssignedWorkOrder();

            //Apartir de aqui empieza el código de la prueba

            //Comprobar que la lista no es nula
            //primer parametro la lista, dos lo que dirá la excepción 
            Assert.IsNotNull(aux, "La lista de assigned work orders no debería ser nula");

            //Comprobar que han entrado los tres incidentes marcados como creados
            //primer parametro el número de elementos, segundo los que calcula el método, tres el mensaje de error
            Assert.AreEqual(3, aux.Count, "La lista debería contener solo los incidentes que no esten completados y esten asignados al operador ");

            //Comprobar que los tres incidentes creados están en la lista
            Assert.IsTrue(aux.Contains(w1), "La lista debería contener el work order w1");
            Assert.IsTrue(aux.Contains(w2), "La lista debería contener el work order w2");
            Assert.IsFalse(aux.Contains(w3), "La lista no debería contener el work order w3");
            Assert.IsFalse(aux.Contains(w4), "La lista no debería contener el work order w4");
            Assert.IsTrue(aux.Contains(w6), "La lista debería contener el work order w6");
            Assert.IsFalse(aux.Contains(w7), "La lista no debería contener el work order w7");
            Assert.IsFalse(aux.Contains(w8), "La lista no debería contener el work order w8");
            
        }
    }
}
