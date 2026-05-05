using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI.Forms
{
    public partial class GetWorkOrderManteHos : Form
    {
        private IManteHosService manteHosService;
        public GetWorkOrderManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;

            this.MaximizeBox = false;
        }

        private void GetWorkOrderManteHos_Load(object sender, EventArgs e)
        {
            
            //Rellenar la tabla de all operators
            allOperatos_gridView.Rows.Clear();
            LoadAllOperators();

            //Rellenar la tabla de assigned operators
            assigenedOpperators_gridView.Rows.Clear();
            LoadAssignedOperators();

            partsUsed_gridView.Rows.Clear();
            List<UsedPart> usedParts = Incident.UsedIncident.WorkOrder.UsedParts.ToList();
            if (usedParts != null)
            {
                foreach (UsedPart up in usedParts)
                {
                    partsUsed_gridView.Rows.Add(up.Part.Code,up.Quantity, up.Part.Description);
                }
            }
            add_button.Enabled = false; 
            remove_button.Enabled = false;
            allOperatos_gridView.ClearSelection();
            assigenedOpperators_gridView.ClearSelection();



            id_workOrder_text.Text = Incident.UsedIncident.Description.ToString();
            sdateLabel.Text = WorkOrder.UsedWorder.StartDate.ToString();
        }

        //Cargar los gridview
        private void LoadAllOperators()
        {
            allOperatos_gridView.Rows.Clear();
            List<Operator> allOperators = manteHosService.getAllOperators().ToList();
            foreach (Operator op in allOperators)
            {
                allOperatos_gridView.Rows.Add(op.Id, op.FullName, op.Shift);
            }
        }
        private void LoadAssignedOperators()
        {
   
            assigenedOpperators_gridView.Rows.Clear();
            List<Operator> assignedOperators = manteHosService.getAssignedOperators().ToList();
            foreach (Operator op in assignedOperators)
            {
                assigenedOpperators_gridView.Rows.Add(op.Id,op.FullName, op.Shift);
            }
        }

        
        //CONTROLAR LOS GRIDVIEW Y SUS SELECCIONES
        private Operator selOp;
        private void allOperatos_gridView_SelectionChanged(object sender, EventArgs e)
        {
            if (allOperatos_gridView.SelectedRows.Count == 0)
            {
                selOp = null;
                return;
            }

            //para cambiar el cursor y que funcione dependiendo de la lista seleccionada
            remove_button.Enabled = false;
            add_button.Enabled = true;
            assigenedOpperators_gridView.ClearSelection();

            DataGridViewRow row = allOperatos_gridView.SelectedRows[0];

            string operatorId = row.Cells["id_columna_all"].Value.ToString();

            selOp = manteHosService.getAllOperators().FirstOrDefault(o => o.Id == operatorId);
            Error_label.Text = "";
        }
        private Operator removeOp;
        private void assigned_gridView_SelectionChanged(object sender, EventArgs e)
        {
            if (assigenedOpperators_gridView.SelectedRows.Count == 0)
            {
                removeOp = null;
                return;
            }
            //para cambiar el cursor y que funcione dependiendo de la lista seleccionada
            remove_button.Enabled = true; 
            add_button.Enabled = false;
            allOperatos_gridView.ClearSelection();

            DataGridViewRow row = assigenedOpperators_gridView.SelectedRows[0];

            string operatorId = row.Cells["id_columna_assigned"].Value.ToString();

            removeOp = manteHosService.getAssignedOperators().FirstOrDefault(o => o.Id == operatorId);
            Error_label.Text = "";
        }

        //CONTROLAR LOS BOTONES
        private void save_button_Click(object sender, EventArgs e)
        {
            if (assigenedOpperators_gridView.Rows.Count == 0)
            {
                Error_label.Text = "At least an operator must be added";
            }
            
            else if (!(assigenedOpperators_gridView.Rows.Count == 0))
            {
             
                manteHosService.Commit();
                this.Close();
            }

        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            if (removeOp != null)
            {
                try
                {
                    manteHosService.RemoveOperatorFromWorkOrder(Incident.UsedIncident, removeOp);
                    //recargamos las grids
                    LoadAssignedOperators();
                    LoadAllOperators();
                }
                catch (ServiceException ex)
                {
                    Error_label.Text = ex.Message;
                }
                catch (Exception ex)
                {
                    Error_label.Text = ex.Message;
                }
            }
        }
        private void add_button_Click(object sender, EventArgs e)
        {

            if (selOp != null)
            {
                try
                {
                    manteHosService.AddOperatorToWorkOrder(Incident.UsedIncident, selOp);
                    //recargamos las grids
                    LoadAssignedOperators();
                    LoadAllOperators();
                }
                catch (ServiceException ex)
                {
                    Error_label.Text = ex.Message;
                }
                catch (Exception ex)
                {
                    Error_label.Text = ex.Message;
                }
            }
        }

  
    }
}
