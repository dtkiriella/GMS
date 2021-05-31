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
    public partial class AddMembers : Form
    {
        public AddMembers()
        {
            InitializeComponent();
            string idqry = "SELECT * FROM Members WHERE Id = (SELECT MAX(Id) from Members ) ";
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(idqry);
            if (dr.HasRows)
            {
                dr.Read();
                string num = dr["Id"].ToString();
                int num_1 = int.Parse(num);
                labelMID.Text = (num_1 + 1).ToString();

            }
            else
            {
                labelMID.Text = 1.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NIC = textBoxNIC.Text;
            string name = textboxName.Text;
            string DOB = dateTimePicker1.Text;
            string Gender = textboxGender.Text;
            string Body_Type = textboxBodyType.Text;
            string Address = richTextBoxAddress.Text;
            string Mobile_Number = textboxMobileNumber.Text;
            string Health_Condition = richTextBoxHealthCondition.Text;
            string Emergency_Contact_Name = textboxEmergencyContactName.Text;
            string Emergency_Contact_Number = (textboxEmergencyContactPhoneNumber.Text);

            DB_Connection dB_Connection = new DB_Connection();
            string insertqry = "INSERT INTO Members(NICorDL,MemberName,DOB,Gender,Body_Type,Address,Mobile_Number,Health_Condition,Emergency_Contact_Name,Emergency_Contact_Number) VALUES('" + NIC + "','" + name + "','" + DOB + "','" + Gender + "','" + Body_Type + "','" + Address + "'," + Mobile_Number + ",'" + Health_Condition + "','" + Emergency_Contact_Name + "','" + Emergency_Contact_Number + "')";
            Console.WriteLine(insertqry);
            dB_Connection.InsertData(insertqry);
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