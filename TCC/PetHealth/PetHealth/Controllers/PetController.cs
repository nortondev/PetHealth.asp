using MySql.Data.MySqlClient;
using PetHealth.Dados;
using PetHealth.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHealth.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        acoesPet acPet = new acoesPet();
        modelPet modPet = new modelPet();


        public void carregaAnimal()
        {
            List<SelectListItem> animais = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;port=3306; DataBase=db_pethealth; user id=root;password=1559"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbAnimal", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    animais.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.animais = new SelectList(animais, "Value", "Text");
        }

        public void carregaSexo()
        {
            List<SelectListItem> sexos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;port=3306; DataBase=db_pethealth; user id=root;password=1559"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbSexo", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    sexos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.sexos = new SelectList(sexos, "Value", "Text");
        }

        public void carregaPlanos()
        {
            List<SelectListItem> planos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;port=3306; DataBase=db_pethealth; user id=root;password=1559"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbPlano", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    planos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.planos = new SelectList(planos, "Value", "Text");
        }
        public ActionResult Pet()
        {
            return View(acPet.selecionaPet());
        }

        public ActionResult ListarPet()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(acPet.selecionaPet());
            }
        }

        public ActionResult ListarPetAdm()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View(acPet.selecionaPet());
            }
        }
        public ActionResult CadastrarPet()
        {
            if (Session["usuarioLogado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {

                if (Session["usuarioLogado1"] != null)
                {
                    ViewBag.tipo = Session["usuarioLogado1"];
                }
                else
                {
                    ViewBag.tipo = Session["usuarioLogado0"];
                }
                carregaAnimal();
                carregaSexo();
                carregaPlanos();
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult CadastrarPet(modelPet pet)
        //{
        //    carregaAnimal();
        //    //pet.Animal = Request["animais"];
        //    pet.idAnimal = Request["animais"];
        //    carregaSexo();
        //    //pet.Sexo = Request["sexos"];
        //    pet.idSexo = Request["sexos"];
        //    carregaPlanos();
        //    //pet.nomePlano = Request["planos"];
        //    pet.idPlano = Request["planos"];
        //    acPet.inserirPet(pet);
        //    ViewBag.Message = "Cadastro Realizado com sucesso";
        //    return RedirectToAction(nameof(ListarPet));

        //}

        [HttpPost]
        public ActionResult CadastrarPet(modelPet md, HttpPostedFileBase file)
        {
            //imagem
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/assets/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/assets"), arquivo);
            file.SaveAs(_path);

            //Salvar no banco
            carregaAnimal();
            //pet.Animal = Request["animais"];
            md.idAnimal = Request["animais"];
            carregaSexo();
            //pet.Sexo = Request["sexos"];
            md.idSexo = Request["sexos"];
            carregaPlanos();
            //pet.nomePlano = Request["planos"];
            md.idPlano = Request["planos"];
            md.fotoPet = file2;
            acPet.inserirPet(md);
            return RedirectToAction(nameof(ListarPet));
        }

        public ActionResult excluirPet(int id)
        {
                acPet.DeletePet(id);
                return RedirectToAction(nameof(ListarPet));
        }

        //Editar Raca
        public ActionResult editarPet()

        {
            carregaAnimal();
            carregaSexo();
            carregaPlanos();
            return View();
        }

        [HttpPost]

        public ActionResult editarPet(modelPet pte)
        {
                carregaAnimal();
                pte.Animal = Request["animais"];
                carregaSexo();
                pte.idSexo = Request["sexos"];
                carregaPlanos();
                pte.idPlano = Request["planos"];
                acPet.atualizarPet(pte);

                return RedirectToAction(nameof(ListarPet));
        }

        //public ActionResult excluirAnimal(int id)
        //{
        //    if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        if (Session["tipologado2"] == null)
        //        {
        //            return RedirectToAction("semAcesso", "Home");
        //        }
        //        acAnimalAcoes.DeleteAnimal(id);
        //        return RedirectToAction(nameof(ListarAnimal));
        //    }
        //}


    }
}