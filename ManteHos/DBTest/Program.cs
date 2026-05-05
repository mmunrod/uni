using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Program();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        Program()
        {
            IDAL dal = new EntityFrameworkDAL(new ManteHosDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal)
        {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE PERSONAS");
            //public Course(string descr, string name)

            //one head 
            Head h1 = new Head("Head1", "h2", "h2");
            dal.Insert<Head>(h1);
            //dal.Commit();

            //two masters
            Master master1 = new Master("MarterClass", "m1", "m1");
            dal.Insert<Master>(master1);
            //dal.Commit();

            Master master2 = new Master("MasterHall", "m2", "m2");
            dal.Insert<Master>(master2);
            //dal.Commit();


            //two areas

            Area a1 = new Area("Class", master1);
            dal.Insert<Area>(a1);
            //dal.Commit();

            Area a2 = new Area("Hall", master2);
            dal.Insert<Area>(a2);
            //dal.Commit();

            //one operator
            Operator op1 = new Operator("Operator1", "o1", "o1", Shift.Morning);
            dal.Insert<Operator>(op1);
            //dal.Commit();

            //one employee
            Employee e1 = new Employee("Employee1", "e3", "e3");
            dal.Insert<Employee>(e1);
            //dal.Commit();

            //part1
            Part p1 = new Part("Screw", 5, "Phillips Head", 3, "mm", 1);
            dal.Insert<Part>(p1);
            //dal.Commit();

            //part2
            Part p2 = new Part("Tape", 10, "Duct Tape", 4, "m", 1);
            dal.Insert<Part>(p2);
            //dal.Commit();

            //first incident
            DateTime date = new DateTime(2025,10,23);
            Incident i1 = new Incident("Software", "DataBaseDown", date, e1);
            i1.Area = a1; 
            dal.Insert<Incident>(i1);
            //dal.Commit();

            //one workorder
            WorkOrder o1 = new WorkOrder(date, i1); 
            dal.Insert<WorkOrder>(o1);

            //second incident
            Incident i2 = new Incident("Hardware", "ElectricityOut", date, e1);
            i2.Area = a1;
            i2.WorkOrder = o1;
            dal.Insert<Incident>(i2);
            //dal.Commit();

            //usedPart
            UsedPart up1 = new UsedPart(3, p1);
            o1.UsedParts.Add(up1);
            dal.Insert<UsedPart>(up1);

            UsedPart up2 = new UsedPart(2, p2);
            o1.UsedParts.Add(up2);
            dal.Insert<UsedPart>(up2);

            dal.Commit();

        }

        // Copiar a partir de aquí
        private void PrintSampleDB(IDAL dal)
        {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nPersonas creadas:");
            foreach (Employee p in dal.GetAll<Employee>())
                Console.WriteLine("   FullName: " + p.FullName + " Id: " + p.Id + " Password: " + p.Password);

            // Show the rest of the database
            Console.WriteLine("\nPiezas creadas:");
            foreach (Part p in dal.GetAll<Part>())
                Console.WriteLine("   Code: " + p.Code + " Description: " + p.Description + " CurrentQuantity: " + p.CurrentQuantity);

            Console.WriteLine("\nAreas, Incidencias,Órdenes de trabajo y piezas pedidas creadas:");
            foreach (Area a in dal.GetAll<Area>())
            {
                Console.WriteLine("   Name: " + a.Name);
                foreach (Incident i in a.Incidents)
                {
                    Console.WriteLine("      Incident Id: " + i.Id + " ReportDate: " + i.ReportDate + " Description: " + i.Description);
                    WorkOrder o = i.WorkOrder;
                    if (o != null)
                    {
                        Console.WriteLine("          WorkOrder Id: " + o.Id + " StartDate: " + o.StartDate);
               
                        foreach (UsedPart up in o.UsedParts)
                        {
                            Console.WriteLine("             Part Description: " + up.Part.Description + " Quantity: " + up.Quantity);
                        }
                    }
                }
            }


        }

    }

}
