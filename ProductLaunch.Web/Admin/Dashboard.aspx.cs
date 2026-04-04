using ProductLaunch.Model;
using System;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductLaunch.Web.Admin
{
    public partial class Dashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblWelcome.Text = Session["AdminUser"].ToString();

            if (!IsPostBack)
            {
                PopulateFilters();
                LoadProspects();
            }
        }

        private void PopulateFilters()
        {
            using (var db = new ProductLaunchContext())
            {
                ddlCountry.Items.Clear();
                ddlCountry.Items.Add(new ListItem("All Countries", ""));
                foreach (var c in db.Countries.OrderBy(x => x.CountryName))
                    ddlCountry.Items.Add(new ListItem(c.CountryName, c.CountryCode));

                ddlRole.Items.Clear();
                ddlRole.Items.Add(new ListItem("All Roles", ""));
                foreach (var r in db.Roles.OrderBy(x => x.RoleName))
                    ddlRole.Items.Add(new ListItem(r.RoleName, r.RoleCode));
            }
        }

        private void LoadProspects()
        {
            var country = ddlCountry.SelectedValue;
            var role    = ddlRole.SelectedValue;
            var search  = txtSearch.Text.Trim();

            using (var db = new ProductLaunchContext())
            {
                var q = db.Prospects.Include("Country").Include("Role").AsQueryable();

                if (!string.IsNullOrEmpty(country))
                    q = q.Where(x => x.Country.CountryCode == country);
                if (!string.IsNullOrEmpty(role))
                    q = q.Where(x => x.Role.RoleCode == role);
                if (!string.IsNullOrEmpty(search))
                    q = q.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.EmailAddress.Contains(search));

                var list = q.ToList();
                lblTotal.Text = "Total Prospects: " + list.Count;
                gvProspects.DataSource = list;
                gvProspects.DataBind();
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadProspects();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            using (var db = new ProductLaunchContext())
            {
                var prospects = db.Prospects.Include("Country").Include("Role").ToList();
                var csv = new StringBuilder();
                csv.AppendLine("FirstName,LastName,Email,Company,Country,Role");
                foreach (var p in prospects)
                    csv.AppendLine($"{p.FirstName},{p.LastName},{p.EmailAddress},{p.CompanyName},{p.Country?.CountryName},{p.Role?.RoleName}");

                Response.Clear();
                Response.ContentType = "text/csv";
                Response.AddHeader("Content-Disposition", "attachment; filename=prospects.csv");
                Response.Write(csv.ToString());
                Response.End();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
