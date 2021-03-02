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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            //Inchid paghinile care nu apartin de Home
            contact_window1.Visible = false;
            contNouWindow1.Visible = false;
            secondCustomControl1.Visible = false;

            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;

            firstCustomControl1.Visible = true;
            button13.Visible = true;
            timer1.Start();

            label2.Visible = true;
        }

        //Buton Acasa
        private void button3_Click(object sender, EventArgs e)
        {
            //Setez ca SlidePanel-ul sa fie initial pe Home
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;

            //Inchid paginile care nu apartin de Home
            //Contact
            contact_window1.Visible = false;
            //Creaza cont nou
            contNouWindow1.Visible = false;
            //Lista de produse
            listView1.Visible = false;
            //Buton de Adauga in cos
            button10.Visible = false;
            //Lista din Cosul meu
            listView2.Visible = false;
            //Butonul Elimina din cos
            button11.Visible = false;
            //Suma totala pentru Cosul meu
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda
            button12.Visible = false;

            //Deschid pagina Home si pornesc timer-ul
            firstCustomControl1.Visible = true;
            button13.Visible = true;
            timer1.Start();
        }

        private int CustomControl = 1;

        //Functie de modificare a paginii Home
        private void LoadCustomControl()
        {
            if (CustomControl == 3)
                CustomControl = 1;
            if (CustomControl == 1)
            {
                secondCustomControl1.Visible = false;

                firstCustomControl1.Visible = true;
                button13.Visible = true;
            }
            else
            {
                firstCustomControl1.Visible = false;
                button13.Visible = false;

                secondCustomControl1.Visible = true;
            }
            CustomControl++;
        }

        //Timer pentru pagina Home
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadCustomControl();
        }

        //Buton Produse
        private void button2_Click_1(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Produse si opresc timer-ul
            //Home
            firstCustomControl1.Visible = false;
            secondCustomControl1.Visible = false;
            button13.Visible = false;
            timer1.Stop();
            //Contact
            contact_window1.Visible = false;
            //Lista din Cosul meu
            listView2.Visible = false;
            //Butonul Elimina din cos
            button11.Visible = false;
            //Suma totala pentru Cosul meu
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda
            button12.Visible = false;
            //Creaza cont nou
            contNouWindow1.Visible = false;

            //Setez ca SlidePanel-ul sa fie pe directia Produse
            SlidePanel.Height = button2.Height;
            SlidePanel.Top = button2.Top;

            //Deschid pagina Produse
            listView1.Visible = true;

            //Realizez setarile pentru List View sa fie only one selected
            listView1.HideSelection = true;
            listView1.HideSelection = false;
            listView1.FullRowSelect = true;

            //Setez dimensiunile fiecarei coloane
            listView1.Columns[0].Width = 72;
            listView1.Columns[1].Width = 350;
            listView1.Columns[2].Width = 150;
            listView1.Columns[3].Width = 150;
            listView1.Columns[4].Width = 120;

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("select_products", connection);
            SqlDataReader dr = command.ExecuteReader();

            listView1.Items.Clear();

            //Populez lista de produse
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                lv.SubItems.Add(dr.GetString(1).ToString());
                lv.SubItems.Add(dr.GetString(2).ToString());
                lv.SubItems.Add(dr.GetString(3).ToString());
                lv.SubItems.Add(dr.GetInt32(4).ToString());

                listView1.Items.Add(lv);
            }
            dr.Close();
            command.Dispose();
            connection.Close();

            //Butonul de Adauga in cos - apare cand esti conectat
            if (label2.Text != "Neconectat")
                button10.Visible = true;
        }

        //Buton Contact
        private void button4_Click(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Contact si opresc timer-ul
            //Home
            firstCustomControl1.Visible = false;
            secondCustomControl1.Visible = false;
            button13.Visible = false;
            timer1.Stop();
            //Lista de produse
            listView1.Visible = false;
            //Butonul de Adauga in cos
            button10.Visible = false;
            //Lista din Cosul meu
            listView2.Visible = false;
            //Butonul Elimina din cos
            button11.Visible = false;
            //Suma totala pentru Cosul meu
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda
            button12.Visible = false;
            //Creaza cont nou
            contNouWindow1.Visible = false;

            //Setez ca SlidePanel-ul sa fie pe directia Contact
            SlidePanel.Height = button4.Height;
            SlidePanel.Top = button4.Top;

            //Deschid pagina Contact
            contact_window1.Visible = true;
        }

        //Buton Crează cont nou
        private void button5_Click(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Cont nou si opresc timer-ul
            //Home
            firstCustomControl1.Visible = false;
            secondCustomControl1.Visible = false;
            button13.Visible = false;
            timer1.Stop();
            //Lista de produse
            listView1.Visible = false;
            //Butonul de Adauga in cos
            button10.Visible = false;
            //Contact
            contact_window1.Visible = false;
            //Lista din Cosul meu
            listView2.Visible = false;
            //Butonul Elimina din cos
            button11.Visible = false;
            //Suma totala pentru Cosul meu
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda
            button12.Visible = false;

            //Deschid pagina Crează cont nou
            contNouWindow1.Visible = true;

            //Setez ca SlidePanel-ul sa fie pe directa Creaza cont nou
            SlidePanel.Height = button5.Height;
            SlidePanel.Top = button5.Top;
        }

        //Buton Logheaza-te
        private void button6_Click(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Login si opresc timer-ul
            //Home
            firstCustomControl1.Visible = false;
            secondCustomControl1.Visible = false;
            button13.Visible = false;
            timer1.Stop();
            //Lista de produse
            listView1.Visible = false;
            //Butonul Adauga in cos
            button10.Visible = false;
            //Contact
            contact_window1.Visible = false;
            //Lista din Cosul meu
            listView2.Visible = false;
            //Butonul Elimina din cos
            button11.Visible = false;
            //Suma totala pentru Cosul meu
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda
            button12.Visible = false;
            //Creaza cont nou
            contNouWindow1.Visible = false;

            //Setez ca SlidePanel-ul sa fie pe directia Login
            SlidePanel.Height = button6.Height;
            SlidePanel.Top = button6.Top;

            //Deschid pagina Logheaza-te
            pictureBox2.Visible = true;
            button7.Visible = true;
            password_text.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            username_text.Visible = true;
            label3.Visible = true;
        }

        //Buton de Login / Window
        private void button7_Click(object sender, EventArgs e)
        {
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string user_name = null;
            string password = null;
            bool user_exists = false;

            SqlCommand command = new SqlCommand("login_User", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@user_name", username_text.Text));
            command.Parameters.Add(new SqlParameter("@password", password_text.Text));

            SqlDataReader dr = null;
            dr = command.ExecuteReader();

            if (dr.Read())
            {
                user_name = dr[0].ToString();
                password = dr[1].ToString();

                if (user_name.Equals(username_text.Text) && password.Equals(password_text.Text))
                {
                    user_exists = true;
                }
            }
            dr.Close();
            command.Dispose();

            if (user_exists == true)
            {
                //Modific statusul pentru Utilizator -> conectat
                command = new SqlCommand("connect_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@user_name", username_text.Text));

                int result = command.ExecuteNonQuery();

                command.Dispose();

                //Obtin id-ul pentru user-ul curent
                command = new SqlCommand("get_user_id", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", username_text.Text));
                command.Parameters.Add("@user_id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                int userId = (int)command.Parameters["@user_id"].Value;

                command.Dispose();

                //Adaug in tabela de Cos de cumparaturi user-ul care s-a logat
                command = new SqlCommand("add_cos_cumparaturi", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userId", userId));

                command.ExecuteNonQuery();

                command.Dispose();

                String username = username_text.Text;

                //Adaug numarul de produse 
                command = new SqlCommand("count_products", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", username));
                command.Parameters.Add("@count", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                result = (int)command.Parameters["@count"].Value;

                label8.Text = "(" + result.ToString() + ")";

                command.Dispose();
                connection.Close();

                username_text.Clear();
                password_text.Clear();

                MessageBox.Show("Conectat!");

                //Cos de cumparaturi - apare cand esti conectat
                button3.Visible = true;
                //Creaza cont nou - dispare cand esti conectat
                button5.Visible = false;
                //Login - dispare cand esti conectat
                button6.Visible = false;
                //Deconectare - apare cand esti conectat
                button8.Visible = true;
                //Butonul Elimina din cos
                button11.Visible = false;

                //Numarul de produse din cos apare cand esti conectat
                label8.Visible = true;

                //Numele utilizatorului - apare cand esti conectat
                label2.Text = username;

                //Deschid pagina Home si pornesc timer-ul
                SlidePanel.Height = button1.Height;
                SlidePanel.Top = button1.Top;

                firstCustomControl1.Visible = true;
                button13.Visible = true;
                timer1.Start();
            }
            else
            {
                username_text.Clear();
                password_text.Clear();

                MessageBox.Show("Username sau parolă invalid/e");
            }
        }

        //Hide password
        private void password_text_TextChanged(object sender, EventArgs e)
        {
            password_text.PasswordChar = '●';
        }

        //Buton Cosul meu
        private void button3_Click_1(object sender, EventArgs e)
        {
            //Inchid paginile care nu apartin de Cosul meu si opresc timer-ul
            firstCustomControl1.Visible = false;
            secondCustomControl1.Visible = false;
            button13.Visible = false;
            timer1.Stop();
            //Lista de produse
            listView1.Visible = false;
            //Butonul Adauga in cos
            button10.Visible = false;
            //Contact
            contact_window1.Visible = false;
            //Creaza cont nou
            contNouWindow1.Visible = false;
            //Login
            pictureBox2.Visible = false;
            button7.Visible = false;
            password_text.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            username_text.Visible = false;
            label3.Visible = false;

            //Setez ca SlidePanel-ul sa fie pe directia Cosul meu
            SlidePanel.Height = button3.Height;
            SlidePanel.Top = button3.Top;

            //Deschid lista din Cosul meu
            listView2.Visible = true;
            //Butonul Elimina din cos
            button11.Visible = true;
            //Adaug label-ul de suma
            label6.Visible = true;
            label7.Visible = true;
            //Buton Finalizare comanda
            button12.Visible = true;

            //Realizez setarile pentru List View sa fie only one selected pentru a putea sterge elemente din cos
            listView2.HideSelection = true;
            listView2.HideSelection = false;
            listView2.FullRowSelect = true;

            //Setez dimensiunile fiecarei coloane
            listView2.Columns[0].Width = 72;
            listView2.Columns[1].Width = 350;
            listView2.Columns[2].Width = 150;
            listView2.Columns[3].Width = 150;
            listView2.Columns[4].Width = 120;

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("get_products_by_user", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));

            SqlDataReader dr = command.ExecuteReader();

            listView2.Items.Clear();

            //Populez lista de produse
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                lv.SubItems.Add(dr.GetString(1).ToString());
                lv.SubItems.Add(dr.GetString(2).ToString());
                lv.SubItems.Add(dr.GetString(3).ToString());
                lv.SubItems.Add(dr.GetInt32(4).ToString());

                listView2.Items.Add(lv);
            }
            dr.Close();
            command.Dispose();

            //Adaug suma totala a produselor din cos
            command = new SqlCommand("sum_products", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));
            command.Parameters.Add("@sum", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            int result = (int)command.Parameters["@sum"].Value;

            label6.Text = result.ToString();

            command.Dispose();

            //Adaug numarul de produse 
            command = new SqlCommand("count_products", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));
            command.Parameters.Add("@count", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            result = (int)command.Parameters["@count"].Value;

            label8.Text = "(" + result.ToString() + ")";

            command.Dispose();
            connection.Close();
        }

        //Buton Adauga in cos
        private void button10_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selectati un produs.");
                return;
            }
            //Salvez produsul selectat
            String text = listView1.SelectedItems[0].Text;
            int product_id = Int32.Parse(text);

            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            //Adaug produsele in cosul user-ului conectat
            SqlCommand command = new SqlCommand("insert_item", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));
            command.Parameters.Add(new SqlParameter("@productId", product_id));

            int result = command.ExecuteNonQuery();
            if (result == 2)
                MessageBox.Show("Produsul a fost adaugat in cos!");

            command.Dispose();

            //Adaug suma totala a produselor din cos
            command = new SqlCommand("sum_products", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));
            command.Parameters.Add("@sum", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            result = (int)command.Parameters["@sum"].Value;

            label6.Text = result.ToString();

            command.Dispose();

            //Adaug numarul de produse 
            command = new SqlCommand("count_products", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userName", label2.Text));
            command.Parameters.Add("@count", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

            command.ExecuteNonQuery();

            result = (int)command.Parameters["@count"].Value;

            label8.Text = "(" + result.ToString() + ")";

            command.Dispose();
            connection.Close();
        }

        //Buton Elimina produsul din cos
        private void button11_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                MessageBox.Show("Nu a fost selectat niciun produs");
            else
            {
                //Salvez produsul selectat
                String text = listView2.SelectedItems[0].Text;
                int product_id = Int32.Parse(text);

                //Open connection
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1433";
                builder.UserID = "SA";
                builder.Password = "parolaAiaPuternic4!";
                builder.InitialCatalog = "";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();

                //Elimin produsul selectat din cosul user-ului conectat
                SqlCommand command = new SqlCommand("delete_item", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", label2.Text));
                command.Parameters.Add(new SqlParameter("@productId", product_id));

                int result = command.ExecuteNonQuery();
                if (result == 2)
                    MessageBox.Show("Produsul a fost eliminat din cos!");

                command.Dispose();

                command = new SqlCommand("get_products_by_user", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", label2.Text));

                SqlDataReader dr = command.ExecuteReader();

                listView2.Items.Clear();

                //Populez lista de produse
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                    lv.SubItems.Add(dr.GetString(1).ToString());
                    lv.SubItems.Add(dr.GetString(2).ToString());
                    lv.SubItems.Add(dr.GetString(3).ToString());
                    lv.SubItems.Add(dr.GetInt32(4).ToString());

                    listView2.Items.Add(lv);
                }
                dr.Close();
                command.Dispose();

                //Adaug suma totala a produselor din cos
                command = new SqlCommand("sum_products", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", label2.Text));
                command.Parameters.Add("@sum", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                result = (int)command.Parameters["@sum"].Value;

                label6.Text = result.ToString();

                command.Dispose();

                //Adaug numarul de produse 
                command = new SqlCommand("count_products", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", label2.Text));
                command.Parameters.Add("@count", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

                command.ExecuteNonQuery();

                result = (int)command.Parameters["@count"].Value;

                label8.Text = "(" + result.ToString() + ")";

                command.Dispose();
                connection.Close();
            }
        }

        //Buton Finalizare comanda
        private void button12_Click(object sender, EventArgs e)
        {
            if (label6.Text != "0")
            {
                //Open connection
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost, 1433";
                builder.UserID = "SA";
                builder.Password = "parolaAiaPuternic4!";
                builder.InitialCatalog = "";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();

                //Sterg elementele din cosul utilizatorului curent
                SqlCommand command = new SqlCommand("delete_all_items", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", label2.Text));

                int result = command.ExecuteNonQuery();
                MessageBox.Show("Comanda a fost finalizată cu succes!");

                command.Dispose();
                connection.Close();

                //Numarul de produse din cos devine 0
                label8.Text = "(0)";

                //Inchid paginile care apartin de Cosul meu
                listView2.Visible = false;
                button11.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                button12.Visible = false;

                //Deschid pagina Home si pornesc timer-ul
                SlidePanel.Height = button1.Height;
                SlidePanel.Top = button1.Top;

                firstCustomControl1.Visible = true;
                button13.Visible = true;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Nu aveti niciun produs in cos.");
            }

        }

        //Buton de Deconectare
        private void button8_Click(object sender, EventArgs e)
        {
            //Open connection
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            //Modific statusul pentru Utilizator -> deconectat
            SqlCommand command = new SqlCommand("disconnect_user", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@user_name", label2.Text));

            int result = command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            //Cos de cumparaturi - dispare cand esti deconectat
            button3.Visible = false;
            //Creaza cont nou - apare cand esti deconectat
            button5.Visible = true;
            //Login - apare cand esti deconectat
            button6.Visible = true;
            //Deconectare - dispare cand esti deconectat
            button8.Visible = false;
            //Numele utilizatorului - apare cand esti deconectat
            label2.Text = "Neconectat";
            //Butonul de Adauga in cos - dispare cand esti deconectat
            button10.Visible = false;
            //Lista de produse - dispare cand te deconectezi
            listView1.Visible = false;
            //Lista din Cosul meu - dispare cand te deconectezi
            listView2.Visible = false;
            //Butonul Elimina din cos - dispare cand te deconectezi
            button11.Visible = false;
            //Suma totala pentru Cosul meu - dispare cand te deconectezi
            label6.Visible = false;
            label7.Visible = false;
            //Buton Finalizare comanda - dispare cand te deconectezi
            button12.Visible = false;
            //Butonul Comanda acum - dispare cand te deconectezi
            button13.Visible = false;
            //Pagina Contact - dispare cand te deconectezi
            contact_window1.Visible = false;
            //Numarul de produse din cos dispare cand te deconectezi
            label8.Visible = false;


            //Deschid pagina Home si pornesc timer-ul
            SlidePanel.Height = button1.Height;
            SlidePanel.Top = button1.Top;

            firstCustomControl1.Visible = true;
            button13.Visible = true;
            timer1.Start();
        }

        //Buton Exit
        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost, 1433";
            builder.UserID = "SA";
            builder.Password = "parolaAiaPuternic4!";
            builder.InitialCatalog = "";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            //Modific statusul pentru Utilizator -> deconectat
            SqlCommand command = new SqlCommand("disconnect_user", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@user_name", label2.Text));

            try
            {
                int result = command.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }

            Application.Exit();
        }

        //Buton Comanda acum
        private void button13_Click(object sender, EventArgs e)
        {
            button2_Click_1(sender, e);
            listView1.Items[3].Selected = true;
        }
    }
}
