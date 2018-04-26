using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
    public partial class _AddGiorno : Page {
		DataAccesObject dao = new DataAccesObject();
        public string Message{ get;set;}
        public DateTime dataC{get;set;}
        public string Comme{get;set;}
        public Giorno Giorno{get;set;}
        public List<Commessa> ListaCommesse{ get;set;}
        public string EsitoAddGiorno{get;set;}
        protected void Page_Load(object sender,EventArgs e) {

        }

		protected void Aggiungi_Click(object sender,EventArgs e) {
  //          string matr = "EEEE";
  //          if(ht.Text ==""){
  //              Message="Scegliere la tipologia delle ore";
  //              Response.Redirect($"~/AddGiorno");
  //          }
  //          dataC = oggi.SelectedDate;
  //          Comme = ht.Text;
  //          Giorno giorno = dao.VisualizzaGiorno(dataC,matr);
  //          string comme2 = commesse.Text;
		//	try{
  //              if (giorno != null && (giorno.data.CompareTo(DateTime.Today) <= 0 || giorno.data.Month >= (DateTime.Now.Month - 6))) {
  //                  if (giorno.HFerie > 0) {
  //                      Giorno = giorno;
  //                      Message = $"Il giorno {dataC.ToString("yyyy-MM-dd")} eri in ferie";
  //                      Response.Redirect($"~/AddGiorno");
  //                  } else if (giorno.HMalattia + giorno.HPermesso + giorno.TotOreLavorate + (Comme != "Ore di ferie" ?  int.Parse(ore.Text)==0 ? 0 : int.Parse(ore.Text) :8) > 8) {
  //                      Giorno = giorno;
  //                      Message = $"Il giorno {dataC.ToString("yyyy-MM-dd")} stai superando le 8 ore";
  //                      Response.Redirect($"~/AddGiorno");
  //                  }
  //              }
		//		if (Comme == "Ore di lavoro"){
  //                  if (ore == null){
  //                      Message = "Inserire le ore";
  //                  }else if(comme2 == ""){
  //                      Message="Inserire la commessa";
  //                      Response.Redirect($"~/AddGiorno");
  //                  }
		//			List<Commessa> commesse = dao.CercaCommesse(comme2);
		//			if (commesse.Count == 0){
		//				Message ="Commessa non trovata";
		//				Response.Redirect($"~/AddGiorno");
		//			} else if(commesse.Count == 1){
		//				dao.CompilaHLavoro(dataC,int.Parse(ore.Text), commesse[0].Id, matr);						
		//			} else if(commesse.Count > 1) {
  //                      Session["stateGiorno"] = new StateGiorno { Data= dataC, Ore=int.Parse(ore.Text) };
  //                      ListaCommesse = commesse;
  //                      Response.Redirect($"~/AddGiorno");
		//			}
		//		} else if (Comme == "Ore di permesso"){
  //                  if (ore == null) {
  //                      Message = "Inserire le ore";
  //                  }
  //                  HType tOre = (HType) 2;
		//			dao.Compila(dataC,int.Parse(ore.Text), tOre, matr);
		//		} else if (Comme == "Ore di malattia") {
  //                  if (ore == null) {
  //                      Message = "Inserire le ore";
  //                  }
  //                  HType tOre = (HType) 1;
		//		    dao.Compila(dataC, int.Parse(ore.Text), tOre, matr);
		//		} else {
		//			HType tOre = (HType) 3;
  //                  dao.Compila(dataC, 8, tOre, matr);
		//		}
		//		EsitoAddGiorno = ore + " " + Comme + " aggiunte!";
		//	}catch(Exception){
  //              Message = "Errore server";
  //          }
  //          Response.Redirect($"~/AddGiorno");
		}
    }
    public class StateGiorno {
            public DateTime Data { get; set; }
            public int Ore { get; set; }
        }
}