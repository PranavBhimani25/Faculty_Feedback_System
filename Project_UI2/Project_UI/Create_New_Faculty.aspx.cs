﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace Project_UI
{
    public partial class Create_New_Faculty : System.Web.UI.Page
    {
        static String fname = "";
        static String lname = "";
        static String mname = "";
        string user_id = "";
        long user;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "1")
                    {

                    }
                    else
                    {
                        Response.Redirect("Login_New.aspx");
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            user_id = TextBox2.Text.ToString();
            user = Int64.Parse(TextBox2.Text.ToString());
            //user = Convert.ToInt64(TextBox1.Text);
            String password = "faculty@123";
            string pass = encryption(password);
            fname = TextBox5.Text;
            lname = TextBox6.Text;
            mname = TextBox7.Text;
            if (user_id.Length > 0)
            {
                SqlConnection cn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox4.Text + ";Integrated Security=True";

                cn.Open();
                string qstring2 = "insert into User_ values ('" + user + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + DropDownList1.SelectedValue + "', '" + pass + "','" + TextBox8.Text + "','" + Session["team_id"] + "') ";
                string qstring1 = "insert into Faculty values ('" + user + "', '" + fname + "')";
                string qstring = "select * from User_ where (User_id ='" + user_id + "') ";
                SqlCommand cmd = new SqlCommand(qstring, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() && dr.GetDecimal(0) == user)
                {
                    Response.Write("<script>alert('Username is allready taken !');</script>");

                    cmd.Dispose();
                }
                else
                {
                    try
                    {
                        dr.Close();
                        cmd.Dispose();
                        SqlCommand cmd2 = new SqlCommand(qstring2, cn);
                        cmd2.ExecuteNonQuery();
                        SqlCommand cmd3 = new SqlCommand(qstring1, cn);
                        cmd3.ExecuteNonQuery();
                        cmd2.Dispose();
                        cmd3.Dispose();
                        Response.Write("<script>alert('Saved Successfully!');</script>");
                        TextBox2.Text = "";
                        TextBox5.Text = "";
                        TextBox6.Text = "";
                        TextBox7.Text = "";
                        TextBox8.Text = "";
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert(''" + ex.Message + "' !');</script>");
                    }
                    cn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Username and password is empty !');</script>");
            }
        }
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding en = new UTF8Encoding();
            encrypt = md5.ComputeHash(en.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i]).ToString();
            }
            return encryptdata.ToString();

        }
    }
}