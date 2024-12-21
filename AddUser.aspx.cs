using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Xml.Linq;
using Npgsql;
using System.Drawing;

namespace UserManagementApp
{
    public partial class Registration : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
       // string receivedString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleDropDown();
                //if (Session["SignUp"] != null)
                //{
                //    receivedString = Session["SignUp"].ToString();
                //    Response.Write("Received String: " + receivedString);

                //    if (receivedString == "signup")
                //    {
                //        btnSave.Text = "Save";
                //    }
                //    else
                //    {
                //        btnSave.Text = "Update";

                //        if (Session["ID"] != null)
                //        {
                //            int id = Convert.ToInt32(Session["ID"]);
                //            string usename = Session["UserName"].ToString();
                //            string mobileno = Session["MobileNo"].ToString();
                //            string email = Session["Email"].ToString();
                //            string address = Session["Address"].ToString();
                //            string role = Session["Role"].ToString();
                //            string password = Session["Password"].ToString();
                //            string confirmpass = Session["ConfirmPass"].ToString();

                //            // Populate the controls on the page
                //            txtUserName.Text = usename;
                //            txtMobileNo.Text = mobileno;
                //            txtEmail.Text = email;
                //            txtAddress.Text = address;
                //            ddlRole.Text = role;
                //            txtPassword.Text = password;
                //            txtConfirmPass.Text = confirmpass;
                //        }
                //    }
                //}
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCircle.Items.Clear();
            ddlDivision.Items.Clear();
           
            ddlCircle.Items.Insert(0, new ListItem("Select Circle", "0"));
            ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
            getCircleData(ddlRegion.Text);

        }
        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDivision.Items.Clear();

            ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
            getDivisionData(ddlCircle.Text);
        }

       

      

        private void getCircleData(String regionValue)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();


               // Query to get all values from a specific column in the table
                string query = "SELECT circle FROM prodadmin.dpmsloginadminmaster where region= @regionValue";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@regionValue", regionValue);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {

                        HashSet<string> columnValues = new HashSet<string>();


                        while (dr.Read())
                        {
                            string circle = dr["circle"].ToString();
                            if (!string.IsNullOrWhiteSpace(circle))
                            {
                                // Add values to HashSet to ensure distinct entries
                                columnValues.Add(dr["circle"].ToString());
                            }

                        }


                        ddlCircle.DataSource = columnValues;
                        ddlCircle.DataBind();

                    }
                }
            }

           
           
        }


        private void getDivisionData(String selectedValue)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();


                // Query to get all values from a specific column in the table
                string query = "SELECT division FROM prodadmin.dpmsloginadminmaster where circle= @selectedValue";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@selectedValue", selectedValue);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {

                        HashSet<string> columnValues = new HashSet<string>();


                        while (dr.Read())
                        {
                            string region = dr["division"].ToString();
                            if (!string.IsNullOrWhiteSpace(region))
                            {
                                // Add values to HashSet to ensure distinct entries
                                columnValues.Add(dr["division"].ToString());
                            }

                        }


                        ddlDivision.DataSource = columnValues;
                        ddlDivision.DataBind();

                    }
                }
            }



        }
        private void RoleDropDown()
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();

                // Query to get all values from a specific column in the table
                //  string query = "SELECT distinct role,region,circle,division FROM dpms.loginadminmaster";
                string query = "SELECT distinct role,region,hierarchyselection FROM prodadmin.dpmsloginadminmaster";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Bind the data to the DropDownList
                        //ddlRole.DataSource = dr;
                        //ddlRole.DataTextField = "role"; // Replace with the column name you want to display
                        //ddlRole.DataValueField = "role"; // Replace with the column name you want to use as value
                        //ddlRole.DataBind();

                        //ddlRole.DataSource = dr;
                        //ddlRole.DataTextField = "role"; // Replace with the column name you want to display
                        //ddlRole.DataValueField = "role"; // Replace with the column name you want to use as value
                        //ddlRole.DataBind();

                        //ddlRegion.DataSource = dr;
                        //ddlRegion.DataTextField = "region"; // Replace with the column name you want to display
                        //ddlRegion.DataValueField = "region"; // Replace with the column name you want to use as value
                        //ddlRegion.DataBind();

                        //ddlCircle.DataSource = dr;
                        //ddlCircle.DataTextField = "circle"; // Replace with the column name you want to display
                        //ddlCircle.DataValueField = "circle"; // Replace with the column name you want to use as value
                        //ddlCircle.DataBind();

                        //ddlDivision.DataSource = dr;
                        //ddlDivision.DataTextField = "division"; // Replace with the column name you want to display
                        //ddlDivision.DataValueField = "division"; // Replace with the column name you want to use as value
                        //ddlDivision.DataBind();

                        //ddlRole.Items.Add(dr["role"].ToString());
                        //ddlRegion.Items.Add(dr["region"].ToString());
                        //ddlCircle.Items.Add(dr["circle"].ToString());
                        //ddlDivision.Items.Add(dr["division"].ToString());
                        // Temporary lists to hold distinct column values
                        HashSet<string> columnRoleValues = new HashSet<string>();
                        HashSet<string> columnRegionValues = new HashSet<string>();
                        HashSet<string> columnHierarchyValues = new HashSet<string>();
                        //HashSet<string> columnCircleValues = new HashSet<string>();
                        //HashSet<string> columnDivisionValues = new HashSet<string>();

                        while (dr.Read())
                        {
                            string region = dr["region"].ToString();
                            string role = dr["role"].ToString();
                            string hierarchy = dr["hierarchyselection"].ToString();
                            if (!string.IsNullOrWhiteSpace(role))
                            {
                                columnRoleValues.Add(dr["role"].ToString());
                            }
                            if (!string.IsNullOrWhiteSpace(region))
                            {
                                // Add values to HashSet to ensure distinct entries
                               // columnRoleValues.Add(dr["role"].ToString());
                                columnRegionValues.Add(dr["region"].ToString());
                                //columnCircleValues.Add(dr["circle"].ToString());
                                //columnDivisionValues.Add(dr["division"].ToString());
                            }
                            if (!string.IsNullOrWhiteSpace(hierarchy))
                            {
                                columnHierarchyValues.Add(dr["hierarchyselection"].ToString());
                            }
                        }

                        // Bind the distinct values to DropDownLists
                        ddlRole.DataSource = columnRoleValues;
                        ddlRole.DataBind();
                        ddlRegion.DataSource = columnRegionValues;
                        ddlRegion.DataBind();
                        ddlHierarchy.DataSource = columnHierarchyValues;
                        ddlHierarchy.DataBind();
                        //ddlCircle.DataSource = columnCircleValues;
                        //ddlCircle.DataBind();
                        //ddlDivision.DataSource = columnDivisionValues;
                        //ddlDivision.DataBind();
                    }
                }
            }

            // Optionally, add a default item to the dropdown (like "Select...")
            ddlRole.Items.Insert(0, new ListItem("Select Role", "0"));
            ddlRegion.Items.Insert(0, new ListItem("Select region", "0"));
            //ddlCircle.Items.Insert(0, new ListItem("Select circle", "0"));
            //ddlDivision.Items.Insert(0, new ListItem("Select division", "0"));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //String btn_text = btnSave.Text;

            //if( btn_text == "Save")
            //{
            //NpgsqlConnection con = new NpgsqlConnection(cs);
            //string query = "insert into dpms.loginadminmaster values(@username,@phonenumber,@emailid,@role,@region,@circle,@division,@password,@confirmpassword,@isBlocked)";
            //NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            //cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            //cmd.Parameters.AddWithValue("@phonenumber", txtMobileNo.Text);
            //cmd.Parameters.AddWithValue("@emailid", txtEmail.Text);
            ////cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            //cmd.Parameters.AddWithValue("@role", ddlRole.Text);
            //cmd.Parameters.AddWithValue("@region", ddlRegion.Text);
            //cmd.Parameters.AddWithValue("@circle", ddlCircle.Text);
            //cmd.Parameters.AddWithValue("@division", ddlDivision.Text);

            //cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            //cmd.Parameters.AddWithValue("@confirmpassword", txtConfirmPass.Text);
            //cmd.Parameters.AddWithValue("@isBlocked",0);



            //con.Open();
            //int a = cmd.ExecuteNonQuery();
            NpgsqlConnection con = new NpgsqlConnection(cs);
            string query = "INSERT INTO prodadmin.dpmsloginadminmaster (username, phonenumber, emailid, role, region, circle, division, password, confirmpassword, isblocking) " +
                           "VALUES (@username, @phonenumber, @emailid, @role, @region, @circle, @division, @password, @confirmpassword, @isblocking)";

            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@phonenumber", txtMobileNo.Text);
            cmd.Parameters.AddWithValue("@emailid", txtEmail.Text);
            cmd.Parameters.AddWithValue("@role", ddlRole.Text);
            cmd.Parameters.AddWithValue("@region", ddlRegion.Text);
            cmd.Parameters.AddWithValue("@circle", ddlCircle.Text);
            cmd.Parameters.AddWithValue("@division", ddlDivision.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@confirmpassword", txtConfirmPass.Text);
            cmd.Parameters.AddWithValue("@isblocking", 0);  // Assuming it's an integer or boolean field

            con.Open();
            int a = cmd.ExecuteNonQuery();
            //con.Close(); 
            if (a > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Registration Successful') </script>");
                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Registration Failed') </script>");
                }
                con.Close();
            //}
            //else
            //{
               
            //    int id = Convert.ToInt32(Session["ID"]);
            //    //Session.Clear();
            //    string username = txtUserName.Text;
            //    string mobileno = txtMobileNo.Text;
            //    string email = txtEmail.Text;
            //    string address = txtAddress.Text;
            //    string role = ddlRole.Text;
            //    string password = txtPassword.Text;
            //    string confirmpass = txtConfirmPass.Text;


            //    SqlConnection con = new SqlConnection(cs);
            //    string query = "UPDATE Admin SET username = @username, mobileno = @mobileno, email = @email, address = @address, role = @role, password = @password, confirmpass = @confirmpass WHERE Id = @ID";

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@ID", id);
            //    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            //    cmd.Parameters.AddWithValue("@mobileno", txtMobileNo.Text);
            //    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            //    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
            //    cmd.Parameters.AddWithValue("@role", ddlRole.Text);
            //    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            //    cmd.Parameters.AddWithValue("@confirmpass", txtConfirmPass.Text);

            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
                

            //    // Redirect back to the GridView page or display a success message
            //    Response.Redirect("Admin.aspx");

            //}
            

        }

        protected void btn_Close(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

      
    }
}