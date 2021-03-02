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

namespace BD_Project
{
    public partial class ContNouWindow : UserControl
    {
        public ContNouWindow()
        {
            InitializeComponent();
        }

        //Hide password
        private void password_text_TextChanged(object sender, EventArgs e)
        {
            password_text.PasswordChar = '●';
        }

        //Buton Creare Cont nou
        private void button2_Click(object sender, EventArgs e)
        {
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            bool user_new = false;

            SqlCommand command = new SqlCommand("create_new_account", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@user_name", username_text.Text));
            command.Parameters.Add(new SqlParameter("@password", password_text.Text));
            command.Parameters.Add(new SqlParameter("@email", email_text.Text));
            command.Parameters.Add(new SqlParameter("@telefon", telefon_text.Text));

            try
            {
                int result = command.ExecuteNonQuery();
                if (result == 1)
                    user_new = true;
            }
            catch (SqlException exception)
            {
                user_new = false;
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }

            if (user_new == false)
            {
                username_text.Clear();
                password_text.Clear();
                email_text.Clear();
                telefon_text.Clear();

                MessageBox.Show("Cont existent");
            }
            else
            {
                username_text.Clear();
                password_text.Clear();
                email_text.Clear();
                telefon_text.Clear();

                MessageBox.Show("Contul a fost creat cu succes!");
            }
        }
    }
}
