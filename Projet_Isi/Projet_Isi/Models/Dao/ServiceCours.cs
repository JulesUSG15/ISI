using System.Data;
using Projet_Isi.Models.Persistance;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;
using Projet_Isi.Models.Utilitaires;
using System;


namespace Projet_Isi.Models.Dao
{
    public class ServiceCours
    {
        public static DataTable GetTousLesCours()
        {
            DataTable Cours;
            Serreurs er = new Serreurs("Erreur sur lecture des Cours.", "Cours.getCours()");

            try
            {
                String mysql = "Select id_cours, nom, description, nom_prof, duree, date ";
                mysql += "from Cours ";

                Cours = DBInterface.Lecture(mysql, er);

                return Cours;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageUtilisateur(), e.Message);
            }

        }

        public static Cours GetunCours (String id)
        {
            DataTable dt;
            Cours unCours = null;
            Serreurs er = new Serreurs("Erreur sur lecture des Cours", "ServiceCours.GetunCours()");
            try
            {
                String mysql = "Select id_cours, nom, description, nom_prof, duree, date ";
                mysql += " from Cours ";
                mysql += " where id_cours = " + id;
                dt = DBInterface.Lecture(mysql, er);
                if (dt.IsInitialized && dt.Rows.Count > 0)
                {
                    unCours = new Cours();
                    DataRow dataRow = dt.Rows[0];
                    unCours.Id_cours = int.Parse(dataRow[0].ToString());
                    unCours.Nom = dataRow[1].ToString();
                    unCours.Description = dataRow[2].ToString();
                    unCours.Nom_prof = dataRow[3].ToString();
                    unCours.Duree = int.Parse(dataRow[4].ToString());
                    unCours.Date = DateTime.Parse(dataRow[5].ToString());
                    return unCours;
                }
                else
                    return null;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }

        public static void UpdateCours(Cours unC)
        {
            Serreurs er = new Serreurs("Erreur sur l'écriture d'un cours", "ServiceCours.UpateCours()");
            String requete = "UPDATE Cours SET" +
                ", nom = " + unC.Nom +
                ", description = " + unC.Description +
                ", nom_prof = " + unC.Nom_prof +
                ", duree = " + unC.Duree +
                ", date = " + FonctionsUtiles.DateToString(unC.Date) +
                " WHERE id_Cours =" + unC.Id_cours;

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }

        public static void SupprimerCours(int id)
        {
            Serreurs er = new Serreurs("Erreur lors de la suppression d'un cours", "ServiceCours.SupprimerCours()");
            String requete = "DELETE FROM Cours WHERE id_Cours = " + id;

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }

        public static void AjouterCours(Cours unC)
        {
            Serreurs er = new Serreurs("Erreur lors de l'ajout d'un cours", "ServiceCours.AjouterCours()");
            String requete = "INSERT INTO Cours (nom, description, nom_prof, duree, date) VALUES (" +
                "'" + unC.Nom + "', " +
                "'" + unC.Description + "', " +
                "'" + unC.Nom_prof + "', " +
                unC.Duree + ", " +
                "'" + FonctionsUtiles.DateToString(unC.Date) + "')";

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }

    }
}
