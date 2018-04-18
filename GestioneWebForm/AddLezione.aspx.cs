using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GestioneWebForm;
using DAO;

namespace GestioneWebForm {
    public partial class AddLezione : Page {
				public Lezione newlesson {get; set;}
				protected void Page_Load(object sender,EventArgs e) {
					
				}
				public void AddLezione_Click(object sender,EventArgs e) {	
					Lezione newlesson = new Lezione();
					DataAccesObject DataAccess = new DataAccesObject();
					newlesson.Nome = nome.Text;
					newlesson.Descrizione = descrizione.Text;
					newlesson.Durata = int.Parse(Durata.Text);
                    string a = Request["idCorso"];
					DataAccess.AddLezione(int.Parse(a),newlesson);

				}  
	}	
}