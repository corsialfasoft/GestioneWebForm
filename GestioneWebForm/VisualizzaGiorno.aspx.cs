using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class _VisualizzaGiorno : Page {
        public string Message;
        public Giorno giorno;

        protected void Page_Load(object sender,EventArgs e) {
            Message = "Selezionare la data di cui si vogliono visualizzare i dettagli";
        }

        protected void SelezionaGiorno(object sender,EventArgs e) {
            int count=0;
            if(IsPostBack) {
                giorno = new DataAccesObject().VisualizzaGiorno(data.SelectedDate, "admin");
                if (giorno == null) {
                    Message= "* La data selezionata non è ancora stata inserita nel registro!";
                } else if (giorno!=null && giorno.Data.ToString("yyyy-MM-dd") != "0001-01-01") {
                    if (TabellaGiorno!=null) {
                       TabellaGiorno.Rows.Clear();
                    }
                    TableRow tr = new TableRow();
                    TableCell tdDescr = new TableCell();
                    CreateCell(tdDescr, "Tipo", 2);
                    CreateCell(tdDescr, "Ore Totali", 2);
                    CreateCell(tdDescr, "Commessa", 2);
                    CreateCell(tdDescr, "Ore Lavoro Commessa", 2);
                    CreateCell(tdDescr, "Note", 4);
                    tr.Cells.Add(tdDescr);
                    TabellaGiorno.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdOreLavoro = new TableCell();
                    CreateCell(tdOreLavoro, "Ore di lavoro", 2);
                    CreateCell(tdOreLavoro, giorno.TotOreLavorate().ToString(), 2);
                    foreach(OreLavorative ocomm in giorno.OreLavorate) {
                        if (count>0) {
                            tr = new TableRow();
                            CreateCell(tdOreLavoro, "", 2);
                            CreateCell(tdOreLavoro, "", 2);
                        }
                        CreateCell(tdOreLavoro, giorno.OreLavorate[count].Nome.ToString(), 2);
                        CreateCell(tdOreLavoro, giorno.OreLavorate[count].Ore.ToString(), 2);
                        CreateCell(tdOreLavoro, giorno.OreLavorate[count].Descrizione.ToString(), 4);
                        tr.Cells.Add(tdOreLavoro);
                        TabellaGiorno.Rows.Add(tr);
                        count++;
                    }
                    tr.Cells.Add(tdOreLavoro);
                    TabellaGiorno.Rows.Add(tr);
                    CreateRow("Ore di Permesso", giorno.HPermesso.ToString(), 2);
                    CreateRow("Ore di Malattia", giorno.HMalattia.ToString(), 2);
                    CreateRow("Ore di Ferie", giorno.HFerie.ToString(), 2);
                }
            }
        }
        private void CreateRow (string text1, string text2, int col) {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            tr.Cells.Add(CreateCell(td, text1, col));
            tr.Cells.Add(CreateCell(td, text2, col));
            TabellaGiorno.Rows.Add(tr);
        }
        private TableCell CreateCell (TableCell td, string text, int col) {
            td.Controls.Add(new Label() {Text = text, CssClass=$"col-xs-{col} col-sm-{col} col-md-{col} col-lg-{col}"});
            return td;
        }
    }
}