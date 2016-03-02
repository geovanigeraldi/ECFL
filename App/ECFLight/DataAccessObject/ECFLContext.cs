using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;

namespace DataAccessObject
{
    class ECFLContext
    {
        private static readonly ECFLContext _fbConnection = new ECFLContext();

        private ECFLContext() { }

        //public static ECFLContext getInstancia()
        //{
        //    return _fbConnection;
        //}

        public static FbConnection GetConexao()
        {
            return new FbConnection(GetSC());
        }

        private static string GetSC()
        {
            string u = "SYSDBA";
            string p = "ECFLROOT";
            string pa = @"C:\Desenvolvimento\Pessoal\ECFLight_Projeto\App\ECFLight\Data\ECFL.FDB";

            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("Database={0}; User={1}; Password={2};Dialect=3", pa, u, p));

            return sb.ToString();
        }

        public static FbDataReader GetDataReader(string sql, List<FbParameter> parametros)
        {
            FbConnection fbConn = ECFLContext.GetConexao();
            try
            {                
                FbDataAdapter fbDa = new FbDataAdapter();
                fbDa.SelectCommand = new FbCommand(sql, fbConn);
                fbConn.Open();
                int i = 0;
                foreach (FbParameter param in parametros)
                {
                    fbDa.SelectCommand.Parameters.Add(param.ParameterName, param.Value.GetType());
                    fbDa.SelectCommand.Parameters[i].Value = param.Value;
                    i++;
                }
                FbDataReader fbR = fbDa.SelectCommand.ExecuteReader();

                return fbR;
            }
            catch
            {
                return null;
            }
            finally
            {
                //fbConn.Close();
            }
        }

    }
}
