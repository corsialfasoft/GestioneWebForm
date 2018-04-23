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
        public PerStud percorso{get;set;}
        public string Message{get;set;}
        public bool add{get;set;}
        protected void Page_Load(object sender,EventArgs e) {add = false;
            //if(int.TryParse(Request["idPs"],out int idPs)){
            int idPs = 1;
                percorso = dao.GetPercorso(idPs);
                annoI.Text = percorso.AnnoInizio.ToString();
                annoF.Text = percorso.AnnoFine.ToString();
                titolo.Text = percorso.Titolo;
                descrizione.Text = percorso.Descrizione;
            //}else{ 
            //    Message = "Errore: percorso non trovato";    
            //}
        }
        protected void Modifica_Click(object sender, EventArgs e) {
			PerStud pN = new PerStud{Titolo=titolo.Text,Descrizione=descrizione.Text,AnnoFine=int.Parse(annoF.Text),AnnoInizio=int.Parse(annoI.Text)};
            dao.ModPerStudi(percorso.Id,pN);
        }
	}
}