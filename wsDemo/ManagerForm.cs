using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsDemo
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form itemView = new ItemForm();
            itemView.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form back = Application.OpenForms["AuthForm"];
            back.Show();
        }
    }
}
