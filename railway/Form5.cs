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
    public partial class Form5 : Form
    {
        String q, cs = "",q1;
        MySqlCommand cmd,cmd1;
        MySqlConnection c1;
        MySqlDataReader d;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=railway;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("Database Connectivity Successful");
            clearall();
           
        }
        void clearall()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select email from res where id=" + textBox1.Text;
                cmd = new MySqlCommand(q, c1);
                int u = Convert.ToInt32(cmd.ExecuteScalar());
                q1 = "select * from res";
                cmd1 = new MySqlCommand(q1, c1);
                d = cmd.ExecuteReader();
                if (d.Read())
                {
                    textBox2.Text = d["id"].ToString();
                    textBox2.Text = d["c_name"].ToString();
                    textBox2.Text = d["addr"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
                clearall();
            }


            c1.Open();
            try
            {
                q = "insert into care values(@complaint)";
                cmd = new MySqlCommand(q, c1);

                cmd.Parameters.AddWithValue("@complaint", textBox5.Text);
                int u = Convert.ToInt32(cmd.ExecuteScalar());


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

        private void button2_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "delete from care where email="+textBox1.Text;
                cmd = new MySqlCommand(q, c1);

                cmd.Parameters.AddWithValue("@complaint", textBox5.Text);
                int u = cmd.ExecuteNonQuery();
                if (u > 0)
                    MessageBox.Show("complaint deleted successfully");
                else
                    MessageBox.Show("complaint is not deleted");

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
