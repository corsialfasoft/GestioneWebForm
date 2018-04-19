using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm.Controls {
    public partial class _ListaCorsi : System.Web.UI.UserControl {
        public List<Corso> Corsi{ get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }
        public void Update(){
            if(Corsi!=null && Corsi.Count>0){
                foreach(Corso c in Corsi){
                    TableRow tR = new TableRow();
                    tR.Cells.Add(CreaCella(new Label {Text = c.Id.ToString(),CssClass = "col-md-2"}));
                    tR.Cells.Add(CreaCella(new Label {Text = c.Descrizione,CssClass = "col-md-6"}));
                    tR.Cells.Add(CreaCella(new Button {Text = "Dettaglio",PostBackUrl = $"~/Corso?id={c.Id}",CssClass = "col-md-4"}));
                    CorsiTable.Rows.Add(tR);
                } 
            } 
        }
        private TableCell CreaCella(Control label){ 
            TableCell c = new TableCell();
            c.Controls.Add(label);
            return c;
        }
    }
}