using System;
namespace Projet_Isi.Models.Metier
{
    public class Ressource
    {
        private int id_ressource;
        private string titre;
        private string description;
        private string lien;
        private DateTime date_publication;

        public int Id_ressource { get => id_ressource; set => id_ressource = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public string Lien { get => lien; set => lien = value; }
        public DateTime Date_publication { get => date_publication; set => date_publication = value; }
    }
}


