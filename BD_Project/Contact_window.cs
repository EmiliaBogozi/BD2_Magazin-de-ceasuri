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
    public partial class Contact_window : UserControl
    {
        public Contact_window()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("new_contact", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@nume", nume_text.Text));
            command.Parameters.Add(new SqlParameter("@prenume", prenume_text.Text));
            command.Parameters.Add(new SqlParameter("@email", email_text.Text));
            command.Parameters.Add(new SqlParameter("@telefon", telefon_text.Text));
            command.Parameters.Add(new SqlParameter("@mesaj", mesaj_text.Text));

            try
            {
                int result = command.ExecuteNonQuery();

                nume_text.Clear();
                prenume_text.Clear();
                email_text.Clear();
                telefon_text.Clear();
                mesaj_text.Clear();

                MessageBox.Show("Mesajul a fost trimis!");
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
    }
}
