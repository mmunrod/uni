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
    public partial class CreateIncidentManteHos : Form
    {
        private IManteHosService manteHosService;
        public CreateIncidentManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;

            //Los errores desaparecen en cuanto se escribe algo 
            Department_Box.TextChanged += DesaparecerError;
            Description_Box.TextChanged += DesaparecerError;

            //que teclas especiales hagan cosas
            this.AcceptButton = Create_Button;

            this.MaximizeBox = false;
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            DateTime inicio = Calendar.Value;
            String department = Department_Box.Text;
            String descrip = Description_Box.Text;
            Employee emp = Employee.LoggedEmployee;
            if (notEmpty())
            {
                try {
                    //void addIncident(String dp, String ds, DateTime? dt, Employee rp);
                    manteHosService.addIncident(department, descrip, inicio, emp); 
                    DialogResult answer = MessageBox.Show("A new incident has been created", "Creation",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                    if(answer == DialogResult.OK)
                    {
                        this.Close(); 
                    }
                }
                catch (ServiceException ex)
                {
                    MessageBox.Show(ex.Message, "Creation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message, "Creation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                Error_Label.Text = "Description and Department must be completed";
                Error_Label.Visible = true; 
            }


        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Description_Box.Clear();
            Department_Box.Clear();
            Error_Label.Text = ""; 
        }

        private bool notEmpty()
        {
            return
                //revisar que haya algo en las dos cajas sino NO VALE 
                !string.IsNullOrEmpty(Department_Box.Text) &&
                !string.IsNullOrEmpty(Description_Box.Text);
        }

        private void DesaparecerError(object sender, EventArgs e)
        {
            Error_Label.Visible = false ; 
        }

        private void Department_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                Description_Box.Focus();
            }
        }
        private void Description_Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Department_Box.Focus();
            }
        }
    }
}
