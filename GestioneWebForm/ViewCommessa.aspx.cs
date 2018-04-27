using DAO;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm {
    public partial class ViewCommessa : Page {
        //public Commessa commessa { get;set; }
        private IDao dao = new DataAccesObject();
        protected string Message { get; set; }
        protected Commessa commessa = null;
        protected List<Commessa> commesse = null;
        protected void Page_Load(object sender,EventArgs e) {
            string nomeC = Request.QueryString["nome"];
            int count=1;
            if (nomeC != null) {
                commessa = dao.CercaCommessa(nomeC);
                if (commessa == null) {
                    Message = "Commessa non trovata!";
                }
                else {
                    TableRow tr = new TableRow();
                    TableCell tdHead = new TableCell();
                    CreateCell(tdHead, "#", 3);
                    CreateCell(tdHead, "Date", 5);
                    CreateCell(tdHead, "Ore Lavorate", 4);
                    tr.Cells.Add(tdHead);
                    ListaOreCommessa.Rows.Add(tr);

                    tr = new TableRow();
                    TableCell tdComm = new TableCell();
                    //List<Giorno> giorni = dao.GiorniCommessa(commessa.Id, "prova");
                    List<Giorno> giorni = dao.GiorniCommessa(commessa.Id, "EEEE");
                    foreach (Giorno banana in giorni) {
                        CreateCell(tdComm, $"{count}", 3);
                        CreateCell(tdComm, banana.Data.ToShortDateString(), 5);
                        CreateCell(tdComm, banana.TotOreLavorate.ToString(), 4);
                        count++;
                    }
                    tr.Cells.Add(tdComm);
                    ListaOreCommessa.Rows.Add(tr);
                }
            }
        }
        private void CreateRow (string text1, string text2, int col) {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            tr.Cells.Add(CreateCell(td, text1, col));
            tr.Cells.Add(CreateCell(td, text2, col));
            ListaOreCommessa.Rows.Add(tr);
        }
        private TableCell CreateCell (TableCell td, string text, int col) {
            td.Controls.Add(new Label() {Text = text, CssClass=$"col-xs-{col} col-sm-{col} col-md-{col} col-lg-{col}"});
            return td;
        }

        protected void Cerca_Click(object sender, EventArgs e){
            if(nomeCommessa.Text.Length != 0) {
                commesse = dao.CercaCommesse(nomeCommessa.Text);
                if(commesse.Count == 1) {
                    Response.Redirect($"~/ViewCommessa?nome={commesse[0].Nome}");
                }
                if(commesse.Count > 0) {
                    tableC.ListaCommesse = commesse;
                    tableC.Update();
                } else {
                    Message = "Commessa non trovata!";
                }
            }
        }
    }
}