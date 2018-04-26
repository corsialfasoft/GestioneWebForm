using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _Comp : Page{ 
        DataAccesObject dao = new DataAccesObject();
        public Competenza compe{get;set;}
        public string Message{get;set;}
        public int idCo{ get;set;}
        protected void Page_Load(object sender,EventArgs e) {
            if(int.TryParse(Request["idCompetenza"],out int x)){
                idCo = x;
                if(!Page.IsPostBack){
                    compe = dao.GetCompetenza(idCo);
                    titolo.Text = compe.Titolo;
                    livello.Text = compe.Livello.ToString();
                    //}else{ 
                    //    Message = "Errore: percorso non trovato";    
                    //}
                }
            }
        }
        protected void Modifica_Click(object sender, EventArgs e) {
			Competenza co = new Competenza{Livello=int.Parse(livello.Text),Titolo=titolo.Text};
            dao.ModComp(idCo,co);
            compe = dao.GetCompetenza(idCo);
			string matr= dao.GetMatrFromComp(idCo);
            var url = String.Format($"~/DettagliCv.aspx?codice={matr}");
            Response.Redirect(url);
        }

		protected void Dettaglio_Click(object sender,EventArgs e) {
			string matr= dao.GetMatrFromComp(idCo);
            var url = String.Format($"~/DettagliCv.aspx?codice={matr}");
            Response.Redirect(url);
		}
	}
}