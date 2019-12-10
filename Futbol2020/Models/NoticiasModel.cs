using System;
namespace Futbol2020.Models
{
    public class NoticiasModel
    {
        public int Id {get; set;}
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string TextoCorto { get; set; }
        public string Texto { get; set; }         
        public string FotoUrl { get; set; }
        public string Autor { get; set; }
    }

    public class NoticiasDataModel
    {
        
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string TextoCorto { get; set; }
        public string Texto { get; set; }
        public string FotoUrl { get; set; }
        public string Autor { get; set; }


    }

    public class NoticiasEditDataModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string TextoCorto { get; set; }
        public string Texto { get; set; }
        public string FotoUrl { get; set; }
        public string Autor { get; set; }


    }

    public class NotificadorModel
    {
        public string Noticias { get; set; }
    }
}

