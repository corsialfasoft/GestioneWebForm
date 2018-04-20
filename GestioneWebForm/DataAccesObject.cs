using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAO{
 public enum HType { HMalattia = 1, HPermesso, HFerie }
	public interface IDao{
		void ModificaCV(CV a, CV b); //modifica un curriculum nel db
		void AggiungiCV(CV a); //quando sei loggato, puoi aggiungere un curriculum nel db
		void CaricaCV(string path); //quando non sei loggato, puoi spedire un curriuculum
		CV Search(string id); //search di un curriculum per id di un curriculum
		List<CV> SearchChiava(string chiava); //search generale per parole chiava 
		List<CV> SearchEta(int eta); //search solo per quella precisa età
		List<CV> SearchRange(int etmin, int etmax); //search per un range di età minimo e massimo
		void EliminaCV(CV curriculum); //Elimina un CV dal db
		List<CV> SearchCognome(string cognome); //Ricerca solo per cognome
        void AddCvStudi(string MatrCv,PerStud studi);
        void AddEspLav(string MatrCv, EspLav esp );
        void AddCompetenze(string MatrCv, Competenza comp);
	
	   
		void CompilaHLavoro(DateTime data, int ore, int idCommessa, int idUtente);
		void Compila(DateTime data, int ore, HType tipoOre, int idUtente);
		Giorno VisualizzaGiorno(DateTime data, int idUtente);
		List<Giorno> GiorniCommessa(int idCommessa, int idUtente);
		Commessa CercaCommessa(string nomeCommessa);
        //Aggiungi nuovo corso. Lo puo fare solo l'admin
        void AddCorso(Corso corso);
        //Aggiungi una lezione a un determinato corso. Lo puo fare solo il prof
        void AddLezione(int idCorso, Lezione lezione);
        //Iscrizione di uno studente a un determinato corso. Lo puo fare solo lo studente specifico
        void Iscriviti (int idCorso, int idStudente);
        //Cerca un determinato corso 
        Corso SearchCorsi(int idCorso);
        //Cerca tutti i corsi che contine la "descrizione" nei suoi attributi(nome,descrizione)
        List<Corso> SearchCorsi(string descrizione);
        //Cerca tutti i corsi che contiene la "descrizione" di un determinato studente(idStudente)
        List<Corso>SearchCorsi(string descrizione, int idUtente);
        //Mostra tutti i corsi presenti nel db
        List<Corso>ListaCorsi();
        //Mostra tutti i corsi a cui è iscritto un determinato studente(idStudente)
        List<Corso>ListaCorsi(int idUtente);
    }
	// public enum HType { HMalattia = 1, HPermesso, HFerie }
    public partial class DataAccesObject : IDao {

        public void AddCompetenze(string MatrCv,Competenza comp) {
            throw new NotImplementedException();
        }

        public void AddCorso(Corso corso) {
            throw new NotImplementedException();
        }

        public void AddCvStudi(string MatrCv,PerStud studi) {
            throw new NotImplementedException();
        }

        public void AddEspLav(string MatrCv,EspLav esp) {
            throw new NotImplementedException();
        }

        public void AddLezione(int idCorso,Lezione lezione) {
            throw new NotImplementedException();
        }

        public void AggiungiCV(CV a) {
            throw new NotImplementedException();
        }

        public void CaricaCV(string path) {
            throw new NotImplementedException();
        }

        public Commessa CercaCommessa(string nomeCommessa) {
            throw new NotImplementedException();
        }

        public void Compila(DateTime data,int ore,HType tipoOre,int idUtente) {
            throw new NotImplementedException();
        }
		/*
		public void Compila(DateTime data,int ore,HType tipoOre,int idUtente) {
			throw new NotImplementedException();
		}
		*/

		public void CompilaHLavoro(DateTime data,int ore,int idCommessa,int idUtente) {
            throw new NotImplementedException();
        }

        public void EliminaCV(CV curriculum) {
            throw new NotImplementedException();
        }

        public List<Giorno> GiorniCommessa(int idCommessa,int idUtente) {
            throw new NotImplementedException();
        }

        public void Iscriviti(int idCorso,int idStudente) {
            throw new NotImplementedException();
        }

        public List<Corso> ListaCorsi() {
            throw new NotImplementedException();
        }

        public List<Corso> ListaCorsi(int idUtente) {
            throw new NotImplementedException();
        }

        public void ModificaCV(CV a,CV b) {
            throw new NotImplementedException();
        }

        public CV Search(string id) {
        CV trovato = new CV();
		SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CercaMatricola",connection);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@matri",System.Data.SqlDbType.NVarChar).Value=id;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					trovato= GetCV(reader.GetInt32(0));
				}
				reader.Close();
				command.Dispose();
				return trovato;

			}catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		
        }

		private CV GetCV(int v)
		{
			throw new NotImplementedException();
		}

		public List<CV> SearchChiava(string chiava) {
			List<CV> trovati = new List<CV>();
		SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CercaParolaChiava",connection);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@parola",System.Data.SqlDbType.NVarChar).Value=chiava;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					trovati.Add(GetCV(reader.GetInt32(0)));
				}
				reader.Close();
				command.Dispose();
				return trovati;

			}catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
        }

        public List<CV> SearchCognome(string cognome) {
        List<CV> trovati = new List<CV>();
		SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CercaCognome",connection);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@cognome",System.Data.SqlDbType.NVarChar).Value=cognome;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					trovati.Add(GetCV(reader.GetInt32(0)));
				}
				reader.Close();
				command.Dispose();
				return trovati;

			}catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
        }

        public Corso SearchCorsi(int idCorso) {
            throw new NotImplementedException();
        }

        public List<Corso> SearchCorsi(string descrizione) {
            throw new NotImplementedException();
        }

        public List<Corso> SearchCorsi(string descrizione,int idUtente) {
            throw new NotImplementedException();
        }

        public List<CV> SearchEta(int eta) {
        List<CV> trovati = new List<CV>();
		SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CercaEta",connection);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@cognome",System.Data.SqlDbType.Int).Value=eta;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					trovati.Add(GetCV(reader.GetInt32(0)));
				}
				reader.Close();
				command.Dispose();
				return trovati;

			}catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
        }

        public List<CV> SearchRange(int etmin,int etmax) {
           List<CV> trovati = new List<CV>();
            List<EspLav> esplav = new List<EspLav>{new EspLav{ AnnoInizio=2012, AnnoFine=2016, Descrizione="Binzinaro",Qualifica="Ciavevo le pompe di benzina"} };
			List<Competenza> competenzas = new List<Competenza> {new Competenza{Livello=2,Titolo="Alto Mago"} };
			List<PerStud> perStuds=new List<PerStud> {new PerStud{AnnoInizio=2000,AnnoFine=2005,Descrizione="Media",Titolo="Licenza media" } };
			return trovati=new List<CV> {new CV  {Nome="Pino",Cognome="Panino",Eta=78,Email="paxxerellotunztunz@netlog.com",Matricola="E9412E",Residenza="Sotto il ponte della tangenziale",Telefono="800900313",Esperienze=esplav,Competenze=competenzas,Percorsostudi=perStuds },
				new CV  {Nome="Pano",Cognome="Panano",Eta=78,Email="paxxerellotunztunz@netlog.com",Matricola="E9412E",Residenza="Sotto il ponte della tangenziale",Telefono="800900313",Esperienze=esplav,Competenze=competenzas,Percorsostudi=perStuds },
				new CV {Nome="Pono",Cognome="Ponono",Eta=78,Email="paxxerellotunztunz@netlog.com",Matricola="E9412E",Residenza="Sotto il ponte della tangenziale",Telefono="800900313",Esperienze=esplav,Competenze=competenzas,Percorsostudi=perStuds }};
        }

        public Giorno VisualizzaGiorno(DateTime data,int idUtente) {
            throw new NotImplementedException();
        }
		public string GetConnection()
		{
			SqlConnectionStringBuilder builder= new SqlConnectionStringBuilder();
			builder.DataSource=@"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog="GECV";
			return builder.ToString();
		}
    }
    public class Profilo{ 
        public string Matrincola{get;set;}
        public string Nome{get;set;}
        public string Cognome{get;set;}
        public string Ruolo{get;set;}
        public string Username{get;set;}
        public string Password{get;set;}
    }

    public class Studente{ 
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Cognome{get;set;}
    }
    public class Corso{ 
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Descrizione{get;set;}
        public DateTime Inizio{get;set;}
        public DateTime Fine {get;set;}
        public List<Studente> Studenti{get;set;}
        public List<Lezione> Lezioni{get;set;}
    }
    public class Lezione{ 
        public int Id{get;set;}
        public string Nome {get;set;}
        public string Descrizione{get;set;}
        public int Durata{get;set;}
    }
	
    public partial class Giorno {
		private List<int> _id;
		private int _id_utente;
		private int[] ore = new int[3];
		private DateTime data;

		public DateTime Data { get { return data; } }
		private List<Commessa> commesse;

		public int ID_UTENTE { get { return _id_utente; } set { _id_utente = value; } }
		public List<int> ID { get { return _id; } set { _id = value; } }
		public int HL { get { return TotCom(); } }
		public int[] Ore { get => ore; set => ore = value; }
		public List<Commessa> Commesse { get => commesse; }


		public Giorno(DateTime data) { this.data = data; }
		public Giorno(DateTime data, int HP, int HM, int HF, List<int> id, int id_utente) {
			this.data = data;
			Ore[(int)HType.HPermesso] = HP;
			Ore[(int)HType.HMalattia] = HM;
			Ore[(int)HType.HFerie] = HF;
			_id = id;
			_id_utente = id_utente;
		}

		public void AddCommessa(Commessa com) {
			if (commesse == null)
				commesse = new List<Commessa>();
			commesse.Add(com);
		}
		private int TotCom() {
			int tot = 0;
			foreach (Commessa com in Commesse) {
				tot += com.OreLavorate;
			}
			return tot;
		}
		public override bool Equals(object obj) {
			return data.Equals(((Giorno)obj).data);
		}
		public override int GetHashCode() {
			return base.GetHashCode();
		}
	}
	public partial class Commessa {

		public int Capacita { get => _capacita; set => _capacita = value; }
		public string Descrizione { get => _descrizione; set => _descrizione = value; }
		public string Nome { get => _nome; set => _nome = value; }
		public int OreLavorate { get => oreLavorate; set => oreLavorate = value; }


		private int _id; public int Id { get; set; }
		private int oreLavorate;
		private string _nome;
		private int _capacita;
		private string _descrizione;

		public Commessa(int id, int oreLavorate, string nome, int capacita, string descrizione) {
			_id = id;
			this.oreLavorate = oreLavorate;
			_nome = nome;
			_capacita = capacita;
			_descrizione = descrizione;
		}
    }

    public class CV {
        public string Matricola {get; set;}
        public string Nome {get; set;}
        public string Cognome {get; set;}
        public int Eta {get; set;}
        public string Email { get; set;}
        public string Residenza {get; set;}
        public string Telefono {get; set;}
        public List<EspLav> Esperienze {get; set;}
        public List<PerStud> Percorsostudi {get; set;}
        public List<Competenza> Competenze {get; set;}
    }
    public class EspLav {
        public int id{get;set;}
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Qualifica {get; set;}
        public string Descrizione {get; set;}
    }
    public class PerStud {
        public int id{get;set;}
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Titolo {get; set;}
        public string Descrizione {get; set;}
    }
    public class Competenza {
        public int id{get;set;}
        public string Titolo {get; set;}
        public int Livello {get; set;}
    }

}