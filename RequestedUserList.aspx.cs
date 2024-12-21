using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;

namespace UserManagementApp
{
    public partial class RequestedUserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                Gridview_requestedUSer.UseAccessibleHeader = true;
                Gridview_requestedUSer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                // Updated SQL query to filter records with "Pending" approval status
                string query = "SELECT * FROM prodadmin.dpmsloginadminmaster WHERE ApprovalStatus = @ApprovalStatus";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    // Add the parameter for ApprovalStatus
                    cmd.Parameters.AddWithValue("@ApprovalStatus", "Pending");

                    using (NpgsqlDataAdapter sda = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Gridview_requestedUSer.DataSource = dt;
                        Gridview_requestedUSer.DataBind();
                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           

            // Your logic to approve the user with the selected role
            // For example, update the database with the approval status and role
        }

        protected void Gridview_requestedUSer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve")
            {
                // Logic to handle approval, e.g., get the objectid
               // int objectId = Convert.ToInt32(e.CommandArgument);

                // Call a JavaScript function to display the modal
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "showModal();", true);
            }
            else if (e.CommandName == "Reject") {
            }

        }

        protected void Gridview_requestedUSer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //private void LoadApprovalStatus()
        //{
        //    // Fetch all users and their approval statuses
        //    string query = "SELECT UserID, Username, Email, ApprovalStatus FROM Users";
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        gvApprovalStatus.DataSource = dt;
        //        gvApprovalStatus.DataBind();
        //    }
        //}

        //protected void gvApprovalStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Approve" || e.CommandName == "Reject")
        //    {
        //        string userId = e.CommandArgument.ToString();
        //        string status = e.CommandName == "Approve" ? "Approved" : "Rejected";

        //        string query = "UPDATE Users SET ApprovalStatus = @ApprovalStatus WHERE UserID = @UserID";
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@ApprovalStatus", status);
        //            cmd.Parameters.AddWithValue("@UserID", userId);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }

        //        // Refresh the GridView
        //        LoadApprovalStatus();
        //    }
        //}
    }
}