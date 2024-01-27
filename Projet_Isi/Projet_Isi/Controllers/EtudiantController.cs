using Microsoft.AspNetCore.Mvc;
using Projet_Isi.Models.Dao;
using Projet_Isi.Models.MesExceptions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet_Isi.Controllers
{
    public class EtudiantController : Controller
    {
        public IActionResult Index()
        {
            System.Data.DataTable Etudiant = null;
            try
            {
                Etudiant = ServiceEtudiant.GetTousLesEtudiant();
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des Cours:" + e.Message);
            }

            return View(Etudiant);
        }
    }
}

