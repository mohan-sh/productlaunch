using ProductLaunch.Model;
using System;
using System.Linq;
using System.Web.UI;

namespace ProductLaunch.Web.Admin
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUser"] != null)
                Response.Redirect("Dashboard.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            using (var db = new ProductLaunchContext())
            {
                var admin = db.AdminUsers
                    .FirstOrDefault(a => a.Username == username && a.Password == password);

                if (admin != null)
                {
                    Session["AdminUser"] = admin.Username;
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    lblError.Text = "Invalid username or password.";
                }
            }
        }
    }
}
