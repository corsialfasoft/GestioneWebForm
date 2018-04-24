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
		public List<Lezione> Lezioni { get; set; }
		public bool IsModificaEnabled { get; set; }
		public bool IsEliminaEnabled { get; set; }
		protected void Page_Load(object sender,EventArgs e)
		{
			if(Lezioni.Count > 0 && Lezioni != null) {
				foreach(Lezione lezione in Lezioni) {
					TableRow tableRow = new TableRow();
					tableRow.Cells.Add(CreaCella(new Label { Text = lezione.Id.ToString() }));
					tableRow.Cells.Add(CreaCella(new Label { Text = lezione.Argomento }));
					tableRow.Cells.Add(CreaCella(new Label { Text = lezione.Durata.ToString() }));
					if(IsModificaEnabled) {// da finire, devo creare una pagina modifica lezione.
						//TableCell table=new TableCell();
						//Button modifica = new Button();
						//modifica.CommandArgument = lezione.Id.ToString();
						//modifica.Command += Modifica_Click;
						//modifica.Text="Modifica";
						//table.Controls.Add(modifica);
						//tableRow.Cells.Add(table);
					}
					if(IsEliminaEnabled) {
						TableCell table=new TableCell();
						Button modifica = new Button();
						modifica.CommandArgument = lezione.Id.ToString();
						modifica.Command += Cancella_Click;
						modifica.Text="Elimina";
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
		}
		public void Modifica_Click(object sender,CommandEventArgs e)
		{

		}
	}
}