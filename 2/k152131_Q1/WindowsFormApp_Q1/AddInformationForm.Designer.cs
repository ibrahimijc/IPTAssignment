namespace WindowsFormApp_Q1
{
    partial class AddInformationForm
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
            this.email = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.genderCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.bpmnumeric = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.button_bpmAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.labelmessage = new System.Windows.Forms.Label();
            this.warning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bpmnumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(111, 55);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(151, 20);
            this.email.TabIndex = 1;
            this.email.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 136);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // genderCombo
            // 
            this.genderCombo.DisplayMember = "Male";
            this.genderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderCombo.FormattingEnabled = true;
            this.genderCombo.Items.AddRange(new object[] {
            "Female",
            "Male",
            "Others"});
            this.genderCombo.Location = new System.Drawing.Point(111, 90);
            this.genderCombo.Name = "genderCombo";
            this.genderCombo.Size = new System.Drawing.Size(67, 21);
            this.genderCombo.TabIndex = 6;
            this.genderCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Gender";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Birth Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(108, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Patient Information";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(260, 207);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(107, 21);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.button1_Click);
            // 
            // bpmnumeric
            // 
            this.bpmnumeric.Location = new System.Drawing.Point(409, 56);
            this.bpmnumeric.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.bpmnumeric.Name = "bpmnumeric";
            this.bpmnumeric.Size = new System.Drawing.Size(103, 20);
            this.bpmnumeric.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(361, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "bpm";
            // 
            // button_bpmAdd
            // 
            this.button_bpmAdd.Location = new System.Drawing.Point(414, 107);
            this.button_bpmAdd.Name = "button_bpmAdd";
            this.button_bpmAdd.Size = new System.Drawing.Size(98, 23);
            this.button_bpmAdd.TabIndex = 14;
            this.button_bpmAdd.Text = "Add bpm";
            this.button_bpmAdd.UseVisualStyleBackColor = true;
            this.button_bpmAdd.Click += new System.EventHandler(this.button_bpmAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(410, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Beat Recorder";
            // 
            // labelmessage
            // 
            this.labelmessage.AutoSize = true;
            this.labelmessage.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmessage.ForeColor = System.Drawing.Color.Red;
            this.labelmessage.Location = new System.Drawing.Point(276, 231);
            this.labelmessage.Name = "labelmessage";
            this.labelmessage.Size = new System.Drawing.Size(0, 16);
            this.labelmessage.TabIndex = 25;
            // 
            // warning
            // 
            this.warning.AutoSize = true;
            this.warning.Location = new System.Drawing.Point(260, 270);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(0, 13);
            this.warning.TabIndex = 26;
            this.warning.Click += new System.EventHandler(this.label11_Click);
            // 
            // AddInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 354);
            this.Controls.Add(this.warning);
            this.Controls.Add(this.labelmessage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.bpmnumeric);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_bpmAdd);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.genderCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.email);
            this.Name = "AddInformationForm";
            this.Text = "AddInformation";
            this.Load += new System.EventHandler(this.AddInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bpmnumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox genderCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.NumericUpDown bpmnumeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_bpmAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelmessage;
        private System.Windows.Forms.Label warning;
    }
}