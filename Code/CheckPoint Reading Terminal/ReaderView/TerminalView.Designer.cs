namespace ReaderViews
{
    partial class TerminalView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalView));
            this.lblScanTagRequest = new System.Windows.Forms.Label();
            this.lblWelcomeTo = new System.Windows.Forms.Label();
            this.btnToggleEndAppointmentPanel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelConfirmEndAppointment = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVerfityAsHost2 = new System.Windows.Forms.Label();
            this.lblVerifyAsHost1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEndAppointment = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtRegistrationFeedback = new System.Windows.Forms.TextBox();
            this.txtActiveAppointmentName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelConfirmEndAppointment.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblScanTagRequest
            // 
            this.lblScanTagRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScanTagRequest.AutoSize = true;
            this.lblScanTagRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanTagRequest.ForeColor = System.Drawing.Color.White;
            this.lblScanTagRequest.Location = new System.Drawing.Point(502, 562);
            this.lblScanTagRequest.Name = "lblScanTagRequest";
            this.lblScanTagRequest.Size = new System.Drawing.Size(935, 55);
            this.lblScanTagRequest.TabIndex = 0;
            this.lblScanTagRequest.Text = "Please scan you tag on the reader below";
            // 
            // lblWelcomeTo
            // 
            this.lblWelcomeTo.AutoSize = true;
            this.lblWelcomeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTo.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeTo.Location = new System.Drawing.Point(770, 303);
            this.lblWelcomeTo.Name = "lblWelcomeTo";
            this.lblWelcomeTo.Size = new System.Drawing.Size(401, 73);
            this.lblWelcomeTo.TabIndex = 1;
            this.lblWelcomeTo.Text = "Welcome To";
            // 
            // btnToggleEndAppointmentPanel
            // 
            this.btnToggleEndAppointmentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnToggleEndAppointmentPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnToggleEndAppointmentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleEndAppointmentPanel.ForeColor = System.Drawing.Color.White;
            this.btnToggleEndAppointmentPanel.Location = new System.Drawing.Point(1, 1052);
            this.btnToggleEndAppointmentPanel.Name = "btnToggleEndAppointmentPanel";
            this.btnToggleEndAppointmentPanel.Size = new System.Drawing.Size(203, 29);
            this.btnToggleEndAppointmentPanel.TabIndex = 5;
            this.btnToggleEndAppointmentPanel.TabStop = false;
            this.btnToggleEndAppointmentPanel.Text = "End Appointment";
            this.btnToggleEndAppointmentPanel.UseVisualStyleBackColor = false;
            this.btnToggleEndAppointmentPanel.Click += new System.EventHandler(this.btnToggleEndAppointmentPanel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1944, 278);
            this.panel1.TabIndex = 6;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(522, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(900, 272);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panelConfirmEndAppointment
            // 
            this.panelConfirmEndAppointment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConfirmEndAppointment.Controls.Add(this.lblMessage);
            this.panelConfirmEndAppointment.Controls.Add(this.panel2);
            this.panelConfirmEndAppointment.Controls.Add(this.txtPassword);
            this.panelConfirmEndAppointment.Controls.Add(this.btnEndAppointment);
            this.panelConfirmEndAppointment.Controls.Add(this.lblPassword);
            this.panelConfirmEndAppointment.Location = new System.Drawing.Point(1, 812);
            this.panelConfirmEndAppointment.Name = "panelConfirmEndAppointment";
            this.panelConfirmEndAppointment.Size = new System.Drawing.Size(202, 238);
            this.panelConfirmEndAppointment.TabIndex = 8;
            this.panelConfirmEndAppointment.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(40, 167);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblVerfityAsHost2);
            this.panel2.Controls.Add(this.lblVerifyAsHost1);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 95);
            this.panel2.TabIndex = 5;
            // 
            // lblVerfityAsHost2
            // 
            this.lblVerfityAsHost2.AutoSize = true;
            this.lblVerfityAsHost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerfityAsHost2.ForeColor = System.Drawing.Color.Black;
            this.lblVerfityAsHost2.Location = new System.Drawing.Point(22, 47);
            this.lblVerfityAsHost2.Name = "lblVerfityAsHost2";
            this.lblVerfityAsHost2.Size = new System.Drawing.Size(165, 20);
            this.lblVerfityAsHost2.TabIndex = 6;
            this.lblVerfityAsHost2.Text = "to end appointment";
            // 
            // lblVerifyAsHost1
            // 
            this.lblVerifyAsHost1.AutoSize = true;
            this.lblVerifyAsHost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerifyAsHost1.ForeColor = System.Drawing.Color.Black;
            this.lblVerifyAsHost1.Location = new System.Drawing.Point(22, 27);
            this.lblVerifyAsHost1.Name = "lblVerifyAsHost1";
            this.lblVerifyAsHost1.Size = new System.Drawing.Size(119, 20);
            this.lblVerifyAsHost1.TabIndex = 5;
            this.lblVerifyAsHost1.Text = "Verify as host";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(29, 140);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TabStop = false;
            // 
            // btnEndAppointment
            // 
            this.btnEndAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnEndAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndAppointment.Location = new System.Drawing.Point(27, 186);
            this.btnEndAppointment.Name = "btnEndAppointment";
            this.btnEndAppointment.Size = new System.Drawing.Size(140, 45);
            this.btnEndAppointment.TabIndex = 2;
            this.btnEndAppointment.Text = "End Appointment";
            this.btnEndAppointment.UseVisualStyleBackColor = false;
            this.btnEndAppointment.Click += new System.EventHandler(this.btnEndAppointment_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(25, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(86, 20);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // txtRegistrationFeedback
            // 
            this.txtRegistrationFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtRegistrationFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegistrationFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrationFeedback.Location = new System.Drawing.Point(1, 689);
            this.txtRegistrationFeedback.Name = "txtRegistrationFeedback";
            this.txtRegistrationFeedback.ReadOnly = true;
            this.txtRegistrationFeedback.Size = new System.Drawing.Size(1938, 109);
            this.txtRegistrationFeedback.TabIndex = 9;
            this.txtRegistrationFeedback.TabStop = false;
            this.txtRegistrationFeedback.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActiveAppointmentName
            // 
            this.txtActiveAppointmentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtActiveAppointmentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtActiveAppointmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActiveAppointmentName.ForeColor = System.Drawing.Color.White;
            this.txtActiveAppointmentName.Location = new System.Drawing.Point(1, 416);
            this.txtActiveAppointmentName.Name = "txtActiveAppointmentName";
            this.txtActiveAppointmentName.ReadOnly = true;
            this.txtActiveAppointmentName.ShortcutsEnabled = false;
            this.txtActiveAppointmentName.Size = new System.Drawing.Size(1942, 109);
            this.txtActiveAppointmentName.TabIndex = 10;
            this.txtActiveAppointmentName.TabStop = false;
            this.txtActiveAppointmentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TerminalView
            // 
            this.AcceptButton = this.btnEndAppointment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1940, 1082);
            this.Controls.Add(this.txtActiveAppointmentName);
            this.Controls.Add(this.txtRegistrationFeedback);
            this.Controls.Add(this.panelConfirmEndAppointment);
            this.Controls.Add(this.lblWelcomeTo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToggleEndAppointmentPanel);
            this.Controls.Add(this.lblScanTagRequest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "TerminalView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPoint Reading Terminal";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelConfirmEndAppointment.ResumeLayout(false);
            this.panelConfirmEndAppointment.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScanTagRequest;
        private System.Windows.Forms.Label lblWelcomeTo;
        private System.Windows.Forms.Button btnToggleEndAppointmentPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelConfirmEndAppointment;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEndAppointment;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblVerfityAsHost2;
        private System.Windows.Forms.Label lblVerifyAsHost1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtRegistrationFeedback;
        private System.Windows.Forms.TextBox txtActiveAppointmentName;
    }
}