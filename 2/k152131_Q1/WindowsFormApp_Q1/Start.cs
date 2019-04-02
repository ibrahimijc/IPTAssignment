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
    public partial class Start : Form
    {

        HeartRateRecorder HeartRecorder;

        public Start()
        {
            InitializeComponent();
            HeartRecorder = new HeartRateRecorder(); 
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "") /// May be use with Or Condition 
            {
                label2.Text = "You must Enter a Name";

            }
            else
            {
                label2.Text = "";
                HeartRecorder.setName (textBox1.Text);
                AddInformationForm sel = new AddInformationForm();
                sel.setPatientInfo(HeartRecorder);
                sel.Show();
               
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {

        }
    }
}
