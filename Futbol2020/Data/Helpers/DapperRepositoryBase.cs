using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Futbol2020.Data.Helpers
{
    public class DapperRepositoryBase
    {

        protected T QueryFirstOrDefault<T>(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            var result = default(T);
            try
            {
                cnn = new DBConnection().Open();
                result = cnn.QueryFirstOrDefault<T>(sql, parameters, null, null, cmd);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            var result = default(T);
            try
            {
                cnn = await new DBConnection().OpenAsync();
                result = await cnn.QueryFirstOrDefaultAsync<T>(sql, parameters, null, null, cmd).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }

        protected List<T> Query<T>(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            var result = default(List<T>);
            try
            {
                cnn = new DBConnection().Open();
                result = cnn.Query<T>(sql, parameters, null, true, null, cmd).ToList();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            var result = default(List<T>);
            try
            {
                cnn = await new DBConnection().OpenAsync();
                result = (List<T>)await cnn.QueryAsync<T>(sql, parameters, null, null, cmd).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }

        protected int Execute(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            int result = 0;
            try
            {
                cnn = new DBConnection().Open();
                result = Convert.ToInt32(cnn.ExecuteScalar(sql, parameters, null, null, cmd));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }
        protected async Task<int> ExecuteAsync(string sql, object parameters = null, CommandType cmd = CommandType.Text)
        {
            IDbConnection cnn = null;
            int result = 0;
            try
            {
                cnn = await new DBConnection().OpenAsync();
                result = await cnn.ExecuteAsync(sql, parameters, null, null, cmd).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CloseConnection(cnn);
            }
            return result;
        }

        public static T Query2<T>(Func<IDbConnection, T> func)
        {
            IDbConnection cnn = null;              //new SqlConnection("Data Source = 192.168.100.91; Initial Catalog = Transparencia; Persist Security Info = true; User Id = sa; Password = @ppsDB15;");
            T result = default(T);
            try
            {
                cnn = new DBConnection().Open();

                result = func(cnn);
            }
            catch (Exception ex)
            {
                string cs = cnn != null ? cnn.ConnectionString : "Sin CS";
                string state = cnn != null ? cnn.State.ToString() : "Sin Estado";

                //Hay que agregar el logger aqui
                //throw new Exception(String.Format("{0}/////Connection String : {1} : Estado :{2}======",ex.Message, cs, state) , ex);
                result = default(T);// System.Activator.CreateInstance<T>(); //this is working in .NET 4.5 environment
                return result;
            }
            finally
            {
                if (cnn != null)
                    cnn.Close();
            }
            return result;
        }

        protected bool CloseConnection(IDbConnection cnn)
        {
            if (cnn != null)
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                    return true;
                }
            }
            return false;
        }

    }
}
