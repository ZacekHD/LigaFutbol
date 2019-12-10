using System;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Futbol2020.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.IO;

namespace Futbol2020.Controllers
{
    public class HomeController : Controller
    {
        //Prueba Coexion de Datos
        private IHostingEnvironment _hostingEnv;
        private readonly LigaModel _ligamodel;

        //---
        public HomeController(IHostingEnvironment hostingEnv)
        {
            _ligamodel = new LigaModel();
            _hostingEnv = hostingEnv;
        }
        //---------------------------------------------
        public IActionResult Index()
        {
            ViewBag.Slider = _ligamodel.ObtenerSliders();            
            IEnumerable<dynamic> res = _ligamodel.ObtenerNoticias();
            string Informador = _ligamodel.ObtenerInformador(); 
            //string cadena = Informador.ToString();
            //string result = Informador.Remove(Informador.Length - 1, 1);
            ViewBag.Noticias = Informador;
            return View(res);
           
            
            //Prueba Conecion Datos
            //IEnumerable<dynamic> res = _ligamodel.ObtenerGob2018();
            //--------------------------------------
            
        }

        #region Seccion de Lista de noticas y administras noticias
        public IActionResult Noticias()
        {
            IEnumerable<dynamic> res = _ligamodel.ObtenerNoticias();
            return View(res);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult ListaNoticias()
        {
            IEnumerable<dynamic> res = _ligamodel.ObtenerNoticias();
            return View(res);
        }


        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult CrearNoticia()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult CrearNoticia(NoticiasDataModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {

                var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
                //var targetDirectory = Path.Combine(_hostingEnv.ContentRootPath, string.Format("~/images/slider"));
                //Windows//var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images\\noticias\\"));
                var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images/noticias/"));
                var savePath = Path.Combine(targetDirectory, filename);
                ImageFile.CopyTo(new FileStream(savePath, FileMode.Create));

                NoticiasDataModel datos = new NoticiasDataModel
                {
                    Titulo = model.Titulo,
                    Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime()),
                    FotoUrl = filename,
                    TextoCorto = model.TextoCorto,
                    Texto = model.Texto,
                    Autor = model.Autor
                };
                _ligamodel.RegistrarNoticia(datos);
            }

           

            
            return RedirectToAction("ListaNoticias");
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult EditarNoticia(int Id)
        {
            NoticiasModel res = _ligamodel.ObtenerNoticia(Id);
            return View(res);

            
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult EditarNoticia(NoticiasModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {

                    //If System.IO.File.Exists(FileToCopy) = True Then
                    //System.IO.File.Copy(FileToCopy, NewCopy)
                    
                    var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
                    //var targetDirectory = Path.Combine(_hostingEnv.ContentRootPath, string.Format("~/images/slider"));
                    //Windows//var targetDirectory2 = Path.Combine(_hostingEnv.WebRootPath, string.Format("images\\noticias\\"));
                    var targetDirectory2 = Path.Combine(_hostingEnv.WebRootPath, string.Format("images/noticias/"));
                    var savePath = Path.Combine(targetDirectory2, filename);
                    ImageFile.CopyTo(new FileStream(savePath, FileMode.Create));

                    NoticiasEditDataModel datos = new NoticiasEditDataModel
                    {
                        Id = model.Id,
                        Titulo = model.Titulo,
                        Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime()),
                        FotoUrl = filename,
                        TextoCorto = model.TextoCorto,
                        Texto = model.Texto,
                        Autor = model.Autor
                    };
                    _ligamodel.EditarNoticia(datos);
                    
                }
                else
                {
                    NoticiasEditDataModel datos = new NoticiasEditDataModel
                    {
                        Id = model.Id,
                        Titulo = model.Titulo,
                        Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime()),
                        FotoUrl = model.FotoUrl,
                        TextoCorto = model.TextoCorto,
                        Texto = model.Texto,
                        Autor = model.Autor
                    };
                    _ligamodel.EditarNoticia(datos);

                }

            }

            return RedirectToAction("ListaNoticias");
        }

        
        [Authorize(Roles = "Administrador")]
        public IActionResult EliminarNoticia(int Id)
        {
            _ligamodel.EliminarNoticia(Id);
            return RedirectToAction("ListaNoticias");
        }

        public IActionResult VerNoticia(int Id)
        {
            NoticiasModel res = _ligamodel.ObtenerNoticia(Id);
            return View(res);
        }
        

        #endregion


        #region Secciones
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Teams()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
