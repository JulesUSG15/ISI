using System;
namespace Projet_Isi.Models.Metier
{
    public class Etudiant
    {
        private int id_etudiant;
        private string nom;
        private string prenom;
        private string mail;
        private DateTime date_inscription;

        public int Id_etudiant { get => id_etudiant; set => id_etudiant = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Mail { get => mail; set => mail = value; }
        public DateTime Date_inscription { get => date_inscription; set => date_inscription = value; }

    }
}
