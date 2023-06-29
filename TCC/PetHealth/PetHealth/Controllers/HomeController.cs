using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Planos()
        {
            return View();
        }


        public ActionResult Sobre()
        {
            return View();
        }


        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            Session["Senha"] = null;
            Session["tipoLogado1"] = null;
            Session["tipologado0"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}