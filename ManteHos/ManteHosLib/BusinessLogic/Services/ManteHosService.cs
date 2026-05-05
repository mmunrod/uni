using ManteHos.Entities;
using ManteHos.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ManteHos.Services
{
    public class ManteHosService : IManteHosService
    {
        private readonly IDAL dal;
        

        public ManteHosService(IDAL dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Borra todos los datos de la BD
        /// </summary>
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        /// <summary>
        /// Salva todos los cambios que haya habido en el contexto de la aplicación desde la última vez que se hizo Commit
        /// </summary>
        public void Commit()
        {
            dal.Commit();
        }

        /// <summary>
        /// Inicializa los datos para que haya ciertos datos para poder usarlos luego
        /// </summary>
        public void DBInitialization()
        {
            RemoveAllData();

            // Dar de alta ciertos datos relevantes para el sistema
            Head head = new Head("Ibañez", "h1", "h1");
            AddPerson(head);
            Master tfmotu = new Master("Bárcenas", "m1", "m1");
            AddPerson(tfmotu);
            Master master2 = new Master("He-Man", "m2", "m2");
            AddPerson(master2);
            Master master3 = new Master("Picasso", "m3", "m3");
            AddPerson(master3);
            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            AddPerson(op1);
            Operator op2 = new Operator("Otilio", "o2", "o2", Shift.Morning);
            AddPerson(op2);
            Operator op3 = new Operator("Rompetechos", "o3", "o3", Shift.Night);
            AddPerson(op3);

            Employee empleado1 = new Employee("Sacarino", "e1", "e1");
            AddPerson(empleado1);
            Employee empleado2 = new Employee("Pepe García", "e2", "e2");
            AddPerson(empleado2);

            Area a1 = new Area("Mecánica", tfmotu);
            AddArea(a1);
            Area a2 = new Area("Electricidad", master2);
            AddArea(a2);
            Area a3 = new Area("Pintura", master3);
            AddArea(a3);

            Part p1 = new Part("Esc50", 5, "Placa de escayola para techo", 1, "Placa de 50x30cms", 5);
            AddPart(p1);
            Part p2 = new Part("TM8", 3000, "Tornillo métrica 8", 100, "Tornillo", 0.01F);
            AddPart(p2);
            Part p3 = new Part("ClimaEst", 4, "Cristal Climalit de ventana estándar", 0, "Cristal 75x100cms", 200);
            AddPart(p3);

            // este va a tener Needed a true
            UsedPart up1= new UsedPart(10, p1);
            dal.Insert<UsedPart>(up1);
            UsedPart up4 = new UsedPart(2950, p2);
            dal.Insert<UsedPart>(up4);
            // este va a tener Needed a false
            UsedPart up2 = new UsedPart(1, p1);
            dal.Insert<UsedPart>(up2);
            UsedPart up3 = new UsedPart(2, p3);
            dal.Insert<UsedPart>(up3);
            dal.Commit();

            Incident i1 = new Incident("Mecanica", "NeededW", DateTime.Now, op1);
            i1.Status = Status.Accepted;
            i1.Area = a1;
            i1.Priority = Priority.Low;

            dal.Insert<Incident>(i1);
            dal.Commit();

            Incident i2 = new Incident("Mecanica", "notNeeded", DateTime.Now, op1);
            i2.Status = Status.Accepted;
            i2.Area = a1;
            i2.Priority = Priority.Low;
            dal.Insert<Incident>(i2);
            dal.Commit();
            

            WorkOrder worderNeeded = new WorkOrder(DateTime.Now, i1);
            worderNeeded.UsedParts.Add(up1);
            worderNeeded.UsedParts.Add(up4);
            worderNeeded.UsedParts.Add(up2);
            worderNeeded.Operators.Add(op1);
            worderNeeded.Operators.Add(op2);
            dal.Insert<WorkOrder>(worderNeeded);
            dal.Commit();

            WorkOrder worderNotNeeded = new WorkOrder(DateTime.Now, i2);
            worderNotNeeded.UsedParts.Add(up3);
            worderNotNeeded.UsedParts.Add(up2);
            worderNotNeeded.Operators.Add(op1);
            dal.Insert<WorkOrder>(worderNotNeeded);
            dal.Commit();

            // Añadir un incident que tenga su work order y que ese work order tenga usedparts
            // Podéis añadir un Workorder que tenga algun Usepart con Needed=true para que no se pueda cerrar
            // y añadir otro workorder en otro incident que tenga todas las useparts a Nedded=false



        }

        public void AddPerson(Employee person)
        {
            // Restricción: No puede haber dos personas con el mismo Id
            if (dal.GetById<Employee>(person.Id) == null)
            {
                dal.Insert<Employee>(person);
                dal.Commit();
            }
            else throw new ServiceException("Person with Id " + person.Id + " already exists.");
        }

        public void AddArea(Area area)
        {
            // Restricción: No puede haber dos áreas con el mismo Nombre
            if (!dal.GetWhere<Area>(x => x.Name == area.Name).Any())
            {
                dal.Insert<Area>(area);
                dal.Commit();
            }
            else throw new ServiceException("Area with Name " + area.Name + " already exists.");
        }

        public void AddPart(Part part)
        {
            // Restricción: No puede haber dos piezas con la misma descripción
            if (!dal.GetWhere<Part>(x => x.Description == part.Description).Any())
            {
                dal.Insert<Part>(part);
                dal.Commit();
            }
            else throw new ServiceException("Part with Description " + part.Description + " already exists.");
        }

        //
        // Resto de metodos necesarios para el servicio
        //

        #region LOGIN

        //an employee starts a new session to have access to the that is available for his role
        //se pueden hacer variable boolean para saber si es master, head o operator y poder hacer display de cada cosa que hace cada role

        public void Login(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ServiceException("Username and password are required");
            }
            //caso en el que si que haya escrito algo, buscas al empleado por su id
            Employee emp = dal.GetById<Employee>(username);

            //han escrito pero usuario no existe
            if (emp == null) throw new ServiceException("User does not exist");

            //han escrito pero la contraseña no es la correcta
            if (emp.Password != password) throw new ServiceException("Password not valid");

            //el usuario existe y su contraseña está bien entonces se guarda
            Employee.LoggedEmployee = emp;
        }
        #endregion

        #region LOGOUT
        public void Logout()
        {
            if (Employee.LoggedEmployee == null)
                throw new ServiceException("No user is logged in");
            else Employee.LoggedEmployee = null;
        }

        #endregion 

        #region ADD INCIDENT
        //--------------------------------CASE 3----------------------------------------------------
        private Incident incident;
        public void addIncident(String dp, String ds, DateTime? dt, Employee rp)
        {
            if (dt == null) incident = new Incident(dp, ds, DateTime.Now, rp);
            else incident = new Incident(dp, ds, (DateTime)dt, rp);

            //creamos una lista donde nos devuelva incidentes que coincidan tal cual 
            var list = dal.GetWhere<Incident>(i =>
            i.Department == dp &&
            i.Description == ds &&
            i.Reporter.Id == rp.Id
            );

            //en caso que exista algo dentro de esa lista no se puede crear
            bool exists = (list ?? Enumerable.Empty<Incident>()).Any();

            if (!exists)
            {
                dal.Insert<Incident>(incident);
                dal.Commit();
            }
            else throw new ServiceException("Incident already exists.");
        }
        #endregion

        #region REVIEW INCIDENT

        public IList<Incident> getIncidentList()
        {
            //if false is not a head or it is not logged in 
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Head )
            {
                //we list the incidents which stated is create
                return dal.GetWhere<Incident>(i => i.Status == Status.Created).ToList();
            }
            return null;
            //saltara la excepcion en la clase head y por eso aqui se devulve nulo 
        }

        public void AcceptIncident(Incident incidents, Area area, Priority priority)
        {
            
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Head)
            {
                //choose the incident to accept 
                //method accept in the incident class
                incidents.Accept(area, priority);
                dal.Commit();
            }

        }

        public void RejectIncident(Incident inci, string reason)
        {
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Head )
            {

                //comprobations of the incident 
                if (inci == null)
                {
                    throw new ServiceException("There's no incident to be rejected");
                }

                inci.Reject(reason);
                dal.Commit();
            }

        }

        //Metodo devolver areas y prioridades para accept or reject
        public IList<Area> getAreaList()
        {
            //if false is not a head or it is not logged in 
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Head )
            {
                //we list the incidents which stated is create
                return dal.GetAll<Area>().ToList();
            }
            return null;
            //saltara la excepcion en la clase head y por eso aqui se devulve nulo 
        }
        public IList<Priority> getPriorityList()
        {
            //if false is not a head or it is not logged in 
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Head )
            {
                //we list the incidents which stated is create
                return Enum.GetValues(typeof(Priority)).Cast<Priority>().ToList();
            }
            return null;
            //saltara la excepcion en la clase head y por eso aqui se devulve nulo 
        }
        #endregion

        #region ASSIGN WORK ORDER
        //-------------------------------CASE5----------------------------------

        //de los incidetes pillas los aceptados
        public ICollection<Incident> GetAcceptedIncidents()
        {
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Master m)
                return dal.GetWhere<Incident>(i => (i.Status == Status.Accepted) && (i.Area.Master.Id == m.Id)).ToList();

            return new List<Incident>();
        }

        public IList<Operator> getAssignedOperators()
        {
            //Entramos al parameter del incident sobre el que estamos trabajando
            return Incident.UsedIncident.WorkOrder.Operators.ToList();
        }
        public IList<Operator> getAllOperators()
        {
            var assigned = getAssignedOperators();
            if (!assigned.Any()) {
                return dal.GetAll<Operator>().ToList();
            }
            var shift = assigned.First().Shift;
            var operatorsSameShift = dal.GetWhere<Operator>(i => i.Shift == shift).ToList();
            return operatorsSameShift.Where(i => !assigned.Any(a => a.Id == i.Id)).ToList();

        }
        public bool GetWorkOrder(int incidentId)
        {
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Master)
            {
                Incident incident = dal.GetById<Incident>(incidentId);

                if (incident == null)
                {
                    throw new ServiceException("Incident does not exist");

                }
                else if (incident.WorkOrder == null) { return false; }
                else {
                    return true;
                }
            }return false;
        }

        public void CreateWorkOrder(Incident incident)
        {
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Master)
            {
                if (incident.WorkOrder == null)
                {
                    //si no tiene se tiene que crear una nueva
                    var aux = new WorkOrder
                    {
                        StartDate = DateTime.Now,
                        Incident = incident,
                    };
                    dal.Insert<WorkOrder>(aux);
                    incident.Status = Status.InProgress;
                    dal.Commit();
                }
            }
        }

        public void AddOperatorToWorkOrder(Incident incident, Operator op)
        {
            incident.WorkOrder.AddOperatorToWorkOrder(op);
            dal.Commit();

        }

        public void RemoveOperatorFromWorkOrder(Incident incident, Operator op)
        {
            incident.WorkOrder.RemoveOperator(op);
            dal.Commit();
        }
        #endregion

        #region CLOSE WORKORDER

        public void ClosedWorkOrder(WorkOrder w, String report, DateTime endDate)
        {
            //hay operator loggeado? 
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Operator )
            {
                w.Close(report, endDate);
                dal.Commit();
            }
            else { throw new ServiceException("You must be an operator to close a WorkOrder"); }

        }
        public ICollection<WorkOrder> GetAssignedWorkOrder()
        {
            ICollection<WorkOrder> assignedWorders = new List<WorkOrder>();
                
            if ((Employee.LoggedEmployee != null) && Employee.LoggedEmployee is Operator op)
            {
                
                assignedWorders = dal.GetWhere<WorkOrder>(w => w.Incident.Status != Status.Completed && w.Operators.Any(o => o.Id == op.Id)).ToList();
            }
            return assignedWorders;
        }
            //The system shows the information of the work order including the parts
            //that have been included in the order and the total cost of the used parts, if
            //any were use
        
        #endregion

        #region INTERFAZ
        public string QueSoy()
        {
            if (Employee.LoggedEmployee != null && Employee.LoggedEmployee is Head h)
            {
                return "Granted Permissions: Head";
            }
            else if (Employee.LoggedEmployee != null && Employee.LoggedEmployee is Master m)
            {
                return "Granted Permissions: Master";
            }
            else if (Employee.LoggedEmployee != null && Employee.LoggedEmployee is Operator o)
            {
                return "Granted Permissions: Operator";
            }
            else return "Granted Permissions: Employee";
        }

        public string miNombre()
        {
            if(Employee.LoggedEmployee != null)
            {
                return Employee.LoggedEmployee.FullName.Trim();
            }
            else { return ""; }
        }

        public bool soyHead()
        {
            if(Employee.LoggedEmployee != null && Employee.LoggedEmployee is Head)
            {
                return true;
            }
            return false;
        }

        public bool soyMaster()
        {
            if (Employee.LoggedEmployee != null && Employee.LoggedEmployee is Master)
            {
                return true;
            }
            return false;
        }

        public bool soyOperator()
        {
            if (Employee.LoggedEmployee != null && Employee.LoggedEmployee is Operator)
            {
                return true;
            }
            return false;
        }
        
        

        #endregion

    }
}
