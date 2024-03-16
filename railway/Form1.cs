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
    public partial class Form1 : Form
    {
        String q, p,cs="";
        MySqlCommand cmd;
        MySqlConnection c1;
        int c = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == 1)
            {
                MessageBox.Show("Your Password Is Already Existed");
            }
            else
            {
                p = textBox1.Text;
                if (textBox1.Text == "")
                    MessageBox.Show("Please Enter Password of Minimum Six Length");
                else if (p.Contains(" "))
                {
                    MessageBox.Show("Space Is Not Allowed");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    c1.Open();
                    try
                    {
                        MessageBox.Show("Valid Password");
                        q = "insert into login values('" + textBox1.Text + "')";
                        cmd = new MySqlCommand(q, c1);
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            MessageBox.Show("Password Created Succesfully");
                            textBox1.Text = "";
                            c++;
                        }
                        else
                            MessageBox.Show("Password Not Created");
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

        private void button2_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select password from login";
                cmd = new MySqlCommand(q, c1);
                String r = cmd.ExecuteScalar().ToString();
                if (r.Equals(textBox1.Text))
                {
                    MessageBox.Show("Login Successful");
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                    textBox1.Text = "";
                    textBox1.Focus();
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

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cs="server=localhost;database=railway;Uid=root;pwd=root";
            c1=new MySqlConnection(cs);
            cmd=new MySqlCommand(q,c1);
            MessageBox.Show("Database Connectivity Successful");
            c1.Open();
            try
            {
                q = "select count(password) from login";
                cmd = new MySqlCommand(q, c1);
                c = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("Number of Password Record : " + c);

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
