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
    public partial class Form6 : Form
    {
        string cs = "", q;
        MySqlDataAdapter da;
        DataTable t;
        MySqlConnection c1;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                c1.Open();
                try
                {
                    q = "select * from traindetails ";
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
            if (comboBox1.SelectedIndex == 1)
            {
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
                if (comboBox1.SelectedIndex == 2)
                {
                    c1.Open();
                    try
                    {
                        q = "select * from care";
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
    }
}
