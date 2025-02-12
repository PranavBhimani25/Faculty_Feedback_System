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
    public partial class Create_New_Student : System.Web.UI.Page
    {
        static String fname = "";
        static String lname = "";
        static String mname = "";
        string user_id = "";
        //long user;
        String sem;
        String year;
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
            catch (Exception ex)
            {
                Response.Redirect("Login_New.aspx");
            }

            HttpCookie ck = Request.Cookies["Info"];
            year = ck["Year"].ToString();
            sem = ck["Sem"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String password = "student@123";
            string pass = encryption(password);
            fname = TextBox5.Text;
            lname = TextBox6.Text;
            mname = TextBox7.Text;
            user_id = TextBox2.Text.ToString();
            long er_id = Int64.Parse(TextBox2.Text);
            String table_year = "Year_" + year;
            if (user_id.Length > 0)
            {
                SqlConnection cn = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;Initial Catalog=HOD" + TextBox1.Text + ";Integrated Security=True";

                cn.Open();
                string qstring2 = "insert into User_ values ('" + er_id + "', '" + fname + "' , '" + mname + "' , '" + lname + "', '" + DropDownList1.SelectedValue + "', '" + pass + "','" + TextBox8.Text + "','" + Session["team_id"] + "') ";
                string qstring1 = "insert into Student values ('" + er_id + "', '" + sem + "' , '" + table_year + "')";
                string qstring = "select * from User_ where (User_id ='" + er_id + "') ";
                String Insert_qstr = "insert into Year_" + year + " values (" + er_id + ",'" + sem + "',0,0,0,0,0,0,0,0,0,0,0,0,0,0)";
                SqlCommand cmd = new SqlCommand(qstring, cn);
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    if (dr1.GetDecimal(0) == er_id)
                        Response.Write("<script>alert('Username is allready taken !');</script>");
                    cmd.Dispose();
                }
                else
                {
                    try
                    {
                        dr1.Close();
                        cmd.Dispose();
                        SqlCommand cmd2 = new SqlCommand(qstring2, cn);
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();
                        try
                        {
                            cmd2 = new SqlCommand(Insert_qstr, cn);
                            cmd2.ExecuteNonQuery();
                            cmd2.Dispose();
                            try
                            {
                                SqlCommand cmd3 = new SqlCommand(qstring1, cn);
                                cmd3.ExecuteNonQuery();
                                cmd3.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Response.Write("123 " + ex.Message);
                            }
                            TextBox2.Text = "";
                            Response.Write("<script>alert('Saved Successfully');</script>");
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Not inserted in User table');</script>");
                    }
                    cn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Username and password is empty');</script>");
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