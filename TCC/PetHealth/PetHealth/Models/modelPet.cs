using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace PetHealth.Models
{
    public class modelPet
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Código do Pet")]
        public int idPet { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome:")]
        public string nomePet { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Animal:")]
        public string idAnimal { get; set; }
        public string Animal { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Sexo:")]
        public string idSexo { get; set; }
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Raça:")]
        public string racaPet { get; set; }

        [Required(ErrorMessage = "A idade é obrigatório")]
        [Display(Name = "Idade:")]
        public int idadePet { get; set; }
        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Peso:")]
        public int pesoPet { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Foto")]
        public string fotoPet { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Plano:")]
        public string idPlano { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Plano:")]
        public string nomePlano { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Cliente:")]
        public string idCliente { get; set; }

        [Required(ErrorMessage = "O peso é obrigatório")]
        [Display(Name = "Cliente:")]
        public string nomeCliente { get; set; }
    }
}