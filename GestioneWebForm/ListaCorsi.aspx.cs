using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _ListaCorsi : Page {
        DataAccesObject d = new DataAccesObject();
        public List<Corso> corsi{get;set;}
        public Corso corso{get;set;}
        public string Message{get;set;}

        protected void Cerca_Click(object sender,EventArgs e) {
                  if(codice.Text.Length > 0 && int.TryParse(codice.Text, out int id)){
                       corso = d.SearchCorsi(id);
                       if(corso != null) {
                           var url = String.Format($"~/Corso.aspx?id={corso.Id}");
                           Response.Redirect(url);
                       }else{ 
                           Message = "Nessun corso trovato";   
                       }
                  }else if(descrizione.Text.Length > 0){
                        corsi = d.SearchCorsi(descrizione.Text);
                        if(corsi!=null && corsi.Count>0){
                        foreach(Corso c in corsi){
                        TableRow tableRow = new TableRow();
                        TableCell c1 = new TableCell();
                        Label l1 = new Label {Text = c.Id.ToString(),CssClass = "col-md-3",};
                        c1.Controls.Add(l1);
                        tableRow.Cells.Add(c1);
                        TableCell c2 = new TableCell();
                        Label l2 = new Label {Text = c.Descrizione,CssClass = "col-md-6"};
                        c2.Controls.Add(l2);
                        tableRow.Cells.Add(c2);
                        TableCell c3 = new TableCell();
                        Button l3 = new Button {
                            Text = "Dettaglio",
                            PostBackUrl = $"~/Corso?id={c.Id}",
                            CssClass = "col-xs-3"
                            };
                        c3.Controls.Add(l3);
                        tableRow.Cells.Add(c3);
                        Table1.Rows.Add(tableRow);
                    }
                }else{ 
                     Message ="Nessun corso trovato";   
                }
            } else {
                Message = "Parametri non validi";
            }
        }
        protected void MyCerca_Click(object sender,EventArgs e) {
            
        }
        protected void Page_Load(object sender,EventArgs e) {

        }
    }
}