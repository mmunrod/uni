namespace ManteHosGUI.Forms
{
    partial class AssignWorkOrderManteHos
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
            this.title_label = new System.Windows.Forms.Label();
            this.area_master_label = new System.Windows.Forms.Label();
            this.list_incidents_label = new System.Windows.Forms.Label();
            this.Area_Master_Text = new System.Windows.Forms.Label();
            this.list_of_Incidents = new System.Windows.Forms.ComboBox();
            this.select_button = new System.Windows.Forms.Button();
            this.report_date = new System.Windows.Forms.Label();
            this.department = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.Label();
            this.date_text = new System.Windows.Forms.Label();
            this.department_text = new System.Windows.Forms.Label();
            this.description_text = new System.Windows.Forms.Label();
            this.priority_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold);
            this.title_label.Location = new System.Drawing.Point(120, 36);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(557, 54);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "ASSIGN WORK ORDER";
            // 
            // area_master_label
            // 
            this.area_master_label.AutoSize = true;
            this.area_master_label.Location = new System.Drawing.Point(68, 135);
            this.area_master_label.Name = "area_master_label";
            this.area_master_label.Size = new System.Drawing.Size(83, 16);
            this.area_master_label.TabIndex = 1;
            this.area_master_label.Text = "Area Master:";
            // 
            // list_incidents_label
            // 
            this.list_incidents_label.AutoSize = true;
            this.list_incidents_label.Location = new System.Drawing.Point(47, 178);
            this.list_incidents_label.Name = "list_incidents_label";
            this.list_incidents_label.Size = new System.Drawing.Size(100, 16);
            this.list_incidents_label.TabIndex = 2;
            this.list_incidents_label.Text = "List of incidents:";
            // 
            // Area_Master_Text
            // 
            this.Area_Master_Text.AutoSize = true;
            this.Area_Master_Text.Location = new System.Drawing.Point(172, 134);
            this.Area_Master_Text.Name = "Area_Master_Text";
            this.Area_Master_Text.Size = new System.Drawing.Size(0, 16);
            this.Area_Master_Text.TabIndex = 3;
            // 
            // list_of_Incidents
            // 
            this.list_of_Incidents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.list_of_Incidents.FormattingEnabled = true;
            this.list_of_Incidents.Location = new System.Drawing.Point(175, 176);
            this.list_of_Incidents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.list_of_Incidents.Name = "list_of_Incidents";
            this.list_of_Incidents.Size = new System.Drawing.Size(575, 24);
            this.list_of_Incidents.TabIndex = 5;
            this.list_of_Incidents.SelectedIndexChanged += new System.EventHandler(this.list_of_Incidents_SelectedIndexChanged);
            this.list_of_Incidents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clickonlist);
            // 
            // select_button
            // 
            this.select_button.Enabled = false;
            this.select_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_button.Location = new System.Drawing.Point(653, 331);
            this.select_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(108, 39);
            this.select_button.TabIndex = 6;
            this.select_button.Text = "SELECT";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // report_date
            // 
            this.report_date.AutoSize = true;
            this.report_date.Location = new System.Drawing.Point(47, 262);
            this.report_date.Name = "report_date";
            this.report_date.Size = new System.Drawing.Size(83, 16);
            this.report_date.TabIndex = 7;
            this.report_date.Text = "Report Date:";
            this.report_date.Visible = false;
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Location = new System.Drawing.Point(47, 304);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(83, 16);
            this.department.TabIndex = 8;
            this.department.Text = "Department :";
            this.department.Visible = false;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(435, 262);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(78, 16);
            this.description.TabIndex = 9;
            this.description.Text = "Description:";
            this.description.Visible = false;
            // 
            // priority
            // 
            this.priority.AutoSize = true;
            this.priority.Location = new System.Drawing.Point(435, 304);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(51, 16);
            this.priority.TabIndex = 10;
            this.priority.Text = "Priority:";
            this.priority.Visible = false;
            // 
            // date_text
            // 
            this.date_text.AutoSize = true;
            this.date_text.Location = new System.Drawing.Point(147, 262);
            this.date_text.Name = "date_text";
            this.date_text.Size = new System.Drawing.Size(0, 16);
            this.date_text.TabIndex = 11;
            // 
            // department_text
            // 
            this.department_text.AutoSize = true;
            this.department_text.Location = new System.Drawing.Point(147, 304);
            this.department_text.Name = "department_text";
            this.department_text.Size = new System.Drawing.Size(0, 16);
            this.department_text.TabIndex = 15;
            // 
            // description_text
            // 
            this.description_text.AutoSize = true;
            this.description_text.Location = new System.Drawing.Point(529, 262);
            this.description_text.Name = "description_text";
            this.description_text.Size = new System.Drawing.Size(0, 16);
            this.description_text.TabIndex = 13;
            // 
            // priority_text
            // 
            this.priority_text.AutoSize = true;
            this.priority_text.Location = new System.Drawing.Point(529, 304);
            this.priority_text.Name = "priority_text";
            this.priority_text.Size = new System.Drawing.Size(0, 16);
            this.priority_text.TabIndex = 14;
            // 
            // AssignWorkOrderManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 407);
            this.Controls.Add(this.priority_text);
            this.Controls.Add(this.description_text);
            this.Controls.Add(this.department_text);
            this.Controls.Add(this.date_text);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.description);
            this.Controls.Add(this.department);
            this.Controls.Add(this.report_date);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.list_of_Incidents);
            this.Controls.Add(this.Area_Master_Text);
            this.Controls.Add(this.list_incidents_label);
            this.Controls.Add(this.area_master_label);
            this.Controls.Add(this.title_label);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AssignWorkOrderManteHos";
            this.Text = "WorkOrderManteHos";
            this.Load += new System.EventHandler(this.AssignWorkOrderManteHos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label area_master_label;
        private System.Windows.Forms.Label list_incidents_label;
        private System.Windows.Forms.Label Area_Master_Text;
        private System.Windows.Forms.ComboBox list_of_Incidents;
        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Label report_date;
        private System.Windows.Forms.Label department;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label priority;
        private System.Windows.Forms.Label date_text;
        private System.Windows.Forms.Label department_text;
        private System.Windows.Forms.Label description_text;
        private System.Windows.Forms.Label priority_text;
    }
}