using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace certificacaoaspnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TesteResults()
        {
            var col = new List<Client>();
            Client cli = new Client() { Id = 1, Name = "Zezinho" };
            col.Add(cli);
            //return View(); retorna ViewResult
            //return PartialView(); retorna ParatialViewResult
            //return Content("Eu nao acredito"); retorna ContentResult
            //return Redirect("/"); retorna RedirectResult
            //return RedirectToAction("contact"); retorna RedirectToRouteResult
            //return RedirectToAction("contact","home");
            //return RedirectToAction("contact", "home", new {page=1, sortBy="name"});
            //return Json(col, JsonRequestBehavior.AllowGet); retorna JsonResult
            //byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\walte\source\repos\certificacaoaspnet\certificacaoaspnet\favicon.ico");
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Image.Jpeg); retorna FileResult
            //return HttpNotFound("deu ruim"); retorna HttpNotFoundResult
            //return new EmptyResult(); retorna EmptyResult - não gera nenhum tipo de erro
            return new EmptyResult();
        }
        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }
    }
}