using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DAO{
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
        void AddCorso(Corso corso);//fatto
        //Aggiungi una lezione a un determinato corso. Lo puo fare solo il prof
        void AddLezione(int idCorso, Lezione lezione);//fatto
        //restituisce le lezioni di un determinato corso
        List<Lezione> SearchLezioni(int idCorso);//fatto
        //Iscrizione di uno studente a un determinato corso. Lo puo fare solo lo studente specifico
        void Iscriviti (int idCorso, string idStudente);//fatto
        //Cerca un determinato corso 
        Corso SearchCorsi(int idCorso);//fatto
        //Cerca tutti i corsi che contine la "descrizione" nei suoi attributi(nome,descrizione)
        List<Corso> SearchCorsi(string descrizione);//fatto
        //Cerca tutti i corsi che contiene la "descrizione" di un determinato studente(idStudente)
        List<Corso>SearchCorsi(string descrizione, string matrUtente);//fatto
        //Mostra tutti i corsi presenti nel db
        List<Corso>ListaCorsi();//fatto
        //Mostra tutti i corsi a cui è iscritto un determinato studente(idStudente)
        List<Corso>ListaCorsi(int idUtente);//fatto
		void EliminaLezione(int idLezione);
    }
	 public enum HType { HMalattia = 1, HPermesso, HFerie }
    public partial class DataAccesObject : IDao {
        public void AddCompetenze(string MatrCv,Competenza comp) {
            throw new NotImplementedException();
        }
        //fatto
        public void AddCorso(Corso corso){
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("AddCorso",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@nome",SqlDbType.NVarChar).Value=corso.Nome;
                cmd.Parameters.Add("@descrizione",SqlDbType.NVarChar).Value=corso.Descrizione;
                cmd.Parameters.Add("@dInizio",SqlDbType.Date).Value=corso.Inizio.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@dFine",SqlDbType.Date).Value=corso.Fine.ToString("yyyy/MM/dd");
                int x = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if(x==0){ 
                    throw new Exception();    
                }
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
        }

        public void AddCvStudi(string MatrCv,PerStud studi) {
            throw new NotImplementedException();
        }

        public void AddEspLav(string MatrCv,EspLav esp) {
            throw new NotImplementedException();
        }
        //fatto
        public void AddLezione(int idCorso,Lezione lezione){
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("AddLezione",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@idCorso",SqlDbType.Int).Value=idCorso;
                cmd.Parameters.Add("@argomento",SqlDbType.NVarChar).Value=lezione.Argomento;
                cmd.Parameters.Add("@durata",SqlDbType.Int).Value=lezione.Durata;
                int x = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if(x==0){ 
                    throw new Exception();    
                }
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
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

        public void CompilaHLavoro(DateTime data,int ore,int idCommessa,int idUtente) {
            throw new NotImplementedException();
        }

        public void EliminaCV(CV curriculum) {
            throw new NotImplementedException();
        }

        public List<Giorno> GiorniCommessa(int idCommessa,int idUtente) {
            throw new NotImplementedException();
        }
        //fatto
        public void Iscriviti(int idCorso,string idStudente){
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("Iscrizione",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@IdCorso",SqlDbType.Int).Value=idCorso;
                cmd.Parameters.Add("@matr",SqlDbType.NVarChar).Value=idStudente;
                int x = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if(x==0){ 
                    throw new Exception();    
                }
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
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
            List<EspLav> esplav = new List<EspLav>{new EspLav{ AnnoInizio=2012, AnnoFine=2016, Descrizione="Binzinaro",Qualifica="Ciavevo le pompe di benzina"} };
			List<Competenza> competenzas = new List<Competenza> {new Competenza{Livello=2,Titolo="Alto Mago"} };
			List<PerStud> perStuds=new List<PerStud> {new PerStud{AnnoInizio=2000,AnnoFine=2005,Descrizione="Media",Titolo="Licenza media" } };
			return new CV {Nome="Pino",Cognome="Panino",Eta=78,Email="paxxerellotunztunz@netlog.com",Matricola="E9412E",Residenza="Sotto il ponte della tangenziale",Telefono="800900313",Esperienze=esplav,Competenze=competenzas,Percorsostudi=perStuds };
			;
        }

        public List<CV> SearchChiava(string chiava) {
            throw new NotImplementedException();
        }

        public List<CV> SearchCognome(string cognome) {
            throw new NotImplementedException();
        }
        //fatto
        private string GetConnection(){
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(){ 
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "GeCo"
                };  
            return builder.ToString();
        }
        
        //fatto
        public Corso SearchCorsi(int idCorso) {
            Corso corso = new Corso();
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("SearchCorso",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@IdCorso",SqlDbType.Int).Value=idCorso;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    int _id = reader.GetInt32(0);
                    string _nome = reader.GetString(1);
                    string _descrizione = reader.GetString(2);
                    DateTime _dInizio = reader.GetDateTime(3);
                    DateTime _dFine = reader.GetDateTime(4);
                    corso = new Corso{Id=_id, Nome = _nome, Descrizione = _descrizione,Inizio = _dInizio, Fine = _dFine};
                }
                reader.Close();
                cmd.Dispose();
                return corso;
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
        }
        
        //fatto
        public List<Corso> SearchCorsi(string descrizione){
            List<Corso> corsi = new List<Corso>();
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("SearchCorsi",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@descrizione",SqlDbType.NVarChar).Value=descrizione;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    int _id = reader.GetInt32(0);
                    string _nome = reader.GetString(1);
                    string _descrizione = reader.GetString(2);
                    DateTime _dInizio = reader.GetDateTime(3);
                    DateTime _dFine = reader.GetDateTime(4);
                    corsi.Add(new Corso{Id=_id, Nome = _nome, Descrizione = _descrizione,Inizio = _dInizio, Fine = _dFine});
                }
                reader.Close();
                cmd.Dispose();
                return corsi;
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
        }

        //fatto
        public List<Corso> SearchCorsi(string descrizione,string matrUtente){
            List<Corso> corsi = new List<Corso>();
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("SearchCorsiStud",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@idStudente",SqlDbType.NVarChar).Value=matrUtente;
                cmd.Parameters.Add("@descrizione",SqlDbType.NVarChar).Value=descrizione;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    int _id = reader.GetInt32(0);
                    string _nome = reader.GetString(1);
                    string _descrizione = reader.GetString(2);
                    DateTime _dInizio = reader.GetDateTime(3);
                    DateTime _dFine = reader.GetDateTime(4);
                    corsi.Add(new Corso{Id=_id, Nome = _nome, Descrizione = _descrizione,Inizio = _dInizio, Fine = _dFine});
                }
                reader.Close();
                cmd.Dispose();
                return corsi;
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
        }

        public List<CV> SearchEta(int eta) {
            throw new NotImplementedException();
        }

        public List<CV> SearchRange(int etmin,int etmax) {
            throw new NotImplementedException();
        }

        public Giorno VisualizzaGiorno(DateTime data,int idUtente) {
            throw new NotImplementedException();
        }

        //fatto
        public List<Lezione> SearchLezioni(int idCorso) {
            List<Lezione> lezioni = new List<Lezione>();
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand ("SearchLezioni",con){CommandType = CommandType.StoredProcedure}; 
                cmd.Parameters.Add("@IdCorso",SqlDbType.Int).Value=idCorso;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    int _id = reader.GetInt32(0);
                    string _argomento = reader.GetString(1);
                    int _durata = reader.GetInt32(2);
                    lezioni.Add(new Lezione{Id=_id, Argomento = _argomento, Durata = _durata});
                }
                reader.Close();
                cmd.Dispose();
                return lezioni;
            }catch(Exception e){ 
                throw e;    
            }finally{ 
                con.Dispose();    
            }
        }

		public void EliminaLezione(int idLezione)
		{
			SqlConnection connection=new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.EliminaLezione",connection);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@IdLezione",System.Data.SqlDbType.Int).Value=idLezione;
				int x = command.ExecuteNonQuery();
				if (x == 0) {
					throw new Exception("La lezione non è stata eliminata");
				}
				command.Dispose();
			}catch (Exception x) {
				throw x;
			} finally {
				connection.Dispose();
			}
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
        public string Argomento {get;set;}
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
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Qualifica {get; set;}
        public string Descrizione {get; set;}
    }
    public class PerStud {
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Titolo {get; set;}
        public string Descrizione {get; set;}
    }
    public class Competenza {
        public string Titolo {get; set;}
        public int Livello {get; set;}
    }

}