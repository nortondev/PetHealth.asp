using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealth.Models
{
    public class modelCliente
    {
        [Display(Name = "Código Cliente")]
        public int idCliente { get; set; }
        [Display(Name = "Nome:")]
        public string nomeCliente { get; set; }
        [Display(Name = "Sobrenome:")]
        public string sobrenomeCliente { get; set; }
        [Display(Name = "Email:")]
        public string emailCliente { get; set; }
        [Display(Name = "Telefone:")]
        public string telefoneCliente { get; set; }

        public string idPet { get; set; }
    }
}