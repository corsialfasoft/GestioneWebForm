using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _AddPerStud : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public string Message{get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }
        protected void Aggiungi_Click(object sender, EventArgs e) {
            if(Request["matr"]!= null){ 
			    PerStud pS = new PerStud{Titolo=titolo.Text,Descrizione=descrizione.Text,AnnoFine=int.Parse(annoFEl.Text),AnnoInizio=int.Parse(annoIEl.Text)};
                try{ 
                    dao.AddCvStudi(Request["matr"],pS);    
                    Message = "Percorso Studio aggiunta";
                }catch(Exception){
                    Message = "Inserimento Percorso Studio fallito";    
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