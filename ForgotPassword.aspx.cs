using Npgsql;
using System;
using System.Configuration;
using System.Web.UI;

namespace UserManagementApp
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialization logic if any
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Ensure that the passwords match
            if (newPassword != confirmPassword)
            {
                Response.Write("<script>alert('Passwords do not match. Please try again.');</script>");
                return;
            }

            try
            {
                // Update password in PostgreSQL database
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
                using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = "UPDATE prodadmin.dpmsloginadminmaster SET Password = @Password, ConfirmPass = @confirmpasswordWHERE Username = @Username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Password reset successful.');</script>");
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Password reset failed. Username not found.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // Logger.Log(ex);
                Response.Write("<script>alert('An error occurred. Please try again later.');</script>");
            }
        }
    }
}
