using ManteHos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace ManteHos.Services
{
    public interface IManteHosService
    {
        void RemoveAllData();
        void Commit();

        // Necesario para la inicialización de la BD
        void DBInitialization();

        //
        // A partir de aquí los necesarios para los CU solicitados
        //
        

        //CASO 1
        void Login(string username,  string password);


        //CASO 2
        void Logout();

        //CASO 3
        void addIncident(String dp, String ds, DateTime? dt, Employee rp);

        //CASO 4
        IList<Incident> getIncidentList();
        void AcceptIncident(Incident IncidentId, Area area, Priority priority);
        void RejectIncident(Incident inci, string reason);

        IList<Area> getAreaList();
        IList<Priority> getPriorityList(); 

        //CASO 5
        //incidentes aceptados 
        ICollection<Incident> GetAcceptedIncidents();
        //workOrder asociado a un incidente 
        bool GetWorkOrder(int incidentId);
        void CreateWorkOrder(Incident incident);
        void AddOperatorToWorkOrder(Incident incident, Operator op);
        void RemoveOperatorFromWorkOrder(Incident incident, Operator op);

        //listas de operadores
        IList<Operator> getAllOperators();
        IList<Operator> getAssignedOperators();

        //CASO 7

        void ClosedWorkOrder(WorkOrder w, String report, DateTime endDate);
        ICollection<WorkOrder> GetAssignedWorkOrder();

        //IDEA FELIZ 
        string QueSoy();
        string miNombre();
        bool soyHead();
        bool soyMaster();
        bool soyOperator(); 
       


    }

       
    }



