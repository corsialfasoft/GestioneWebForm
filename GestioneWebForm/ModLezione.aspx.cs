using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _ModLezione : Page {
		DataAccesObject dao= new DataAccesObject();
        protected void Page_Load(object sender,EventArgs e) {
			int x;
			int.TryParse(Request["id"],out x);
			Lezione lez=dao.SearchLezione(x);
			argomento.Text=lez.Argomento;
			Durata.Text=lez.Durata.ToString();
        }

		protected void ModLezione_Click (object sender,EventArgs e)
		{
			
		}
	}
}