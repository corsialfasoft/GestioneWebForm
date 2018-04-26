namespace GestioneWebForm
{
    public class Studente
    {
        private string _matricola;
        private string _nome;
        private string _cognome;

        public string Matricola => _matricola;
        public string Nome => _nome;
        public string Cognome => _cognome;

        public Studente(string matricola) => this._matricola = matricola;

        public Studente(string matricola, string nome, string cognome)
        {
            this._matricola = matricola;
            this._nome = nome;
            this._cognome = cognome;
        }

        public override string ToString() => $"{this._matricola},{this._nome},{this._cognome}";

        public bool Equals(Studente s)
        {
            if (this._matricola == s.Matricola && this._nome == s.Nome && this._cognome == s.Cognome)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}