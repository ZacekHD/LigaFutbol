using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Futbol2020.Models
{
    public class SliderModel
    {
        public int Id { get; set; }
        public string FotoUrl { get; set; }
        public string Clase { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Id_Titular { get; set; }
        public DateTime Fecha { get; set; }
        public int Activo { get; set; }
    }

    public class SliderDataModel
    {
        public string FotoUrl { get; set; }
        public string Clase { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Id_Titular { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class SliderEditModel
    {
        public int Id { get; set; }
        public string FotoUrl { get; set; }
        public string Clase { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Id_Titular { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class SliderViewModel
    {
        public int Id { get; set; }
        public string FotoUrl { get; set; }
    }

    public class SliderNoticiaModel
    {
        public int Id_Titulo { get; set; }
        public string Titulo_S { get; set; }
    }
}
