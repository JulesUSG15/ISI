namespace Projet_Isi.Models.Metier
{
    public class Cours
    {
        private int id_cours;
        private string nom;
        private string description;
        private string nom_prof;
        private int duree;
        private DateTime date;

        public int Id_cours { get => id_cours; set => id_cours = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Description { get => description; set => description = value; }
        public string Nom_prof { get => nom_prof; set => nom_prof = value; }
        public int Duree { get => duree; set => duree = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}

