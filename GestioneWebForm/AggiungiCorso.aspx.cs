using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _AggiungiCorso : Page {
        public string Message{get;set;}
        public Corso Corso{get;set;}
        public DataAccesObject d = new DataAccesObject();
        public List<Corso> Corsi{get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }

        protected void Crea_Click(object sender, EventArgs e){
            try{
                Corsi = new List<Corso>();
                Corso = new Corso{Nome = nome.Text, Inizio = inizio.SelectedDate, Fine = fine.SelectedDate, Descrizione = descrizione.Text };
                Corsi.Add(Corso);
                d.AddCorso(Corso);
                Session["Corsi"]= Corsi;
                Message = $"Corso {Corso.Nome} aggiunto";
            }catch(Exception){
                Message="Errore non tutti i campi sono stati riempiti !";
            }finally{ 
                var url = String.Format($"~/CercaCorsi");
                Response.Redirect(url);  
            }
        }
    }
}