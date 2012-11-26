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
    public partial class NewRegister : Form
    {
        DataAccess dbClass = new DataAccess();
        private string ID;
        private string Name;
        private string DOB;
        private int Grade;
        private string State;

        public NewRegister()
        {
            InitializeComponent();
            fillGrid();
        }

        public NewRegister(string p1, string p2, string p3, int p4, string State)
        {
            // TODO: Complete member initialization
            this.ID = p1;
            this.Name = p2;
            this.DOB = p3;
            this.Grade = p4;
            this.State = State;
            dbClass.RegisterStudent(ID, Name, DOB, Grade, State);

         
        fillGrid();
        }
      
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1021, 544);
        }

        public void NewRegister_Load(object sender, EventArgs e)
        {
            this.Size = new Size(699, 544);

            //get last studnt id
            lblID.Text = Student_Management_System.Properties.Settings.Default.ID.ToString();

            fillGrid();

        }      

        private void btnSave_Click(object sender, EventArgs e)
        {
            string State="";


            if (cbTrue.Checked == true)
            {
                State = "True";
            }
            else
            {
                State = "False";
            }

            //insert data into database
            this.ID = lblID.Text;
            this.Name = txtName.Text;
            this.DOB = dateTimePicker1.Value.ToShortDateString();
            this.Grade = int.Parse(txtAVG.Text);
            this.State = State;
            dbClass.RegisterStudent(ID, Name,DOB, Grade, State);
                                

            //save last Student ID
            Student_Management_System.Properties.Settings.Default.ID = int.Parse(txtAVG.Text);
            Student_Management_System.Properties.Settings.Default.Save();


            fillGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            NewForm op = new NewForm();
            op.Show();
        }

        void fillGrid()
        {
            try
            {

                //Fill grid view
                dataGridView1.Rows.Clear();
                string qury = "select id as Student_ID, name as Student_name,dob as Date_of_Birth,grade,active as Student_Active_State  from Registation";
                this.dataGridView1.DataSource = dbClass.getData(qury);


            }
            catch (Exception)
            {
                
               
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
