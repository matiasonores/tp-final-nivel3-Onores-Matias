using Dominio;
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
            VerificarAcceso();
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
                Session.Clear();
                Response.Redirect("Login.aspx");
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

        private void VerificarAcceso()
        {
            try
            {
                bool puedeVer;
                bool esAdmin = false;
                Usuario user = Session["User"] != null ? (Usuario)Session["User"] : null;

                if (user != null)
                {
                    esAdmin = user.Admin;

                    if(esAdmin)
                    {
                        puedeVer = true;
                    }
                    else
                    {
                        puedeVer =  Page is _Default || Page is Perfil || Page is ArticulosFavoritos || Page is DetalleArticulo;
                        btnArticulos.Visible = false;
                        btnCategorias.Visible = false;
                        //btnFavoritos.Visible = false;
                    }
                }
                else 
                {
                    puedeVer = Page is Login || Page is _Default || Page is Signin;
                    btnArticulos.Visible = false;
                    btnCategorias.Visible = false;
                    btnFavoritos.Visible = false;
                }

                if (!puedeVer)
                {
                    Response.Redirect("Login.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}