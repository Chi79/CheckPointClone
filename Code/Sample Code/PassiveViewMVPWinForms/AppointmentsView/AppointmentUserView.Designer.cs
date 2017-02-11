namespace AppointmentsView
{
    partial class frmAppointmentView
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
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtCompletionDate = new System.Windows.Forms.TextBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtAppointment = new System.Windows.Forms.TextBox();
            this.lblCompletionDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblAppointment = new System.Windows.Forms.Label();
            this.chkCompleted = new System.Windows.Forms.CheckBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(312, 247);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 51;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(231, 247);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 50;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("PT Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(43, 192);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 20);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.Text = "Status";
            // 
            // txtCompletionDate
            // 
            this.txtCompletionDate.Location = new System.Drawing.Point(401, 123);
            this.txtCompletionDate.Name = "txtCompletionDate";
            this.txtCompletionDate.Size = new System.Drawing.Size(118, 20);
            this.txtCompletionDate.TabIndex = 48;
            this.txtCompletionDate.TextChanged += new System.EventHandler(this.txtCompletionDate_TextChanged);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(401, 75);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(118, 20);
            this.txtDueDate.TabIndex = 47;
            this.txtDueDate.TextChanged += new System.EventHandler(this.txtDueDate_TextChanged);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(401, 36);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(118, 20);
            this.txtStartDate.TabIndex = 46;
            this.txtStartDate.TextChanged += new System.EventHandler(this.txtStartDate_TextChanged);
            // 
            // txtAppointment
            // 
            this.txtAppointment.Location = new System.Drawing.Point(43, 20);
            this.txtAppointment.Multiline = true;
            this.txtAppointment.Name = "txtAppointment";
            this.txtAppointment.Size = new System.Drawing.Size(242, 48);
            this.txtAppointment.TabIndex = 45;
            this.txtAppointment.TextChanged += new System.EventHandler(this.txtAppointment_TextChanged);
            // 
            // lblCompletionDate
            // 
            this.lblCompletionDate.AutoSize = true;
            this.lblCompletionDate.Location = new System.Drawing.Point(389, 107);
            this.lblCompletionDate.Name = "lblCompletionDate";
            this.lblCompletionDate.Size = new System.Drawing.Size(146, 13);
            this.lblCompletionDate.TabIndex = 44;
            this.lblCompletionDate.Text = "Completion Date mm/dd/yyyy";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(401, 59);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(114, 13);
            this.lblDueDate.TabIndex = 43;
            this.lblDueDate.Text = "Due Date mm/dd/yyyy";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(400, 20);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(116, 13);
            this.lblStartDate.TabIndex = 42;
            this.lblStartDate.Text = "Start Date mm/dd/yyyy";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(45, 71);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 41;
            this.lblPriority.Text = "Priority";
            // 
            // lblAppointment
            // 
            this.lblAppointment.AutoSize = true;
            this.lblAppointment.Location = new System.Drawing.Point(43, 4);
            this.lblAppointment.Name = "lblAppointment";
            this.lblAppointment.Size = new System.Drawing.Size(66, 13);
            this.lblAppointment.TabIndex = 40;
            this.lblAppointment.Text = "Appointment";
            // 
            // chkCompleted
            // 
            this.chkCompleted.AutoSize = true;
            this.chkCompleted.Location = new System.Drawing.Point(304, 125);
            this.chkCompleted.Name = "chkCompleted";
            this.chkCompleted.Size = new System.Drawing.Size(82, 17);
            this.chkCompleted.TabIndex = 39;
            this.chkCompleted.Text = "Completed?";
            this.chkCompleted.UseVisualStyleBackColor = true;
            this.chkCompleted.CheckedChanged += new System.EventHandler(this.chkCompleted_CheckedChanged);
            // 
            // cboPriority
            // 
            this.cboPriority.FormattingEnabled = true;
            this.cboPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cboPriority.Location = new System.Drawing.Point(45, 87);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(104, 21);
            this.cboPriority.TabIndex = 38;
            this.cboPriority.SelectedIndexChanged += new System.EventHandler(this.cboPriority_SelectedIndexChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(462, 159);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 37;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(381, 159);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 36;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(43, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(43, 146);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 34;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmAppointmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 285);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtCompletionDate);
            this.Controls.Add(this.txtDueDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtAppointment);
            this.Controls.Add(this.lblCompletionDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblAppointment);
            this.Controls.Add(this.chkCompleted);
            this.Controls.Add(this.cboPriority);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Name = "frmAppointmentView";
            this.Text = "AppointmentUserView";
            this.Load += new System.EventHandler(this.frmAppointmentView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtCompletionDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtAppointment;
        private System.Windows.Forms.Label lblCompletionDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblAppointment;
        private System.Windows.Forms.CheckBox chkCompleted;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
    }
}