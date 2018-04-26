using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm.Controll {
    public partial class ListCurriculum : System.Web.UI.UserControl {
        public List<CV> CV { get; set;}
        protected void Page_Load(object sender, EventArgs e) {

        }
        public void Update() {
            if (CV != null) {
                foreach (CV p in CV) {
                    TableRow tr = new TableRow();
                    tr.Cells.Add(CreaCella(new Label() { Text = p.Nome, CssClass = "col-xs-6" }));
                    tr.Cells.Add(CreaCella(new Label() { Text = p.Cognome.ToString(), CssClass = "col-xs-2" }));
                    tr.Cells.Add(CreaCella(new Label() { Text = p.Matricola.ToString(), CssClass = "col-xs-2" }));
                    tr.Cells.Add(CreaCella(new Button() { Text = "dettaglio", PostBackUrl = $"/DettagliCV.aspx?codice={p.Matricola}", CssClass = "col-xs-6" }));
                    //modificare Url per il Dettaglio
					tr.Cells.Add(CreaBottone(new Button() { Text = "elimina", ID=$"{p.Matricola}" , CssClass = "col-xs-6" }));
					

                    //tr.Cells.Add(CreaCella(new Button() { Text = "elimina", OnClientClick="ELimina()" , CssClass = "col-xs-6" }));
                    //modificare Url per il Elimina

                    Curriculum.Rows.Add(tr);
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
			Response.Redirect($"/RicercaCurriculum.aspx?");
		}

		private TableCell CreaCella(Control label) {
            TableCell cella = new TableCell();
            cella.Controls.Add(label);
            return cella;
        }
    }
}