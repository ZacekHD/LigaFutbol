using System;
namespace Futbol2020.Models
{
    public class TorneoModel
    {
        public TorneoModel()
        {
        }
    }

    public class Usuarios
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string A_Paterno { get; set; }
        public string A_Materno { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }


    }


    //----------------------Prueba Acceso a Datos Model
    public class ResultadosVotosModel
    {
        public string Descripcion { get; set; }
        public string Año { get; set; }
        public string Distrito { get; set; }
        public string Municipio { get; set; }
        public int PAN { get; set; }
        public int PRI { get; set; }
        public int PRD { get; set; }
        public int PVEM { get; set; }
        public int PT { get; set; }
        public int PBC { get; set; }
        public int TRANS { get; set; }
        public int MC { get; set; }
        public int MORENA { get; set; }
        public int Mayor { get; set; }
        public string Ganador { get; set; }
        public int NoRegistrado { get; set; }
        public int VotoNulo { get; set; }
        public int TotalVotos { get; set; }
        public int DistritoNum { get; set; }

    }
    //-----------------------------------------------------
}
