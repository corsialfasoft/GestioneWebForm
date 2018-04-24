using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _AddEspLav : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public string Message{get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }
        protected void Aggiungi_Click(object sender, EventArgs e) {
            if(Request["matr"]!= null){ 
			    EspLav eL = new EspLav{Qualifica=qualifica.Text,Descrizione=descrizioneEl.Text,AnnoFine=int.Parse(annoFEl.Text),AnnoInizio=int.Parse(annoIEl.Text)};
                try{ 
                    dao.AddEspLav(Request["matr"],eL);    
                    Message = "Esperienza lavorativa aggiunta";
                }catch(Exception){
                    Message = "Inserimento Esperienza Lavorativa fallito";    
                }
            }else{ 
                Message = "Curriculum inesistente";    
            }
            //var url = String.Format($"~/DettagliCv.aspx?matr={Request["matr"]}");
            var url = String.Format($"~/DettagliCv.aspx");
            Response.Redirect(url);
        }
	}
}