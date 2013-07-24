<%@ Application CodeBehind="Global.asax.cs" Language="C#" %>
<script RunAt="server">
    protected void Application_Start(object sender, EventArgs e) {
        Application.Lock();
        Application["DataDirectory"] = Server.MapPath("/App_Data");
        Application.UnLock();
    }

    protected void Session_Start(object sender, EventArgs e) {

    }

    protected void Application_BeginRequest(object sender, EventArgs e) {

    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e) {

    }

    protected void Application_Error(object sender, EventArgs e) {

    }

    protected void Session_End(object sender, EventArgs e) {

    }

    protected void Application_End(object sender, EventArgs e) {

    }
</script>
