using PetHealth.Dados;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PetHealth.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        acoesPagamento acPagamento = new acoesPagamento();
        modelPagamento modPagamento = new modelPagamento();
        
        public ActionResult CadastroPagamento()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult CadastroPagamento(modelPagamento pagamento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        acPagamento.inserirPagamento(pagamento);
        //        ViewBag.Message = "Cadastro realizado com sucesso.";
        //    }
        //    return RedirectToAction(nameof(/*MeusPets*/));
        //}
    }
}