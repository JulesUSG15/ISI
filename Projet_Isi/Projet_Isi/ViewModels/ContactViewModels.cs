using System;
using System.ComponentModel.DataAnnotations;

namespace Projet_Isi.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L'e-mail est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le sujet est requis.")]
        public string Sujet { get; set; }

        [Required(ErrorMessage = "Le message est requis.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Le message doit avoir entre 10 et 500 caractères.")]
        public string Message { get; set; }
    }
}
