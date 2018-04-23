using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _EspLav : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public EspLav esperienza{get;set;}
        public string Message{get;set;}
        public int idEl{ get;set;}
        protected void Page_Load(object sender,EventArgs e) {
            idEl = 5;
            if(!Page.IsPostBack){
                esperienza = dao.GetEsperienza(idEl);
                annoIEl.Text = esperienza.AnnoInizio.ToString();
                annoFEl.Text =esperienza.AnnoFine.ToString();
                qualifica.Text = esperienza.Qualifica;
                descrizioneEl.Text = esperienza.Descrizione;
                //}else{ 
                //    Message = "Errore: percorso non trovato";    
                //}
            }
        }
        protected void Modifica_Click(object sender, EventArgs e) {
			EspLav eL = new EspLav{Qualifica=qualifica.Text,Descrizione=descrizioneEl.Text,AnnoFine=int.Parse(annoFEl.Text),AnnoInizio=int.Parse(annoIEl.Text)};
            dao.ModEspLav(idEl,eL);
            esperienza = dao.GetEsperienza(idEl);
            var url = String.Format($"~/EspLav");
            Response.Redirect(url);
        }
	}
}