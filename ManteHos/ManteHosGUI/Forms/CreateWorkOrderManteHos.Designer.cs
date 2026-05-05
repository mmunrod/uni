namespace ManteHosGUI.Forms
{
    partial class CreateWorkOrderManteHos
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
            this.startDate_label = new System.Windows.Forms.Label();
            this.Operator_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.save_button = new System.Windows.Forms.Button();
            this.add_operator_button = new System.Windows.Forms.Button();
            this.remove_operator_button = new System.Windows.Forms.Button();
            this.StartDate_Pick = new System.Windows.Forms.DateTimePicker();
            this.assigned_gridView = new System.Windows.Forms.DataGridView();
            this.id_columna_assigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allOperators_gridView = new System.Windows.Forms.DataGridView();
            this.id_columna_all = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName_columna_all = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_columna_all = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error_label = new System.Windows.Forms.Label();
            this.Incident_label = new System.Windows.Forms.Label();
            this.Identificacion_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.assigned_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allOperators_gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_label.Location = new System.Drawing.Point(358, 28);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(422, 39);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "CREATE WORK ORDER";
            // 
            // startDate_label
            // 
            this.startDate_label.AutoSize = true;
            this.startDate_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate_label.Location = new System.Drawing.Point(29, 146);
            this.startDate_label.Name = "startDate_label";
            this.startDate_label.Size = new System.Drawing.Size(70, 16);
            this.startDate_label.TabIndex = 1;
            this.startDate_label.Text = "Start date :";
            // 
            // Operator_label
            // 
            this.Operator_label.AutoSize = true;
            this.Operator_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Operator_label.Location = new System.Drawing.Point(29, 195);
            this.Operator_label.Name = "Operator_label";
            this.Operator_label.Size = new System.Drawing.Size(73, 16);
            this.Operator_label.TabIndex = 3;
            this.Operator_label.Text = "Operators :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(230, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "ASSIGNED OPERATORS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(712, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "AVAILABLE OPERATORS";
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(996, 536);
            this.save_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(89, 46);
            this.save_button.TabIndex = 7;
            this.save_button.Text = "SAVE";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // add_operator_button
            // 
            this.add_operator_button.Enabled = false;
            this.add_operator_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_operator_button.Location = new System.Drawing.Point(996, 286);
            this.add_operator_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_operator_button.Name = "add_operator_button";
            this.add_operator_button.Size = new System.Drawing.Size(89, 39);
            this.add_operator_button.TabIndex = 8;
            this.add_operator_button.Text = "ADD";
            this.add_operator_button.UseVisualStyleBackColor = true;
            this.add_operator_button.Click += new System.EventHandler(this.add_operator_button_Click);
            // 
            // remove_operator_button
            // 
            this.remove_operator_button.Enabled = false;
            this.remove_operator_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_operator_button.Location = new System.Drawing.Point(26, 286);
            this.remove_operator_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.remove_operator_button.Name = "remove_operator_button";
            this.remove_operator_button.Size = new System.Drawing.Size(89, 39);
            this.remove_operator_button.TabIndex = 9;
            this.remove_operator_button.Text = "REMOVE";
            this.remove_operator_button.UseVisualStyleBackColor = true;
            this.remove_operator_button.Click += new System.EventHandler(this.remove_operator_button_Click);
            // 
            // StartDate_Pick
            // 
            this.StartDate_Pick.Location = new System.Drawing.Point(127, 141);
            this.StartDate_Pick.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartDate_Pick.Name = "StartDate_Pick";
            this.StartDate_Pick.Size = new System.Drawing.Size(285, 22);
            this.StartDate_Pick.TabIndex = 14;
            // 
            // assigned_gridView
            // 
            this.assigned_gridView.AllowUserToAddRows = false;
            this.assigned_gridView.AllowUserToDeleteRows = false;
            this.assigned_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assigned_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_columna_assigned,
            this.fullName_columna,
            this.shift_columna});
            this.assigned_gridView.Location = new System.Drawing.Point(127, 259);
            this.assigned_gridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.assigned_gridView.MultiSelect = false;
            this.assigned_gridView.Name = "assigned_gridView";
            this.assigned_gridView.ReadOnly = true;
            this.assigned_gridView.RowHeadersWidth = 51;
            this.assigned_gridView.RowTemplate.Height = 24;
            this.assigned_gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assigned_gridView.Size = new System.Drawing.Size(396, 222);
            this.assigned_gridView.TabIndex = 16;
            this.assigned_gridView.SelectionChanged += new System.EventHandler(this.assigned_gridView_SelectionChanged);
            // 
            // id_columna_assigned
            // 
            this.id_columna_assigned.HeaderText = "Id";
            this.id_columna_assigned.MinimumWidth = 6;
            this.id_columna_assigned.Name = "id_columna_assigned";
            this.id_columna_assigned.ReadOnly = true;
            this.id_columna_assigned.Width = 50;
            // 
            // fullName_columna
            // 
            this.fullName_columna.HeaderText = "Full Name";
            this.fullName_columna.MinimumWidth = 6;
            this.fullName_columna.Name = "fullName_columna";
            this.fullName_columna.ReadOnly = true;
            this.fullName_columna.Width = 150;
            // 
            // shift_columna
            // 
            this.shift_columna.HeaderText = "Shift";
            this.shift_columna.MinimumWidth = 6;
            this.shift_columna.Name = "shift_columna";
            this.shift_columna.ReadOnly = true;
            this.shift_columna.Width = 125;
            // 
            // allOperators_gridView
            // 
            this.allOperators_gridView.AllowUserToAddRows = false;
            this.allOperators_gridView.AllowUserToDeleteRows = false;
            this.allOperators_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allOperators_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_columna_all,
            this.fullName_columna_all,
            this.shift_columna_all});
            this.allOperators_gridView.Location = new System.Drawing.Point(601, 259);
            this.allOperators_gridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allOperators_gridView.MultiSelect = false;
            this.allOperators_gridView.Name = "allOperators_gridView";
            this.allOperators_gridView.ReadOnly = true;
            this.allOperators_gridView.RowHeadersWidth = 51;
            this.allOperators_gridView.RowTemplate.Height = 24;
            this.allOperators_gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allOperators_gridView.Size = new System.Drawing.Size(389, 222);
            this.allOperators_gridView.TabIndex = 17;
            this.allOperators_gridView.SelectionChanged += new System.EventHandler(this.allOperators_gridView_SelectionChanged);
            // 
            // id_columna_all
            // 
            this.id_columna_all.HeaderText = "Id";
            this.id_columna_all.MinimumWidth = 6;
            this.id_columna_all.Name = "id_columna_all";
            this.id_columna_all.ReadOnly = true;
            this.id_columna_all.Width = 50;
            // 
            // fullName_columna_all
            // 
            this.fullName_columna_all.HeaderText = "Full Name";
            this.fullName_columna_all.MinimumWidth = 6;
            this.fullName_columna_all.Name = "fullName_columna_all";
            this.fullName_columna_all.ReadOnly = true;
            this.fullName_columna_all.Width = 150;
            // 
            // shift_columna_all
            // 
            this.shift_columna_all.HeaderText = "Shift";
            this.shift_columna_all.MinimumWidth = 6;
            this.shift_columna_all.Name = "shift_columna_all";
            this.shift_columna_all.ReadOnly = true;
            this.shift_columna_all.Width = 125;
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.ForeColor = System.Drawing.Color.Red;
            this.Error_label.Location = new System.Drawing.Point(598, 536);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(0, 16);
            this.Error_label.TabIndex = 18;
            // 
            // Incident_label
            // 
            this.Incident_label.AutoSize = true;
            this.Incident_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Incident_label.Location = new System.Drawing.Point(29, 95);
            this.Incident_label.Name = "Incident_label";
            this.Incident_label.Size = new System.Drawing.Size(73, 16);
            this.Incident_label.TabIndex = 19;
            this.Incident_label.Text = "Incident id: ";
            // 
            // Identificacion_text
            // 
            this.Identificacion_text.AutoSize = true;
            this.Identificacion_text.Location = new System.Drawing.Point(127, 95);
            this.Identificacion_text.Name = "Identificacion_text";
            this.Identificacion_text.Size = new System.Drawing.Size(0, 16);
            this.Identificacion_text.TabIndex = 20;
            // 
            // CreateWorkOrderManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 610);
            this.Controls.Add(this.Identificacion_text);
            this.Controls.Add(this.Incident_label);
            this.Controls.Add(this.Error_label);
            this.Controls.Add(this.allOperators_gridView);
            this.Controls.Add(this.assigned_gridView);
            this.Controls.Add(this.StartDate_Pick);
            this.Controls.Add(this.remove_operator_button);
            this.Controls.Add(this.add_operator_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Operator_label);
            this.Controls.Add(this.startDate_label);
            this.Controls.Add(this.title_label);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CreateWorkOrderManteHos";
            this.Text = "CreateWorkOrderManteHos";
            this.Load += new System.EventHandler(this.CreateWorkOrderManteHos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assigned_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allOperators_gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Label startDate_label;
        private System.Windows.Forms.Label Operator_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button add_operator_button;
        private System.Windows.Forms.Button remove_operator_button;
        private System.Windows.Forms.DateTimePicker StartDate_Pick;
        private System.Windows.Forms.DataGridView assigned_gridView;
        private System.Windows.Forms.DataGridView allOperators_gridView;
        private System.Windows.Forms.Label Error_label;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_columna_assigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_columna_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName_columna_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_columna_all;
        private System.Windows.Forms.Label Incident_label;
        private System.Windows.Forms.Label Identificacion_text;
    }
}