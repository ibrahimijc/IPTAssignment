using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormApp_Q1
{
    public partial class AddInformationForm : Form
    {
        HeartRateRecorder hr;
        public AddInformationForm()
        {
            InitializeComponent();
            hr = new HeartRateRecorder();
            this.genderCombo.Text = "Male";

        }

        private void AddInformation_Load(object sender, EventArgs e)
        {

        }

        public void setPatientInfo(HeartRateRecorder h)
        {
            this.hr = h;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.email.Text=="")
            {
                warning.Text = "Please Enter Details";
                return;
            }
            else
            {
                warning.Text = "";
            }

            if (!hr.checkIfTodayFileExist()) // Continue if today's file dosen't exist
            {
                //hr.setName(name);

                hr.setDOB(dateTimePicker1.Value);
                hr.setAge((DateTime)dateTimePicker1.Value);
                hr.setEmail(email.Text);
                hr.setGender(genderCombo.Text[0]);
                hr.printToXML();
                
            }
            else
            {
                // this.labelmessage.Text = "Warning : File already exist for today";
                hr.setDOB(dateTimePicker1.Value);
                hr.setAge((DateTime)dateTimePicker1.Value);
                hr.setEmail(email.Text);
                hr.setGender(genderCombo.Text[0]);
                hr.appendToXML();

            }
            this.Close();
        }

        private void button_bpmAdd_Click(object sender, EventArgs e)
        {
           

            if (this.email.Text == "")
            {
                this.warning.Text = "Enter All Details please";
                return;
            }
            else
            {
                this.warning.Text = "";
            }

            DateTime today = DateTime.Now;
            String beatReading = this.bpmnumeric.Value + "";
            String time = "" + today.ToString("HH") + ":" + today.Minute + ":"+today.Second;
            hr.addBPM(beatReading, time);
        }

        private void buttonNumericHour_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonNumericMin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
