using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserManagementApp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["PostgreSQL 14"].ConnectionString;
        Boolean initialload = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // initialload = true;
                regionDropdownList();

            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //regionDropdownList();
            // initialload=false;
            ddlCircle.Items.Clear();
            ddlDivision.Items.Clear();
            //ddlDistrict.Items.Clear();
            lblCircle.Text = "0";
            lblDivision.Text = "0";
            //lblDistrict.Text = "0";
            ddlCircle.Items.Insert(0, new ListItem("Select Circle", "0"));
            ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
           // ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));


            string selectedValue = ddlRegion.SelectedItem.Text;
            string selectedCount = ddlRegion.SelectedItem.Value;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                lblRegion.Text = selectedCount;
                getCircleData(selectedValue);
            }
        }

        protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDivision.Items.Clear();
            //ddlDistrict.Items.Clear();

            lblDivision.Text = "0";
           // lblDistrict.Text = "0";
            ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
           // ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));

            string selectedValue = ddlCircle.SelectedItem.Text;
            string selectedCount = ddlCircle.SelectedItem.Value;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                lblCircle.Text = selectedCount;
                getDivisionData(selectedValue);
            }
        }

      
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlDistrict.Items.Clear();

            //lblDistrict.Text = "0";
            //ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));

            string selectedValue = ddlDivision.SelectedItem.Text;
            string selectedCount = ddlDivision.SelectedItem.Value;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                lblDivision.Text = selectedCount;
                //getDistrictData(selectedValue);
            }
        }

        //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //initialload = false;

        //    string selectedValue = ddlDistrict.SelectedItem.Text;
        //    string selectedCount = ddlDistrict.SelectedItem.Value;
        //    if (!string.IsNullOrEmpty(selectedValue))
        //    {
        //        lblDistrict.Text = selectedCount;
        //        //  getDistrictData(selectedValue);
        //    }
        //}

        private void getDivisionData(string selectedValue)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();

                string query = "SELECT division, COUNT(*) AS user_count FROM prodadmin.dpmsloginadminmaster WHERE circle = @regionValue GROUP BY division";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@regionValue", selectedValue);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        Dictionary<string, int> regionUserCounts3 = new Dictionary<string, int>();
                        int totalUserCount3 = 0;

                        while (dr.Read())
                        {
                            // Get the region and corresponding user count from the query
                            string region3 = dr["division"].ToString();
                            int userCount3 = Convert.ToInt32(dr["user_count"]);
                            if (!string.IsNullOrWhiteSpace(region3))
                            {
                                // Sum up the user counts
                                totalUserCount3 += userCount3;

                                // Check if the key already exists in the dictionary
                                if (regionUserCounts3.ContainsKey(region3))
                                {
                                    // If the region already exists, you may choose to update the count (e.g., sum the counts)
                                    regionUserCounts3[region3] += userCount3;
                                }
                                else
                                {
                                    // If the region does not exist, add it to the dictionary
                                    regionUserCounts3.Add(region3, userCount3);
                                }
                            }
                        }

                        // Bind the dictionary to the dropdown list
                        ddlDivision.DataSource = regionUserCounts3;
                        ddlDivision.DataTextField = "Key";  // The region name
                        ddlDivision.DataValueField = "Value";  // The user count (if needed)
                        ddlDivision.DataBind();
                    }
                }
            }
            ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));

            //using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            //{
            //    conn.Open();

            //    string query = "SELECT division, COUNT(*) AS user_count FROM dpms.loginadminmaster where circle = @regionValue GROUP BY division";
            //    //  string query = "SELECT circle, COUNT(*) AS user_count FROM dpms.loginadminmaster where circle= @regionValue";

            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@regionValue", selectedValue);
            //        using (NpgsqlDataReader dr = cmd.ExecuteReader())
            //        {
            //            Dictionary<string, int> regionUserCounts3 = new Dictionary<string, int>();
            //            int totalUserCount3 = 0;

            //            while (dr.Read())
            //            {
            //                // Add the region and corresponding user count to the dictionary
            //                string region3 = dr["division"].ToString();
            //                int userCount3 = Convert.ToInt32(dr["user_count"]);
            //                // Sum up the user counts
            //                totalUserCount3 += userCount3;
            //                regionUserCounts3.Add(region3, userCount3);
            //            }

            //            // Bind the dictionary to the dropdown list
            //            ddlDivision.DataSource = regionUserCounts3;//regionUserCounts.Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key }).ToList();// regionUserCounts;
            //            ddlDivision.DataTextField = "Key";   // The region name
            //            ddlDivision.DataValueField = "Value"; // The user count (if needed)
            //            ddlDivision.DataBind();

            //            // Optionally, display the total count of regions somewhere
            //            // lblCircle.Text = "" + totalUserCount.ToString();
            //        }
            //    }


            //}
            //using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            //{
            //    conn.Open();

            //    // Query to get all values from a specific column in the table
            //    string query = "SELECT division FROM dpms.loginadminmaster where circle= @selectedValue";

            //    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            //    {
            //        cmd.Parameters.AddWithValue("@selectedValue", selectedValue);
            //        using (NpgsqlDataReader dr = cmd.ExecuteReader())
            //        {

            //            HashSet<string> columnValues = new HashSet<string>();


            //            while (dr.Read())
            //            {
            //                // Add values to HashSet to ensure distinct entries
            //                columnValues.Add(dr["division"].ToString());

            //            }


            //            ddlDivision.DataSource = columnValues;
            //            ddlDivision.DataBind();

            //        }
            //    }
            //}

            //if (ddlDivision.Items.Count > 1 && initialload)
            //{
            //    ddlDivision.SelectedIndex = 0;  // Set the first non-default value
            //    ddlDivision_SelectedIndexChanged(ddlDivision, EventArgs.Empty);  // Manually trigger the event for ddlRegion
            //}

            // Optionally, add a default item to the dropdown (like "Select...")
            // ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
        }

        //private void getDistrictData(string selectedValue)
        //{

        //    using (NpgsqlConnection conn = new NpgsqlConnection(cs))
        //    {
        //        conn.Open();

        //        string query = "SELECT district, COUNT(*) AS user_count FROM prodadmin.dpmsloginadminmaster where division = @regionValue GROUP BY district";
        //        //  string query = "SELECT circle, COUNT(*) AS user_count FROM dpms.loginadminmaster where circle= @regionValue";

        //        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@regionValue", selectedValue);
        //            using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                Dictionary<string, int> regionUserCounts = new Dictionary<string, int>();
        //                int totalUserCount = 0;

        //                while (dr.Read())
        //                {
        //                    // Add the region and corresponding user count to the dictionary
        //                    string region = dr["district"].ToString();
        //                    int userCount = Convert.ToInt32(dr["user_count"]);
        //                    if (!string.IsNullOrWhiteSpace(region))
        //                    {
        //                        // Sum up the user counts
        //                        totalUserCount += userCount;
        //                        regionUserCounts.Add(region, userCount);
        //                    }
        //                }

        //                // Bind the dictionary to the dropdown list
        //                ddlDistrict.DataSource = regionUserCounts;//regionUserCounts.Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key }).ToList();// regionUserCounts;
        //                ddlDistrict.DataTextField = "Key";   // The region name
        //                ddlDistrict.DataValueField = "Value"; // The user count (if needed)
        //                ddlDistrict.DataBind();

        //                // Optionally, display the total count of regions somewhere
        //                // lblCircle.Text = "" + totalUserCount.ToString();
        //            }
        //        }


        //    }

        //    //using (NpgsqlConnection conn = new NpgsqlConnection(cs))
        //    //{
        //    //    conn.Open();

        //    //    // Query to get all values from a specific column in the table
        //    //    string query = "SELECT district FROM dpms.loginadminmaster where division= @selectedValue";

        //    //    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //    //    {
        //    //        cmd.Parameters.AddWithValue("@selectedValue", selectedValue);
        //    //        using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //    //        {

        //    //            HashSet<string> columnValues = new HashSet<string>();


        //    //            while (dr.Read())
        //    //            {
        //    //                // Add values to HashSet to ensure distinct entries
        //    //                columnValues.Add(dr["district"].ToString());

        //    //            }


        //    //            ddlDistrict.DataSource = columnValues;
        //    //            ddlDistrict.DataBind();

        //    //        }
        //    //    }
        //    //}

        //    // Optionally, add a default item to the dropdown (like "Select...")
        //     ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));

        //    //if (ddlDistrict.Items.Count > 1 && initialload)
        //    //{
        //    //    ddlDistrict.SelectedIndex = 0;  // Set the first non-default value
        //    //    ddlDistrict_SelectedIndexChanged(ddlDistrict, EventArgs.Empty);  // Manually trigger the event for ddlRegion
        //    //}
        //}

        private void getCircleData(String regionValue)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();

                string query = "SELECT circle, COUNT(*) AS user_count FROM prodadmin.dpmsloginadminmaster where region = @regionValue GROUP BY circle";
              //  string query = "SELECT circle, COUNT(*) AS user_count FROM dpms.loginadminmaster where circle= @regionValue";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@regionValue", regionValue);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        Dictionary<string, int> regionUserCounts1 = new Dictionary<string, int>();
                        int totalUserCount1 = 0;

                        while (dr.Read())
                        {
                            // Add the region and corresponding user count to the dictionary
                            string region = dr["circle"].ToString();
                            int userCount = Convert.ToInt32(dr["user_count"]);
                            if (!string.IsNullOrWhiteSpace(region))
                            {
                                // Sum up the user counts
                                totalUserCount1 += userCount;
                                regionUserCounts1.Add(region, userCount);
                            }
                        }

                        // Bind the dictionary to the dropdown list
                        ddlCircle.DataSource = regionUserCounts1;//regionUserCounts.Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key }).ToList();// regionUserCounts;
                        ddlCircle.DataTextField = "Key";   // The region name
                        ddlCircle.DataValueField = "Value"; // The user count (if needed)
                        ddlCircle.DataBind();

                        // Optionally, display the total count of regions somewhere
                       // lblCircle.Text = "" + totalUserCount.ToString();
                    }
                }

                // Query to get all values from a specific column in the table
                //string query = "SELECT circle FROM dpms.loginadminmaster where circle= @regionValue";

                //using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                //{
                //    cmd.Parameters.AddWithValue("@regionValue", regionValue);
                //    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                //    {

                //        HashSet<string> columnValues = new HashSet<string>();


                //        while (dr.Read())
                //        {
                //            // Add values to HashSet to ensure distinct entries
                //            columnValues.Add(dr["circle"].ToString());

                //        }


                //        ddlCircle.DataSource = columnValues;
                //        ddlCircle.DataBind();

                //    }
                //}
            }

            // Optionally, add a default item to the dropdown (like "Select...")
           ddlCircle.Items.Insert(0, new ListItem("Select Circle", "0"));
           //hrow new NotImplementedException();
            //if (ddlCircle.Items.Count > 1 && initialload )
            //{
            //    ddlCircle.SelectedIndex = 0;  // Set the first non-default value
            //    ddlCircle_SelectedIndexChanged(ddlCircle, EventArgs.Empty);  // Manually trigger the event for ddlRegion
            //}
        }

        //private void regionDropdownList()
        //{

        //    using (NpgsqlConnection conn = new NpgsqlConnection(cs))
        //    {
        //        conn.Open();

        //        // Query to get all values from a specific column in the table
        //        string query = "SELECT region FROM dpms.loginadminmaster";

        //        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //        {
        //            using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //            {

        //                HashSet<string> columnRegionValues = new HashSet<string>();


        //                while (dr.Read())
        //                {
        //                    // Add values to HashSet to ensure distinct entries
        //                    columnRegionValues.Add(dr["region"].ToString());

        //                }


        //                ddlRegion.DataSource = columnRegionValues;
        //                ddlRegion.DataBind();

        //            }
        //        }
        //    }

        //    // Optionally, add a default item to the dropdown (like "Select...")
        //    // ddlRegion.Items.Insert(0, new ListItem("Select region", "0"));

        //}

        private void regionDropdownList()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(cs))
            {
                conn.Open();

                // Query to get the region and the count of users in each region
                string query = "SELECT region, COUNT(*) AS user_count FROM prodadmin.dpmsloginadminmaster GROUP BY region";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        Dictionary<string, int> regionUserCounts2 = new Dictionary<string, int>();
                        int totalUserCount2 = 0;

                        while (dr.Read())
                        {
                            // Add the region and corresponding user count to the dictionary
                            string region = dr["region"].ToString();
                            int userCount = Convert.ToInt32(dr["user_count"]);
                            if (!string.IsNullOrWhiteSpace(region))
                            {
                                // Sum up the user counts
                                totalUserCount2 += userCount;
                                regionUserCounts2.Add(region, userCount);
                            }
                        }

                        // Bind the dictionary to the dropdown list
                        ddlRegion.DataSource = regionUserCounts2;//regionUserCounts.Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key }).ToList();// regionUserCounts;
                        ddlRegion.DataTextField = "Key";   // The region name
                        ddlRegion.DataValueField = "Value"; // The user count (if needed)
                        ddlRegion.DataBind();

                        // Optionally, display the total count of regions somewhere
                       // lblRegion.Text = "" + totalUserCount.ToString();
                    }
                }
            }

            // Optionally, add a default item to the dropdown (like "Select region")
            ddlRegion.Items.Insert(0, new ListItem("Select region", "0"));
            // ddlRegion_SelectedIndexChanged(ddlRegion, EventArgs.Empty);
            //if (ddlRegion.Items.Count > 1 && initialload) // Ensure dropdown has items
            //{
            //    ddlRegion.SelectedIndex = 0;  // Set the first non-default value
            //    ddlRegion_SelectedIndexChanged(ddlRegion, EventArgs.Empty);  // Manually trigger the event for ddlRegion
            //}

        }

        //private void regionDropdownList()
        //{
        //    using (NpgsqlConnection conn = new NpgsqlConnection(cs))
        //    {
        //        conn.Open();

        //        // Combined query for region, circle, division, and district with user count
        //        string query = @"
        //SELECT 'Region' AS level, region AS name, COUNT(*) AS user_count
        //FROM dpms.loginadminmaster
        //GROUP BY region
        //UNION ALL
        //SELECT 'Circle' AS level, circle AS name, COUNT(*) AS user_count
        //FROM dpms.loginadminmaster
        //GROUP BY circle
        //UNION ALL
        //SELECT 'Division' AS level, division AS name, COUNT(*) AS user_count
        //FROM dpms.loginadminmaster
        //GROUP BY division
        //UNION ALL
        //SELECT 'District' AS level, district AS name, COUNT(*) AS user_count
        //FROM dpms.loginadminmaster
        //GROUP BY district;";

        //        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //        {
        //            using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                // Dictionaries to store the combined results of region, circle, division, and district
        //                Dictionary<string, int> regionUserCounts = new Dictionary<string, int>();
        //                Dictionary<string, int> circleUserCounts = new Dictionary<string, int>();
        //                Dictionary<string, int> divisionUserCounts = new Dictionary<string, int>();
        //                Dictionary<string, int> districtUserCounts = new Dictionary<string, int>();

        //                int regionTotalUserCount = 0;
        //                int circleTotalUserCount = 0;
        //                int divisionTotalUserCount = 0;
        //                int districtTotalUserCount = 0;

        //                while (dr.Read())
        //                {
        //                    // Get the grouping level (Region, Circle, Division, District)
        //                    string level = dr["level"].ToString();
        //                    string name = dr["name"].ToString();
        //                    int userCount = Convert.ToInt32(dr["user_count"]);

        //                    if (level == "Region")
        //                    {
        //                        regionTotalUserCount += userCount;
        //                        if (regionUserCounts.ContainsKey($"{level}: {name}"))
        //                        {
        //                            // If the key exists, update the value by adding the user count
        //                            regionUserCounts[$"{level}: {name}"] += userCount;
        //                        }
        //                        else
        //                        {
        //                            regionUserCounts.Add($"{level}: {name}", userCount);
        //                        }
        //                    }
        //                    else if (level == "Circle")
        //                    {
        //                        circleTotalUserCount += userCount;
        //                        if (circleUserCounts.ContainsKey($"{level}: {name}"))
        //                        {
        //                            // If the key exists, update the value by adding the user count
        //                            circleUserCounts[$"{level}: {name}"] += userCount;
        //                        }
        //                        else
        //                        {
        //                            circleUserCounts.Add($"{level}: {name}", userCount);
        //                        }
        //                    }
        //                    else if (level == "Division")
        //                    {
        //                        divisionTotalUserCount += userCount;
        //                        if (divisionUserCounts.ContainsKey($"{level}: {name}"))
        //                        {
        //                            // If the key exists, update the value by adding the user count
        //                            divisionUserCounts[$"{level}: {name}"] += userCount;
        //                        }
        //                        else
        //                        {
        //                            divisionUserCounts.Add($"{level}: {name}", userCount);
        //                        }
        //                    }
        //                    else if (level == "District")
        //                    {
        //                        districtTotalUserCount += userCount;
        //                        if (districtUserCounts.ContainsKey($"{level}: {name}"))
        //                        {
        //                            // If the key exists, update the value by adding the user count
        //                            districtUserCounts[$"{level}: {name}"] += userCount;
        //                        }
        //                        else
        //                        {
        //                            districtUserCounts.Add($"{level}: {name}", userCount);
        //                        }
        //                    }
        //                }

        //                // Bind the dictionaries to the dropdown lists
        //                // Region
        //                ddlRegion.DataSource = regionUserCounts
        //                    .Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key })
        //                    .ToList();
        //                ddlRegion.DataTextField = "Text";   // The level (region, circle, etc.) and name with user count
        //                ddlRegion.DataValueField = "Value"; // Just the name (region, circle, etc.)
        //                ddlRegion.DataBind();
        //                lblRegion.Text = "" + regionTotalUserCount.ToString();

        //                // Circle
        //                ddlCircle.DataSource = circleUserCounts
        //                    .Select(c => new { Text = c.Key + " (" + c.Value + " users)", Value = c.Key })
        //                    .ToList();
        //                ddlCircle.DataTextField = "Text";
        //                ddlCircle.DataValueField = "Value";
        //                ddlCircle.DataBind();
        //                lblCircle.Text = "" + circleTotalUserCount.ToString();

        //                // Division
        //                ddlDivision.DataSource = divisionUserCounts
        //                    .Select(d => new { Text = d.Key + " (" + d.Value + " users)", Value = d.Key })
        //                    .ToList();
        //                ddlDivision.DataTextField = "Text";
        //                ddlDivision.DataValueField = "Value";
        //                ddlDivision.DataBind();
        //                lblDivision.Text = "" + divisionTotalUserCount.ToString();

        //                // District
        //                ddlDistrict.DataSource = districtUserCounts
        //                    .Select(d => new { Text = d.Key + " (" + d.Value + " users)", Value = d.Key })
        //                    .ToList();
        //                ddlDistrict.DataTextField = "Text";
        //                ddlDistrict.DataValueField = "Value";
        //                ddlDistrict.DataBind();
        //                lblDistrict.Text = "" + districtTotalUserCount.ToString();
        //            }
        //        }
        //    }

        //    // Optionally, add a default item to each dropdown (like "Select Region", "Select Circle", etc.)
        //    //ddlRegion.Items.Insert(0, new ListItem("Select Region", "0"));
        //    //ddlCircle.Items.Insert(0, new ListItem("Select Circle", "0"));
        //    //ddlDivision.Items.Insert(0, new ListItem("Select Division", "0"));
        //    //ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));

        //    if (ddlRegion.Items.Count > 1)  // Ensure dropdown has items
        //    {
        //        ddlRegion.SelectedIndex = 0;  // Set the first non-default value
        //        ddlRegion_SelectedIndexChanged(ddlRegion, EventArgs.Empty);  // Manually trigger the event for ddlRegion
        //    }

        //}


        //private void regionDropdownList()
        //{
        //    using (NpgsqlConnection conn = new NpgsqlConnection(cs))
        //    {
        //        conn.Open();

        //        // Query to get the region and the count of users in each region
        //        string query = "SELECT region, COUNT(*) AS user_count FROM dpms.loginadminmaster GROUP BY region";

        //        using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
        //        {
        //            using (NpgsqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                Dictionary<string, int> regionUserCounts = new Dictionary<string, int>();
        //                int totalUserCount = 0;

        //                while (dr.Read())
        //                {
        //                    // Add the region and corresponding user count to the dictionary
        //                    string region = dr["region"].ToString();
        //                    int userCount = Convert.ToInt32(dr["user_count"]);
        //                    // Sum up the user counts
        //                    totalUserCount += userCount;
        //                    regionUserCounts.Add(region, userCount);
        //                }

        //                // Bind the dictionary to the dropdown list
        //                ddlRegion.DataSource = regionUserCounts;//regionUserCounts.Select(r => new { Text = r.Key + " (" + r.Value + " users)", Value = r.Key }).ToList();// regionUserCounts;
        //                ddlRegion.DataTextField = "Key";   // The region name
        //                ddlRegion.DataValueField = "Value"; // The user count (if needed)
        //                ddlRegion.DataBind();

        //                // Optionally, display the total count of regions somewhere
        //                lblRegion.Text = "" + totalUserCount.ToString();
        //            }
        //        }
        //    }

        //    // Optionally, add a default item to the dropdown (like "Select region")
        //    //ddlRegion.Items.Insert(0, new ListItem("Select region", "0"));
        //    // ddlRegion_SelectedIndexChanged(ddlRegion, EventArgs.Empty);
        //    if (ddlRegion.Items.Count > 1)  // Ensure dropdown has items
        //    {
        //        ddlRegion.SelectedIndex = 0;  // Set the first non-default value
        //        ddlRegion_SelectedIndexChanged(ddlRegion, EventArgs.Empty);  // Manually trigger the event for ddlRegion
        //    }

        //}


    }
}