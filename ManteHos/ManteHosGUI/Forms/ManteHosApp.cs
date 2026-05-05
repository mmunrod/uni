using ManteHos.Entities;
using ManteHos.Services;
using ManteHosGUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class ManteHosApp : Form
    {

        //inicializarlo como en el form 
        private IManteHosService manteHosService;
        public ManteHosApp(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;
            this.MaximizeBox = false;
        }

        private void ManteHosApp_Load(object sender, EventArgs e)
        {
            LogOut.Enabled = false;
            ActivarBotones();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginManteHos loginForm = new LoginManteHos(manteHosService);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                ActivarBotones();
                // Si hay dentro un empleado logeado habilitas
                LogOut.Enabled = true;
                //Como ya hay un empleado logeado deshabilitas el poder volver a hacer Login
                LoginButton.Enabled = false;
                this.AcceptButton = null;
                MiName_Label.Text = manteHosService.miNombre(); 
                Type_Permision.Text = manteHosService.QueSoy();
            }
        }

        private void DB_Initialization_Click(object sender, EventArgs e)
        {
            try
            {
                //creas la base de datos, método dado
                manteHosService.DBInitialization();
                //si se crea te lo confirma
                DialogResult answer = MessageBox.Show("Database Created Sucessfully","DataBase creation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                //cuando le des a ok, deshabilitas el botón para que no se cree constantemente
                if (answer == DialogResult.OK) {
                    DB_Initilization.Enabled = false; 
                }
            }
            catch (Exception ex)
            {
                //Avisas que ha salido mal la creación de la base de datos por algo raro
                MessageBox.Show("Unable to initialize Database", "Error Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Create_Incident_Click(object sender, EventArgs e)
        {
            CreateIncidentManteHos createForm = new CreateIncidentManteHos(manteHosService); 
            createForm.ShowDialog();
        }

        private void Review_Incident_Click(object sender, EventArgs e)
        {
            ReviewIncidentManteHos reviewForm = new ReviewIncidentManteHos(manteHosService);
            reviewForm.ShowDialog();
        }

        private void Assign_WorkOrder_Click(object sender, EventArgs e)
        {
            AssignWorkOrderManteHos assignForm = new AssignWorkOrderManteHos(manteHosService);
            assignForm.ShowDialog();
        }

        private void Close_WorkOrder_Click(object sender, EventArgs e)
        {
            CloseWorkOrderManteHos closeForm = new CloseWorkOrderManteHos(manteHosService);
            closeForm.ShowDialog();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure you want to log out?", "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                try
                {
                    //intento de cerrar la sesion, si no hay catch el error 
                    manteHosService.Logout();
                    MessageBox.Show("Successfully logged out.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
                    LoginButton.Enabled = true;
                    LogOut.Enabled = false;
                    Type_Permision.Text = "";
                    MiName_Label.Text = "";

                    //desactivamos botones otra vez
                    //Desactivamos todos hasta que haya un login 
                    Create_Incident.Enabled = false;
                    Review_Incident.Enabled = false;
                    Assign_WorkOrder.Enabled = false;
                   
                    Close_WorkOrder.Enabled = false;

                }
                catch (ServiceException ex)
                {
                    //sale un nuveo mesaje de error 
                    MessageBox.Show(ex.Message,"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ActivarBotones()
        {
            //Desactivamos todos hasta que haya un login 
            Create_Incident.Enabled = false;
            Review_Incident.Enabled = false;
            Assign_WorkOrder.Enabled = false;
          
            Close_WorkOrder.Enabled = false;

            //Employee permisos 
            if (Employee.LoggedEmployee is Employee) {
                Create_Incident.Enabled = true;
            }

            //Operator permisos
            if (manteHosService.soyOperator())
            {
               
                Close_WorkOrder.Enabled = true;
            }

            //Master permisos
            if (manteHosService.soyMaster())
            {
                Assign_WorkOrder.Enabled = true;
            }

            //Head permisos 
            if (manteHosService.soyHead())
            {
                Review_Incident.Enabled = true;
            }
        }
        //
        
    }
}
