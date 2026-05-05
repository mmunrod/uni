using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManteHos.Entities
{
    public partial class WorkOrder
    {
        public WorkOrder() {
            this.UsedParts = new List<UsedPart>();
            this.Operators = new List<Operator>();
        }

        public WorkOrder(DateTime sd, Incident i) : this() {

            this.StartDate = sd;
            this.Incident = i;
            
        }
        //este es para pasar test 
        public void AddOperator(Operator op1)
        {
            if (!Operators.Contains(op1))
            {
                Operators.Add(op1);
            }
            else { throw new Exception("The operator is already contained."); }
        }
        public void AddOperatorToWorkOrder(Operator op){

            if (!Operators.Any()){
                AddOperator(op);
                return;
            }
            var shFirst = Operators.First().Shift;
            if (op.Shift == shFirst) AddOperator(op);
            else { throw new Exception("The operator can't be selected because it has different shift"); }
        }

         public void RemoveOperator(Operator op){

             if (!Operators.Any()) throw new Exception("There are no assigned operators");
             var ope = Operators.FirstOrDefault(o => o.Id == op.Id);
             if (ope == null)  throw new Exception("The operator is not assigned in this work order.");

             Operators.Remove(ope);
         }

        public UsedPart AddUsedPart(int aQuantity, Part aPart)
        {
            UsedPart uP = new UsedPart(aQuantity, aPart);
            //uP.WorkOrder = this;
            UsedParts.Add(uP);
            return uP;
        }
        

 
            public bool IsClosed => EndDate != null;

        //si UsedParts es distinto de null, llama a Any(). Si hay un needed used part devuelve true y si no devuelve false
        //Si UsedParts es null, devuelve falso 
        //Solo será true cuando haya alguna usedPart con needed a true
            public bool HasPendingParts => UsedParts?.Any(up => up.Needed) ?? false;
       

            public void Close(string repairReport, DateTime endDate){
                if (IsClosed) throw new Exception("The WorkOrder was already closed");

                if (string.IsNullOrWhiteSpace(repairReport)) throw new Exception("A report is needed");

                // Verificar que no hay piezas pendientes (LOOP del diagrama)
                if (HasPendingParts) { 
                    throw new Exception("The workOrder has pending parts, it cannot be closed");
                    
                }
                if (endDate < this.StartDate) throw new Exception("The end date cannot be before the start date");
                // Cerrar la orden
                EndDate = endDate;
                RepairReport = repairReport;

                // Marcar el incidente como completado
                Incident.Status= Status.Completed;
                Incident.CostOfUsedParts = CalculateTotalCost();

            }
           
            public float CalculateTotalCost(){

                if (!UsedParts.Any()) return 0;
                return UsedParts.Sum(up => up.Quantity * up.Part.UnitPrice);

            }
    }
}

