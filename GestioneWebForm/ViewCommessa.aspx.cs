using DAO;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class ViewCommessa : Page {
        public Commessa Commessa { get;set; }
        private IDao dao = new DataAccesObject();
        protected string Message { get; set; }
        protected void Page_Load(object sender,EventArgs e) {
            string nomeC = Request.QueryString["nome"];
            if (nomeC.Length > 0) {
                Commessa = dao.CercaCommessa(nomeC);
                if (Commessa == null) {
                    Message = "Commessa non trovata";
                } else {
                    TableRow row = new TableRow();

                    ListaOreCommessa.
                }
            }

        }
        protected void Cerca_Click(object sender, EventArgs e){
            if (nomeCommessa.Text.Length != 0) { 
                List<Commessa> commesse =  dao.CercaCommesse(nomeCommessa.Text);
                if (commesse.Count > 0) {
                    tableC.ListaCommesse = commesse;
                    tableC.Update();
                } else
                    Message = "Commessa non trovata";
            }
        }
        private TableCell CreateCellLebel(string text, int lunghezza) {
            TableCell col = new TableCell();
            col.Controls.Add(new Label() { Text = text, CssClass = $"col-xs-{lunghezza} col-sm-{lunghezza} col-md-{lunghezza} col-lg-{lunghezza}" });
            return col;
        }
    }
}