using System;
namespace Projet_Isi.Models.Metier
{
    public class Utilisateur
    {
        private int id_utilisateur;
        private String nom_utilisateur;
        private String mot_de_passe;
        private String salt;
        private String role;

        public int Id_utilisateur { get => id_utilisateur; set => id_utilisateur = value; }
        public string Nom_utilisateur { get => nom_utilisateur; set => nom_utilisateur = value; }
        public string Mot_de_passe { get => mot_de_passe; set => mot_de_passe = value; }
        public string Role { get => role; set => role = value; }
        public string Salt { get => salt; set => salt = value; }

        public Utilisateur(int num, String nom, String MP, String role)
        {
            this.id_utilisateur = num;
            this.nom_utilisateur = nom;
            this.mot_de_passe = MP;
            this.role = role;
        }

        public Utilisateur()
        { }
    }
}

