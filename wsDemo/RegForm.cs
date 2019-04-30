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
    public partial class RegForm : Form
    {
        SqlConnection connection = new SqlConnection(Properties.Settings.Default.wsDemoConnectionString);

        public RegForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form back = Application.OpenForms["AuthForm"];
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int errors = 0;
            String message = "";

            if (textBox1.Text == "")
            {
                errors++;
                message += "Пожалуйста введите имя\n";
            }
            if (textBox2.Text == "")
            {
                errors++;
                message += "Пожалуйста введите логин\n";
            }
            if (textBox3.Text == "")
            {
                errors++;
                message += "Пожалуйста введите пароль\n";
            }

            if (textBox4.Text == "")
            {
                errors++;
                message += "Пожалуйста введите подтверждение пароля\n";
            }

            if (textBox3.Text != textBox4.Text)
            {
                errors++;
                message += "Пароли не совпадают!\n";
            }

            if (errors > 0)
            {
                MessageBox.Show(message);
            }
            else
            {
                connection.Open();

                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [user] (login, password, role, name) VALUES (@login, @password, @role, @name)", connection);
                    command.Parameters.AddWithValue("@login", textBox1.Text);
                    command.Parameters.AddWithValue("@password", textBox2.Text);
                    command.Parameters.AddWithValue("@role", "client");
                    command.Parameters.AddWithValue("@name", textBox4.Text);
                    int regged = Convert.ToInt32(command.ExecuteNonQuery());
                    connection.Close();
                    MessageBox.Show("Пользователь успешно зарегистрировался!\n");

                }
                catch (SqlException ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("Такой пользователь существует!\n");
                }
            }


        }
    }
}
