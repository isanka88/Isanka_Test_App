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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewRegister op = new NewRegister();
            op.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnStudentDetails_Click(object sender, EventArgs e)
        {
            NewForm nw = new NewForm();
            nw.ShowDialog();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            NewRegister op = new NewRegister();
            op.ShowDialog();

        }
    }
}
