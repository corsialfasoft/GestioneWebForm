using System.Collections.Generic;

namespace GestioneWebForm
{
    public class Lezione
    {
        private int _idLezione;
        private string _nome;
        private string _descrizione;
        private int _durata;
        private List<Studente> _presenti = new List<Studente>();

        public int IdLezione => _idLezione;
        public string Nome => _nome;
        public string Descrizione {
            get => _descrizione;
            set => this._descrizione = value;
        }
        public int Durata {
            get => _durata;
            set => this._durata = value;
        }
        public List<Studente> Presenti => _presenti;

        public Lezione(int id, string nome)
        {
            this._idLezione = id;
            this._nome = nome;
        }
        public Lezione(int id, string nome, string descrizione)
        {
            this._idLezione = id;
            this._nome = nome;
            this._descrizione = descrizione;
        }
        public Lezione(string nome, string descrizione, int durata)
        {
            this._nome = nome;
            this._descrizione = descrizione;
            this._durata = durata;
        }

        public void AddPresenza(Studente s) => this._presenti.Add(s);

        public bool ControllaPresenza(Studente s)
        {
            foreach (Studente st in this._presenti)
            {
                if (st.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
}