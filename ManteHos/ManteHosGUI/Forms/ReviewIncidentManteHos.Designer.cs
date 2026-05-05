namespace ManteHosGUI.Forms
{
    partial class ReviewIncidentManteHos
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
            this.List_Incidents = new System.Windows.Forms.ComboBox();
            this.date_title = new System.Windows.Forms.Label();
            this.Department_title = new System.Windows.Forms.Label();
            this.Description_title = new System.Windows.Forms.Label();
            this.Employee_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.Date_Text = new System.Windows.Forms.Label();
            this.Department_Text = new System.Windows.Forms.Label();
            this.Description_Text = new System.Windows.Forms.Label();
            this.Employee_Text = new System.Windows.Forms.Label();
            this.Accept_Button = new System.Windows.Forms.Button();
            this.Reject_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Priority_Title = new System.Windows.Forms.Label();
            this.Area_Title = new System.Windows.Forms.Label();
            this.Area_Box = new System.Windows.Forms.ComboBox();
            this.Priority_Box = new System.Windows.Forms.ComboBox();
            this.RejectReason_Title = new System.Windows.Forms.Label();
            this.RejectReason_Box = new System.Windows.Forms.TextBox();
            this.Error_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // List_Incidents
            // 
            this.List_Incidents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.List_Incidents.FormattingEnabled = true;
            this.List_Incidents.Location = new System.Drawing.Point(219, 160);
            this.List_Incidents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.List_Incidents.Name = "List_Incidents";
            this.List_Incidents.Size = new System.Drawing.Size(725, 28);
            this.List_Incidents.TabIndex = 1;
            this.List_Incidents.SelectedIndexChanged += new System.EventHandler(this.List_Incidents_SelectedIndexChanged);
            this.List_Incidents.Click += new System.EventHandler(this.List_Incidents_Click);
            // 
            // date_title
            // 
            this.date_title.AutoSize = true;
            this.date_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_title.Location = new System.Drawing.Point(564, 271);
            this.date_title.Name = "date_title";
            this.date_title.Size = new System.Drawing.Size(68, 25);
            this.date_title.TabIndex = 2;
            this.date_title.Text = "Date:";
            // 
            // Department_title
            // 
            this.Department_title.AutoSize = true;
            this.Department_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Department_title.Location = new System.Drawing.Point(75, 318);
            this.Department_title.Name = "Department_title";
            this.Department_title.Size = new System.Drawing.Size(147, 25);
            this.Department_title.TabIndex = 3;
            this.Department_title.Text = "Department: ";
            // 
            // Description_title
            // 
            this.Description_title.AutoSize = true;
            this.Description_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description_title.Location = new System.Drawing.Point(75, 369);
            this.Description_title.Name = "Description_title";
            this.Description_title.Size = new System.Drawing.Size(145, 25);
            this.Description_title.TabIndex = 4;
            this.Description_title.Text = "Description: ";
            // 
            // Employee_title
            // 
            this.Employee_title.AutoSize = true;
            this.Employee_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employee_title.Location = new System.Drawing.Point(75, 266);
            this.Employee_title.Name = "Employee_title";
            this.Employee_title.Size = new System.Drawing.Size(129, 25);
            this.Employee_title.TabIndex = 5;
            this.Employee_title.Text = "Employee: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Incident: ";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(240, 41);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(552, 65);
            this.title_label.TabIndex = 7;
            this.title_label.Text = "REVIEW INCIDENT";
            // 
            // Date_Text
            // 
            this.Date_Text.AutoSize = true;
            this.Date_Text.Location = new System.Drawing.Point(645, 275);
            this.Date_Text.Name = "Date_Text";
            this.Date_Text.Size = new System.Drawing.Size(67, 20);
            this.Date_Text.TabIndex = 8;
            this.Date_Text.Text = "pruebas";
            // 
            // Department_Text
            // 
            this.Department_Text.AutoSize = true;
            this.Department_Text.Location = new System.Drawing.Point(216, 318);
            this.Department_Text.Name = "Department_Text";
            this.Department_Text.Size = new System.Drawing.Size(67, 20);
            this.Department_Text.TabIndex = 9;
            this.Department_Text.Text = "pruebas";
            // 
            // Description_Text
            // 
            this.Description_Text.AutoSize = true;
            this.Description_Text.Location = new System.Drawing.Point(213, 369);
            this.Description_Text.MaximumSize = new System.Drawing.Size(562, 0);
            this.Description_Text.Name = "Description_Text";
            this.Description_Text.Size = new System.Drawing.Size(67, 20);
            this.Description_Text.TabIndex = 10;
            this.Description_Text.Text = "pruebas";
            // 
            // Employee_Text
            // 
            this.Employee_Text.AutoSize = true;
            this.Employee_Text.Location = new System.Drawing.Point(216, 271);
            this.Employee_Text.Name = "Employee_Text";
            this.Employee_Text.Size = new System.Drawing.Size(67, 20);
            this.Employee_Text.TabIndex = 11;
            this.Employee_Text.Text = "pruebas";
            // 
            // Accept_Button
            // 
            this.Accept_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept_Button.Location = new System.Drawing.Point(83, 544);
            this.Accept_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(161, 75);
            this.Accept_Button.TabIndex = 12;
            this.Accept_Button.Text = "ACCEPT";
            this.Accept_Button.UseVisualStyleBackColor = true;
            this.Accept_Button.Click += new System.EventHandler(this.Accept_Button_Click);
            // 
            // Reject_Button
            // 
            this.Reject_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reject_Button.Location = new System.Drawing.Point(273, 544);
            this.Reject_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Reject_Button.Name = "Reject_Button";
            this.Reject_Button.Size = new System.Drawing.Size(161, 75);
            this.Reject_Button.TabIndex = 13;
            this.Reject_Button.Text = "REJECT";
            this.Reject_Button.UseVisualStyleBackColor = true;
            this.Reject_Button.Click += new System.EventHandler(this.Reject_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Button.Location = new System.Drawing.Point(784, 544);
            this.Save_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(161, 75);
            this.Save_Button.TabIndex = 14;
            this.Save_Button.Text = "SAVE";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // Priority_Title
            // 
            this.Priority_Title.AutoSize = true;
            this.Priority_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Priority_Title.Location = new System.Drawing.Point(75, 425);
            this.Priority_Title.Name = "Priority_Title";
            this.Priority_Title.Size = new System.Drawing.Size(101, 25);
            this.Priority_Title.TabIndex = 15;
            this.Priority_Title.Text = "Priority: ";
            // 
            // Area_Title
            // 
            this.Area_Title.AutoSize = true;
            this.Area_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Area_Title.Location = new System.Drawing.Point(564, 321);
            this.Area_Title.Name = "Area_Title";
            this.Area_Title.Size = new System.Drawing.Size(75, 25);
            this.Area_Title.TabIndex = 16;
            this.Area_Title.Text = "Area: ";
            // 
            // Area_Box
            // 
            this.Area_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Area_Box.FormattingEnabled = true;
            this.Area_Box.Location = new System.Drawing.Point(648, 321);
            this.Area_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Area_Box.Name = "Area_Box";
            this.Area_Box.Size = new System.Drawing.Size(136, 28);
            this.Area_Box.TabIndex = 17;
            // 
            // Priority_Box
            // 
            this.Priority_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Priority_Box.FormattingEnabled = true;
            this.Priority_Box.Location = new System.Drawing.Point(217, 419);
            this.Priority_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Priority_Box.Name = "Priority_Box";
            this.Priority_Box.Size = new System.Drawing.Size(136, 28);
            this.Priority_Box.TabIndex = 18;
            // 
            // RejectReason_Title
            // 
            this.RejectReason_Title.AutoSize = true;
            this.RejectReason_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejectReason_Title.Location = new System.Drawing.Point(75, 422);
            this.RejectReason_Title.Name = "RejectReason_Title";
            this.RejectReason_Title.Size = new System.Drawing.Size(212, 25);
            this.RejectReason_Title.TabIndex = 19;
            this.RejectReason_Title.Text = "Rejection Reason: ";
            // 
            // RejectReason_Box
            // 
            this.RejectReason_Box.Location = new System.Drawing.Point(293, 420);
            this.RejectReason_Box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RejectReason_Box.Name = "RejectReason_Box";
            this.RejectReason_Box.Size = new System.Drawing.Size(653, 26);
            this.RejectReason_Box.TabIndex = 20;
            // 
            // Error_Label
            // 
            this.Error_Label.AutoSize = true;
            this.Error_Label.ForeColor = System.Drawing.Color.Red;
            this.Error_Label.Location = new System.Drawing.Point(645, 510);
            this.Error_Label.Name = "Error_Label";
            this.Error_Label.Size = new System.Drawing.Size(0, 20);
            this.Error_Label.TabIndex = 21;
            // 
            // ReviewIncidentManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 682);
            this.Controls.Add(this.Error_Label);
            this.Controls.Add(this.RejectReason_Box);
            this.Controls.Add(this.RejectReason_Title);
            this.Controls.Add(this.Priority_Box);
            this.Controls.Add(this.Area_Box);
            this.Controls.Add(this.Area_Title);
            this.Controls.Add(this.Priority_Title);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Reject_Button);
            this.Controls.Add(this.Accept_Button);
            this.Controls.Add(this.Employee_Text);
            this.Controls.Add(this.Description_Text);
            this.Controls.Add(this.Department_Text);
            this.Controls.Add(this.Date_Text);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Employee_title);
            this.Controls.Add(this.Description_title);
            this.Controls.Add(this.Department_title);
            this.Controls.Add(this.date_title);
            this.Controls.Add(this.List_Incidents);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReviewIncidentManteHos";
            this.Text = "ReviewIncidentManteHos";
            this.Load += new System.EventHandler(this.ReviewIncidentManteHos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox List_Incidents;
        private System.Windows.Forms.Label date_title;
        private System.Windows.Forms.Label Department_title;
        private System.Windows.Forms.Label Description_title;
        private System.Windows.Forms.Label Employee_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label Date_Text;
        private System.Windows.Forms.Label Department_Text;
        private System.Windows.Forms.Label Description_Text;
        private System.Windows.Forms.Label Employee_Text;
        private System.Windows.Forms.Button Accept_Button;
        private System.Windows.Forms.Button Reject_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label Priority_Title;
        private System.Windows.Forms.Label Area_Title;
        private System.Windows.Forms.ComboBox Area_Box;
        private System.Windows.Forms.ComboBox Priority_Box;
        private System.Windows.Forms.Label RejectReason_Title;
        private System.Windows.Forms.TextBox RejectReason_Box;
        private System.Windows.Forms.Label Error_Label;
    }
}