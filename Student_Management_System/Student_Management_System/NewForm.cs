using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class NewForm : Form
    {

        DataAccess dbClass = new DataAccess();
        public NewForm()
        {
            InitializeComponent();
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
          

            string State = "";


            if (cbTrue.Checked == true)
            {
                State = "True";
            }
            else
            {
                State = "False";
            }

         
            this.Hide();
                   

            //save last Student ID
            Student_Management_System.Properties.Settings.Default.ID = int.Parse(txtAVG.Text);
            Student_Management_System.Properties.Settings.Default.Save();

            //insert data into database
            NewRegister op = new NewRegister(lblID.Text, txtName.Text, dateTimePicker1.Value.ToShortDateString(), int.Parse(txtAVG.Text), State);
          
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void NewForm_Load(object sender, EventArgs e)
        {

            //get last studnt id
            lblID.Text = Student_Management_System.Properties.Settings.Default.ID.ToString();
        }

        private void txtAVG_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xx = int.Parse(txtAVG.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Insert only Numbers");
                txtAVG.Text = "";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int xx = int.Parse(txtName.Text);
                MessageBox.Show("Insert only Letters");
                txtName.Text = "";
            }
            catch (Exception)
            {
               
            }
        }
    }
}
