using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
	public partial class DettagliCv : System.Web.UI.Page {
		public CV c {get;set;}
		protected void Page_Load(object sender,EventArgs e) {
			IDao dao = new DataAccesObject();
			c=new CV();
			string matricola="ciao";
			c=dao.Search(matricola);
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
				TableCell tcAI= new TableCell();
				tcAI.Controls.Add(new Label{Text=pers[i].AnnoInizio.ToString(), CssClass ="col-xs-2" });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell();
				tcAF.Controls.Add(new Label{Text=pers[i].AnnoFine.ToString() , CssClass ="col-xs-2"});
				tr.Cells.Add(tcAF);
				TablePerStudi.Rows.Add(tr);
				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell();
				tcTipo.Controls.Add(new Label{Text=pers[i].Titolo , CssClass ="col-xs-6"});
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell();
				tcDesc.Controls.Add(new Label{Text=pers[i].Descrizione, CssClass ="col-xs-6"});
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell();
				tcMod.Controls.Add(new Button {Text="Modifica"} ); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TablePerStudi.Rows.Add(tr2);
			}
		}
		protected void InitTableES(List<EspLav> esperienze){
			for(int i = 0; i<esperienze.Count; i++){
				TableRow tr= new TableRow();
				TableCell tcAI= new TableCell();
				tcAI.Controls.Add(new Label{Text=esperienze[i].AnnoInizio.ToString(), CssClass ="col-xs-2" });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell();
				tcAF.Controls.Add(new Label{Text=esperienze[i].AnnoFine.ToString() , CssClass ="col-xs-2"});
				tr.Cells.Add(tcAF);
				TablePerStudi.Rows.Add(tr);
				TableRow tr2 = new TableRow();
				TableCell tcTipo = new TableCell();
				tcTipo.Controls.Add(new Label{Text=esperienze[i].Qualifica , CssClass ="col-xs-6"});
				tr2.Cells.Add(tcTipo);
				TableCell tcDesc = new TableCell();
				tcDesc.Controls.Add(new Label{Text=esperienze[i].Descrizione, CssClass ="col-xs-6"});
				tr2.Cells.Add(tcDesc);
				TableCell tcMod = new TableCell();
				tcMod.Controls.Add(new Button {Text="Modifica"} ); // manca IL REFERENIAMENTO
				tr2.Cells.Add(tcMod);
				TableEspLav.Rows.Add(tr2);
			}
		}
		protected void InitTableComp(List<Competenza> competenze){
			for(int i = 0; i<competenze.Count; i++){
				TableRow tr= new TableRow();
				TableCell tcAI= new TableCell();
				tcAI.Controls.Add(new Label{Text=competenze[i].Livello.ToString(), CssClass ="col-xs-2" });
				tr.Cells.Add(tcAI);
				TableCell tcAF = new TableCell();
				tcAF.Controls.Add(new Label{Text=competenze[i].Titolo, CssClass ="col-xs-6"});
				tr.Cells.Add(tcAF);
				 TableComp.Rows.Add(tr);
				
			}
		}
	}
}