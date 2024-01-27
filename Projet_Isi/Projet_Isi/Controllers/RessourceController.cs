using Microsoft.AspNetCore.Mvc;
using Projet_Isi.Models.Dao;
using Projet_Isi.Models.MesExceptions;

namespace Projet_Isi.Controllers
{
    public class RessourceController : Controller
    {
        public IActionResult Index()
        {
            System.Data.DataTable Ressource = null;

            try
            {
                Ressource = ServiceRessource.GetToutesRessources();

            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des Ressources:" + e.Message);
            }

            return View(Ressource);
        }
    }
}

