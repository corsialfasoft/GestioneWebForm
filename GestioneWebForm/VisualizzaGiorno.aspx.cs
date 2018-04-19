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
            if(IsPostBack) {
                giorno = new DataAccesObject().VisualizzaGiorno(data.SelectedDate, "admin");
                if (giorno == null) {
                    Message= "La data selezionata non è presente nel DB!";
                } else if (giorno!=null && giorno.Data.ToString("yyyy-MM-dd") != "0001-01-01") {
                    //TabellaGiorno.Cancellatutto!!!
                    TableRow tr = new TableRow();
                    TableCell tdOreLavoro = new TableCell();
                    tdOreLavoro.Controls.Add(new Label() {Text = "Ore di lavoro", CssClass="col-xs-2"});
                    tdOreLavoro.Controls.Add(new Label() { Text = giorno.TotOreLavorate().ToString(), CssClass="col-xs-2" });
                    tr.Cells.Add(tdOreLavoro);
                    TabellaGiorno.Rows.Add(tr);
                    tr = new TableRow();
                    TableCell tdOrePerm = new TableCell();
                    tdOrePerm.Controls.Add(new Label() { Text = "Ore di Permesso", CssClass="col-xs-2" });
                    tdOrePerm.Controls.Add(new Label() { Text = giorno.HPermesso.ToString(), CssClass="col-xs-2" });
                    tr.Cells.Add(tdOrePerm);
                    TabellaGiorno.Rows.Add(tr);
                }
            }
        }
    }
}