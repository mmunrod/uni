namespace ManteHosGUI
{
    partial class ManteHosApp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManteHosApp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.PrincipalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DB_Initilization = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Create_Incident = new System.Windows.Forms.ToolStripMenuItem();
            this.Review_Incident = new System.Windows.Forms.ToolStripMenuItem();
            this.workOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Assign_WorkOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.Close_WorkOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.Type_Permision = new System.Windows.Forms.Label();
            this.MiName_Label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrincipalMenu,
            this.incidentToolStripMenuItem,
            this.workOrdersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // PrincipalMenu
            // 
            this.PrincipalMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DB_Initilization,
            this.ExitButton});
            this.PrincipalMenu.Name = "PrincipalMenu";
            this.PrincipalMenu.Size = new System.Drawing.Size(70, 24);
            this.PrincipalMenu.Text = "System";
            // 
            // DB_Initilization
            // 
            this.DB_Initilization.Name = "DB_Initilization";
            this.DB_Initilization.Size = new System.Drawing.Size(137, 26);
            this.DB_Initilization.Text = "DB Init";
            this.DB_Initilization.Click += new System.EventHandler(this.DB_Initialization_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(137, 26);
            this.ExitButton.Text = "Exit";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // incidentToolStripMenuItem
            // 
            this.incidentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Create_Incident,
            this.Review_Incident});
            this.incidentToolStripMenuItem.Name = "incidentToolStripMenuItem";
            this.incidentToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.incidentToolStripMenuItem.Text = "Incident";
            // 
            // Create_Incident
            // 
            this.Create_Incident.Name = "Create_Incident";
            this.Create_Incident.Size = new System.Drawing.Size(139, 26);
            this.Create_Incident.Text = "Create ";
            this.Create_Incident.Click += new System.EventHandler(this.Create_Incident_Click);
            // 
            // Review_Incident
            // 
            this.Review_Incident.Name = "Review_Incident";
            this.Review_Incident.Size = new System.Drawing.Size(139, 26);
            this.Review_Incident.Text = "Review";
            this.Review_Incident.Click += new System.EventHandler(this.Review_Incident_Click);
            // 
            // workOrdersToolStripMenuItem
            // 
            this.workOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Assign_WorkOrder,
            this.Close_WorkOrder});
            this.workOrdersToolStripMenuItem.Name = "workOrdersToolStripMenuItem";
            this.workOrdersToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.workOrdersToolStripMenuItem.Text = "WorkOrders";
            // 
            // Assign_WorkOrder
            // 
            this.Assign_WorkOrder.Name = "Assign_WorkOrder";
            this.Assign_WorkOrder.Size = new System.Drawing.Size(135, 26);
            this.Assign_WorkOrder.Text = "Assign";
            this.Assign_WorkOrder.Click += new System.EventHandler(this.Assign_WorkOrder_Click);
            // 
            // Close_WorkOrder
            // 
            this.Close_WorkOrder.Name = "Close_WorkOrder";
            this.Close_WorkOrder.Size = new System.Drawing.Size(135, 26);
            this.Close_WorkOrder.Text = "Close";
            this.Close_WorkOrder.Click += new System.EventHandler(this.Close_WorkOrder_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(757, 12);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(87, 34);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(664, 12);
            this.LogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(88, 34);
            this.LogOut.TabIndex = 2;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Type_Permision
            // 
            this.Type_Permision.AutoSize = true;
            this.Type_Permision.Location = new System.Drawing.Point(13, 514);
            this.Type_Permision.Name = "Type_Permision";
            this.Type_Permision.Size = new System.Drawing.Size(0, 16);
            this.Type_Permision.TabIndex = 3;
            // 
            // MiName_Label
            // 
            this.MiName_Label.AutoSize = true;
            this.MiName_Label.Location = new System.Drawing.Point(12, 479);
            this.MiName_Label.Name = "MiName_Label";
            this.MiName_Label.Size = new System.Drawing.Size(0, 16);
            this.MiName_Label.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(219, 162);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(149, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "HOSPITAL MAINTENANCE";
            // 
            // ManteHosApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 546);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MiName_Label);
            this.Controls.Add(this.Type_Permision);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManteHosApp";
            this.Text = "ManteHosApp";
            this.Load += new System.EventHandler(this.ManteHosApp_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PrincipalMenu;
        private System.Windows.Forms.ToolStripMenuItem DB_Initilization;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.ToolStripMenuItem incidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Create_Incident;
        private System.Windows.Forms.ToolStripMenuItem workOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitButton;
        private System.Windows.Forms.ToolStripMenuItem Review_Incident;
        private System.Windows.Forms.ToolStripMenuItem Assign_WorkOrder;
        private System.Windows.Forms.ToolStripMenuItem Close_WorkOrder;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Label Type_Permision;
        private System.Windows.Forms.Label MiName_Label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

