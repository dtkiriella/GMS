﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym_Management_System
{
    public partial class Modify_members : Form
    {
        public Modify_members()
        {
            InitializeComponent();
        }

        private void textbox_Members_Id_TextChanged(object sender, EventArgs e)
        { 
            if(textbox_Members_Id.Text != "")
            {
                try
                {
                    int id = int.Parse(textbox_Members_Id.Text);
                    DB_Connection dB_Connection = new DB_Connection();
                    SqlConnection con = new SqlConnection(dB_Connection.connectionstring);
                    con.Open();
                    string qry = "SELECT * FROM Members Where Id=@Id ";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader da = dB_Connection.getDatausing_a(cmd);
                    if (da.HasRows)
                    {
                        while (da.Read())
                        {
                            textBoxNIC.Text = da.GetValue(1).ToString();
                            textboxName.Text = da.GetValue(2).ToString();
                            textboxGender.Text = da.GetValue(4).ToString();
                            textboxBodyType.Text = da.GetValue(5).ToString();
                            richTextBoxAddress.Text = da.GetValue(6).ToString();
                            textboxMobileNumber.Text = da.GetValue(7).ToString();
                            richTextBoxHealthCondition.Text = da.GetValue(8).ToString();
                            textboxEmergencyContactName.Text = da.GetValue(9).ToString();
                            textboxEmergencyContactPhoneNumber.Text = da.GetValue(10).ToString();
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("There is no member by member id:"+id+"\nTry again with another Id");
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNIC.Text = "";
            textboxName.Text = "";
            textboxGender.Text = "";
            textboxBodyType.Text = "";
            richTextBoxAddress.Text = "";
            textboxMobileNumber.Text = "";
            richTextBoxHealthCondition.Text = "";
            textboxEmergencyContactName.Text = "";
            textboxEmergencyContactPhoneNumber.Text = "";
        }
    }
}