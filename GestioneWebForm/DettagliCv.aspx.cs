using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
	public partial class DettagliCv : System.Web.UI.Page {
		public string Message {get;set;}
		public CV c {get;set;}
		protected void Page_Load(object sender,EventArgs e) {
			IDao dao = new DataAccesObject();
			c=new CV();
			//string matricola="ciao";
			//c=dao.Search(Request["codice"]);
			c=dao.Search("BBBB");
			if(!Page.IsPostBack){
				NomeTextBox.Text=c.Nome;
				CognomeTextBox.Text=c.Cognome;
				EtaTextBox.Text=c.Eta.ToString();
				ResidenzaTextBox.Text=c.Residenza;
				EmailTextBox.Text=c.Email;
				TelefonoTextBox.Text=c.Telefono;
				if(c.Percorsostudi==null){
					InitTablePS(new List<PerStud>());
				}else{
					InitTablePS(c.Percorsostudi);
					//}
					if(c.Esperienze == null) {
						InitTableES(new List<EspLav>());
					} else {
						InitTableES(c.Esperienze);
					}
					if(c.Competenze == null) {
						InitTableComp(new List<Competenza>());
					} else {
						InitTableComp(c.Competenze);
					}
				}
			}
		}
		protected void InitTablePS(List<PerStud> pers) {
			for(int i = 0; i < pers.Count; i++) {
				TableRow tr = new TableRow();
				TableCell tcAI = new TableCell() { CssClass = "col-md-6" };
				tcAI.Controls.Add(new Label { Text = pers[i].AnnoInizio.ToString() });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { CssClass = "col-md-6" };
				tcAF.Controls.Add(new Label { Text = pers[i].AnnoFine.ToString() });
				tr.Cells.Add(tcAF);
				TablePerStudi.Rows.Add(tr);

				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell() { CssClass = "col-md-6" };
				tcTipo.Controls.Add(new Label { Text = pers[i].Titolo });
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell() { CssClass = "col-md-3" };
				tcDesc.Controls.Add(new Label { Text = pers[i].Descrizione });
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell() { CssClass = "col-md-3" };
				tcMod.Controls.Add(CreaBottone(new Button { Text = "ModificaPerStud",ID = $"{pers[i].Id}" })); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TablePerStudi.Rows.Add(tr2);

			}
		}
		protected void InitTableES(List<EspLav> esperienze) {
			for(int i = 0; i < esperienze.Count; i++) {
				TableRow tr = new TableRow();
				TableCell tcAI = new TableCell() { CssClass = "col-md-6" };
				tcAI.Controls.Add(new Label { Text = esperienze[i].AnnoInizio.ToString() });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { CssClass = "col-md-6" };
				tcAF.Controls.Add(new Label { Text = esperienze[i].AnnoFine.ToString() });
				tr.Cells.Add(tcAF);
				TableEspLav.Rows.Add(tr);

				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell() { CssClass = "col-md-6" };
				tcTipo.Controls.Add(new Label { Text = esperienze[i].Qualifica });
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell() { CssClass = "col-md-3" };
				tcDesc.Controls.Add(new Label { Text = esperienze[i].Descrizione });
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell() { CssClass = "col-md-3" };
				tcMod.Controls.Add(CreaBottone(new Button { Text = "ModificaEsp",ID = $"{esperienze[i].Id}" })); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TableEspLav.Rows.Add(tr2);
			}
		}
		private TableCell CreaBottone(Control b){
			Button c = (Button) b;
			switch(c.Text){
				case "ModificaEsp":{
					c.Click+= ModEsp;
					TableCell cell = new TableCell();
					cell.Controls.Add(c);
					return cell;
					
				}
				case "ModificaComp":{
					c.Click+= C_ModComp;
					TableCell cell = new TableCell();
					cell.Controls.Add(c);
					return cell;
				}
				case "ModificaPerStud":{
					c.Click+= C_ModPerStud;
					TableCell cell = new TableCell();
					cell.Controls.Add(c);
					return cell;
				}
				default :
					Message="Attenzione Qualcosa è andata storto";
					return null;
			}
			
		}

		private void C_ModPerStud(object sender,EventArgs e) {
			Button b = (Button) sender;
			Response.Redirect( string.Format($"~/PerStud?idPercorso={b.ID}"));
		}

		private void C_ModComp(object sender,EventArgs e) {
			Button b = (Button) sender;
			Response.Redirect( string.Format($"~/Comp?idCompetenza={b.ID}"));
		}

		private void ModEsp(object sender,EventArgs e) {
			Button b = (Button) sender;
			Response.Redirect( string.Format($"~/EspLav?idEsperienza={b.ID}"));
		}
		protected void InitTableComp(List<Competenza> competenze) {
			for(int i = 0; i < competenze.Count; i++) {
				TableRow tr = new TableRow();
				TableCell tcAI = new TableCell() { CssClass = "col-md-6" };
				tcAI.Controls.Add(new Label { Text = competenze[i].Livello.ToString() });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { CssClass = "col-md-6" };
				tcAF.Controls.Add(new Label { Text = competenze[i].Titolo });
				tr.Cells.Add(tcAF);
				TableCell tcMod = new TableCell() { CssClass = "col-md-1" };
				tcMod.Controls.Add(CreaBottone(new Button { Text = "ModificaComp",ID = $"{competenze[i].Id}" })); // manca IL REFERENIAMENTO
				tr.Cells.Add(tcMod);
				TableComp.Rows.Add(tr);

			}
		}

		protected void modAnag_Click(object sender,EventArgs e) {
			DataAccesObject dao = new DataAccesObject();
			CV Mod = new CV();
			Mod.Nome= NomeTextBox.Text;
			Mod.Cognome= CognomeTextBox.Text;
			Mod.Eta=int.Parse(EtaTextBox.Text);
			Mod.Residenza= ResidenzaTextBox.Text;
			Mod.Email=EmailTextBox.Text;
			Mod.Telefono= TelefonoTextBox.Text;
			TelefonoTextBox.Text = "CAAA";
			dao.ModificaCV(c,Mod);
			c=Mod;
		}

		protected void btnPerStud_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/PerStud?matr={c.Matricola}"));
		}

		protected void btnEspLav_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/EspLav?matr={c.Matricola}"));
		}

		protected void btnComp_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/Comp?matr={c.Matricola}"));
		}

		protected void btn_AddPerStudi_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/AddPerStud?matr={c.Matricola}"));
		}

		protected void btn_AddEspLav_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/AddEspLav?matr={c.Matricola}"));
		}

		protected void btn_AddComp_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/AddComp?matr={c.Matricola}"));
		}
	}
}