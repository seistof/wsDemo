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
            Client.Value = false;
            Manager.Value = false;
            Stockman.Value = false;
            Director.Value = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            reg = new RegForm();
            reg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
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
                    name = reader[3].ToString();
                }

                Form form = null;
                switch (role)
                {
                    case "client":
                        form = new ClientForm();
                        this.Hide();
                        form.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        Client.Value = true;
                        break;

                    case "stockman":
                        form = new StockmanForm();
                        this.Hide();
                        form.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        Stockman.Value = true;
                        break;

                    case "manager":
                        form = new ManagerForm();
                        this.Hide();
                        form.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        Manager.Value = true;
                        break;

                    case "director":
                        form = new DirectorForm();
                        this.Hide();
                        form.Show();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        Director.Value = true;
                        break;

                    default:
                        MessageBox.Show("Роль не установлена или пользователь не найден!\n");
                        break;
                }
            } else
            {
                MessageBox.Show("Поля не должны быть пустыми!\n");
            }
        }
    }
}
