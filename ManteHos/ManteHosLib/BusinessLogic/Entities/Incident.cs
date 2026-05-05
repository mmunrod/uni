using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class Incident
    {
        //the empty constructor 
        public Incident() { }

        //the constructor
        public Incident(String dp, String ds, DateTime dt, Employee rp)
        {
            //initialize the characteristics parameters
            this.Department = dp;
            this.Description = ds;
            this.ReportDate = dt;

            //the atributte pointing to another class
            this.Reporter = rp;

            //the parameters set by default
            this.CostOfUsedParts = 0;
            this.Priority = ManteHos.Entities.Priority.Low;
            this.Status = ManteHos.Entities.Status.Created;



            

        }
        ///HACER LOS CLOSE DESDE WORKORDER Y DE AHI SE MANDA A INCIDENT QUE CALCULA EL PRECIO DE LOS USED PARTS 
        ///

        //NO SE SI ESTO TIENE SENTIDO

        //aceptar negar o marcar como completo un incidente

        //Check the status : Created, Accepted, Rejected, InProgress, Pending, Completed,
        public bool isCreated => Status == Status.Created;
        public bool isAccepted => Status == Status.Accepted;
        public bool isRejected => Status == Status.Rejected;
        public bool isInProgress => Status == Status.InProgress;
        public bool isPending => Status == Status.Pending;
        public bool IsCompleted => Status == Status.Completed;



        public void Accept(Area area, Priority priority)
        {
            if (!isCreated)
                throw new ServiceException("Only possible to accept created incidents");
        
            if (area == null)
                throw new ServiceException("Area must be assigned");

            Area = area;
            Priority = priority;
            Status = Status.Accepted;
           
        }

        
        public void Reject(string reason)
        {
            if (!isCreated)
                throw new ServiceException("Only created incidents can be rejected");
            
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("A reason to be reject must be given");
            
            Status = Status.Rejected;
            RejectionReason = reason;
        }

        /*
        public void MarkAsCompleted()
        {
            if (Status != Status.Accepted)
                throw new InvalidOperationException("Solo se pueden completar incidentes aceptados");
            
            Status = Status.Completed;
        }

        public bool NeedsReview()
        {
            return Status == Status.Created || Status == Status.Pending;
        }
          */
        

    }
}
