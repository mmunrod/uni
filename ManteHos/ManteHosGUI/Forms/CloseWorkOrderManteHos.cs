using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManteHosGUI.Forms
{
    public partial class CloseWorkOrderManteHos : Form
    {
        private IManteHosService manteHosService;
        private Object s;
        private EventArgs ev;
        public CloseWorkOrderManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;

            this.MaximizeBox = false;
        }

        private void CloseWorkOrderManteHos_Load(object sender, EventArgs e)
        {
            s = sender; ev = e;
            LoadWorders();
            idWorder.Visible = false;
            start_date.Visible = false;
            repreport.Visible = false;  
            usedParts.Visible = false;
            partsGridView.Visible = false;
            totCost.Visible = false;
            opeList.Visible = false;
            opsLista.Visible = false;
            reportTextBox.Visible = false;
            reportWarning.Visible = false;
            enddateLabel.Visible = false;
            endDatePicker.Visible = false;
            incidentLabel .Visible = false;
            daterror.Visible = false;


            name_op.Text =  manteHosService.miNombre();
        }

        //Cargar las diferentes listas
        private void LoadWorders()
        {
            ICollection<WorkOrder> worders = manteHosService.GetAssignedWorkOrder();

            comboBoxworders.DataSource = worders.ToList();
            comboBoxworders.DisplayMember = "Description";
            comboBoxworders.ValueMember = "Id";

            comboBoxworders.SelectedIndex = -1;
            comboBoxworders.SelectedItem = null;
            comboBoxworders.Text = "";

        }
       
        private void loadOpsLista(WorkOrder w)
        {
            opsLista.View = View.Details;
            opsLista.FullRowSelect = true;
            opsLista.GridLines = true;

            opsLista.Columns.Clear();
            opsLista.Columns.Add("Id");
            opsLista.Columns.Add("Name");
            opsLista.Columns.Add("Shift");

            opsLista.Items.Clear();
            foreach (var op in w.Operators)
            {
                opsLista.Items.Add(new ListViewItem(new string[]
                {
                    op.Id,
                    op.FullName,
                    op.Shift.ToString()
                }));
            }

        }
        private void loadParts(WorkOrder w) {

            partsGridView.AutoGenerateColumns = false;
            partsGridView.Columns.Clear();

            partsGridView.Columns.Add("Code", "Code");
            partsGridView.Columns.Add("Amount", "Amount");
            partsGridView.Columns.Add("Description", "Description");

            partsGridView.Rows.Clear();
            if (w.UsedParts != null)
            {
                foreach (UsedPart up in w.UsedParts)
                {
                    partsGridView.Rows.Add(up.Part.Code, up.Quantity, up.Part.Description);
                }
            }
        }

        //Cuando se cmbia la seleccion del combo box que sucede
        private void comboBoxworders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxworders.SelectedItem is WorkOrder workOrder)
            {
                reportWarning.Visible = false;
                daterror.Visible = false;
                reportTextBox.Clear();
                
                idWorder.Visible = true;
                idWorder.Text = "Work Order selected: " + workOrder.Id;

                incidentLabel.Visible = true;
                incidentLabel.Text = "Incident: " + workOrder.Incident.Description;

                start_date.Visible = true;
                start_date.Text = "Start Date: " + workOrder.StartDate.ToString();

                repreport.Visible = true;
                repreport.Text = "Repair Report: " ;
                reportTextBox.Visible = true;

                usedParts.Visible = true;
                usedParts.Text = "Parts Used: ";

                partsGridView.Visible = true;
                loadParts(workOrder);

                totCost.Visible = true;
                totCost.Text = "Total cost of used parts: " + workOrder.CalculateTotalCost() + "€";

                opeList.Visible = true;
                opeList.Text = "Assigned Operators: ";

                //Configuro la list view de los operators
                opsLista.Visible = true;
                if (workOrder?.Operators != null)
                {
                    loadOpsLista(workOrder);
                }

                enddateLabel.Visible = true;
                endDatePicker.Visible = true;
                endDatePicker.Value = DateTime.Now;

                //para poder checkear lo del tiempo 
                WorkOrder.UsedWorder = workOrder;
                Incident.UsedIncident = workOrder.Incident;

            }
        }


        //Controlar los botones
        private void closeButton_Click(object sender, EventArgs e)
        {
            reportWarning.Visible = false;
            daterror.Visible = false;
            
            if (comboBoxworders.SelectedItem is WorkOrder workOrder) {
                String report = reportTextBox.Text;
                DateTime sd = workOrder.StartDate;
                try
                {
                    manteHosService.ClosedWorkOrder(workOrder, report, endDatePicker.Value);
                        DialogResult answer = MessageBox.Show("The Work Order has been closed correctly!", "Close",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Asterisk);
                        if (answer == DialogResult.OK)
                        {
                            this.Close();
                        } 
                    
                }
                catch 
                {
                    if (endDatePicker.Value < sd)
                    {
                        daterror.Visible = true;
                    }
                    if (report.Length == 0 || report == null)
                    {
                        reportWarning.Visible = true;
                    }
                    if (workOrder.HasPendingParts) {
                        
                        DialogResult answer = MessageBox.Show("Sorry! This Work Order has still Pending Parts, you cannot close it...", "Pending Parts",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Asterisk);
                        if (answer == DialogResult.OK)
                        {
                            CloseWorkOrderManteHos_Load(s,ev);
                        }
                    }
                }
            }
        }

        
    }
}
