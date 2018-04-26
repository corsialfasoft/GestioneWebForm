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
			//string matricola="ciao";
			Profilo p = Session["profile"] as Profilo;
			c=dao.Search(Request["codice"]);
			
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
				}
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
			}else{
				if(c.Percorsostudi==null){
					InitTablePS(new List<PerStud>());
				}else{
					InitTablePS(c.Percorsostudi);
				}
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
		protected void InitTablePS(List<PerStud> pers) {
			for(int i = 0; i < pers.Count; i++) {
				TableRow tr = new TableRow();
				TableCell tcAI = new TableCell() { CssClass = "col-md-6"};
				tcAI.Controls.Add(new Label { Text =$"<b>AnnoInzio</b>:{pers[i].AnnoInizio.ToString()}" });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { CssClass = "col-md-6" };
				tcAF.Controls.Add(new Label { Text =$"<b>AnnoFine</b>: {pers[i].AnnoFine.ToString()}" });
				tr.Cells.Add(tcAF);
				TablePerStudi.Rows.Add(tr);

				TableRow tr2 = new TableRow(){ CssClass="noBorderTop"};
				TableCell tcTipo = new TableCell() { CssClass = "col-md-6 noBorderTop" };
				tcTipo.Controls.Add(new Label { Text =$"<b>Titolo</b>:{pers[i].Titolo}"});
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell() { CssClass = "col-md-3 noBorderTop" };
				tcDesc.Controls.Add(new Label { Text =$"<b>Descrizione</b>: {pers[i].Descrizione} "});
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell() { CssClass = "col-md-3 noBorderTop" };
                tcMod.Controls.Add(new Button { Text = "Modifica ",PostBackUrl = $"/PerStud.aspx?idPercorso={pers[i].Id}",ID = $"{pers[i].Id}" });
				tr2.Cells.Add(tcMod);
				TablePerStudi.Rows.Add(tr2);
				//tr2.BorderStyle= BorderStyle.Outset;
			}
		}
		protected void InitTableES(List<EspLav> esperienze) {
			for(int i = 0; i < esperienze.Count; i++) {
				TableRow tr = new TableRow(){ CssClass="table"};
				TableCell tcAI = new TableCell() { CssClass = "col-md-4" };
				tcAI.Controls.Add(new Label { Text =$"<div class='col-md-6'><b>AnnoInizio:</b></div><div>{esperienze[i].AnnoInizio.ToString()} </div>"});
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { ColumnSpan=2, CssClass = "col-md-8"};
				tcAF.Controls.Add(new Label { Text =$"<div class='col-md-6'><b>AnnoFine:</b></div><div>{esperienze[i].AnnoFine.ToString()} </div>" });
				tr.Cells.Add(tcAF);
				TableEspLav.Rows.Add(tr);

				TableRow tr2 = new TableRow(){CssClass="noBorderTop"} ;
				TableCell tcTipo = new TableCell() { CssClass = "col-md-6 noBorderTop"};
				tcTipo.Controls.Add(new Label { Text =$"<div class='col-md-6'><b>Qualifica:</b></div><div> {esperienze[i].Qualifica} </div>" });
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell() { CssClass = "col-md-3  noBorderTop" };
				tcDesc.Controls.Add(new Label { Text = $"<div class='col-md-6'><b>Descrizione:</b></div><div> {esperienze[i].Descrizione} </div> <br>" });
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell() { CssClass = "col-md-3  noBorderTop" };
                tcMod.Controls.Add(new Button { Text = "Modifica", PostBackUrl = $"/EspLav.aspx?idEsperienza={esperienze[i].Id}" ,ID = $"{esperienze[i].Id}" });
				tr2.Cells.Add(tcMod);
				//tr2.BorderStyle= BorderStyle.Outset;
				TableEspLav.Rows.Add(tr2);
			}
		}
		protected void InitTableComp(List<Competenza> competenze) {
			for(int i = 0; i < competenze.Count; i++) {
				TableRow tr = new TableRow();
				TableCell tcAI = new TableCell() { CssClass = "col-md-6" };
				tcAI.Controls.Add(new Label { Text = $"<b>Livello:</b>{competenze[i].Livello.ToString()}" });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell() { CssClass = "col-md-6" };
				tcAF.Controls.Add(new Label { Text =$"<b>Titolo:</b>{competenze[i].Titolo}"});
				tr.Cells.Add(tcAF);
				TableCell tcMod = new TableCell() { CssClass = "col-md-1" };
                tcMod.Controls.Add(new Button { Text = "Modifica", PostBackUrl = $"/Comp.aspx?idCompetenza={competenze[i].Id}" ,ID = $"{competenze[i].Id}" });
				tr.Cells.Add(tcMod);
				//tr.ControlStyle.BorderStyle= BorderStyle.Groove;

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
			dao.ModificaCV(c,Mod);
			c=dao.Search(c.Matricola);
		}

		protected void btn_AddPerStudi_Click(object sender,EventArgs e) {
			Response.Redirect( string.Format($"~/AddPerStud?matr={c.Matricola}"));
		}

		protected void btn_AddEspLav_Click(object sender,EventArgs e) {
            var url = string.Format($"~/AddEspLav?matr={c.Matricola}");
			Response.Redirect(url);
		}
        
		protected void btn_AddComp_Click(object sender,EventArgs e) {
            var url = string.Format($"~/AddComp?matr={c.Matricola}");
			Response.Redirect(url);
		}
	}
}