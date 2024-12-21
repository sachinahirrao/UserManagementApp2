using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Npgsql;
using Npgsql.Internal;

namespace UserManagementApp
{
    public partial class Default : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ForgotPassword_Click(object sender, EventArgs e)
        {
            // Add your logic to handle the "Forgot Password" action
            // For example, redirect to a "Forgot Password" page
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            // Add your logic to handle the "Register" action
            // For example, redirect to a "Register" page
            Response.Redirect("UserRegistration.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            string query = "SELECT isblocking, approvalstatus FROM prodadmin.dpmsloginadminmaster WHERE username = @user AND password = @pass";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", txtUserName.Text);
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
            con.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    // Check if user is blocked
                    int isblocking = dr["isblocking"] != DBNull.Value ? dr.GetInt32(dr.GetOrdinal("isblocking")) : 0;

                    // Check approval status
                    string approvalstatus = dr["approvalstatus"] != DBNull.Value ? dr.GetString(dr.GetOrdinal("approvalstatus")) : "";

                    if (approvalstatus.Equals("Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("The user's approval status is pending.");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Your approval is pending. Please contact the Administrator.') </script>");
                    }
                    else if (isblocking == 1)
                    {
                        Console.WriteLine("The user is blocked.");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('The user is blocked. Please contact the Administrator.') </script>");
                    }
                    else
                    {
                        Console.WriteLine("The user is not blocked and approval is completed.");
                        Session["user"] = txtUserName.Text;
                        Response.Redirect("Dashboard.aspx");
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Login Failed') </script>");
            }

            con.Close();
        }


        //protected void Login_Click(object sender, EventArgs e)
        //{
        //    NpgsqlConnection con = new NpgsqlConnection(cs);
        //    string query = "select isblocking from prodadmin.dpmsloginadminmaster where username = @user and password = @pass";
        //    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
        //    cmd.Parameters.AddWithValue("@user", txtUserName.Text);
        //    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
        //    con.Open();
        //    NpgsqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        if (dr.Read())
        //        {
        //            //bool isblocking = dr.GetBoolean(dr.GetOrdinal("isblocking"));
        //            if (dr["isblocking"] != DBNull.Value)
        //            {
        //                int isblocking = dr.GetInt32(dr.GetOrdinal("isblocking"));

        //                if (isblocking == 1)
        //                {
        //                    Console.WriteLine("The user is blocked.");
        //                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('The user is blocked.Please connect to Administrator.') </script>");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("The user is not blocked.");
        //                    Session["user"] = txtUserName.Text;
        //                    // Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts","<script>alert('Login Successful') </script>");
        //                    Response.Redirect("Dashboard.aspx");
        //                }
        //            } else
        //            {
        //                Console.WriteLine("The user is not blocked.");
        //                Session["user"] = txtUserName.Text;
        //                // Page.ClientScript.RegisterStartupScript(this.GetType(),"Scripts","<script>alert('Login Successful') </script>");
        //                Response.Redirect("Dashboard.aspx");
        //            }
        //        }

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Login Failed') </script>");
        //    }
        //    con.Close();

        //}

        protected void Sign_Up(object sender, EventArgs e)
        {
            //string myString = "signup";
            //Session["SignUp"] = myString;
        }
    }
}