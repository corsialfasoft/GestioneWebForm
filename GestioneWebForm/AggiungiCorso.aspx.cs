using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class _AggiungiCorso : Page {
        public string Message;
        public Corso Corso;
        public List<Corso> Corsi = new List<Corso>();
        protected void Page_Load(object sender,EventArgs e) {

        }

        protected void Crea_Click(object sender, EventArgs e){
            if(nome.Text != null && inizio.Text != null && fine.Text != null && descrizione.Text != null)
            {
                Corso c = new Corso(nome.Text, DateTime.Parse(inizio.Text.ToString()), DateTime.Parse(fine.Text.ToString()), descrizione.Text);
                Corsi.Add(c);
                Session["Corsi"]= Corsi;
            }
            else
            {
                Message="Errore non tutti i campi sono stati riempiti !";
            }
        }
    }
}