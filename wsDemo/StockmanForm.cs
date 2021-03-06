﻿using System;
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
    public partial class StockmanForm : Form
    {
        public StockmanForm()
        {
            InitializeComponent();
        }

        private void fabricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fabricView = new FabricForm();
            fabricView.Show();
            this.Hide();
        }

        private void furnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form furnitureView = new FurnitureForm();
            furnitureView.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StockmanForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form back = Application.OpenForms["AuthForm"];
            back.Show();
        }
    }
}
