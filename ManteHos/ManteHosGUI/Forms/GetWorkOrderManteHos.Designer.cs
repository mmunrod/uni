namespace ManteHosGUI.Forms
{
    partial class GetWorkOrderManteHos
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.id_workOrder_text = new System.Windows.Forms.Label();
            this.allOperatos_gridView = new System.Windows.Forms.DataGridView();
            this.id_columna_all = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assigenedOpperators_gridView = new System.Windows.Forms.DataGridView();
            this.id_columna_assigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullName_columna_assigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shift_columna_assigned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_button = new System.Windows.Forms.Button();
            this.remove_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.Error_label = new System.Windows.Forms.Label();
            this.partsUsed_gridView = new System.Windows.Forms.DataGridView();
            this.part_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description_columna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.sdateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.allOperatos_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assigenedOpperators_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsUsed_gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Incident id: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parts Used :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 461);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "ASSIGNED OPERATORS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(749, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "AVAILABLE OPERATORS";
            // 
            // id_workOrder_text
            // 
            this.id_workOrder_text.AutoSize = true;
            this.id_workOrder_text.Location = new System.Drawing.Point(210, 131);
            this.id_workOrder_text.Name = "id_workOrder_text";
            this.id_workOrder_text.Size = new System.Drawing.Size(0, 20);
            this.id_workOrder_text.TabIndex = 8;
            // 
            // allOperatos_gridView
            // 
            this.allOperatos_gridView.AllowUserToAddRows = false;
            this.allOperatos_gridView.AllowUserToDeleteRows = false;
            this.allOperatos_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allOperatos_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_columna_all,
            this.fullName_columna,
            this.shift_columna});
            this.allOperatos_gridView.Location = new System.Drawing.Point(640, 511);
            this.allOperatos_gridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allOperatos_gridView.MultiSelect = false;
            this.allOperatos_gridView.Name = "allOperatos_gridView";
            this.allOperatos_gridView.ReadOnly = true;
            this.allOperatos_gridView.RowHeadersWidth = 51;
            this.allOperatos_gridView.RowTemplate.Height = 24;
            this.allOperatos_gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allOperatos_gridView.Size = new System.Drawing.Size(446, 278);
            this.allOperatos_gridView.TabIndex = 11;
            this.allOperatos_gridView.SelectionChanged += new System.EventHandler(this.allOperatos_gridView_SelectionChanged);
            // 
            // id_columna_all
            // 
            this.id_columna_all.HeaderText = "Id";
            this.id_columna_all.MinimumWidth = 6;
            this.id_columna_all.Name = "id_columna_all";
            this.id_columna_all.ReadOnly = true;
            this.id_columna_all.Width = 50;
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
            this.shift_columna.Width = 75;
            // 
            // assigenedOpperators_gridView
            // 
            this.assigenedOpperators_gridView.AllowUserToAddRows = false;
            this.assigenedOpperators_gridView.AllowUserToDeleteRows = false;
            this.assigenedOpperators_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assigenedOpperators_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_columna_assigned,
            this.fullName_columna_assigned,
            this.shift_columna_assigned});
            this.assigenedOpperators_gridView.Location = new System.Drawing.Point(133, 511);
            this.assigenedOpperators_gridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.assigenedOpperators_gridView.MultiSelect = false;
            this.assigenedOpperators_gridView.Name = "assigenedOpperators_gridView";
            this.assigenedOpperators_gridView.ReadOnly = true;
            this.assigenedOpperators_gridView.RowHeadersWidth = 51;
            this.assigenedOpperators_gridView.RowTemplate.Height = 24;
            this.assigenedOpperators_gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.assigenedOpperators_gridView.Size = new System.Drawing.Size(446, 278);
            this.assigenedOpperators_gridView.TabIndex = 12;
            this.assigenedOpperators_gridView.SelectionChanged += new System.EventHandler(this.assigned_gridView_SelectionChanged);
            // 
            // id_columna_assigned
            // 
            this.id_columna_assigned.HeaderText = "Id";
            this.id_columna_assigned.MinimumWidth = 6;
            this.id_columna_assigned.Name = "id_columna_assigned";
            this.id_columna_assigned.ReadOnly = true;
            this.id_columna_assigned.Width = 50;
            // 
            // fullName_columna_assigned
            // 
            this.fullName_columna_assigned.HeaderText = "Full Name";
            this.fullName_columna_assigned.MinimumWidth = 6;
            this.fullName_columna_assigned.Name = "fullName_columna_assigned";
            this.fullName_columna_assigned.ReadOnly = true;
            this.fullName_columna_assigned.Width = 150;
            // 
            // shift_columna_assigned
            // 
            this.shift_columna_assigned.HeaderText = "Shift";
            this.shift_columna_assigned.MinimumWidth = 6;
            this.shift_columna_assigned.Name = "shift_columna_assigned";
            this.shift_columna_assigned.ReadOnly = true;
            this.shift_columna_assigned.Width = 75;
            // 
            // add_button
            // 
            this.add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_button.Location = new System.Drawing.Point(1107, 536);
            this.add_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(100, 49);
            this.add_button.TabIndex = 13;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // remove_button
            // 
            this.remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove_button.Location = new System.Drawing.Point(15, 536);
            this.remove_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(100, 49);
            this.remove_button.TabIndex = 14;
            this.remove_button.Text = "REMOVE";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(1107, 800);
            this.save_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(100, 68);
            this.save_button.TabIndex = 15;
            this.save_button.Text = "SAVE";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // Error_label
            // 
            this.Error_label.AutoSize = true;
            this.Error_label.ForeColor = System.Drawing.Color.Red;
            this.Error_label.Location = new System.Drawing.Point(637, 826);
            this.Error_label.Name = "Error_label";
            this.Error_label.Size = new System.Drawing.Size(0, 20);
            this.Error_label.TabIndex = 17;
            // 
            // partsUsed_gridView
            // 
            this.partsUsed_gridView.AllowUserToAddRows = false;
            this.partsUsed_gridView.AllowUserToDeleteRows = false;
            this.partsUsed_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsUsed_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.part_columna,
            this.amount_columna,
            this.description_columna});
            this.partsUsed_gridView.Location = new System.Drawing.Point(214, 240);
            this.partsUsed_gridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partsUsed_gridView.MultiSelect = false;
            this.partsUsed_gridView.Name = "partsUsed_gridView";
            this.partsUsed_gridView.ReadOnly = true;
            this.partsUsed_gridView.RowHeadersWidth = 51;
            this.partsUsed_gridView.RowTemplate.Height = 24;
            this.partsUsed_gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsUsed_gridView.Size = new System.Drawing.Size(544, 142);
            this.partsUsed_gridView.TabIndex = 18;
            // 
            // part_columna
            // 
            this.part_columna.HeaderText = "Part";
            this.part_columna.MinimumWidth = 6;
            this.part_columna.Name = "part_columna";
            this.part_columna.ReadOnly = true;
            this.part_columna.Width = 125;
            // 
            // amount_columna
            // 
            this.amount_columna.HeaderText = "Amount";
            this.amount_columna.MinimumWidth = 6;
            this.amount_columna.Name = "amount_columna";
            this.amount_columna.ReadOnly = true;
            this.amount_columna.Width = 75;
            // 
            // description_columna
            // 
            this.description_columna.HeaderText = "Description";
            this.description_columna.MinimumWidth = 6;
            this.description_columna.Name = "description_columna";
            this.description_columna.ReadOnly = true;
            this.description_columna.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(459, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 46);
            this.label3.TabIndex = 19;
            this.label3.Text = "WORK ORDER";
            // 
            // sdateLabel
            // 
            this.sdateLabel.AutoSize = true;
            this.sdateLabel.Location = new System.Drawing.Point(177, 178);
            this.sdateLabel.Name = "sdateLabel";
            this.sdateLabel.Size = new System.Drawing.Size(0, 20);
            this.sdateLabel.TabIndex = 20;
            // 
            // GetWorkOrderManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 919);
            this.Controls.Add(this.sdateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.partsUsed_gridView);
            this.Controls.Add(this.Error_label);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.assigenedOpperators_gridView);
            this.Controls.Add(this.allOperatos_gridView);
            this.Controls.Add(this.id_workOrder_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GetWorkOrderManteHos";
            this.Text = "GetWorkOrderManteHos";
            this.Load += new System.EventHandler(this.GetWorkOrderManteHos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allOperatos_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assigenedOpperators_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partsUsed_gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label id_workOrder_text;
        private System.Windows.Forms.DataGridView allOperatos_gridView;
        private System.Windows.Forms.DataGridView assigenedOpperators_gridView;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label Error_label;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_columna_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_columna_assigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullName_columna_assigned;
        private System.Windows.Forms.DataGridViewTextBoxColumn shift_columna_assigned;
        private System.Windows.Forms.DataGridView partsUsed_gridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_columna;
        private System.Windows.Forms.DataGridViewTextBoxColumn description_columna;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sdateLabel;
    }
}