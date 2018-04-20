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
                    Message= "La data selezionata non è presente nel DB!";
                } else if (giorno!=null && giorno.Data.ToString("yyyy-MM-dd") != "0001-01-01") {
                    if (TabellaGiorno!=null) {
                       TabellaGiorno.Rows.Clear();
                    }
                    TableRow tr = new TableRow();
                    TableCell tdDescr = new TableCell();
                    tdDescr.Controls.Add(new Label() { Text = "Tipo", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2", });
                    tdDescr.Controls.Add(new Label() { Text = "Ore Totali", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2", });
                    tdDescr.Controls.Add(new Label() { Text = "Commessa", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2", });
                    tdDescr.Controls.Add(new Label() { Text = "Ore Lavoro Commessa", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2", });
                    tdDescr.Controls.Add(new Label() { Text = "Note", CssClass="col-xs-4 col-sm-4 col-md-4 col-lg-4", });
                    tr.Cells.Add(tdDescr);
                    TabellaGiorno.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdOreLavoro = new TableCell();
                    tdOreLavoro.Controls.Add(new Label() {Text = "Ore di lavoro", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2"});
                    tdOreLavoro.Controls.Add(new Label() { Text = giorno.TotOreLavorate().ToString(), CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    foreach(OreCommessa ocomm in giorno.OreLavorate) {
                        if (count>0) {
                            tr = new TableRow();
                            tdOreLavoro.Controls.Add(new Label() { CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                            tdOreLavoro.Controls.Add(new Label() { CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                        }
                        tdOreLavoro.Controls.Add(new Label() { Text = giorno.OreLavorate[count].Nome.ToString(),CssClass = "col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                        tdOreLavoro.Controls.Add(new Label() { Text = giorno.OreLavorate[count].Ore.ToString(),CssClass = "col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                        tdOreLavoro.Controls.Add(new Label() { Text = giorno.OreLavorate[count].Descrizione.ToString(),CssClass = "col-xs-4 col-sm-4 col-md-4 col-lg-4" });
                        tr.Cells.Add(tdOreLavoro);
                        TabellaGiorno.Rows.Add(tr);
                        count++;
                    }
                    tr.Cells.Add(tdOreLavoro);
                    TabellaGiorno.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdOrePerm = new TableCell();
                    tdOrePerm.Controls.Add(new Label() { Text = "Ore di Permesso", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2", });
                    tdOrePerm.Controls.Add(new Label() { Text = giorno.HPermesso.ToString(), CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    tr.Cells.Add(tdOrePerm);
                    TabellaGiorno.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdOreMal = new TableCell();
                    tdOreMal.Controls.Add(new Label() { Text = "Ore di Malattia", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    tdOreMal.Controls.Add(new Label() { Text = giorno.HMalattia.ToString(), CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    tr.Cells.Add(tdOreMal);
                    TabellaGiorno.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdOreFerie = new TableCell();
                    tdOreFerie.Controls.Add(new Label() { Text = "Ore di Ferie", CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    tdOreFerie.Controls.Add(new Label() { Text = giorno.HFerie.ToString(), CssClass="col-xs-2 col-sm-2 col-md-2 col-lg-2" });
                    tr.Cells.Add(tdOreFerie);
                    TabellaGiorno.Rows.Add(tr);
                }
            }
        }
    }
}