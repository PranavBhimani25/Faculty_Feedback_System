﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Project_UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataTable tb = new DataTable();
        DataRow dr;

        long sum = 0;

        int poor;
        int very_poor;
        int good;
        int very_good;
        int excellent;
        int count;
        int maxvalue;
        float per;
        float q2per;
        float q3per;
        float q4per;
        float q5per;
        float q6per;
        float q7per;
        float q8per;
        float q9per;
        float q10per;
        float q11per;
        float q12per;
        protected void Page_Load(object sender, EventArgs e)
        {
            div2.Visible = false;
            try
            {
                String sessionId = HttpContext.Current.Session.SessionID;
                if (Session["sid"].ToString() == sessionId)
                {
                    if (Session["role_id"].ToString() == "2")
                    {

                    }
                    else
                    {
                        Response.Redirect("Login_New.aspx");
                    }
                }
                var currentYear = DateTime.Today.Year;
                for (int i = 10; i >= 0; i--)
                {
                    DropDownList3.Items.Add((currentYear - i).ToString());
                }
            }
            catch (Exception)
            {
                Response.Redirect("Login_New.aspx");
            }

            //------------------------------------------------------------------------------------------------------------

            if (!IsPostBack)
            {
                SqlConnection cn = new SqlConnection();
                //cn.ConnectionString = "Data Source=TARUN\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=HANSIL-S-PC-DGJ\\SQLEXPRESS;;Initial Catalog=Project;Integrated Security=True";
                //cn.ConnectionString = "Data Source=LAPTOP-IJ86VO59\\SQLEXPRESS;Initial Catalog=" + Session["team_id"] + ";;Integrated Security=True";
                //Session["team_id"]
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
                string conString = connectionString.Replace("Project", Session["team_id"].ToString());
                cn.ConnectionString = conString;
                String sql = "Select Subject_code,Subject_name from Subject where Faculty_id = " + Session["User_id"] + " ";
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Subject");
                    cn.Close();
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataTextField = "Subject_name";
                    DropDownList1.DataValueField = "Subject_name";
                    DropDownList1.DataBind();

                    DropDownList2.DataSource = ds;
                    DropDownList2.DataTextField = "Subject_code";
                    DropDownList2.DataValueField = "Subject_code";
                    DropDownList2.DataBind();

                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(Subject is not Found /n)</script>");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnectionString"].ToString();
            string conString = connectionString.Replace("Project", Session["team_id"].ToString());
            cn.ConnectionString = conString;
            String year = "Year_" + DropDownList3.SelectedItem;
            String sql = "Select * from " + year + " where Subject_code = " + DropDownList2.SelectedItem + " ";
            cn.Open();

            div1.Visible = false;
            div2.Visible = true;

            title.Text = "Subject Name : " + DropDownList1.SelectedValue.ToString() + "<br/>Subject Code : " + DropDownList2.SelectedValue.ToString();

            tb.Columns.Add("Question", typeof(string));
            tb.Columns.Add("Excellent", typeof(string));
            tb.Columns.Add("Very_Good", typeof(string));
            tb.Columns.Add("Good", typeof(string));
            tb.Columns.Add("Poor", typeof(string));
            tb.Columns.Add("Very_Poor", typeof(string));
            // Q1 ---------------------------------------------------------------------------------------------------
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(3));
                    count++;
                    switch (dr.GetString(3))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                per = (100 * sum) / maxvalue;

                createtable(1, excellent, very_good, good, poor, very_poor);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("<h3 align = 'center'>Subject is not Found </h3> ");

            }

            //Q2 ----------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(4));
                    count++;
                    switch (dr.GetString(4))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q2per = (100 * sum) / maxvalue;
                createtable(2, excellent, very_good, good, poor, very_poor);

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
               
            }

            //Q3 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(5));
                    count++;
                    switch (dr.GetString(5))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q3per = (100 * sum) / maxvalue;

                createtable(3, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

            }

            //Q4 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(6));
                    count++;
                    switch (dr.GetString(6))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q4per = (100 * sum) / maxvalue;
                createtable(4, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
            }

            //Q5 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(7));
                    count++;
                    switch (dr.GetString(7))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q5per = (100 * sum) / maxvalue;
                createtable(5, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
               
            }

            //Q6 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(8));
                    count++;
                    switch (dr.GetString(8))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q6per = (100 * sum) / maxvalue;
                createtable(6, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
            }

            //Q7 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(9));
                    count++;
                    switch (dr.GetString(9))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q7per = (100 * sum) / maxvalue;
                createtable(7, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
            }
            //Q8 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(10));
                    count++;
                    switch (dr.GetString(10))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q8per = (100 * sum) / maxvalue;
                createtable(8, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
            }

            //Q9 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(11));
                    count++;
                    switch (dr.GetString(11))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q9per = (100 * sum) / maxvalue;
                createtable(9, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                
            }

            //Q10 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(12));
                    count++;
                    switch (dr.GetString(12))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q10per = (100 * sum) / maxvalue;
                createtable(10, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
            }

            //Q11 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(13));
                    count++;
                    switch (dr.GetString(13))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q11per = (100 * sum) / maxvalue;
                createtable(11, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
            }


            //Q12 ------------------------------------------------------------------------------------------------------
            try
            {
                sum = 0;
                poor = 0;
                very_poor = 0;
                good = 0;
                very_good = 0;
                excellent = 0;
                count = 0;
                maxvalue = 0;
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sum = sum + Int64.Parse(dr.GetString(14));
                    count++;
                    switch (dr.GetString(14))
                    {
                        case "1":
                            very_poor++;
                            break;
                        case "2":
                            poor++;
                            break;
                        case "3":
                            good++;
                            break;
                        case "4":
                            very_good++;
                            break;
                        case "5":
                            excellent++;
                            break;
                        default:
                            break;
                    }
                }
                maxvalue = count * 5;
                q12per = (100 * sum) / maxvalue;
                createtable(12, excellent, very_good, good, poor, very_poor);
                dr.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
            }

            SqlConnection cn2 = new SqlConnection();
            cn2.ConnectionString = conString;
            String Insert_str = "Insert into Feedback values (" + DropDownList2.SelectedItem + " ," + per + "," + q2per + "," + q3per + "," + q4per + "," + q5per + "," + q6per + "," + q7per + "," + q8per + "," + q9per + "," + q10per + "," + q11per + "," + q12per + ")";
            try
            {
                cn2.Open();
                SqlCommand cmd2 = new SqlCommand(Insert_str, cn2);
                cmd2.ExecuteNonQuery();
                Response.Write("Insert sucessful");
            }
            catch (Exception ex)
            {
                //Response.Write("Can't send Data second time !!");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedIndex = DropDownList1.SelectedIndex;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedIndex = DropDownList2.SelectedIndex;

        }

        public void createtable(int no, int a, int b, int c, int d, int e)
        {
            dr = tb.NewRow();
            dr["Question"] = no;
            dr["Excellent"] = a;
            dr["Very_Good"] = b;
            dr["Good"] = c;
            dr["Poor"] = d;
            dr["Very_Poor"] = e;
            tb.Rows.Add(dr);
            Gv1.DataSource = tb;
            Gv1.DataBind();
            ViewState["table1"] = tb;
        }
    }
}