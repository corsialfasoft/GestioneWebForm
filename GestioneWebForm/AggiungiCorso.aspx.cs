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
            if(nome.Text != null && inizio.Text != null && fine.Text != null && descrizione.Text != null)
            {
                Corsi = new List<Corso>();
                Corso = new Corso{Nome = nome.Text, Inizio = DateTime.Parse(inizio.Text.ToString()), Fine = DateTime.Parse(fine.Text.ToString()), Descrizione = descrizione.Text };
                Corsi.Add(Corso);
                d.AddCorso(Corso);
                Session["Corsi"]= Corsi;
            }
            else
            {
                Message="Errore non tutti i campi sono stati riempiti !";
            }
        }
    }
}