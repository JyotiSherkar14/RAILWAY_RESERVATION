using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace railway
{
    public partial class Form8 : Form
    {
        String cs = "";
        String q;
        MySqlConnection c1;
       
        MySqlDataAdapter da;
        DataTable t;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=railway;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);

            MessageBox.Show("Database Connectivity Successful");
            c1.Open();
            try
            {
                q = "select * from res";
                da = new MySqlDataAdapter(q, c1);
                t = new DataTable();
                da.Fill(t);
                dataGridView1.DataSource = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();

            }
        }
    }
}
