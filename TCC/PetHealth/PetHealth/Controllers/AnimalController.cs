using PetHealth.Dados;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealth.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        acoesAnimal acAnimal = new acoesAnimal();
        modelAnimal modAnimal = new modelAnimal();
        public ActionResult Animal()
        {
            return View(acAnimal.selecionaAnimal());
        }

        public ActionResult ListarAnimal()
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
                return View(acAnimal.selecionaAnimal());
            }
        }
        public ActionResult CadastrarAnimal()
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
        public ActionResult CadastrarAnimal(modelAnimal md, HttpPostedFileBase file)
        {
            //imagem
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);

            //Salvar no banco
            md.fotoAnimal = file2;
            acAnimal.inserirAnimal(md);
            ViewBag.msg = "Cadastro realizado";
            return View();
        }

        //public ActionResult editarTipo(int id)
        //{
        //    if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        if (Session["tipoLogado2"] == null)
        //        {
        //            return RedirectToAction("semAcesso", "Home");
        //        }
        //        return View(acTipoAcoes.BuscarTipo().Find(modTipo => modTipo.codTipo == id));
        //    }
        //}
        //[HttpPost]
        //public ActionResult editarTipo(clTipo cl)
        //{
        //    if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        if (Session["tipoLogado2"] == null)
        //        {
        //            return RedirectToAction("semAcesso", "Home");
        //        }
        //        acTipoAcoes.atualizarTipo(cl);
        //        return RedirectToAction(nameof(ListarTipo));
        //    }
        //}

        //public ActionResult excluirTipo(int id)
        //{
        //    if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        if (Session["tipoLogado2"] == null)
        //        {
        //            return RedirectToAction("semAcesso", "Home");
        //        }
        //        acTipoAcoes.DeleteTipo(id);
        //        return RedirectToAction(nameof(ListarTipo));
        //    }
        //}
    }
}