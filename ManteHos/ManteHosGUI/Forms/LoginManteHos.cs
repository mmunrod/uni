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
using ManteHosGUI.Forms;

namespace ManteHosGUI.Forms
{
    public partial class LoginManteHos : Form
    {
        private IManteHosService manteHosService;
        public LoginManteHos(IManteHosService manteHosService)
        {
            InitializeComponent();
            this.manteHosService = manteHosService;
            //al darle a enter el ok se pulsa automatico 
            this.AcceptButton = OK;
            this.MaximizeBox = false;
            PassWord_Box.TextChanged += DesaparecerError;
            UserName_Box.TextChanged += DesaparecerError;   
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (NotEmpty())
            {
                try
                {
                    //AQUI FALTA QUE COMPROBEMOS SI ENTRA O NO AHORA MISMO OK NO HACE NADA SOLO ACTIVA LOGOUT
                    manteHosService.Login(UserName_Box.Text, PassWord_Box.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ServiceException ex)
                {
                    Error_Label.Text = ex.Message;
                    Error_Label.Visible = true;

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Login Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
              
            }
            else
            {
                Error_Label.Text = "Username and password are required ";
                Error_Label.Visible = true;
            }
        }

        protected virtual bool NotEmpty()
        {
            return
                //el .text hace que pase de ser array a string!!!
                !string.IsNullOrEmpty(PassWord_Box.Text) &&
                !string.IsNullOrEmpty(UserName_Box.Text);
        }

        private void Show_Password_Click(object sender, EventArgs e)
        {
            if (PassWord_Box.UseSystemPasswordChar)
            {
                PassWord_Box.UseSystemPasswordChar = false;
            }
            else
            {
                PassWord_Box.UseSystemPasswordChar = true;
            }
        }

        //Al volver a escribir algo en un campo desaparece la frase del error
        private void DesaparecerError(object sender, EventArgs e)
        {
            Error_Label.Visible = false;
        }

        //hacer que escribas el username y te puedas mover con la flecha
        private void UserName_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                PassWord_Box.Focus();
            }
        }
        private void Password_Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                UserName_Box.Focus();
            }
        }
    }
}
