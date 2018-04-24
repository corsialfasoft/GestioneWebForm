using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _AddComp : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public string Message{get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }
        protected void Aggiungi_Click(object sender, EventArgs e) {
            if(Request["matr"]!= null){ 
			    Competenza cO = new Competenza{Titolo=titolo.Text,Livello=int.Parse(livello.Text)};
                try{ 
                    dao.AddCompetenze(Request["matr"],cO);    
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