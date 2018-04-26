using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class listaCV : Page {
        List<CV> curriculums {get; set;}
        protected void Page_Load(object sender,EventArgs e) { 
            curriculums = (List<CV>)Session["listaCV"] ?? null;
            ListaCVPg.CV  = curriculums;
            ListaCVPg.Update();
        }
       
    }
}