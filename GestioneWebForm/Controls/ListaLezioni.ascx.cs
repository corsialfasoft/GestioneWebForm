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
		public List<Lezione> Lezioni {get;set; }
		protected void Page_Load(object sender,EventArgs e)
		{

		}
	}
}