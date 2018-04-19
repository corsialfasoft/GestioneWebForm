using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _CercaCorsi : Page {
        public Profilo ut = new Profilo{Matrincola = "qw",Ruolo= "admin" ,Nome="Drago",Cognome="Brinzi", Username="Tandy",Password="qwertyui" };
        public DataAccesObject d = new DataAccesObject();
        public List<Corso> corsi{get;set;}
        public Corso corso{get;set;}
        public string Message{get;set;}

        protected void Cerca_Click(object sender,EventArgs e){
            if(codice.Text.Length>0){ 
                if(int.TryParse(codice.Text,out int id)){
                    var url = String.Format($"~/Corso?id={id}");
                    Response.Redirect(url);
                }
            }else if(descrizione.Text.Length>0){
                corsiTable.Corsi = d.SearchCorsi(descrizione.Text);
                corsiTable.Update();
            }else{ 
                Message = "Parametri non validi";    
            }
        }
        
        protected void MyCerca_Click(object sender,EventArgs e) {
            if(descrizione.Text.Length==0){
                descrizione.Text="";
            }
            corsiTable.Corsi = d.SearchCorsi(descrizione.Text,ut.Matrincola);
            corsiTable.Update();
        }
        protected void Page_Load(object sender,EventArgs e) {

        }
    }
}