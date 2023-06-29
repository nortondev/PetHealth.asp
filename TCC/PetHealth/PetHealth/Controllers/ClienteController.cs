using PetHealth.Dados;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PetHealth.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        acoesCliente acCliente = new acoesCliente();
        modelCliente modCliente = new modelCliente();
        //public ActionResult Cliente()
        //{
        //    return View(acCliente.selecionaCliente());
        //}

        public ActionResult ListarCliente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoLogado0"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                return View(acCliente.selecionaCliente());
            }
        }
        public ActionResult CadastrarCliente()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                if (Session["tipoLogado0"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                else
                {
                    ViewBag.Nome = Session["usuarioLogado"];

                    if (Session["usuarioLogado1"] != null)
                    {
                        ViewBag.tipo = Session["usuarioLogado1"];
                    }
                    else
                    {
                        ViewBag.tipo = Session["usuarioLogado0"];
                    }
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult CadastrarCliente(modelCliente cliente)
        {
            if (ModelState.IsValid)
            {
                acCliente.inserirCliente(cliente);
            }
            return RedirectToAction("CadastroPagamento", "Pagamento");
        }
        public ActionResult excluirCliente(int id)
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (Session["tipoLogado0"] == null)
                {
                    return RedirectToAction("semAcesso", "Home");
                }
                acCliente.DeleteCliente(id);
                return RedirectToAction(nameof(ListarCliente));
            }
        }
    }
}