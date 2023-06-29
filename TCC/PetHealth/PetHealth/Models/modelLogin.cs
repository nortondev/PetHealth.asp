using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetHealth.Models
{
    public class modelLogin
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome:")]
        public string nomeUsuario { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [Display(Name = "Sobrenome:")]
        public string sobrenomeUsuario { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório")]
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        public string tipo { get; set; }
    }
}