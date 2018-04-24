using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _Corso : Page {
        public Profilo ut = new Profilo{Matrincola = "aa",Ruolo= "prof" ,Nome="Drago",Cognome="Brinzi", Username="Tandy",Password="qwertyui" };
        DataAccesObject d = new DataAccesObject();
        public Corso corso{get;set;}
        public List<Lezione> lezioni{ get;set;}
        public string Message{get;set;}
		

        //protected void LezioniOn_Click(object sender,EventArgs e) {
         
			
        //}
        //protected void LezioniOff_Click(object sender,EventArgs e) {
        //    lezioni = null;
        //}
        protected void AddLezione_Click(object sender,EventArgs e) {
            var url = String.Format($"~/AddLezione?idCorso={corso.Id}");
            Response.Redirect(url);
        }
        protected void Iscriviti_Click(object sender,EventArgs e) {
            try{ 
                d.Iscriviti(corso.Id,ut.Matrincola);
                Message = "Iscrizione al corso riuscita";
            }catch(Exception){ 
                Message = "Iscrizione al corso non riuscita";
            }
        }

        protected void Page_Load(object sender,EventArgs e) {
            string a = Request["id"];
            if(int.TryParse(a, out int idi)){ 
                corso = d.SearchCorsi(idi);
			lezioni = d.SearchLezioni(corso.Id)?? null;
			Lezione.Lezioni = lezioni;
			Lezione.IdCorso = idi;
            }else{
                Message = "Nessun elemento trovato";     
            }
        }
    }
}