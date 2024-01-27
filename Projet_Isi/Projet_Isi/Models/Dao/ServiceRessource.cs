using System.Data;
using Projet_Isi.Models.Persistance;
using Projet_Isi.Models.MesExceptions;

namespace Projet_Isi.Models.Dao
{
    public class ServiceRessource
    {
        public static DataTable GetToutesRessources()
        {
            DataTable Ressource;
            Serreurs er = new Serreurs("Erreur sur lecture des Ressources.", "Ressources.getRessources()");
            try
            {
                String mysql = "Select id_ressource, titre, description, lien, date_publication";
                mysql += "from Ressources";

                Ressource = DBInterface.Lecture(mysql, er);

                return Ressource;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageUtilisateur(), e.Message);
            }

        }
    }
}

