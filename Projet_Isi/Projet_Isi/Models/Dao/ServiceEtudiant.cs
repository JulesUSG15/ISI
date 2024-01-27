using System.Data;
using Projet_Isi.Models.Persistance;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;
using Projet_Isi.Models.Utilitaires;
using System;


namespace Projet_Isi.Models.Dao
{
    public class ServiceEtudiant
    {
        public static DataTable GetTousLesEtudiant()
        {
            DataTable Etudiant;
            Serreurs er = new Serreurs("Erreur sur lecture des Etudiants.", "Cours.getEtudiant()");

            try
            {
                String mysql = "Select id_etudiant, nom, prenom, email, date_inscription ";
                mysql += "from Etudiant ";

                Etudiant = DBInterface.Lecture(mysql, er);

                return Etudiant;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageUtilisateur(), e.Message);
            }

        }

    }

}