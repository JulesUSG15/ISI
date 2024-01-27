using System.Data;
using Projet_Isi.Models.Persistance;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;
using Projet_Isi.Models.Utilitaires;

namespace Projet_Isi.Models.Dao
{
    public class ServiceUtilisateur
    {
        public Utilisateur GetUtilisateur(String nom)
        {
            DataTable dt;
            Utilisateur unUti = null;
            String mysql = "SELECT id_utilisateur, nom_utilisateur, mot_de_passe, salt, role " +
                " where nom_utilisateur = " + "'" + nom + "'";
            Serreurs er = new Serreurs("Erreur sur recherche d'un utilisateur", "ServiceUtilisateur.getUtilisateur()");
            try
            {
                dt = DBInterface.Lecture(mysql, er);
                if (dt.IsInitialized && dt.Rows.Count > 0)
                {
                    unUti = new Utilisateur();
                    DataRow dataRow = dt.Rows[0];
                    unUti.Id_utilisateur = Int16.Parse(dataRow[0].ToString());
                    unUti.Nom_utilisateur = dataRow[1].ToString();
                    unUti.Mot_de_passe = dataRow[2].ToString();
                    unUti.Salt = dataRow[3].ToString();
                    unUti.Role = dataRow[4].ToString();
                    return unUti;
                }
                else
                {
                    return null;
                }
            }
            catch (MonException e)
            {
                throw e;
            }
            catch (Exception exc)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), exc.Message);
            }
        }

        public void InscrireUtilisateur(Utilisateur utilisateur)
        {
            Serreurs er = new Serreurs("Erreur lors de l'inscription d'un utilisateur", "ServiceUtilisateur.InscrireUtilisateur()");

            try
            {
                string insertQuery = "INSERT INTO Utilisateurs (nom_utilisateur, mot_de_passe, salt, role) " +
                                     "VALUES ('" + utilisateur.Nom_utilisateur + "', '" + utilisateur.Mot_de_passe + "', '" + utilisateur.Salt + "', '" + utilisateur.Role + "')";

                DBInterface.Execute_Transaction(insertQuery);
            }
            catch (MonException e)
            {
                throw e;
            }
            catch (Exception exc)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), exc.Message);
            }
        }

    }
}

