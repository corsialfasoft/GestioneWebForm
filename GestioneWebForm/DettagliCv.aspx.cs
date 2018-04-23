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
			c=dao.Search("EEEE");
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
			if(c.Esperienze==null){
				InitTableES(new List<EspLav>());
			}else{
				InitTableES(c.Esperienze);
			}
			if(c.Competenze==null){
				InitTableComp(new List<Competenza>());
			}else{
				InitTableComp(c.Competenze);
			}
			
		}
		protected void InitTablePS(List<PerStud> pers){
			for(int i = 0; i<pers.Count; i++){
				TableRow tr= new TableRow();
				TableCell tcAI= new TableCell(){CssClass ="col-md-6"};
				tcAI.Controls.Add(new Label{Text=pers[i].AnnoInizio.ToString()});
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell(){CssClass ="col-md-6"};
				tcAF.Controls.Add(new Label{Text=pers[i].AnnoFine.ToString() });
				tr.Cells.Add(tcAF);
				TablePerStudi.Rows.Add(tr);
				
				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell( ){CssClass ="col-md-6"};
				tcTipo.Controls.Add(new Label{Text=pers[i].Titolo });
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell(){CssClass ="col-md-3"};
				tcDesc.Controls.Add(new Label{Text=pers[i].Descrizione});
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell( ){CssClass ="col-md-3"};
				tcMod.Controls.Add(new Button {Text="Modifica",ID="btnM" } ); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TablePerStudi.Rows.Add(tr2);

			}
		}
		protected void InitTableES(List<EspLav> esperienze){
			for(int i = 0; i<esperienze.Count; i++){
				TableRow tr= new TableRow();
				TableCell tcAI= new TableCell(){CssClass ="col-md-6"};
				tcAI.Controls.Add(new Label{Text=esperienze[i].AnnoInizio.ToString() });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell(){CssClass ="col-md-6"};
				tcAF.Controls.Add(new Label{Text=esperienze[i].AnnoFine.ToString() });
				tr.Cells.Add(tcAF);
				TableEspLav.Rows.Add(tr);
				
				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell(){CssClass ="col-md-6"};
				tcTipo.Controls.Add(new Label{Text=esperienze[i].Qualifica});
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell(){CssClass ="col-md-3"};
				tcDesc.Controls.Add(new Label{Text=esperienze[i].Descrizione});
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell(){CssClass ="col-md-3"};
				tcMod.Controls.Add(new Button {Text="Modifica",ID="btnM" }); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TableEspLav.Rows.Add(tr2);
			}
		}
		protected void InitTableComp(List<Competenza> competenze){
			for(int i = 0; i<competenze.Count; i++){
				TableRow tr= new TableRow();
				TableCell tcAI= new TableCell(){CssClass ="col-md-6"};
				tcAI.Controls.Add(new Label{Text=competenze[i].Livello.ToString() });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell(){CssClass ="col-md-6"};
				tcAF.Controls.Add(new Label{Text=competenze[i].Titolo});
				tr.Cells.Add(tcAF);
				TableCell tcMod = new TableCell(){CssClass ="col-md-1"};
				tcMod.Controls.Add(new Button {Text="Modifica",ID="btnM"} ); // manca IL REFERENIAMENTO
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
	}
}