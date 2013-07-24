using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        m_submit.Click += new EventHandler(m_submit_Click);
    }

    void m_submit_Click(object sender, EventArgs e) {
        Session["user"] = m_username.Text;
        Session["pass"] = m_password.Text;
        Response.Redirect((string)Session["return"] ?? "/");
    }
}