using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Futbol2020.Data.Helpers
{
    public class DapperFuntions
    {

        public static T Query<T>(Func<IDbConnection, T> func)
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


        public static async Task<T> QueryAsync<T>(Func<IDbConnection, Task<T>> func)
        {
            IDbConnection cnn = null;              //new SqlConnection("Data Source = 192.168.100.91; Initial Catalog = Transparencia; Persist Security Info = true; User Id = sa; Password = @ppsDB15;");
            T result = default(T);
            try
            {
                cnn = new DBConnection().Open();

                result = await func(cnn);
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

        public static async Task<T> QueryAsync2<T>(Func<IDbConnection, Task<T>> func)
        {
            IDbConnection cnn = null;              //new SqlConnection("Data Source = 192.168.100.91; Initial Catalog = Transparencia; Persist Security Info = true; User Id = sa; Password = @ppsDB15;");
            T result = default(T);
            try
            {
                cnn = new DBConnection(2).Open();

                result = await func(cnn);
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

    }
}
