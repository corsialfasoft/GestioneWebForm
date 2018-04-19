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
                public string Message{get;set;}
				public Lezione newlesson {get; set;}
				protected void Page_Load(object sender,EventArgs e) {
					
				}
				public void AddLezione_Click(object sender,EventArgs e) {
					DataAccesObject DataAccess = new DataAccesObject();
                    newlesson = new Lezione {Nome = nome.Text,Descrizione = descrizione.Text,Durata = int.Parse(Durata.Text) };
                    string a = Request["idCorso"];
                    if(int.TryParse(a, out int id)){ 
                        DataAccess.AddLezione(id,newlesson);
                        Message = $"Lezine {"newlesson.Nome"} aggiunta al corso selezionato";
                        var url = String.Format($"~/Corso?id={id}");
                        Response.Redirect(url);
                        return ;                
                    }else{ 
                        Message = "Corso inesistente";
                        var url = String.Format($"~/CercaCorsi");
                        Response.Redirect(url);
                        return;
                    }
                    
				}  
	}	
}