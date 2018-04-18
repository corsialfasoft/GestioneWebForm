using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _Corso : Page {
        DataAccesObject d = new DataAccesObject();
        public Corso corso{get;set;}
        public string Message{get;set;}
        protected void Page_Load(object sender,EventArgs e) {
            string a = Request["id"];
            if(int.TryParse(a, out int idi)){ 
                corso = d.SearchCorsi(idi); 
            }else{
                Message = "Nessun elemento trovato";     
            }
        }
    }
}