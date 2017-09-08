namespace OpenHardwareMonitor.GUI
{
    partial class NotificationsForm
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
            this.GPULoad = new System.Windows.Forms.Label();
            this.GPULoadDDL = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GPUTemperatureDDL = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GPULoadNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.GPUTemperatureNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.notificationEmailTxtBox = new System.Windows.Forms.TextBox();
            this.CPUTemperatureNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.CPULoadNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.CPUTemperatureDDL = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CPULoadDDL = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MemoryUsageNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.MemoryUsageDDL = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GPULoadNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTemperatureNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTemperatureNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPULoadNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoryUsageNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GPULoad
            // 
            this.GPULoad.AutoSize = true;
            this.GPULoad.Location = new System.Drawing.Point(21, 47);
            this.GPULoad.Name = "GPULoad";
            this.GPULoad.Size = new System.Drawing.Size(57, 13);
            this.GPULoad.TabIndex = 0;
            this.GPULoad.Text = "GPU Load";
            // 
            // GPULoadDDL
            // 
            this.GPULoadDDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GPULoadDDL.FormattingEnabled = true;
            this.GPULoadDDL.Items.AddRange(new object[] {
            "",
            ">",
            "<"});
            this.GPULoadDDL.Location = new System.Drawing.Point(131, 44);
            this.GPULoadDDL.Name = "GPULoadDDL";
            this.GPULoadDDL.Size = new System.Drawing.Size(38, 21);
            this.GPULoadDDL.TabIndex = 1;
            this.GPULoadDDL.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Notification will be send if one of the following confitions will be true :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(234, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(234, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = " °C";
            // 
            // GPUTemperatureDDL
            // 
            this.GPUTemperatureDDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GPUTemperatureDDL.FormattingEnabled = true;
            this.GPUTemperatureDDL.Items.AddRange(new object[] {
            "",
            ">",
            "<"});
            this.GPUTemperatureDDL.Location = new System.Drawing.Point(131, 72);
            this.GPUTemperatureDDL.Name = "GPUTemperatureDDL";
            this.GPUTemperatureDDL.Size = new System.Drawing.Size(38, 21);
            this.GPUTemperatureDDL.TabIndex = 6;
            this.GPUTemperatureDDL.SelectionChangeCommitted += new System.EventHandler(this.GPUTemperatureDDL_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "GPU Temperature";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Send notofication to email adderss";
            // 
            // GPULoadNumUpDown
            // 
            this.GPULoadNumUpDown.Location = new System.Drawing.Point(175, 45);
            this.GPULoadNumUpDown.Name = "GPULoadNumUpDown";
            this.GPULoadNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.GPULoadNumUpDown.TabIndex = 10;
            // 
            // GPUTemperatureNumUpDown
            // 
            this.GPUTemperatureNumUpDown.Location = new System.Drawing.Point(175, 73);
            this.GPUTemperatureNumUpDown.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.GPUTemperatureNumUpDown.Name = "GPUTemperatureNumUpDown";
            this.GPUTemperatureNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.GPUTemperatureNumUpDown.TabIndex = 11;
            // 
            // notificationEmailTxtBox
            // 
            this.notificationEmailTxtBox.Location = new System.Drawing.Point(188, 261);
            this.notificationEmailTxtBox.Name = "notificationEmailTxtBox";
            this.notificationEmailTxtBox.Size = new System.Drawing.Size(137, 20);
            this.notificationEmailTxtBox.TabIndex = 12;
            // 
            // CPUTemperatureNumUpDown
            // 
            this.CPUTemperatureNumUpDown.Location = new System.Drawing.Point(175, 137);
            this.CPUTemperatureNumUpDown.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.CPUTemperatureNumUpDown.Name = "CPUTemperatureNumUpDown";
            this.CPUTemperatureNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.CPUTemperatureNumUpDown.TabIndex = 20;
            // 
            // CPULoadNumUpDown
            // 
            this.CPULoadNumUpDown.Location = new System.Drawing.Point(175, 109);
            this.CPULoadNumUpDown.Name = "CPULoadNumUpDown";
            this.CPULoadNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.CPULoadNumUpDown.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(234, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = " °C";
            // 
            // CPUTemperatureDDL
            // 
            this.CPUTemperatureDDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPUTemperatureDDL.FormattingEnabled = true;
            this.CPUTemperatureDDL.Items.AddRange(new object[] {
            "",
            ">",
            "<"});
            this.CPUTemperatureDDL.Location = new System.Drawing.Point(131, 136);
            this.CPUTemperatureDDL.Name = "CPUTemperatureDDL";
            this.CPUTemperatureDDL.Size = new System.Drawing.Size(38, 21);
            this.CPUTemperatureDDL.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "CPU Temperature";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(234, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "%";
            // 
            // CPULoadDDL
            // 
            this.CPULoadDDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CPULoadDDL.FormattingEnabled = true;
            this.CPULoadDDL.Items.AddRange(new object[] {
            "",
            ">",
            "<"});
            this.CPULoadDDL.Location = new System.Drawing.Point(131, 108);
            this.CPULoadDDL.Name = "CPULoadDDL";
            this.CPULoadDDL.Size = new System.Drawing.Size(38, 21);
            this.CPULoadDDL.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "CPU Load";
            // 
            // MemoryUsageNumUpDown
            // 
            this.MemoryUsageNumUpDown.Location = new System.Drawing.Point(175, 174);
            this.MemoryUsageNumUpDown.Name = "MemoryUsageNumUpDown";
            this.MemoryUsageNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.MemoryUsageNumUpDown.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(234, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "%";
            // 
            // MemoryUsageDDL
            // 
            this.MemoryUsageDDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MemoryUsageDDL.FormattingEnabled = true;
            this.MemoryUsageDDL.Items.AddRange(new object[] {
            "",
            ">",
            "<"});
            this.MemoryUsageDDL.Location = new System.Drawing.Point(131, 173);
            this.MemoryUsageDDL.Name = "MemoryUsageDDL";
            this.MemoryUsageDDL.Size = new System.Drawing.Size(38, 21);
            this.MemoryUsageDDL.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Memory Usage";
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 369);
            this.Controls.Add(this.MemoryUsageNumUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MemoryUsageDDL);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CPUTemperatureNumUpDown);
            this.Controls.Add(this.CPULoadNumUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CPUTemperatureDDL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CPULoadDDL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.notificationEmailTxtBox);
            this.Controls.Add(this.GPUTemperatureNumUpDown);
            this.Controls.Add(this.GPULoadNumUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GPUTemperatureDDL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GPULoadDDL);
            this.Controls.Add(this.GPULoad);
            this.Name = "NotificationsForm";
            this.Text = "NotificationsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NotificationsForm_FormClosed);
            this.Load += new System.EventHandler(this.NotificationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GPULoadNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTemperatureNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTemperatureNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPULoadNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoryUsageNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GPULoad;
        private System.Windows.Forms.ComboBox GPULoadDDL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox GPUTemperatureDDL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown GPULoadNumUpDown;
        private System.Windows.Forms.NumericUpDown GPUTemperatureNumUpDown;
        private System.Windows.Forms.TextBox notificationEmailTxtBox;
        private System.Windows.Forms.NumericUpDown CPUTemperatureNumUpDown;
        private System.Windows.Forms.NumericUpDown CPULoadNumUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CPUTemperatureDDL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CPULoadDDL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown MemoryUsageNumUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox MemoryUsageDDL;
        private System.Windows.Forms.Label label11;
    }
}