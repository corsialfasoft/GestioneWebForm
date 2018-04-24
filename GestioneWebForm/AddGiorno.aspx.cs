using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
    public partial class _AddGiorno : Page {
		DataAccesObject dao = new DataAccesObject();
        public string Message{ get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }

		protected void Aggiungi_Click(object sender,EventArgs e){
		}
    }
}