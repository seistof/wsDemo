using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsDemo
{
    public partial class FurnitureForm : Form
    {
        StockmanForm stock;

        public FurnitureForm()
        {
            InitializeComponent();
        }

        private void FurnitureForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ws_demoDataSet.furniture' table. You can move, or remove it, as needed.
            this.furnitureTableAdapter.Fill(this.ws_demoDataSet.furniture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            stock = new StockmanForm();
            stock.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
