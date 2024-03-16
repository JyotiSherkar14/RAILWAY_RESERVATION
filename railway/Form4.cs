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
    public partial class Form4 : Form
    {
        String cs = "";
        String q;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        
        DataTable t;
       
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                q = "Delete from res where id=" + textBox1.Text;
                cmd = new MySqlCommand(q, con); 
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Record Deleted Successfully");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                    MessageBox.Show("Invalid data");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Delete Exception" + ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
                con.Open();
                try
                {
                    q = "select * from res";
                    da = new MySqlDataAdapter(q, con);
                    t = new DataTable();
                    da.Fill(t);
                    dataGridView1.DataSource = t;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Exception" + ex);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }

            

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=railway;Uid=root;pwd=root";
            con = new MySqlConnection(cs);
            MessageBox.Show("Database Connectivity Successful");
           

        }
    }
}
