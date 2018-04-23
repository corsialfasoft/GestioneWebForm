using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm.Controll {
    public partial class _ListPerStud : System.Web.UI.UserControl {
        public List<PerStud> percorsi { get; set;}
        protected void Page_Load(object sender, EventArgs e) {

        }
        public void Update() {
            if (percorsi != null) {
                foreach (PerStud ps in percorsi) {
                    TableRow tr = new TableRow();
                    tr.Cells.Add(CreaCella(new Label() { Text = ps.Titolo, ID="MTitolo", CssClass = "col-xs-6" }));
                    tr.Cells.Add(CreaCella(new Label() { Text = ps.Descrizione,ID="MTitolo", CssClass = "col-xs-2" }));
                    tr.Cells.Add(CreaCella(new Label() { Text = ps.AnnoInizio.ToString(),ID="MTitolo", CssClass = "col-xs-2" }));
                    tr.Cells.Add(CreaCella(new Label() { Text = ps.AnnoFine.ToString(), ID="MTitolo", CssClass = "col-xs-2" }));
                    tr.Cells.Add(CreaBottone(new Button() { Text = "Modifica", ID=$"{ps.Id}" , CssClass = "col-xs-6" }));
                    TPerStud.Rows.Add(tr);
                }
            }
        }
        private TableCell CreaBottone(Control b){
			Button c = (Button) b;
			c.Click += C_Click1;
			TableCell cell = new TableCell();
			cell.Controls.Add(c);
			return cell;
		}

		private void C_Click1(object sender,EventArgs e) {
			Button b = (Button)sender;
			String matr = b.ID;
			DataAccesObject dao = new DataAccesObject();
			dao.EliminaCV(dao.Search(matr));
		}

		private TableCell CreaCella(Control label) {
            TableCell cella = new TableCell();
            cella.Controls.Add(label);
            return cella;
        }
    }
}