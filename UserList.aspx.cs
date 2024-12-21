using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManagementApp
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // DataTable dt = new DataTable();
                // //dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)), new DataColumn("UserName", typeof(int)) });


                // //GridView1.DataSource = SqlDataSource1;

                //// GridView1.DataBind();
               

                BindGridView();
                 GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

        }
        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM prodadmin.dpmsloginadminmaster", conn))
                {
                    using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
        //protected void addUserClicked(object sender, EventArgs e)
        //{
        //    //string myString = "signup";
        //    //Session["SignUp"] = myString;
        //    // Redirect to the desired page
        //    Response.Redirect("AddUser.aspx");
        //}

        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    BindGridView();
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    BindGridView();

        //}

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

        //    SqlDataSource1.DeleteParameters["ID"].DefaultValue = id.ToString();
        //    SqlDataSource1.Delete();

        //    BindGridView();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    // Retrieve the row being edited.
        //    GridViewRow row = GridView1.Rows[e.RowIndex];

        //    // Get the new values.
        //   // int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        //   // string name = (row.Cells[1].Controls[0] as TextBox).Text;
        //   // int age = Convert.ToInt32((row.Cells[2].Controls[0] as TextBox).Text);
        //   //// [username] = @username, [mobileno] = @mobileno, [email] = @email, [address] = @address, [role] = @role, [password] = @password, [confirmpass] = @confirmpasse

        //   // // Update the database using the SQLDataSource.
        //   // SqlDataSource1.UpdateParameters["Id"].DefaultValue = id.ToString();
        //   // SqlDataSource1.UpdateParameters["username"].DefaultValue = username;
        //   // SqlDataSource1.UpdateParameters["mobileno"].DefaultValue = mobileno.ToString();
        //   // SqlDataSource1.Update();

        //    // Exit edit mode.
        //    GridView1.EditIndex = -1;
        //    BindGridView();

        //}

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void DeleteRowFromDatabase(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
            NpgsqlConnection con = new NpgsqlConnection(connectionString);
            string query = "DELETE FROM prodadmin.dpmsloginadminmaster WHERE objectid = @objectid";
            
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@objectid", id);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    // Optionally, show a success message or handle the result
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Record deleted successfully!') </script>");
            }
                else
                {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Deletion failed. Please try again.') </script>");
            }
            
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                // Fetch data from the database
               // string connectionString = "dbum";
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
                string query = "SELECT * FROM prodadmin.dpmsloginadminmaster WHERE objectid = @objectid";

                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@objectid", id);
                    conn.Open();

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Assuming you're retrieving fields like Name, Age, and Address
                        string username = reader["username"].ToString();
                        string mobileno = reader["phonenumber"].ToString();
                        string email = reader["emailid"].ToString();
                        //string address = reader["address"].ToString();
                        string role = reader["role"].ToString();
                        string region = reader["region"].ToString();
                        string circle = reader["circle"].ToString();
                        string division = reader["division"].ToString();

                        string password = reader["password"].ToString();
                        string confirmpass = reader["confirmpassword"].ToString();
                        int isblocking = reader["isblocking"] != DBNull.Value ? Convert.ToInt32(reader["isblocking"]) : 0;


                        // Store data in Session variables
                        Session["SignUp"] = "Edit";
                        Session["ID"] = id;
                        Session["UserName"] = username;
                        Session["MobileNo"] = mobileno;
                        Session["Email"] = email;
                        //Session["Address"] = address;
                        Session["Role"] = role;
                        Session["Region"] = region;
                        Session["Circle"] = circle;
                        Session["Divison"] = division;
                        Session["Password"] = password; 
                        Session["confirmpassword"] = confirmpass;
                        Session["isblocking"] = isblocking;
                    }

                    conn.Close();
                }

                // Redirect to the edit page
                Response.Redirect("UpdateUser.aspx");
            }
            else if (e.CommandName == "DeleteRow")
            {
                // Retrieve the ID of the row that was clicked
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DeleteRowFromDatabase(rowIndex);

                BindGridView();

                // Implement delete logic here using the rowIndex value
                // Example: DeleteRecord(rowIndex);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}