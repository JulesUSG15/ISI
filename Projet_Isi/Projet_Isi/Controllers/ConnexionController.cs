using Microsoft.AspNetCore.Mvc;
using Projet_Isi.Models.Dao;
using Projet_Isi.Models.MesExceptions;
using Projet_Isi.Models.Metier;
using Projet_Isi.Models.Utilitaires;

namespace Projet_Isi.Controllers
{
    public class ConnexionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Controle()
        {
            try
            {
                string login = Request.Form["login"];
                string mdp = Request.Form["pwd"];

                ServiceUtilisateur serviceUtilisateur = new ServiceUtilisateur();
                Utilisateur utilisateur = serviceUtilisateur.GetUtilisateur(login);

                if (utilisateur != null)
                {
                    Byte[] selmdp = MonMotPassHash.GenerateSalt();
                    Byte[] mdpByte = MonMotPassHash.PasswordHashe(mdp, selmdp);
                    string mdpS = MonMotPassHash.BytesToString(mdpByte);
                    string saltS = MonMotPassHash.BytesToString(selmdp);
                    string sel = utilisateur.Salt;

                    Byte[] salt = MonMotPassHash.transformeEnBytes(sel);
                    Byte[] tempo = MonMotPassHash.transformeEnBytes(utilisateur.Mot_de_passe);

                    if (!MonMotPassHash.VerifyPassword(salt, mdp, tempo))
                    {
                        ModelState.AddModelError("Erreur", "Erreur lors du contrôle du mot de passe pour : " + login);
                        return RedirectToAction("Index", "Connexion");
                    }
                }
                else
                {
                    ModelState.AddModelError("Erreur", "Erreur login erroné : " + login);
                    return RedirectToAction("Index", "Connexion");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'authentification : " + e.Message);
                return RedirectToAction("Index", "Connexion");
            }
        }
    }
}
