using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace GestioneWebForm {
    public partial class _AddGiorno : Page {
		IDao dao = new DataAccesObject();
        public string Message{ get;set;}
        public DateTime dataC{get;set;}
        public string Comme{get;set;}
        public Giorno Giorno{get;set;}
        public List<Commessa> ListaCommesse{ get;set;}
        public string EsitoAddGiorno{get;set;}
        public DateTime GeCoDataTime { get; private set; }

        protected void Page_Load(object sender,EventArgs e) {
            Message = Request["Message"]?? null;
        }

		protected void Aggiungi_Click(object sender,EventArgs e){
            string matr = "EEEE";
            int oreM = 0;
            DateTime giornoV = oggi.SelectedDate;
            if(tipoOre.Text==""){
                Message="Scegliere la tipologia delle ore";
                Response.Redirect($"~/AddGiorno?Message={Message}");
            }
            if (ore == null && tipoOre.Text != "Ore di ferie" || (int.TryParse(ore.Text,out oreM)&& oreM <= 0)) {
                Message = "Inserire le ore";
                Response.Redirect($"~/AddGiorno?Message={Message}");
            }
            Giorno giorno = dao.VisualizzaGiorno(giornoV, matr);
			try{
                int oreT =0;
                int oreL = 0;
                if (giorno != null && (giornoV.CompareTo(DateTime.Today) <= 0 || giornoV.Month >= (DateTime.Now.Month - 6))) {
                    oreT = giorno.HMalattia + giorno.HPermesso + giorno.TotOreLavorate + giorno.HFerie;
                    if (giorno.HFerie > 0) {
                        Giorno = giorno;
                        Message = $"Il giorno {giorno.Data.ToString("yyyy-MM-dd")} eri in ferie";
                       Response.Redirect($"~/AddGiorno?Message={Message}");
                    }
                    oreL= giorno.TotOreLavorate;
                }
				if (tipoOre.Text == "Ore di lavoro"){
                    if(commesse.Text == ""){
                        Message="Inserire la commessa";
                       Response.Redirect($"~/AddGiorno?Message={Message}");
                    }
                    if (oreT == oreL && oreT + oreM > 14) {
                        Giorno = giorno;
                        Message="Massimo ore lavorative raggiunte!";
                        Response.Redirect($"~/AddGiorno?Message={Message}");
                    } else if (oreT != oreL && oreT + oreM > 8)
                        ErrorMessage(giornoV, giorno);
                    List<Commessa> commesseCs = dao.CercaCommesse(commesse.Text);
					if (commesseCs.Count == 0){
						Message ="Commessa non trovata";
						Response.Redirect($"~/AddGiorno?Message={Message}");
					} else if(commesseCs.Count == 1){
                        if (commesseCs[0].OreLavorate+oreM>commesseCs[0].Capienza) {
                            Message = $"Capienza ore commessa superate!\nMassimo ore: {commesseCs[0].Capienza}";
                            Response.Redirect($"~/AddGiorno?Message={Message}");
                        }
						dao.CompilaHLavoro(giornoV,oreM, commesseCs[0].Id, matr);				
					} else if(commesseCs.Count > 1) {
                        Session["stateGiorno"] = new StateGiorno { Data= giornoV, Ore=oreM };
                        ListaCommesse = commesseCs;
                        Response.Redirect($"~/AddGiorno?Message={Message}");
					}
				} else if (tipoOre.Text == "Ore di permesso"){
                    if (oreT + oreM > 8)
                        ErrorMessage(giornoV, giorno);
                    dao.Compila(giornoV,oreM, (HType)2, matr);
				} else if (tipoOre.Text == "Ore di malattia") {
                    if (oreT + oreM > 8) 
                        ErrorMessage(giornoV, giorno);
                    dao.Compila(giornoV, oreM, (HType)1, matr);
				} else if (tipoOre.Text == "Ore di ferie"){
                    if (oreT + 8 > 8) 
                        ErrorMessage(giornoV, giorno);
                    dao.Compila(giornoV, 8, (HType)3, matr);
                } else {
                    Message = $"Input Errato!";
                    Response.Redirect($"~/AddGiorno?Message={Message}");
                }
				EsitoAddGiorno = ore + " " + tipoOre + " aggiunte!";
                GeCoDataTime = giornoV;
            } catch(Exception ex){
                Message = ex.Message;
                //Message = "Errore server";
            }
		}
        private void ErrorMessage(DateTime dateTime, Giorno giorno) {
            Giorno = giorno;
            Message = $"Il giorno {dateTime.ToString("yyyy-MM-dd")} stai superando le 8 ore";
            Response.Redirect($"~/AddGiorno?Message={Message}");
        }

            /*{
            string matr = "EEEE";
            Comme = tipoOre.Text;
            if( Comme ==""){
                Message="Scegliere la tipologia delle ore";
                Response.Redirect($"~/AddGiorno");
            }
            dataC = oggi.SelectedDate;
            Giorno giorno = dao.VisualizzaGiorno(dataC,matr);
            string comme2 = commesse.Text;
			try{
                if (giorno != null && (giorno.data.CompareTo(DateTime.Today) <= 0 || giorno.data.Month >= (DateTime.Now.Month - 6))) {
                    if (giorno.HFerie > 0) {
                        Giorno = giorno;
                        Message = $"Il giorno {dataC.ToString("yyyy-MM-dd")} eri in ferie";
                        Response.Redirect($"~/AddGiorno");
                    } else if (giorno.HMalattia + giorno.HPermesso + giorno.TotOreLavorate + (Comme != "Ore di ferie" ?  int.Parse(ore.Text)==0 ? 0 : int.Parse(ore.Text) :8) > 8) {
                        Giorno = giorno;
                        Message = $"Il giorno {dataC.ToString("yyyy-MM-dd")} stai superando le 8 ore";
                        Response.Redirect($"~/AddGiorno");
                    }
                }
				if (Comme == "Ore di lavoro"){
                    if (ore == null){
                        Message = "Inserire le ore";
                    }else if(comme2 == ""){
                        Message="Inserire la commessa";
                        Response.Redirect($"~/AddGiorno");
                    }
					List<Commessa> commesse = dao.CercaCommesse(comme2);
					if (commesse.Count == 0){
						Message ="Commessa non trovata";
						Response.Redirect($"~/AddGiorno");
					} else if(commesse.Count == 1){
						dao.CompilaHLavoro(dataC,int.Parse(ore.Text), commesse[0].Id, matr);						
					} else if(commesse.Count > 1) {
                        Session["stateGiorno"] = new StateGiorno { Data= dataC, Ore=int.Parse(ore.Text) };
                        ListaCommesse = commesse;
                        Response.Redirect($"~/AddGiorno");
					}
				} else if (Comme == "Ore di permesso"){
                    if (ore == null) {
                        Message = "Inserire le ore";
                    }
                    HType tOre = (HType) 2;
					dao.Compila(dataC,int.Parse(ore.Text), tOre, matr);
				} else if (Comme == "Ore di malattia") {
                    if (ore == null) {
                        Message = "Inserire le ore";
                    }
                    HType tOre = (HType) 1;
				    dao.Compila(dataC, int.Parse(ore.Text), tOre, matr);
				} else {
					HType tOre = (HType) 3;
                    dao.Compila(dataC, 8, tOre, matr);
				}
				EsitoAddGiorno = ore + " " + Comme + " aggiunte!";
			}catch(Exception){
                Message = "Errore server";
            }
            Response.Redirect($"~/AddGiorno");
		}
    }*/
    public class StateGiorno {
            public DateTime Data { get; set; }
            public int Ore { get; set; }
        }
    } 
}