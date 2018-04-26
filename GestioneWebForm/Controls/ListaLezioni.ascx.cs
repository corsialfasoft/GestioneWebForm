using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm.Controls
{
	public partial class ListaLezioni : System.Web.UI.UserControl
	{
		public int IdCorso { get;set;}
		public List<Lezione> Lezioni { get; set; }
		public bool IsModificaEnabled { get; set; }
		public bool IsEliminaEnabled { get; set; }
		protected void Page_Load(object sender,EventArgs e)
		{
			if(Lezioni.Count > 0 && Lezioni != null) {
				TableRow row = new TableRow();
				row.Cells.Add(CreaCella(new Label() { Text="idLezione",}));
				row.Cells.Add(CreaCella(new Label() { Text="Descrizione"}));
				row.Cells.Add(CreaCella(new Label() { Text="Durata"}));
				LezioniList.Rows.Add(row);
				foreach(Lezione lezione in Lezioni) {
					TableRow tableRow = new TableRow();
					tableRow.Cells.Add(CreaCella(new Label() { Text = lezione.Id.ToString() ,CssClass="col-xs-6"}));
					tableRow.Cells.Add(CreaCella(new Label() { Text = lezione.Argomento ,CssClass="col-xs-6"}));
					tableRow.Cells.Add(CreaCella(new Label() { Text = lezione.Durata.ToString(),CssClass="col-xs-6" }));
					if(IsModificaEnabled) {// da finire, devo creare una pagina modifica lezione.
						TableCell table = new TableCell();
						Button modifica = new Button();
						modifica.CommandArgument = lezione.Id.ToString();
						modifica.Command += Modifica_Click;
						modifica.Text = "Modifica";
						modifica.CssClass="col-xs-4";
						table.Controls.Add(modifica);
						tableRow.Cells.Add(table);
					}
					if(IsEliminaEnabled) {
						TableCell table=new TableCell();
						Button modifica = new Button();
						modifica.CommandArgument = lezione.Id.ToString();
						modifica.Command += Cancella_Click;
						modifica.Text="Elimina";
						modifica.CssClass="col-xs-4";
						table.Controls.Add(modifica);
						tableRow.Cells.Add(table);
					}
				LezioniList.Rows.Add(tableRow);
				}
			}
		}
		private TableCell CreaCella(Control label)
		{
			TableCell c = new TableCell();
			c.Controls.Add(label);
			return c;
		}
		public void Cancella_Click(object sender,CommandEventArgs e)
		{
			DataAccesObject dao = new DataAccesObject();
			int idLezione;
			int.TryParse((string)e.CommandArgument,out idLezione);
			dao.EliminaLezione(idLezione);
			Response.Redirect($"~/Corso?id={IdCorso}");
		}
		public void Modifica_Click(object sender,CommandEventArgs e)
		{
			int idLez;
			int.TryParse((string)e.CommandArgument,out idLez);
			Response.Redirect($"~/ModLezione?id={idLez}&idCorso={IdCorso}");
		}
	}
}