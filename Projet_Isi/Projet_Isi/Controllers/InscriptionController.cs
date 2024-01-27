using Microsoft.AspNetCore.Mvc;
using Projet_Isi.Models.Dao;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;
using Projet_Isi.Models.Utilitaires;

namespace Projet_Isi.Controllers
{
    public class InscriptionController : Controller
    {
        // Action pour afficher le formulaire d'inscription
        public IActionResult Index()
        {
            return View();
        }

        // Action pour traiter le formulaire d'inscription (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inscrire(Utilisateur utilisateur)
        {
            try
            {
                // Validez les données de l'utilisateur ici (ex. : vérification du mot de passe, de l'e-mail, etc.)
                if (ModelState.IsValid)
                {
                    // Ajoutez ici la logique pour enregistrer l'utilisateur dans votre base de données
                    // Utilisez un service ou un gestionnaire pour gérer l'inscription
                    // Assurez-vous de stocker correctement le mot de passe en utilisant le sel et le hachage
                    ServiceUtilisateur serviceUtilisateur = new ServiceUtilisateur();

                    // Générez le sel pour le mot de passe
                    Byte[] selmdp = MonMotPassHash.GenerateSalt();
                    Byte[] mdpByte = MonMotPassHash.PasswordHashe(utilisateur.Mot_de_passe, selmdp);
                    utilisateur.Salt = MonMotPassHash.BytesToString(selmdp);
                    utilisateur.Mot_de_passe = MonMotPassHash.BytesToString(mdpByte);

                    // Définissez le rôle de l'utilisateur (par exemple, "utilisateur" ou "admin")
                    // utilisateur.Role = "utilisateur";

                    // Enregistrez l'utilisateur dans la base de données
                    serviceUtilisateur.InscrireUtilisateur(utilisateur);

                    // Redirigez l'utilisateur vers une page de connexion après l'inscription réussie
                    return RedirectToAction("Index", "Connexion");
                }

                // Rechargez la page d'inscription avec des erreurs de modèle si la validation échoue
                return View("Index", utilisateur);
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'inscription : " + e.Message);
                return View("Index", utilisateur); // Rechargez la page d'inscription avec des erreurs
            }
        }
    }
}
