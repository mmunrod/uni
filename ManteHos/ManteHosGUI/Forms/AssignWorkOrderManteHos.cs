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
    public partial class AssignWorkOrderManteHos : Form
    {
        private IManteHosService manteHosService;
        public AssignWorkOrderManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;
            this.MaximizeBox = false;
        }
        private void AssignWorkOrderManteHos_Load(object sender, EventArgs e)
        {
            LoadIncidents();
            Area_Master_Text.Text = manteHosService.miNombre();
            select_button.Enabled = false;
        }
        private ICollection<Incident> incidents;
        
        private void LoadIncidents()
        {
            //si no hay incidentes muestrar erroer
            
                incidents = manteHosService.GetAcceptedIncidents();
                 list_of_Incidents.DataSource = incidents.ToList();
                 list_of_Incidents.DisplayMember = "Description";
                 list_of_Incidents.ValueMember = "Id";
                 list_of_Incidents.SelectedIndex = -1;
        }
        
        private void list_of_Incidents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_of_Incidents.SelectedItem is Incident i)
            {
                
                date_text.Text = i.ReportDate.ToString("g");
                department_text.Text = i.Department.ToString();
                description_text.Text = i.Description.ToString();
                priority_text.Text=i.Priority.ToString();

                //Al seleccionar un incidente se ven sus datos
                report_date.Visible = true;
                department.Visible = true;
                description.Visible = true;
                priority.Visible = true;

                date_text.Visible = true;
                department_text.Visible = true;
                description_text.Visible = true;
                priority_text.Visible = true;

                select_button.Enabled = true;
            }
            else
            {
                report_date.Visible = false;
                department.Visible = false;
                description.Visible = false;
                priority.Visible = false;

                date_text.Visible = false;
                department_text.Visible = false;
                description_text.Visible = false;
                priority_text.Visible = false;

                select_button.Enabled = false;
            }
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            if (list_of_Incidents.SelectedItem is Incident i)
            {//si hay un work order assignado ese incidente se abre getWorkOrderManteHos
                if (manteHosService.GetWorkOrder(i.Id))
                {
                    Incident.UsedIncident = i;
                    WorkOrder.UsedWorder = i.WorkOrder;
                    GetWorkOrderManteHos getWorkOrder = new GetWorkOrderManteHos(manteHosService);
                    getWorkOrder.ShowDialog();
                    this.Close();
                }//si no hay work Order asociado hay que preguntar si se quiere crear un work order para ese incidente
                else {
                    DialogResult aux = MessageBox.Show("There is no work order associated to this incident. Would you like to create one?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (aux == DialogResult.Yes)
                    {
                        //Como ya te ha dicho que si la quiere crear la creas y linkeas todo, ya se apuntan el uno al otro
                        Incident.UsedIncident = i; 
                        WorkOrder w = new WorkOrder(DateTime.Now, i);
                        WorkOrder.UsedWorder = w;
                        i.WorkOrder = w;
                        manteHosService.Commit(); 

                        CreateWorkOrderManteHos createWorkOrder = new CreateWorkOrderManteHos(manteHosService);
                        createWorkOrder.ShowDialog();
                        this.Close();
                    }
                }
                
            }
            
          
        }

        #region NO_INCIDENT_FOUND
        private void clickonlist(object sender, MouseEventArgs e)
        {
            if (incidents == null || incidents.Count == 0)
            {
               DialogResult answer = MessageBox.Show("There are no incidents in this area.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
