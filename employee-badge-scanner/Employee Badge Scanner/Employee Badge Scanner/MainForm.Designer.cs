
namespace Employee_Badge_Scanner
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoggingStatusOutput = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLoggingBegin = new System.Windows.Forms.Label();
            this.btnStartStopLogging = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLoggingLengthOutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tmrCardScan = new System.Windows.Forms.Timer(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtScannedValue = new System.Windows.Forms.TextBox();
            this.listHistory = new System.Windows.Forms.ListBox();
            btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(413, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(594, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Badge Scanner and Logger";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Status: ";
            // 
            // lblLoggingStatusOutput
            // 
            this.lblLoggingStatusOutput.AutoSize = true;
            this.lblLoggingStatusOutput.BackColor = System.Drawing.Color.Red;
            this.lblLoggingStatusOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggingStatusOutput.Location = new System.Drawing.Point(114, 36);
            this.lblLoggingStatusOutput.Name = "lblLoggingStatusOutput";
            this.lblLoggingStatusOutput.Size = new System.Drawing.Size(117, 25);
            this.lblLoggingStatusOutput.TabIndex = 2;
            this.lblLoggingStatusOutput.Text = "Not Logging";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(302, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Logging Begin:";
            // 
            // lblLoggingBegin
            // 
            this.lblLoggingBegin.AutoSize = true;
            this.lblLoggingBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggingBegin.Location = new System.Drawing.Point(451, 36);
            this.lblLoggingBegin.Name = "lblLoggingBegin";
            this.lblLoggingBegin.Size = new System.Drawing.Size(232, 25);
            this.lblLoggingBegin.TabIndex = 4;
            this.lblLoggingBegin.Text = "2022-01-01 01:45:00 PM";
            // 
            // btnStartStopLogging
            // 
            this.btnStartStopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStopLogging.Location = new System.Drawing.Point(23, 82);
            this.btnStartStopLogging.Name = "btnStartStopLogging";
            this.btnStartStopLogging.Size = new System.Drawing.Size(185, 36);
            this.btnStartStopLogging.TabIndex = 5;
            this.btnStartStopLogging.Text = "Start Logging";
            this.btnStartStopLogging.UseVisualStyleBackColor = true;
            this.btnStartStopLogging.Click += new System.EventHandler(this.btnStartStopLogging_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLoggingLengthOutput);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblLoggingStatusOutput);
            this.groupBox1.Controls.Add(this.btnStartStopLogging);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblLoggingBegin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1445, 135);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging ";
            // 
            // lblLoggingLengthOutput
            // 
            this.lblLoggingLengthOutput.AutoSize = true;
            this.lblLoggingLengthOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggingLengthOutput.Location = new System.Drawing.Point(451, 82);
            this.lblLoggingLengthOutput.Name = "lblLoggingLengthOutput";
            this.lblLoggingLengthOutput.Size = new System.Drawing.Size(264, 25);
            this.lblLoggingLengthOutput.TabIndex = 7;
            this.lblLoggingLengthOutput.Text = "1 Hour, 3 minutes, 2 seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(302, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Logging Length:";
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeID.Location = new System.Drawing.Point(294, 202);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(169, 31);
            this.lblEmployeeID.TabIndex = 7;
            this.lblEmployeeID.Text = "Employee ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(269, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "Employee Name";
            // 
            // tmrCardScan
            // 
            this.tmrCardScan.Enabled = true;
            this.tmrCardScan.Interval = 250;
            this.tmrCardScan.Tick += new System.EventHandler(this.tmrCardScan_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(263, 405);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(219, 31);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Employee Status";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Menu;
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(41, 439);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(692, 38);
            this.txtStatus.TabIndex = 13;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtEmployeeName.Enabled = false;
            this.txtEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(41, 335);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(692, 38);
            this.txtEmployeeName.TabIndex = 14;
            this.txtEmployeeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtScannedValue
            // 
            this.txtScannedValue.BackColor = System.Drawing.SystemColors.Menu;
            this.txtScannedValue.Enabled = false;
            this.txtScannedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannedValue.Location = new System.Drawing.Point(41, 236);
            this.txtScannedValue.Name = "txtScannedValue";
            this.txtScannedValue.Size = new System.Drawing.Size(692, 38);
            this.txtScannedValue.TabIndex = 15;
            this.txtScannedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listHistory
            // 
            this.listHistory.FormattingEnabled = true;
            this.listHistory.Location = new System.Drawing.Point(760, 241);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(703, 277);
            this.listHistory.TabIndex = 16;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new System.Drawing.Point(18, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(138, 36);
            btnRefresh.TabIndex = 17;
            btnRefresh.Text = "Refresh CSV File";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 521);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(this.listHistory);
            this.Controls.Add(this.txtScannedValue);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblEmployeeID);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Employee Badge Scanner";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoggingStatusOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoggingBegin;
        private System.Windows.Forms.Button btnStartStopLogging;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLoggingLengthOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEmployeeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer tmrCardScan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtScannedValue;
        private System.Windows.Forms.ListBox listHistory;
        public static System.Windows.Forms.Button btnRefresh;
    }
}

