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
    public partial class AuthForm : Form
    {
        Form reg;

        public AuthForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            reg = new RegForm();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.wsDemoConnectionString);
            connection.Open();

            String login = textBox1.Text;
            String password = textBox2.Text;

            SqlCommand command = new SqlCommand("SELECT * FROM [user] WHERE login = '" + login + "' AND password = '" + password + "'", connection);
            SqlDataReader reader = command.ExecuteReader();

            String role = "", name = "";
            while (reader.Read())
            {
                role = reader[2].ToString();
                name = reader[2].ToString();
            }

            Form form = null;
            switch (role)
            {
                case "client":
                    //form = new ClientForm();
                    this.Hide();
                    form.Show();
                    break;

                case "stockman":
                    form = new StockmanForm();
                    this.Hide();
                    form.Show();
                    break;

                case "manager":
                    //form = new ManagerForm();
                    this.Hide();
                    form.Show();
                    break;

                case "director":
                    //form = new DirectorForm();
                    this.Hide();
                    form.Show();
                    break;

                default:
                    MessageBox.Show("Роль не установлена или пользователь не найден!");
                    break;
            }
        }
    }
}
