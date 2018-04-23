using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _PerStud : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public List<PerStud> percorsi{get;set;}
        public bool add{get;set;}
        protected void Page_Load(object sender,EventArgs e) {
            add = false;
            string matr = Request["matr"];
            percorsi = dao. GetPerStudi(matr);
        }

		protected void AggiungiBut_Click(object sender,EventArgs e){
            add=true;
		}
        protected void Aggiungi_Click(object sender,EventArgs e){
            add=true;
		}
        protected void Modifica_Click(object sender,EventArgs e){
            add=true;
		}
	}
}