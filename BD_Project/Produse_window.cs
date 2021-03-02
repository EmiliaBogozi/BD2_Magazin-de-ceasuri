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
    public partial class Produse_window : UserControl
    {
        public Produse_window()
        {
            InitializeComponent();
            listView1.HideSelection = true;
            listView1.HideSelection = false;
            listView1.FullRowSelect = true;

            listView1.Columns[0].Width = 72;
            listView1.Columns[1].Width = 370;
            listView1.Columns[2].Width = 150;
            listView1.Columns[3].Width = 150;
            listView1.Columns[4].Width = 120;
        }

        private void Produse_window_Load(object sender, EventArgs e)
        {
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
        }
    }
}
