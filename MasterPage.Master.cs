using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManagementApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        String btnClickString;
        LinkButton button;
        private bool isButtonClicked = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
               // SetActiveMenu();
                //btnUpdateUser.CssClass = "menu-button active";
                // Set the initial active item if needed
                //btnDashboard.CssClass = "menu-button active";
                //    // Example data binding
                //    var menuItems = new List<MenuItem>
                //    {
                //        new MenuItem { Label = "Home", IconClass = "bi bi-border-all" },
                //        new MenuItem { Label = "Menu 1", IconClass = "bi bi-receipt" },
                //        new MenuItem { Label = "Menu 2", IconClass = "bi bi-ticket-perforated" },
                //        new MenuItem { Label = "Menu 3", IconClass = "bi bi-person-bounding-box" },
                //        new MenuItem { Label = "Menu 4", IconClass = "bi bi-star" },
                //        new MenuItem { Label = "Menu 5", IconClass = "bi bi-card-checklist" }
                //    };

                //    MenuRepeater.DataSource = menuItems;
                //    MenuRepeater.DataBind();
            }*/

            if (Session["IsButtonClicked"] != null)
            {
                String idString = (string)Session["IsButtonClicked"];                // Logic to skip during button click
                ResetMenuClasses(idString);
                //Button button = FindControlById(idString) as Button;
               // button.CssClass = "menu-button active";


            } else if (!IsPostBack)
            {
                // Set default active button on first load
                // SetActiveMenu("btnDashboard");
                // btnDashboard.BackColor = System.Drawing.Color.Green;
                // btnDashboard.CssClass = "menu-button active";
                //if(button != null)
                //ResetMenuClasses(button);
                lblUserName.Text = (string)Session["user"];
            }
            else
            {
                //btnAddUser.BackColor = System.Drawing.Color.Red;
                // Restore active button from ViewState on postback
                // SetActiveMenu(ViewState["ActiveButton"]?.ToString());
               // btnAddUser.CssClass = "menu-button active";
                //ResetMenuClasses();

            }
        }
        private Control FindControlById(int objectid)
        {
            // Convert the integer ID to string
            string idAsString = objectid.ToString();

            // Check if control is directly on the page
            Control control = Page.FindControl(idAsString);

            // If not found, check if it is inside other containers (e.g., Panel)
            if (control == null)
            {
                control = FindControlRecursive(Page, idAsString);
            }

            return control;
        }

        private Control FindControlRecursive(Control parent, string idAsString)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.ID == idAsString)
                {
                    return control;
                }
                if (control.HasControls())
                {
                    Control foundControl = FindControlRecursive(control, idAsString);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            return null;
        }

        //private Control FindControlById(string id)
        //{
        //    // Check if control is directly on the page
        //    Control control = Page.FindControl(id);

        //    // If not found, check if it is inside other containers (e.g., Panel)
        //    if (control == null)
        //    {
        //        control = FindControlRecursive(Page, id);
        //    }

        //    return control;
        //}

        //private Control FindControlRecursive(Control parent, string id)
        //{
        //    foreach (Control control in parent.Controls)
        //    {
        //        if (control.ID == id)
        //        {
        //            return control;
        //        }
        //        if (control.HasControls())
        //        {
        //            Control foundControl = FindControlRecursive(control, id);
        //            if (foundControl != null)
        //            {
        //                return foundControl;
        //            }
        //        }
        //    }
        //    return null;
        //}
        /*  protected void lnkLogout_Click(object sender, EventArgs e)
          {
              Session.Abandon();
              Response.Redirect("Login.aspx");
          }*/

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            button = sender as LinkButton;
            //ResetMenuClasses();
            Session["IsButtonClicked"] = button.ID;
            //btnDashboard.CssClass = "menu-button active";
            //SetActiveMenu("btnDashboard");
            // Logic for Dashboard button
            Response.Redirect("Dashboard.aspx");
            // btnDashboard.BackColor = System.Drawing.Color.Green;
           
        }

        protected void btnUserList_Click(object sender, EventArgs e)
        {
            btnClickString = btnDashboard.Text;
            button = sender as LinkButton;
            Session["IsButtonClicked"] = button.ID;
            //ResetMenuClasses();
            //btnUserList.CssClass = "menu-button active";
            //SetActiveMenu("btnUserList");
            // Logic for User List button
            Response.Redirect("UserList.aspx");
            // btnUserList.BackColor = System.Drawing.Color.Green;
           
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            button = sender as LinkButton;
            //ResetMenuClasses();
            Session["IsButtonClicked"] = button.ID;
            //btnAddUser.CssClass = "menu-button active";
            // SetActiveMenu("btnAddUser");
            // Logic for Add User button
            Response.Redirect("AddUser.aspx");
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", "window.location.href='AddUser.aspx';", true);
            // btnAddUser.BackColor = System.Drawing.Color.Green;
           
            
        }

        //protected void btnUpdateUser_Click(object sender, EventArgs e)
        //{
        //    //ResetMenuClasses();
        //    //btnUpdateUser.CssClass = "menu-button active";
        //    // Logic for Update User button
        //    Response.Redirect("UpdateUser.aspx");
        //}

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            button = sender as LinkButton;
            Session["IsButtonClicked"] = button.ID;
            // ResetMenuClasses();
            //btnContactUs.CssClass = "menu-button active";
            // btnDashboard.Attributes.Add("class", "menu-button active");
            // btnContactUs.Attributes["class"] = "menu-button active";
            // btnContactUs.Attributes["class"] = "menu-button active";
            // SetActiveMenu("btnContactUs");
            // Logic for Contact Us button
            Response.Redirect("ContactUs.aspx");
            
        }

        private void SetActiveMenu(string activeButtonId)
        {
            // Remove 'active' class from all buttons
            btnDashboard.CssClass = "menu-button";
            btnUserList.CssClass = "menu-button";
            btnAddUser.CssClass = "menu-button";
            //btnContactUs.CssClass = "menu-button";

            // Add 'active' class to the selected button
            var activeButton = FindControl(activeButtonId) as LinkButton;
            if (activeButton != null)
            {
                activeButton.CssClass += ".active";
                ViewState["ActiveButton"] = activeButtonId; // Save active button in ViewState
            }
        }
       /* private void ResetMenuClasses(LinkButton inputString)
        {
            
            
            btnDashboard.CssClass = "menu-button";
            btnAddUser.CssClass = "menu-button";
            btnUserList.CssClass = "menu-button";
            btnContactUs.CssClass = "menu-button";
            inputString.CssClass = "menu-button";
            //btnDashboard.Attributes.Add("class", "menu-button");
            //btnUserList.Attributes.Add("class", "menu-button");
            //btnAddUser.Attributes.Add("class", "menu-button");
            //btnUpdateUser.Attributes.Add("class", "menu-button");
            //btnContactUs.Attributes.Add("class", "menu-button");
            //btnDashboard.Attributes["class"] = "menu-button";
            //btnUserList.Attributes["class"] = "menu-button";
            //btnAddUser.Attributes["class"] = "menu-button";
            ////btnUpdateUser.Attributes["class"] = "menu-button";
            //btnContactUs.Attributes["class"] = "menu-button";
        }*/

        protected void btnLogout(object sender, EventArgs e)
        {
            Console.WriteLine("Logout");
            // Clear session data
            Session.Clear();

            // Optionally abandon the session entirely (removes session cookie)
            Session.Abandon();

            // Redirect to login page (replace with your login page URL)
            Response.Redirect("~/Default.aspx");
        }
        private void ResetMenuClasses(String btnstring)
        {
            btnDashboard.CssClass = "menu-button";
            btnUserList.CssClass = "menu-button";
            btnAddUser.CssClass = "menu-button";
           // btnUpdateUser.CssClass = "menu-button";
            //btnContactUs.CssClass = "menu-button";
            if (btnstring == "btnDashboard")
            {
                btnDashboard.CssClass = "menu-button active";
            }
            else if (btnstring == "btnUserList")
            {
                btnUserList.CssClass = "menu-button active";
            }
            else if (btnstring == "btnAddUser")
            {
                btnAddUser.CssClass = "menu-button active";
            }
            //else if (btnstring == "btnContactUs")
            //{
            //    btnContactUs.CssClass = "menu-button active";
            //}

        }

        protected void btnRequestedUSer_Click(object sender, EventArgs e)
        {
            button = sender as LinkButton;
            Session["IsButtonClicked"] = button.ID;
            
            Response.Redirect("RequestedUserList.aspx");

        }
        //protected void lnkLogout_Click(object sender, EventArgs e)
        //{
        //    // Your logout logic here
        //    // For example:
        //    Session.Abandon();
        //    Response.Redirect("Login.aspx");
        //}
        //public class MenuItem
        //{
        //    public string Label { get; set; }
        //    public string IconClass { get; set; }
        //}
    }
}