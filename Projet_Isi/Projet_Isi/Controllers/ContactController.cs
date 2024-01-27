using Microsoft.AspNetCore.Mvc;
using Projet_Isi.ViewModels;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        var model = new ContactViewModel(); // Initialisez le modèle ici
        return View(model);
    }


    [HttpPost]
    public IActionResult Index(ContactViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Traitez le formulaire de contact ici (envoyez un e-mail, enregistrez-le en base de données, etc.)

            // Redirigez l'utilisateur vers une page de confirmation ou une autre action
            return RedirectToAction("Confirmation");
        }

        // Si le modèle n'est pas valide, réaffichez le formulaire avec les erreurs
        return View(model);
    }

    public IActionResult Confirmation()
    {
        return View();
    }
}
