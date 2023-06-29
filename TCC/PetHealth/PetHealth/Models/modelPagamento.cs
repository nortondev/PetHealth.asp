using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetHealth.Models
{
    public class modelPagamento
    {
        public int idPagamento { get; set; }
        public string numeroCartao { get; set; }
        public string nomeCartao { get; set; }
    }
}