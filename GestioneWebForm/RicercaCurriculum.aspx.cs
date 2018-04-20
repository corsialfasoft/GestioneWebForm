using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DAO;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class _RicercaCurriculum : Page {
		public string Message { get;set;}
		public List<CV> trovati { get;set;}
		DataAccesObject dao = new DataAccesObject();
        protected void Page_Load(object sender,EventArgs e) {

        }

		protected void Cerca_Click(object sender,EventArgs e)
		{
			trovati= new List<CV>();
			int eta=0;
			int etaMin=0;
			int etaMax=0;
			if(Chiava.Text != "") {
				trovati=dao.SearchChiava(Chiava.Text);
			}else if (Eta.Text!="" && int.TryParse(Eta.Text,out eta)){
					trovati=dao.SearchEta(eta);
			}else if (EtaMin.Text!=""&& int.TryParse(EtaMin.Text,out etaMin)&&EtaMax.Text!="" && int.TryParse(EtaMax.Text,out etaMax)) {
				if(etaMin < etaMax) { 
				trovati = dao.SearchRange(etaMin,etaMax);
				} else {
					Message="Inserire un range di età valido";
				}
			}else if(Cognome.Text != "") {
				trovati=dao.SearchCognome(Cognome.Text);
			} else  {
				Message="Inserire dei campi di ricerca validi";
			}
			if(trovati.Count > 0) {
				Session["listaCV"]=trovati;
				var url=$"~/ListCV.aspx";
				Response.Redirect(url);
			} else {
				Message="Non è stato trovato alcun elemento con i parametri di ricerca";
			}
		}
	}
}