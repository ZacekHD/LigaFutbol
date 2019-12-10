using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Futbol2020.Data.Helpers;
using Microsoft.AspNetCore.Authorization;
using Futbol2020.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Futbol2020.Controllers
{
    
    //[Authorize]
    [Authorize(Roles = "Administrador")]
    public class AdministradorController : Controller
    {
        private IHostingEnvironment _hostingEnv;
        private readonly LigaModel _ligamodel;
       
        public AdministradorController(IHostingEnvironment hostingEnv)
        {
            _ligamodel = new LigaModel();
            _hostingEnv = hostingEnv;

        }
        // GET: /<controller>/


        public IActionResult Index()
        {
            string userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //Convert.ToDateTime(Helpers.Helpers.GetValidDateTime());
            return View();
        }

        public IActionResult CrearSlider()
        {
            List<SliderNoticiaModel> res = _ligamodel.ObtenerNoticiasSlider();
            ViewBag.Noticias = res;

            return View();
        }

        public IActionResult ListaSlider()
        {
            IEnumerable<dynamic> res = _ligamodel.ObtenerSliders();
            return View(res);           
        }

        [HttpPost]
        public IActionResult CrearSlider(SliderModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                
                var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
                //var targetDirectory = Path.Combine(_hostingEnv.ContentRootPath, string.Format("~/images/slider"));
                var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images\\slider\\"));
                //MAC//var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images/slider/"));
                var savePath = Path.Combine(targetDirectory, filename);
                ImageFile.CopyTo(new FileStream(savePath, FileMode.Create));

                SliderDataModel datos = new SliderDataModel
                {
                    FotoUrl = filename,
                    Clase = model.Clase,
                    Titulo = model.Titulo,
                    Descripcion = model.Descripcion,
                    Id_Titular = model.Id_Titular,
                    Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime()),
                };
                _ligamodel.RegistrarSlider(datos);
            }
            return RedirectToAction("ListaSlider");

        }

        public IActionResult EditarSlider(int Id)
        {
            List<SliderNoticiaModel> res2 = _ligamodel.ObtenerNoticiasSlider();
            ViewBag.Noticias = res2;
            SliderModel res = _ligamodel.ObtenerSlider(Id);
            return View(res);
        }

        [HttpPost]
        public IActionResult EditarSlider(SliderModel model, IFormFile ImageFile)
        {
            
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    var filename = ContentDispositionHeaderValue.Parse(ImageFile.ContentDisposition).FileName.Trim('"');
                    //var targetDirectory = Path.Combine(_hostingEnv.ContentRootPath, string.Format("~/images/slider"));
                    var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images\\slider\\"));
                    //MAC//var targetDirectory = Path.Combine(_hostingEnv.WebRootPath, string.Format("images/slider/"));
                    var savePath = Path.Combine(targetDirectory, filename);
                    ImageFile.CopyTo(new FileStream(savePath, FileMode.Create));
                                 

                    SliderEditModel datos = new SliderEditModel
                    {
                        Id = model.Id,
                        FotoUrl = filename,
                        Clase = model.Clase,
                        Titulo = model.Titulo,
                        Descripcion = model.Descripcion,

                        Id_Titular = model.Id_Titular,
                        Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime())

                    };
                    _ligamodel.EditarSlider(datos);
                    
                }
                else
                {
                   
                    SliderEditModel datos = new SliderEditModel
                    {
                        Id = model.Id,
                        FotoUrl = model.FotoUrl,
                        Clase = model.Clase,
                        Titulo = model.Titulo,
                        Descripcion = model.Descripcion,
                        Id_Titular = model.Id_Titular,
                        Fecha = Convert.ToDateTime(Helpers.Helpers.GetValidDateTime())

                    };
                    _ligamodel.EditarSlider(datos);

                }

            }
            return RedirectToAction("ListaSlider");
        }       
              
        public IActionResult EliminarSlider(int Id)
        {
            _ligamodel.EliminarSlider(Id);
            return RedirectToAction("ListaSlider");
        }


        //[HttpPost]
        //public IActionResult EditarImagenSlider(SliderModel model, IFormFile ImageFile)
        //{
        //    return View();
        //}


    }
}
