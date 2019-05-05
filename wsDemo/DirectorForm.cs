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
    public partial class DirectorForm : Form
    {
        public DirectorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DirectorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form back = Application.OpenForms["AuthForm"];
            back.Show();
        }
    }
}
