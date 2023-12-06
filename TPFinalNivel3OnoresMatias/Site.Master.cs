using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3OnoresMatias
{
    public partial class SiteMaster : MasterPage
    {
        public bool isLoggedIn { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            isLoggedIn = Session["User"] != null ? true : false;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

        protected void btnSigin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Signin.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}