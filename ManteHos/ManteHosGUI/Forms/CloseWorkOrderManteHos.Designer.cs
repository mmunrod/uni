namespace ManteHosGUI.Forms
{
    partial class CloseWorkOrderManteHos
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
            this.workordersAssigned = new System.Windows.Forms.Label();
            this.comboBoxworders = new System.Windows.Forms.ComboBox();
            this.closeWorderTitle = new System.Windows.Forms.Label();
            this.idWorder = new System.Windows.Forms.Label();
            this.start_date = new System.Windows.Forms.Label();
            this.repreport = new System.Windows.Forms.Label();
            this.usedParts = new System.Windows.Forms.Label();
            this.totCost = new System.Windows.Forms.Label();
            this.partsGridView = new System.Windows.Forms.DataGridView();
            this.opsLista = new System.Windows.Forms.ListView();
            this.opeList = new System.Windows.Forms.Label();
            this.reportTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.reportWarning = new System.Windows.Forms.Label();
            this.enddateLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.incidentLabel = new System.Windows.Forms.Label();
            this.name_op = new System.Windows.Forms.Label();
            this.daterror = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // workordersAssigned
            // 
            this.workordersAssigned.AutoSize = true;
            this.workordersAssigned.Location = new System.Drawing.Point(61, 91);
            this.workordersAssigned.Name = "workordersAssigned";
            this.workordersAssigned.Size = new System.Drawing.Size(177, 20);
            this.workordersAssigned.TabIndex = 1;
            this.workordersAssigned.Text = "Work orders asigned to:";
            // 
            // comboBoxworders
            // 
            this.comboBoxworders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxworders.FormattingEnabled = true;
            this.comboBoxworders.Location = new System.Drawing.Point(489, 87);
            this.comboBoxworders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxworders.Name = "comboBoxworders";
            this.comboBoxworders.Size = new System.Drawing.Size(475, 28);
            this.comboBoxworders.TabIndex = 2;
            this.comboBoxworders.SelectedIndexChanged += new System.EventHandler(this.comboBoxworders_SelectedIndexChanged);
            // 
            // closeWorderTitle
            // 
            this.closeWorderTitle.AutoSize = true;
            this.closeWorderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeWorderTitle.Location = new System.Drawing.Point(312, 23);
            this.closeWorderTitle.Name = "closeWorderTitle";
            this.closeWorderTitle.Size = new System.Drawing.Size(417, 40);
            this.closeWorderTitle.TabIndex = 3;
            this.closeWorderTitle.Text = "CLOSE WORK ORDER";
            // 
            // idWorder
            // 
            this.idWorder.AutoSize = true;
            this.idWorder.Location = new System.Drawing.Point(61, 175);
            this.idWorder.Name = "idWorder";
            this.idWorder.Size = new System.Drawing.Size(162, 20);
            this.idWorder.TabIndex = 4;
            this.idWorder.Text = "Work Order selected: ";
            // 
            // start_date
            // 
            this.start_date.AutoSize = true;
            this.start_date.Location = new System.Drawing.Point(486, 175);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(91, 20);
            this.start_date.TabIndex = 5;
            this.start_date.Text = "Start Date: ";
            // 
            // repreport
            // 
            this.repreport.AutoSize = true;
            this.repreport.Location = new System.Drawing.Point(61, 314);
            this.repreport.Name = "repreport";
            this.repreport.Size = new System.Drawing.Size(113, 20);
            this.repreport.TabIndex = 6;
            this.repreport.Text = "Repair Report:";
            // 
            // usedParts
            // 
            this.usedParts.AutoSize = true;
            this.usedParts.Location = new System.Drawing.Point(58, 426);
            this.usedParts.Name = "usedParts";
            this.usedParts.Size = new System.Drawing.Size(96, 20);
            this.usedParts.TabIndex = 7;
            this.usedParts.Text = "Parts Used: ";
            // 
            // totCost
            // 
            this.totCost.AutoSize = true;
            this.totCost.Location = new System.Drawing.Point(61, 689);
            this.totCost.Name = "totCost";
            this.totCost.Size = new System.Drawing.Size(179, 20);
            this.totCost.TabIndex = 8;
            this.totCost.Text = "Total cost of used parts:";
            // 
            // partsGridView
            // 
            this.partsGridView.AllowUserToAddRows = false;
            this.partsGridView.AllowUserToDeleteRows = false;
            this.partsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsGridView.Location = new System.Drawing.Point(177, 426);
            this.partsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.partsGridView.MultiSelect = false;
            this.partsGridView.Name = "partsGridView";
            this.partsGridView.ReadOnly = true;
            this.partsGridView.RowHeadersWidth = 62;
            this.partsGridView.RowTemplate.Height = 28;
            this.partsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.partsGridView.Size = new System.Drawing.Size(302, 240);
            this.partsGridView.TabIndex = 9;
            // 
            // opsLista
            // 
            this.opsLista.HideSelection = false;
            this.opsLista.Location = new System.Drawing.Point(666, 426);
            this.opsLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.opsLista.Name = "opsLista";
            this.opsLista.Size = new System.Drawing.Size(299, 240);
            this.opsLista.TabIndex = 10;
            this.opsLista.UseCompatibleStateImageBehavior = false;
            // 
            // opeList
            // 
            this.opeList.AutoSize = true;
            this.opeList.Location = new System.Drawing.Point(506, 426);
            this.opeList.Name = "opeList";
            this.opeList.Size = new System.Drawing.Size(154, 20);
            this.opeList.TabIndex = 11;
            this.opeList.Text = "Assigned Operators:";
            // 
            // reportTextBox
            // 
            this.reportTextBox.Location = new System.Drawing.Point(221, 310);
            this.reportTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reportTextBox.Name = "reportTextBox";
            this.reportTextBox.Size = new System.Drawing.Size(743, 26);
            this.reportTextBox.TabIndex = 12;
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(831, 689);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(134, 59);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "CLOSE";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // reportWarning
            // 
            this.reportWarning.AutoSize = true;
            this.reportWarning.ForeColor = System.Drawing.Color.Red;
            this.reportWarning.Location = new System.Drawing.Point(218, 354);
            this.reportWarning.Name = "reportWarning";
            this.reportWarning.Size = new System.Drawing.Size(421, 20);
            this.reportWarning.TabIndex = 14;
            this.reportWarning.Text = "*A repair report is required in order to close the Work Order";
            // 
            // enddateLabel
            // 
            this.enddateLabel.AutoSize = true;
            this.enddateLabel.Location = new System.Drawing.Point(486, 227);
            this.enddateLabel.Name = "enddateLabel";
            this.enddateLabel.Size = new System.Drawing.Size(81, 20);
            this.enddateLabel.TabIndex = 15;
            this.enddateLabel.Text = "End Date:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(589, 221);
            this.endDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(375, 26);
            this.endDatePicker.TabIndex = 16;
            // 
            // incidentLabel
            // 
            this.incidentLabel.AutoSize = true;
            this.incidentLabel.Location = new System.Drawing.Point(61, 227);
            this.incidentLabel.Name = "incidentLabel";
            this.incidentLabel.Size = new System.Drawing.Size(74, 20);
            this.incidentLabel.TabIndex = 17;
            this.incidentLabel.Text = "Incident: ";
            // 
            // name_op
            // 
            this.name_op.AutoSize = true;
            this.name_op.Location = new System.Drawing.Point(237, 91);
            this.name_op.Name = "name_op";
            this.name_op.Size = new System.Drawing.Size(0, 20);
            this.name_op.TabIndex = 18;
            // 
            // daterror
            // 
            this.daterror.AutoSize = true;
            this.daterror.ForeColor = System.Drawing.Color.Red;
            this.daterror.Location = new System.Drawing.Point(589, 256);
            this.daterror.Name = "daterror";
            this.daterror.Size = new System.Drawing.Size(340, 20);
            this.daterror.TabIndex = 19;
            this.daterror.Text = "*The end date must be later than the start date";
            this.daterror.Visible = false;
            // 
            // CloseWorkOrderManteHos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 768);
            this.Controls.Add(this.daterror);
            this.Controls.Add(this.name_op);
            this.Controls.Add(this.incidentLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.enddateLabel);
            this.Controls.Add(this.reportWarning);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.reportTextBox);
            this.Controls.Add(this.opeList);
            this.Controls.Add(this.opsLista);
            this.Controls.Add(this.partsGridView);
            this.Controls.Add(this.totCost);
            this.Controls.Add(this.usedParts);
            this.Controls.Add(this.repreport);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.idWorder);
            this.Controls.Add(this.closeWorderTitle);
            this.Controls.Add(this.comboBoxworders);
            this.Controls.Add(this.workordersAssigned);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CloseWorkOrderManteHos";
            this.Text = "CloseWorkOrderManteHos";
            this.Load += new System.EventHandler(this.CloseWorkOrderManteHos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.partsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label workordersAssigned;
        private System.Windows.Forms.ComboBox comboBoxworders;
        private System.Windows.Forms.Label closeWorderTitle;
        private System.Windows.Forms.Label idWorder;
        private System.Windows.Forms.Label start_date;
        private System.Windows.Forms.Label repreport;
        private System.Windows.Forms.Label usedParts;
        private System.Windows.Forms.Label totCost;
        private System.Windows.Forms.DataGridView partsGridView;
        private System.Windows.Forms.ListView opsLista;
        private System.Windows.Forms.Label opeList;
        private System.Windows.Forms.TextBox reportTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label reportWarning;
        private System.Windows.Forms.Label enddateLabel;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label incidentLabel;
        private System.Windows.Forms.Label name_op;
        private System.Windows.Forms.Label daterror;
    }
}