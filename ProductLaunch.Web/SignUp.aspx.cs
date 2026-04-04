using ProductLaunch.Entities;
using ProductLaunch.Model;
using ProductLaunch.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductLaunch.Web
{
    public partial class SignUp : Page
    {
        private static Dictionary<string, Country> _Countries;
        private static Dictionary<string, Role> _Roles;

        public static void PreloadStaticDataCache()
        {
            _Countries = new Dictionary<string, Country>();
            _Roles = new Dictionary<string, Role>();
            using (var context = new ProductLaunchContext())
            {
                foreach (var country in context.Countries.OrderBy(x => x.CountryName))
                    _Countries[country.CountryCode] = country;
                foreach (var role in context.Roles.OrderBy(x => x.RoleName))
                    _Roles[role.RoleCode] = role;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateRoles();
                PopulateCountries();
            }
        }

        private void PopulateRoles()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.AddRange(_Roles.Select(x => new ListItem(x.Value.RoleName, x.Key)).ToArray());
        }

        private void PopulateCountries()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.AddRange(_Countries.Select(x => new ListItem(x.Value.CountryName, x.Key)).ToArray());
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            var prospect = new Prospect
            {
                FirstName   = txtFirstName.Text,
                LastName    = txtLastName.Text,
                EmailAddress = txtEmail.Text,
                CompanyName = txtCompanyName.Text,
                Country     = _Countries[ddlCountry.SelectedValue],
                Role        = _Roles[ddlRole.SelectedValue]
            };

            new NatsPublisher().PublishProspect(prospect);

            Server.Transfer("ThankYou.aspx");
        }
    }
}
