using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestioneWebForm {
    public partial class _MyPage : Page {
		public string Matricola;
        protected void Page_Load(object sender,EventArgs e) {

        }

		protected void Go_Click(object sender,EventArgs e)
		{
			Matricola = "banana";
			Response.Redirect($"~/DettaglioCurriculum.aspx?id={Matricola}");
		}
	}
}