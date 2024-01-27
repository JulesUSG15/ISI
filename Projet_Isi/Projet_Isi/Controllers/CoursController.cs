using Microsoft.AspNetCore.Mvc;
using Projet_Isi.Models.Dao;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;

namespace Projet_Isi.Controllers
{
    public class CoursController : Controller
    {
        public IActionResult Index()
        {
            System.Data.DataTable Cours = null;
            try
            {
                Cours = ServiceCours.GetTousLesCours();
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des Cours:" + e.Message);
            }

            return View(Cours);
        }

        public IActionResult Modifier(int id)
        {
            Cours unCours = null;
            try
            {
                unCours = ServiceCours.GetunCours(id.ToString());
                return View(unCours);
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Modifier(Cours unCours)
        {
            try
            {
                ServiceCours.UpdateCours(unCours);
                return RedirectToAction("Index");
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }

        public IActionResult Supprimer(int id)
        {
            Cours unCours = null;
            try
            {
                unCours = ServiceCours.GetunCours(id.ToString());
                if (unCours == null)
                {
                    return NotFound();
                }
                return View(unCours);
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmerSuppression(int id)
        {
            try
            {
                ServiceCours.SupprimerCours(id);
                return RedirectToAction("Index");
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }

        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ajouter(Cours unCours)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceCours.AjouterCours(unCours);
                    return RedirectToAction("Index");
                }
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'ajout du Cours : " + e.Message);
            }

            return View(unCours);
        }


    }
}
