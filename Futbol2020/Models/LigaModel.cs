using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futbol2020.Data.Dao;

namespace Futbol2020.Models
{
    public class LigaModel
    {

        private readonly DAOInformacion infoSQL;

        public LigaModel()
        {
            infoSQL = new DAOInformacion();
        }

        //public List<SeccionVotoViewModel> ObtenerVotosSecciones()
        //{
        //    return infoSQL.GetVotos<SeccionVotoViewModel>().ToList();
        //}

        //public List<SeccionNoGanadaViewModel> ObtenerSeccionNoGanadas()
        //{
        //    return infoSQL.List<SeccionNoGanadaViewModel>("SeccionesNoMorena");
        //}

        //public List<ColoniaSeccionViewModel> ObtenerColonias()
        //{
        //    return infoSQL.List<ColoniaSeccionViewModel>("ColoniasXSeccion");
        //}



        //Prueba Conexion
        //public List<ResultadosVotosModel> ObtenerGob2018()
        //{
        //return infoSQL.List<ResultadosVotosModel>("ResGob2018xSeccion");
        //}

        //Usuarios ------------------------------------------
        public List<Usuarios> ObtenerUsuarios()
        {
            return infoSQL.List<Usuarios>("Usuario");
        }

        //Informador -----------------------------------------
        public string ObtenerInformador()
        {
            return infoSQL.Get3<string>("Notificador");
        }

        //Noticias -------------------------------------------
        public List<NoticiasModel> ObtenerNoticias()
        {
            return infoSQL.List<NoticiasModel>("Noticias");
        }

        public List<SliderNoticiaModel> ObtenerNoticiasSlider()
        {
            return infoSQL.List<SliderNoticiaModel>("Slider_Noticias");
        }

        public NoticiasModel ObtenerNoticia(int Id)
        {
            return infoSQL.Get2<NoticiasModel>(Id, "Noticias");

        }
        public int RegistrarNoticia(NoticiasDataModel model)
        {
            return infoSQL.Add(model, "Noticias");
        }

        public int EditarNoticia(NoticiasEditDataModel model)
        {
            return infoSQL.Update(model, "Noticias");
        }

        public int EliminarNoticia(int Id)
        {
            return infoSQL.Delete(Id, "Noticias");
        }
        //--------------------------------------------

        //Administracion -----------------------------
        //Slider -------------------------------------

        public int RegistrarSlider(SliderDataModel model)
        {
            return infoSQL.Add(model, "Slider");
        }

        public List<SliderModel> ObtenerSliders()
        {
            return infoSQL.List<SliderModel>("Slider");
        }

        public SliderModel ObtenerSlider(int Id)
        {
            return infoSQL.Get2<SliderModel>(Id, "Slider");
        }

        public int EditarSlider(SliderEditModel model)
        {
            return infoSQL.Update(model, "Slider");
        }

        public int EditarImagenSlider(SliderViewModel model)
        {
            return infoSQL.Update(model, "Img_Slider");
        }

        public int EliminarSlider(int Id)
        {
            return infoSQL.Delete(Id, "Slider");
        }
        //--------------------------------------------






    }
}
