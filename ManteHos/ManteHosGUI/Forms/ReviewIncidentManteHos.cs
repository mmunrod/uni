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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManteHosGUI.Forms
{
    public partial class ReviewIncidentManteHos : Form
    {
        private IManteHosService manteHosService;
        public ReviewIncidentManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;
            this.MaximizeBox = false;
        }
        //para ver que boton está pulsado
        private enum ActionMode { None, Accept, Reject }
        private ActionMode currentAction = ActionMode.None;

        //Al cargar el manteHos sale esto de primeras 
        private void ReviewIncidentManteHos_Load(object sender, EventArgs e)
        {
            LoadIncidents();
            LoadAreas();
            LoadPriority();

            //deshabilitar save para que no se pueda guardar sin nada
            Save_Button.Enabled = false;

            //Los escondes todo
            Priority_Title.Visible = false;
            Priority_Box.Visible = false;
            Area_Title.Visible = false;
            Area_Box.Visible = false;
            RejectReason_Title.Visible = false;
            RejectReason_Box.Visible = false;
            Save_Button.Visible = false;
        }

        private ICollection<Incident> incidents;
        private void LoadIncidents()
        {
            incidents = manteHosService.getIncidentList();

            List_Incidents.DataSource = incidents.ToList();
            List_Incidents.DisplayMember = "Description";  
            List_Incidents.ValueMember = "Id";

            List_Incidents.SelectedIndex = -1;
            List_Incidents.SelectedItem = null;
            List_Incidents.Text = "";

            ClearText(); 
        }

        //Cargar los valores de area
        private void LoadAreas()
        {
            ICollection<Area> areas = manteHosService.getAreaList();

            Area_Box.DataSource = areas.ToList();
            Area_Box.DisplayMember = "Name";
            Area_Box.ValueMember = "Id";

            ClearAreas(); 
        }

        private void ClearAreas()
        {
            //Que empieze en blanco 
            Area_Box.SelectedIndex = -1;
            Area_Box.SelectedItem = null;
            Area_Box.Text = "";
        }

        //Cargar los valores de prioridad
        private void LoadPriority()
        {
            ICollection<Priority> priorities = manteHosService.getPriorityList();

            Priority_Box.DataSource = priorities.ToList();

            ClearPriority(); 
        }

        private void ClearPriority()
        {
            //que empiece en blanco 
            Priority_Box.SelectedIndex = -1;
            Priority_Box.SelectedItem = null;
            Priority_Box.Text = "";
        }
        private void List_Incidents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(List_Incidents.SelectedItem is Incident i)
            {
                Date_Text.Text= i.ReportDate.ToString("g");
                Department_Text.Text = i.Department.ToString();
                Description_Text.Text = i.Description.ToString();
                Employee_Text.Text = i.Reporter.FullName.ToString();

                //Al cambiar de incidente se reactivan los botones
                Accept_Button.Enabled = true; 
                Reject_Button.Enabled = true;
                Save_Button.Visible = false;
                Save_Button.Enabled = false;

                //quitar todas las cajas que hayan podido salir
                Priority_Title.Visible = false;
                Priority_Box.Visible = false;
                Area_Title.Visible =false;
                Area_Box.Visible = false;
                RejectReason_Title.Visible = false;
                RejectReason_Box.Visible = false;

                ClearPriority();
                ClearAreas();
            }
            else
            {
                ClearText();

            }
        }

        private void ClearText()
        {
            Date_Text.Text = "";
            Department_Text.Text = "";
            Description_Text.Text = "";
            Employee_Text.Text = "";
        }

        private void Accept_Button_Click(object sender, EventArgs e)
        {
            //Activar area y prioridad
            Priority_Title.Visible = true;
            Priority_Box.Visible = true;
            Area_Title.Visible = true;
            Area_Box.Visible = true;
            RejectReason_Title.Visible = false;
            RejectReason_Box.Visible = false;
            Error_Label.Text = "";

            //activamos save y punch 
            Save_Button.Visible = true;
            Save_Button.Enabled = true;
            Accept_Button.Enabled = false;
            Reject_Button.Enabled = true;

            currentAction = ActionMode.Accept; 

        }

        private void Reject_Button_Click(object sender, EventArgs e)
        {
            //Activar area y prioridad
            Priority_Title.Visible = false;
            Priority_Box.Visible = false;
            Area_Title.Visible = false;
            Area_Box.Visible = false;
            RejectReason_Title.Visible = true;
            RejectReason_Box.Visible = true;
            Error_Label.Text = "";

            //activamos save y punch 
            Save_Button.Visible = true;
            Save_Button.Enabled = true;
            Accept_Button.Enabled = true;
            Reject_Button.Enabled = false;

            currentAction = ActionMode.Reject;
        }

       
        private void Save_Button_Click(object sender, EventArgs e)
        {
            //SI ESTA ACEPTANDO FUNCIONA ESTO 
            if (currentAction == ActionMode.Accept)
            {
                try
                {
                    if(Area_Box.SelectedItem == null && Priority_Box.SelectedItem == null) { Error_Label.Text = "*Area and priority must be selected"; return; }
                    if (Area_Box.SelectedItem == null && Priority_Box.SelectedItem != null) { Error_Label.Text = "*Area must be selected"; return; }
                    if (Priority_Box.SelectedItem == null && Area_Box.SelectedItem != null) { Error_Label.Text = "*Priority must be selected"; return; }

                    if (!(List_Incidents.SelectedItem is Incident i))
                    {
                        Error_Label.Text = "No incident selected";
                        return;
                    }
                    else
                    {
                        // Obtener datos
                        Area area = (Area)Area_Box.SelectedItem;
                        Priority priority = (Priority)Priority_Box.SelectedItem;

                        // Llamar al servicio (usa ID, no el objeto)

                        manteHosService.AcceptIncident(i, area, priority);

                        DialogResult answer = MessageBox.Show("Incident accepted",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (answer == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }

                }
                catch (ServiceException ex)
                {
                    //sale un nuveo mesaje de error 
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    //sale un nuveo mesaje de error 
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            //SI ESTA RECHAZANDO HACE ESTO 
            if (currentAction == ActionMode.Reject)
            {
                try
                {
                    if (string.IsNullOrEmpty(RejectReason_Box.Text)) { Error_Label.Text = "*A reject reason must be provided"; return; }
                    String reason = RejectReason_Box.Text;

                    if (!(List_Incidents.SelectedItem is Incident i))
                    {
                        Error_Label.Text = "No incident selected";
                        return;
                    }

                    manteHosService.RejectIncident(i, reason);

                    DialogResult answer = MessageBox.Show("Incident rejected",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (answer == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                catch (ServiceException ex)
                {
                    //sale un nuveo mesaje de error 
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    //sale un nuevo mesaje de error 
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void List_Incidents_Click(object sender, EventArgs e)
        {
            if(incidents == null || incidents.Count == 0)
            {
                DialogResult answer = MessageBox.Show("There are no pending incidents to accept or reject.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
