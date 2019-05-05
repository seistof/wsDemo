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
    public partial class ItemForm : Form


    {
        Form manager;
        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ws_demoDataSet2.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter1.Fill(this.ws_demoDataSet2.item);
            // TODO: This line of code loads data into the 'ws_demoDataSet1.item' table. You can move, or remove it, as needed.
            this.itemTableAdapter.Fill(this.ws_demoDataSet1.item);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            manager = new ManagerForm();
            manager.Show();
        }
    }
}
