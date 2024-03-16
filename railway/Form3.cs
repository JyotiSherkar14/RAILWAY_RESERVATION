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
    public partial class Form3 : Form
    {
        String q, cs = "",q1;
        MySqlCommand cmd,cmd1;
        MySqlConnection c1;
        int t=0, a = 1,c=1,tp=0;
  
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=railway;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            cmd = new MySqlCommand(q, c1);
           
            loadID();
        }
        void loadID()
        {
            c1.Open();
            try
            {
                q = "select max(id) from res";
                cmd = new MySqlCommand(q, c1);
                int u = Convert.ToInt32(cmd.ExecuteScalar());
                textBox12.Text = (u + 1).ToString();
                q1 = "select max(pnr) from res";
                cmd1 = new MySqlCommand(q1, c1);
                int u1 = Convert.ToInt32(cmd.ExecuteScalar());
                textBox1.Text = (u + 1).ToString();
               
            }
            catch (Exception ex)
            {
                //MessageBox.Show("exception " + ex);
                textBox12.Text = "1";
                textBox1.Text = "1";
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text=="")
            {
                MessageBox.Show("please select starting place ");
                
            }
            else if (comboBox2.Text=="")
            {
                MessageBox.Show("please select ending place");
                textBox2.Focus();
            }
            else if (textBox5.Text=="")
            {
                MessageBox.Show("please enter train number");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("please enter train name");
                textBox7.Focus();
            }
            else if(textBox4.Text=="")
            {
                MessageBox.Show("please enter number of tickets");
                textBox4.Focus();
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("please enter your name");
                textBox8.Focus();
            }
            else if (textBox9.Text == "")
            {
                MessageBox.Show("please enter mobile number");
                textBox9.Focus();
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("please enter your address");
                textBox10.Focus();
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("please enter your email address");
                textBox11.Focus();
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("please select gender");
            }
            else
            {
                MessageBox.Show("all data enter");
            }
            c1.Open();
            try
            {
                q = "insert into res values(@id,@pnr,@s_place,@e_place,@t_no,@t_name,@price,@doj,@noticket,@t_price,@c_name,@addr,@mob,@email,@gender)";//parameterised querry
                cmd = new MySqlCommand(q, c1);
  
                cmd.Parameters.AddWithValue("@id", textBox12.Text);
                cmd.Parameters.AddWithValue("@pnr", textBox1.Text);
                cmd.Parameters.AddWithValue("@s_place",comboBox1.Text);
                cmd.Parameters.AddWithValue("@e_place", comboBox2.Text);
                cmd.Parameters.AddWithValue("@t_no", textBox5.Text);
                cmd.Parameters.AddWithValue("@t_name", textBox7.Text);
                cmd.Parameters.AddWithValue("@email", textBox11.Text);
                cmd.Parameters.AddWithValue("@addr", textBox10.Text);
                cmd.Parameters.AddWithValue("@doj", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@price", textBox2.Text);
                cmd.Parameters.AddWithValue("@noticket", textBox4.Text);
                cmd.Parameters.AddWithValue("@t_price", textBox6.Text);
                cmd.Parameters.AddWithValue("@c_name", textBox8.Text);
                cmd.Parameters.AddWithValue("@mob", textBox9.Text);
                if (radioButton1.Checked == true)
                    cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
                else if (radioButton2.Checked == true)
                    cmd.Parameters.AddWithValue("@gender", radioButton2.Text);
                else
                    cmd.Parameters.AddWithValue("@gender", radioButton3.Text);
                int r = cmd.ExecuteNonQuery(); 
                if (r > 0)
                    MessageBox.Show("user created successfully");
                else
                    MessageBox.Show("user is not created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
                clearall();
                loadID();
            }
            
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearall();
        }
        void clearall()
        {
           
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            radioButton1.Text = "";
            radioButton2.Text = "";
            radioButton3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            button1.Visible = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PUNE" && comboBox2.Text == "PUNE" || comboBox1.Text == "MUMBAI" && comboBox2.Text == "MUMBAI" || comboBox1.Text == "PARLI" && comboBox2.Text == "PARLI" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "SANGLI" && comboBox2.Text == "SANGLI")
            {
                MessageBox.Show("Your starting place and ending place should not be same");
                comboBox2.Text = "";
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "MUMBAI" || comboBox1.Text == "MUMBAI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "PUNE")
            {
                t = 750;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PUNE")
            {
                t = 800;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "MUMBAI")
            {
                t = 1100;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "MUMBAI")
            {
                t = 1300;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "MUMBAI")
            {
                t = 950;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 550;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 600;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PARLI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PARLI")
            {
                t = 470;
                textBox2.Text = t.ToString();
            }
                
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          //  int s;
            //c = Convert.ToInt16(textBox4.Text);
            c1.Open();
           
          //  tp = Convert.ToInt32(textBox6.Text);
            try
            {
                if (c <= 0)
                {
                    MessageBox.Show("Invalid Number of seat");
                    textBox4.Focus();
                }
                else
                {
                    c = Convert.ToInt32(textBox4.Text);//t2 = Convert.ToSingle(textBox2.Text);
                 //   t = Convert.ToInt32(textBox2.Text);
                    tp = t * c;
                    textBox6.Text = tp.ToString();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PUNE" && comboBox2.Text == "MUMBAI" || comboBox1.Text == "MUMBAI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "PUNE")
            {
                t = 750;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PUNE")
            {
                t = 800;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "MUMBAI")
            {
                t = 1100;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "MUMBAI")
            {
                t = 1300;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "MUMBAI")
            {
                t = 950;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 550;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 600;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PARLI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PARLI")
            {
                t = 470;
                textBox2.Text = t.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            c1.Open();
            //c = Convert.ToInt16(textBox4.Text);
            // tp = Convert.ToInt32(textBox6.Text);
            try
            {
                if (c <= 0)
                {
                    MessageBox.Show("Invalid Number of seat");
                    textBox4.Focus();
                }
                else
                {
                    c = Convert.ToInt32(textBox4.Text);//t2 = Convert.ToSingle(textBox2.Text);
                  //  t = Convert.ToInt32(textBox2.Text);
                    tp = t * c;
                    textBox6.Text = tp.ToString();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "PUNE" && comboBox2.Text == "PUNE" || comboBox1.Text == "MUMBAI" && comboBox2.Text == "MUMBAI" || comboBox1.Text == "PARLI" && comboBox2.Text == "PARLI" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "SANGLI" && comboBox2.Text == "SANGLI")
            {
                MessageBox.Show("Your starting place and ending place should not be same");
                comboBox2.Text = "";
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "MUMBAI" || comboBox1.Text == "MUMBAI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "PUNE")
            {
                t = 750;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PUNE")
            {
                t = 800;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PUNE" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PUNE")
            {
                t = 450;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "MUMBAI")
            {
                t = 1100;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "KOLHAPUR" || comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "MUMBAI")
            {
                t = 1300;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "MUMBAI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "MUMBAI")
            {
                t = 950;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "PARLI" || comboBox1.Text == "PARLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 550;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "KOLHAPUR" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "KOLHAPUR")
            {
                t = 600;
                textBox2.Text = t.ToString();
            }
            else if (comboBox1.Text == "PARLI" && comboBox2.Text == "SANGLI" || comboBox1.Text == "SANGLI" && comboBox2.Text == "PARLI")
            {
                t = 470;
                textBox2.Text = t.ToString();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
          
        

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
            
           
        //}

    }
}
