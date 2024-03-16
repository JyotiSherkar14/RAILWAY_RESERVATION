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
    public partial class Form7 : Form
    {

        String q, cs = "";
        MySqlCommand cmd;
        MySqlConnection c1;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=railway;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);

            MessageBox.Show("Database Connectivity Successful");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearall();
        }
        void clearall()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "insert into traindetails values(@t_no,@t_name,@s_place,@e_place,@price)";
                cmd = new MySqlCommand(q, c1);

                cmd.Parameters.AddWithValue("@t_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@t_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@s_place", comboBox1.Text);
                cmd.Parameters.AddWithValue("@e_place", comboBox2.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                int u = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }
    }
}
