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
    public partial class CreateWorkOrderManteHos : Form
    {
        private IManteHosService manteHosService;
        public CreateWorkOrderManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;

            this.MaximizeBox = false;
        }
        private void CreateWorkOrderManteHos_Load(object sender, EventArgs e)
        {
            //Rellenar la tabla de all operators
            allOperators_gridView.Rows.Clear();
            LoadAllOperators();

            //Rellenar la tabla de assigned operators
            assigned_gridView.Rows.Clear();
            LoadAssignedOperators();

            //Limpiar todos lo botones y lo seleccionado
            add_operator_button.Enabled = false;
            remove_operator_button.Enabled = false;
            allOperators_gridView.ClearSelection();
            assigned_gridView.ClearSelection();


            Identificacion_text.Text = Incident.UsedIncident.Description.ToString();
        }

        //RELLENAR LOS GRIDVIEW
        private void LoadAllOperators()
        {
            allOperators_gridView.Rows.Clear();
            List<Operator> allOperators = manteHosService.getAllOperators().ToList();
            foreach (Operator op in allOperators) {
                allOperators_gridView.Rows.Add(op.Id, op.FullName, op.Shift);
            }
        }
        private void LoadAssignedOperators()
        {
           
            assigned_gridView.Rows.Clear(); 
            List<Operator> assignedOperators = manteHosService.getAssignedOperators().ToList();
            foreach (Operator op in assignedOperators)
            {
                assigned_gridView.Rows.Add(op.Id, op.FullName, op.Shift);
            }
        }

        //CONTROLAR LAS GRIDVIEWS
        private Operator selOp; 
        private void allOperators_gridView_SelectionChanged(object sender, EventArgs e)
        {
            if (allOperators_gridView.SelectedRows.Count == 0)
            {
                selOp = null;
                return;
            }

            //para cambiar el cursor y que funcione dependiendo de la lista seleccionada
            remove_operator_button.Enabled = false;
            add_operator_button.Enabled = true;
            assigned_gridView.ClearSelection();
            DataGridViewRow row = allOperators_gridView.SelectedRows[0];

            string operatorId = row.Cells["id_columna_all"].Value.ToString();

            selOp = manteHosService.getAllOperators()
                .FirstOrDefault(o => o.Id == operatorId); 
           
            Error_label.Text = "";
        }
        
        private Operator removeOp;
        private void assigned_gridView_SelectionChanged(object sender, EventArgs e)
        {
            if (assigned_gridView.SelectedRows.Count == 0)
            {
                removeOp = null;
                return;
            }
            //para cambiar el cursor y que funcione dependiendo de la lista seleccionada
            remove_operator_button.Enabled = true;
            add_operator_button.Enabled = false;
            allOperators_gridView.ClearSelection();

            DataGridViewRow row = assigned_gridView.SelectedRows[0];

            string operatorId = row.Cells["id_columna_assigned"].Value.ToString();

            removeOp = manteHosService.getAssignedOperators().FirstOrDefault(o => o.Id == operatorId);
            Error_label.Text = "";
        }

        //ACCIONES DE LOS BOTONES
        private void add_operator_button_Click(object sender, EventArgs e)
        {
            if (selOp != null) {
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
                catch (Exception ex) {
                    Error_label.Text = ex.Message;
                }
            }
            

        }
        private void remove_operator_button_Click(object sender, EventArgs e)
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

        private void save_button_Click(object sender, EventArgs e)
        {
            
            if (assigned_gridView.Rows.Count == 0)
            {
                Error_label.Text = "At least an operator must be added";
            }
            if (StartDate_Pick.Value < Incident.UsedIncident.ReportDate)
            {
                Error_label.Text = "The start date cannot be before the current date";
            }
            else if(!(assigned_gridView.Rows.Count == 0) && !(StartDate_Pick.Value < Incident.UsedIncident.ReportDate)) { 
                WorkOrder.UsedWorder.StartDate = StartDate_Pick.Value;
                manteHosService.Commit();
                this.Close();
            }
        }
        
    }
}

