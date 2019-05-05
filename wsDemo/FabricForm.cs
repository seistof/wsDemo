using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsDemo
{
    public partial class FabricForm : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.wsDemoConnectionString);
        StockmanForm stock;
        DataSet ds;
        SqlDataAdapter sda;
        DataSet changes;
        bool firstLoad = true;

        public FabricForm()
        {
            InitializeComponent();
        }

        public void LoadList()
        {
            String query = "SELECT * FROM fabric";
            sda = new SqlDataAdapter(query, connection);
            ds = new DataSet();
            sda.Fill(ds, "fabric");
            dataGridView1.DataSource = ds.Tables["fabric"];

            
            if (firstLoad == true)
            {
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "imgage";
                img.HeaderText = "Картинка";
                dataGridView1.Columns.Add(img);
                firstLoad = false;
            }


            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    String basePath = "C:/Users/seist/source/repos/wsDemo/wsDemo/images/";
                    String fileName = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
                    String fullPath = basePath + fileName;

                    Image image;
                    if (File.Exists(fullPath))
                    {
                        image = Image.FromFile(fullPath);
                    }
                    else
                    {
                        image = Image.FromFile(basePath + "empty.jpg");
                    }
                    dataGridView1.Rows[i].Cells["image"].Value = image;
                }
            }
        }

        private void FabricForm_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            stock = new StockmanForm();
            stock.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow items in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(items.Index);
            }
            this.button3_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changes = ds.GetChanges();
            if (changes != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                builder.GetInsertCommand();
                int updatesRows = sda.Update(changes, "fabric");
                ds.AcceptChanges();
            }
            this.LoadList();
            MessageBox.Show("Успешно!");
        }
    }
}
