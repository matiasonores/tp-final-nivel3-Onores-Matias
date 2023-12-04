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
    }
}