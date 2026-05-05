namespace ManteHosGUI.Forms
{
    partial class CreateIncidentManteHos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Department_Box = new System.Windows.Forms.TextBox();
            this.Description_Box = new System.Windows.Forms.TextBox();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.Create_Button = new System.Windows.Forms.Button();
            this.Calendar = new System.Windows.Forms.DateTimePicker();
            this.Error_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORT INCIDENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date of the incident: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Department :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description :";
            // 
            // Department_Box
            // 
            this.Department_Box.Location = new System.Drawing.Point(206, 167);
            this.Department_Box.Name = "Department_Box";
            this.Department_Box.Size = new System.Drawing.Size(381, 22);
            this.Department_Box.TabIndex = 5;
            this.Department_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Department_Box_KeyDown);
            // 
            // Description_Box
            // 
            this.Description_Box.Location = new System.Drawing.Point(206, 226);
            this.Description_Box.MaximumSize = new System.Drawing.Size(4, 60);
            this.Description_Box.MinimumSize = new System.Drawing.Size(381, 22);
            this.Description_Box.Name = "Description_Box";
            this.Description_Box.Size = new System.Drawing.Size(381, 22);
            this.Description_Box.TabIndex = 6;
            this.Description_Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Description_Box_KeyUp);
            // 
            // Clear_Button
            // 
            this.Clear_Button.Location = new System.Drawing.Point(57, 328);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(95, 42);
            this.Clear_Button.TabIndex = 7;
            this.Clear_Button.Text = "CLEAR";
            this.Clear_Button.UseVisualStyleBackColor = true;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // Create_Button
            // 
            this.Create_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Button.Location = new System.Drawing.Point(492, 327);
            this.Create_Button.Name = "Create_Button";
            this.Create_Button.Size = new System.Drawing.Size(95, 42);
            this.Create_Button.TabIndex = 8;
            this.Create_Button.Text = "CREATE";
            this.Create_Button.UseVisualStyleBackColor = true;
            this.Create_Button.Click += new System.EventHandler(this.Create_Button_Click);
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(206, 112);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(200, 22);
            this.Calendar.TabIndex = 9;
            // 
            // Error_Label
            // 
            this.Error_Label.AutoSize = true;
            this.Error_Label.ForeColor = System.Drawing.Color.Red;
            this.Error_Label.Location = new System.Drawing.Point(206, 278);
            this.Error_Label.Name = "Error_Label";
            this.Error_Label.Size = new System.Drawing.Size(0, 16);
            this.Error_Label.TabIndex = 10;
            // 
            // CreateIncidentManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 413);
            this.Controls.Add(this.Error_Label);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.Create_Button);
            this.Controls.Add(this.Clear_Button);
            this.Controls.Add(this.Description_Box);
            this.Controls.Add(this.Department_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateIncidentManteHos";
            this.Text = "Report Incident";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Department_Box;
        private System.Windows.Forms.TextBox Description_Box;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Button Create_Button;
        private System.Windows.Forms.DateTimePicker Calendar;
        private System.Windows.Forms.Label Error_Label;
    }
}