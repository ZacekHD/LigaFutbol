using Futbol2020.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Futbol2020.Data.Dao
{
    public class DAOInformacion : DapperRepositoryBase
    {
        public int Add(dynamic model, string tabla)
        {
            string sql = String.Format("{0}_Add", tabla);
            return this.Execute(sql, model, CommandType.StoredProcedure);
        }

        public int Update(dynamic model, string tabla)
        {
            string sql = String.Format("{0}_Edit", tabla);
            return this.Execute(sql, model, CommandType.StoredProcedure);
        }


        public int Delete(int id, string tabla)
        {
            string sql = String.Format("{0}_Del", tabla);
            return this.Execute(sql, new { Id = id }, CommandType.StoredProcedure);
        }


        public List<T> List<T>(string tabla)
        {
            string sql = String.Format("{0}_List", tabla);
            return this.Query<T>(sql, null, System.Data.CommandType.StoredProcedure);
        }

        public T Get<T>(string id, string tabla)
        {
            string sql = String.Format("{0}_Get", tabla);
            return this.QueryFirstOrDefault<T>(sql, new { Id = id }, System.Data.CommandType.StoredProcedure);
        }
        public T Get2<T>(int id, string tabla)
        {
            string sql = String.Format("{0}_Get", tabla);
            return this.QueryFirstOrDefault<T>(sql, new { Id = id }, System.Data.CommandType.StoredProcedure);
        }

        public T Get3<T>(string tabla)
        {
            string sql = String.Format("{0}_Get", tabla);
            return this.QueryFirstOrDefault<T>(sql, null, System.Data.CommandType.StoredProcedure);
        }
        //public dynamic Get2(int Id,string tabla)
        //{
        //    dynamic result;
        //    string sql = String.Format("{0}_Get", tabla);
        //    result = QueryFirstOrDefault<dynamic>(sql, null, CommandType.StoredProcedure);
        //    return result;
        //}

        //public List<T> GetVotos<T>()
        //{
        //    return Query<T>("Mapa_EleccionesGobernadorSecciones_List", null, System.Data.CommandType.StoredProcedure);
        //}

        public dynamic GetFirst(string tabla)
        {
            dynamic result;
            string sql = String.Format("{0}_Get", tabla);
            result = QueryFirstOrDefault<dynamic>(sql, null, CommandType.StoredProcedure);
            return result;
        }
    }
}
