namespace ManteHosGUI.Forms
{
    partial class LoginManteHos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.Button();
            this.Error_Label = new System.Windows.Forms.Label();
            this.UserName_Box = new System.Windows.Forms.TextBox();
            this.PassWord_Box = new System.Windows.Forms.TextBox();
            this.UserName_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Show_Password = new System.Windows.Forms.Button();
            this.Title_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.ForeColor = System.Drawing.Color.Black;
            this.OK.Location = new System.Drawing.Point(270, 313);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 48);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Error_Label
            // 
            this.Error_Label.AutoSize = true;
            this.Error_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_Label.ForeColor = System.Drawing.Color.Red;
            this.Error_Label.Location = new System.Drawing.Point(151, 265);
            this.Error_Label.Name = "Error_Label";
            this.Error_Label.Size = new System.Drawing.Size(0, 16);
            this.Error_Label.TabIndex = 1;
            this.Error_Label.Visible = false;
            // 
            // UserName_Box
            // 
            this.UserName_Box.Location = new System.Drawing.Point(154, 145);
            this.UserName_Box.Name = "UserName_Box";
            this.UserName_Box.Size = new System.Drawing.Size(216, 22);
            this.UserName_Box.TabIndex = 2;
            this.UserName_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserName_Box_KeyDown);
            // 
            // PassWord_Box
            // 
            this.PassWord_Box.Location = new System.Drawing.Point(154, 215);
            this.PassWord_Box.Name = "PassWord_Box";
            this.PassWord_Box.Size = new System.Drawing.Size(178, 22);
            this.PassWord_Box.TabIndex = 3;
            this.PassWord_Box.UseSystemPasswordChar = true;
            this.PassWord_Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Password_Box_KeyUp);
            // 
            // UserName_Label
            // 
            this.UserName_Label.AutoSize = true;
            this.UserName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName_Label.Location = new System.Drawing.Point(26, 145);
            this.UserName_Label.Name = "UserName_Label";
            this.UserName_Label.Size = new System.Drawing.Size(88, 18);
            this.UserName_Label.TabIndex = 4;
            this.UserName_Label.Text = "UserName";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_Label.Location = new System.Drawing.Point(26, 216);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(83, 18);
            this.Password_Label.TabIndex = 5;
            this.Password_Label.Text = "Password";
            // 
            // Show_Password
            // 
            this.Show_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Show_Password.Location = new System.Drawing.Point(338, 210);
            this.Show_Password.Name = "Show_Password";
            this.Show_Password.Size = new System.Drawing.Size(32, 30);
            this.Show_Password.TabIndex = 7;
            this.Show_Password.Text = "👁️‍🗨️";
            this.Show_Password.UseVisualStyleBackColor = true;
            this.Show_Password.Click += new System.EventHandler(this.Show_Password_Click);
            // 
            // Title_Label
            // 
            this.Title_Label.AutoSize = true;
            this.Title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Label.Location = new System.Drawing.Point(146, 43);
            this.Title_Label.Name = "Title_Label";
            this.Title_Label.Size = new System.Drawing.Size(148, 46);
            this.Title_Label.TabIndex = 8;
            this.Title_Label.Text = "LOGIN";
            // 
            // LoginManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 412);
            this.Controls.Add(this.Title_Label);
            this.Controls.Add(this.Show_Password);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.UserName_Label);
            this.Controls.Add(this.PassWord_Box);
            this.Controls.Add(this.UserName_Box);
            this.Controls.Add(this.Error_Label);
            this.Controls.Add(this.OK);
            this.Name = "LoginManteHos";
            this.Text = "LoginManteHos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label Error_Label;
        private System.Windows.Forms.TextBox UserName_Box;
        private System.Windows.Forms.TextBox PassWord_Box;
        private System.Windows.Forms.Label UserName_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.Button Show_Password;
        private System.Windows.Forms.Label Title_Label;
    }
}