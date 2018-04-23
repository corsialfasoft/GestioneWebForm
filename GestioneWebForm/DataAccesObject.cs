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
        Competenza GetCompetenza(int id);
        EspLav GetEsperienza(int id);
        PerStud GetPercorso(int id);
	
	   
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
				DataSource = @"(localdb)\MSSQLLocalDB",
				InitialCatalog = "GECV"
			};
			SqlConnection connection = new SqlConnection(builder.ToString());
			int x;
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.AddCompetenze",connection) {
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.Add("@Tipo",SqlDbType.NVarChar).Value=comp.Titolo;
				command.Parameters.Add("@Livello",SqlDbType.Int).Value=comp.Livello;
				command.Parameters.Add("@MatrCv",SqlDbType.NVarChar).Value=MatrCv;
				x = command.ExecuteNonQuery();
				command.Dispose();
				if (x == 0) { 
					throw new Exception("Nessun curriculum eliminato!");
					}				
			}catch(Exception e) {
				throw e;
			}finally {
				connection.Dispose();
			}
        }

        public void AddCorso(Corso corso) {
            throw new NotImplementedException();
        }

        public void AddCvStudi(string MatrCv,PerStud studi) {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
				DataSource = @"(localdb)\MSSQLLocalDB",
				InitialCatalog = "GECV"
			};
			SqlConnection connection = new SqlConnection(builder.ToString());
			int x;
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.AddCvStudi",connection) {
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.Add("@AnnoI",SqlDbType.Int).Value=studi.AnnoInizio;
				command.Parameters.Add("@AnnoF",SqlDbType.Int).Value=studi.AnnoFine;
				command.Parameters.Add("@Titolo",SqlDbType.VarChar).Value=studi.Titolo;
				command.Parameters.Add("@Descrizione",SqlDbType.VarChar).Value=studi.Descrizione;
				command.Parameters.Add("@MatrCv",SqlDbType.NVarChar).Value=MatrCv;
				 x = command.ExecuteNonQuery();
				command.Dispose();
				if (x == 0) { 
					throw new Exception("Nessun curriculum eliminato!");
					}				
			}catch(Exception e) {
				throw e;
			}finally {
				connection.Dispose();
			}
        }

        public void AddEspLav(string MatrCv,EspLav esp) {
            SqlConnection con= new SqlConnection(GetConnection());
			try {
				con.Open();
				SqlCommand command = new SqlCommand("AddEspLav",con);
				command.CommandType=CommandType.StoredProcedure;
				command.Parameters.Add("@AnnoI",SqlDbType.Int).Value=esp.AnnoInizio;
				command.Parameters.Add("@AnnoF",SqlDbType.Int).Value=esp.AnnoFine;
				command.Parameters.Add("@Qualifica",SqlDbType.NVarChar).Value=esp.Qualifica;
				command.Parameters.Add("@Descrizione",SqlDbType.NVarChar).Value=esp.Descrizione;
				command.Parameters.Add("@matr",SqlDbType.NVarChar).Value=MatrCv;
                int x = command.ExecuteNonQuery();
				command.Dispose();
				if (x == 0) { 
					throw new Exception("Nessuna Esperienza Inserita");
					}
				
			}catch(Exception e) {
				throw e;
			}finally {
				con.Dispose();
			}
        }

        public void AddLezione(int idCorso,Lezione lezione) {
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
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
				DataSource = @"(localdb)\MSSQLLocalDB",
				InitialCatalog = "GECV"
			};
			SqlConnection connection = new SqlConnection(builder.ToString());
			int x;
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.DeleteCurriculum",connection) {
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.Add("@idcurr",SqlDbType.NVarChar).Value=curriculum.Matricola;
				 x = command.ExecuteNonQuery();
				command.Dispose();
				if (x == 0) { 
					throw new Exception("Nessun curriculum eliminato!");
					}				
			}catch(Exception e) {
				throw e;
			}finally {
				connection.Dispose();
			}
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
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("ModificaCurriculum",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@matricolaM", System.Data.SqlDbType.NVarChar).Value=a.Matricola ;
				command.Parameters.Add("@nomeM", System.Data.SqlDbType.NVarChar).Value=b.Nome;
				command.Parameters.Add("@cognomeM", System.Data.SqlDbType.NVarChar).Value=b.Cognome;
				command.Parameters.Add("@etaM", System.Data.SqlDbType.Int).Value=b.Eta;
				command.Parameters.Add("@emailM", System.Data.SqlDbType.NVarChar).Value=b.Email;
				command.Parameters.Add("@residenzaM", System.Data.SqlDbType.NVarChar).Value=b.Residenza;
				command.Parameters.Add("@telefonoM", System.Data.SqlDbType.NVarChar).Value=b.Telefono;
				command.ExecuteNonQuery();
                //ModEspLav(a.Matricola,a.Esperienze[0],b.Esperienze[0]);
                //ModPerStudi(a.Matricola,a.Percorsostudi[0],ViewBag.PercorsoStudi);
                //ModComp(a.Matricola,a.Competenze[0],b.Competenze[0]);
				command.Dispose();
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
       

        public CV Search(string matr) {
			CV trovato = new CV();
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("GetCv",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value=matr;
				SqlDataReader reader = command.ExecuteReader();
				CV c = new CV();
				while(reader.Read()){
					c.Nome = reader.GetString(0) ?? "";
					c.Cognome = reader.GetString(1)?? "";
					c.Eta = reader.GetInt32(2);
					c.Matricola = reader.GetString(3) ?? "";
					c.Email = reader.GetValue(4)==DBNull.Value ? "" : reader.GetString(4) ;
					c.Residenza = reader.GetValue(5)==DBNull.Value ? "" : reader.GetString(5) ;
					c.Telefono =  reader.GetValue(6)==DBNull.Value ? "" : reader.GetString(6) ;
				}
				c.Percorsostudi= GetPerStudi(c.Matricola);
				c.Esperienze = GetEspLav(c.Matricola);
				c.Competenze = GetComp(c.Matricola);
				reader.Close();
				command.Dispose();
				return c;
			}catch (Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
        }
		public List<Competenza> GetComp(string matricola) {
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("GetComp",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value=matricola;
				List<Competenza> res = new List<Competenza>();
				SqlDataReader reader = command.ExecuteReader();
				Competenza e = new Competenza();
				while(reader.Read()){
                    e.Id = reader.GetValue(0) == DBNull.Value? 0 : reader.GetInt32(0);
					e.Livello = reader.GetValue(1) == DBNull.Value ? 0 : reader.GetInt32(1);
					e.Titolo = reader.GetValue(2) == DBNull.Value ? "" : reader.GetString(2);
				
					res.Add(e);
				}
				reader.Close();
				command.Dispose();
				return res;
			}catch(Exception e){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
		public List<PerStud> GetPerStudi(string matricola) {
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("GetPerStudi",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value=matricola;
				List<PerStud> res = new List<PerStud>();
				SqlDataReader reader = command.ExecuteReader();
				PerStud e = new PerStud();
				while(reader.Read()){
                    e.Id = reader.GetValue(0) == DBNull.Value? 0 : reader.GetInt32(0);
					e.AnnoInizio = reader.GetValue(1) == DBNull.Value ? 0 : reader.GetInt32(1);
					e.AnnoFine = reader.GetValue(2) == DBNull.Value ? 0 : reader.GetInt32(2);
					e.Titolo = reader.GetValue(3) == DBNull.Value ? "" : reader.GetString(3);
					e.Descrizione = reader.GetValue(4) == DBNull.Value ? "" : reader.GetString(4);
					res.Add(e);
				}
				reader.Close();
				command.Dispose();
				return res;
			}catch(Exception e){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
		public List<EspLav> GetEspLav(string matricola) {
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("GetEspLav",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value=matricola;
				List<EspLav> res = new List<EspLav>();
				SqlDataReader reader = command.ExecuteReader();
				EspLav e = new EspLav();
				while(reader.Read()){
                    e.Id = reader.GetValue(0) == DBNull.Value? 0 : reader.GetInt32(0);
					e.AnnoInizio = reader.GetValue(1) == DBNull.Value ? 0 : reader.GetInt32(1);
					e.AnnoFine = reader.GetValue(2) == DBNull.Value ? 0 : reader.GetInt32(2);
					e.Qualifica = reader.GetValue(3)==DBNull.Value ? "" : reader.GetString(3);
					e.Descrizione =reader.GetValue(4)==DBNull.Value ? "" : reader.GetString(4);
					res.Add(e);
				}
				reader.Close();
				command.Dispose();
				return res;
			}catch(Exception e){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
		

        //fatto
        public Competenza GetCompetenza(int id){ 
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                Competenza c = new Competenza();
                SqlCommand cmd = new SqlCommand("GetCompetenza",con){CommandType=CommandType.StoredProcedure};
                cmd.Parameters.Add("id",SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    c.Id = reader.GetInt32(0);
                    c.Titolo = reader.GetString(1);
                    c.Livello = reader.GetInt32(2);
                }
                reader.Close();
                cmd.Dispose();
                return c;
            }catch(Exception e){ 
                throw e;
            }
            finally{ 
                con.Dispose();
            }   
        }
        //fatto
        public EspLav GetEsperienza(int id){ 
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                EspLav es = new EspLav();
                SqlCommand cmd = new SqlCommand("GetEsperienza",con){CommandType=CommandType.StoredProcedure};
                cmd.Parameters.Add("id",SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    es.Id = reader.GetInt32(0);
                    es.AnnoInizio  = reader.GetInt32(1);
                    es.AnnoFine = reader.GetInt32(2);
                    es.Qualifica = reader.GetString(3);
                    es.Descrizione = reader.GetString(4);
                }
                reader.Close();
                cmd.Dispose();
                return es;
            }catch(Exception e){ 
                throw e;
            }
            finally{ 
                con.Dispose();
            }   
        }
        //fatto
        public PerStud GetPercorso(int id){ 
            SqlConnection con = new SqlConnection(GetConnection());
            try{
                con.Open();
                PerStud ps = new PerStud();
                SqlCommand cmd = new SqlCommand("GetPercorso",con){CommandType=CommandType.StoredProcedure};
                cmd.Parameters.Add("id",SqlDbType.Int).Value = id;
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){ 
                    ps.Id = reader.GetInt32(0);
                    ps.AnnoInizio  = reader.GetInt32(1);
                    ps.AnnoFine = reader.GetInt32(2);
                    ps.Titolo = reader.GetString(3);
                    ps.Descrizione = reader.GetString(4);
                }
                reader.Close();
                cmd.Dispose();
                return ps;
            }catch(Exception e){ 
                throw e;
            }
            finally{ 
                con.Dispose();
            }   
        }
        
        public void AggiungiCV(CV c) {
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("AddCv",connection) {
					CommandType = System.Data.CommandType.StoredProcedure
				};
				command.Parameters.Add("@Nome",System.Data.SqlDbType.NVarChar).Value= c.Nome;
				command.Parameters.Add("@Cognome",System.Data.SqlDbType.NVarChar).Value= c.Cognome;
				command.Parameters.Add("@Eta",System.Data.SqlDbType.Int).Value= c.Eta;
				command.Parameters.Add("@Matricola",System.Data.SqlDbType.NVarChar).Value= c.Matricola;
				command.Parameters.Add("@Residenza",System.Data.SqlDbType.NVarChar).Value= c.Residenza;
				command.Parameters.Add("@Telefono",System.Data.SqlDbType.NVarChar).Value= c.Telefono;
				command.ExecuteNonQuery();
				command.Dispose();
			}catch(Exception e){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
        //modificato
		public void ModEspLav(int id, EspLav Mod){
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("ModEspLav",connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@id" , System.Data.SqlDbType.Int).Value= id;
				command.Parameters.Add("@annoIMod" , System.Data.SqlDbType.Int).Value= Mod.AnnoInizio;
				command.Parameters.Add("@annoFMod" , System.Data.SqlDbType.Int).Value= Mod.AnnoFine;
				command.Parameters.Add("@qualificaMod" , System.Data.SqlDbType.NVarChar).Value= Mod.Qualifica;
				command.Parameters.Add("@descrMod" , System.Data.SqlDbType.NVarChar).Value= Mod.Descrizione;
				int x =command.ExecuteNonQuery();
				command.Dispose();
                if(x<1){ 
                    throw new Exception();    
                }
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
        //modificato
		public void ModPerStudi(int id, PerStud Mod){
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("ModPerStud",connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@id" , System.Data.SqlDbType.Int).Value= id;
				command.Parameters.Add("@annoIMod" , System.Data.SqlDbType.Int).Value= Mod.AnnoInizio;
				command.Parameters.Add("@annoFMod" , System.Data.SqlDbType.Int).Value= Mod.AnnoFine;
				command.Parameters.Add("@titoloMod" , System.Data.SqlDbType.NVarChar).Value= Mod.Titolo;
				command.Parameters.Add("@descrMod" , System.Data.SqlDbType.NVarChar).Value= Mod.Descrizione;
				int x =command.ExecuteNonQuery();
				command.Dispose();
                if(x<1){ 
                    throw new Exception();    
                }
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}
        //modificato
		public void ModComp (int id, Competenza Mod){
			SqlConnection connection = new SqlConnection(GetConnection());
			try{
				connection.Open();
				SqlCommand command = new SqlCommand("ModComp",connection);
				command.CommandType = System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@id" , System.Data.SqlDbType.Int).Value= id;
				command.Parameters.Add("@titoloMod" , System.Data.SqlDbType.NVarChar).Value= Mod.Titolo;
				command.Parameters.Add("@livMod" , System.Data.SqlDbType.Int).Value= Mod.Livello;
				command.ExecuteNonQuery();
				command.Dispose();
			}catch(Exception e ){
				throw e;
			}finally{
				connection.Dispose();
			}
		}

		private CV GetCV(String v){
			CV c = new CV();
			c.Nome="Florin";
			c.Cognome="Gheliuc";
			c.Matricola="GGGGG";
			c.Eta=22;
			c.Email="geliuc";
			c.Residenza="Turin";
			c.Telefono="ZeroUndici";
			c.Esperienze=new List<EspLav>();
			c.Competenze=new List<Competenza>();
			c.Percorsostudi= new List<PerStud>();
			return c;
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
					trovati.Add(Search(reader.GetString(0)));
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
					trovati.Add(Search(reader.GetString(0)));
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
				command.Parameters.Add("@eta",System.Data.SqlDbType.Int).Value=eta;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					trovati.Add(Search(reader.GetString(0)));
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
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
				DataSource = @"(localdb)\MSSQLLocalDB",
				InitialCatalog = "GECV"
			};
			SqlConnection connection = new SqlConnection(builder.ToString());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CercaEtaMinMax",connection) {
					CommandType = CommandType.StoredProcedure
				};
				command.Parameters.Add("@e_min",SqlDbType.Int).Value=etmin;
				command.Parameters.Add("@e_max",SqlDbType.Int).Value=etmax;
				SqlDataReader reader = command.ExecuteReader();
				while (reader.Read()){
					trovati.Add(Search(reader.GetString(0)));
				}
				reader.Close();
				command.Dispose();
				return trovati;				
			}catch(Exception e) {
				throw e;
			}finally {
				connection.Dispose();
			}
        }

        public Giorno VisualizzaGiorno(DateTime data,int idUtente) {
            throw new NotImplementedException();
        }
		public string GetConnection()
		{
			SqlConnectionStringBuilder builder= new SqlConnectionStringBuilder();
			builder.DataSource=@"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog="GECuV";
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
		public CV (){
			Esperienze= new List<EspLav>();
			Percorsostudi=new List<PerStud>();
			Competenze = new List<Competenza>();
		}
    }
    public class EspLav {
        public int Id{get;set;}
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Qualifica {get; set;}
        public string Descrizione {get; set;}
    }
    public class PerStud {
        public int Id{get;set;}
        public int AnnoInizio {get; set;}
        public int AnnoFine {get; set;}
        public string Titolo {get; set;}
        public string Descrizione {get; set;}
    }
    public class Competenza {
        public int Id{get;set;}
        public string Titolo {get; set;}
        public int Livello {get; set;}
    }

}