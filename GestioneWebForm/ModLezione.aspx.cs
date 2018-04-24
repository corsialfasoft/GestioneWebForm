using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace GestioneWebForm
{
	public partial class _ModLezione : Page
	{
		public int idLezione { get; set; }
		public int idCorso { get; set; }
		DataAccesObject dao = new DataAccesObject();
		protected void Page_Load(object sender,EventArgs e)
		{
			int x;
			int y;
			int.TryParse((string)Request["id"],out x);
			idLezione = x;
			int.TryParse((string)Request["idCorso"],out y);
			idCorso = y;
			if(!Page.IsPostBack) {

				Lezione lez = dao.SearchLezione(x);
				argomento.Text = lez.Argomento;
				Durata.Text = lez.Durata.ToString();
			}
		}

		protected void ModLezione_Click(object sender,EventArgs e)
		{
			string unna = argomento.Text;
			Lezione lez = new Lezione { Id = idLezione,Argomento = argomento.Text,Durata = int.Parse(Durata.Text) };
			dao.ModificaLezione(lez);
			Response.Redirect($"~/Corso?id={idCorso}");
		}
	}
}