using PetHealth.Dados;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealth.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        acoesLogin acLogin = new acoesLogin();
        modelLogin modLogin = new modelLogin();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(modelLogin verLogin)
        {
            acLogin.TestarUsuario(verLogin);
            if (verLogin.Usuario != null && verLogin.Senha != null)
            {
                Session["usuarioLogado"] = verLogin.Usuario.ToString();
                Session["senhaLogado"] = verLogin.Senha.ToString();

                if (verLogin.tipo == "0")
                {
                    Session["tipoLogado0"] = verLogin.tipo.ToString();
                    return RedirectToAction("usuarioAdmin", "Login");
                }
                else
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString();
                    return RedirectToAction("usuarioComum", "Login");
                }
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }

        }
        public ActionResult CadastroLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroLogin(modelLogin login)
        {
            if (ModelState.IsValid)
            {
                acLogin.CadastrarUsuario(login);
                ViewBag.Message = "Cadastro realizado com sucesso.";
            }
            return RedirectToAction(nameof(Login));
        }

        public ActionResult usuarioAdmin()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Nome = Session["usuarioLogado"];

                if (Session["usuarioLogado0"] != null)
                {
                    ViewBag.tipo = Session["usuarioLogado0"];
                }
                else
                {
                    ViewBag.tipo = Session["usuarioLogado1"];
                }
                return View();
            }
        }

        public ActionResult usuarioComum()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Nome = Session["usuarioLogado"];

                if (Session["usuarioLogado0"] != null)
                {
                    ViewBag.tipo = Session["usuarioLogado0"];
                }
                else
                {
                    ViewBag.tipo = Session["usuarioLogado1"];
                }
                return View();
            }
        }
    }
}