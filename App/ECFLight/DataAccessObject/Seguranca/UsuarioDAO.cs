using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using DataAccessObject.Model;

namespace DataAccessObject
{
    public class UsuarioDAO 
    {
        public bool ValidarLogin(string strLogin, string strSenha)
        {

            try
            {
                string sql = "select* from TB_USUARIO where ATIVO = 'S' and LOGIN = @login and SENHA = @pwd";

                List<FbParameter> lfb = new List<FbParameter>();
                lfb.Add(new FbParameter("@login", strLogin));
                lfb.Add(new FbParameter("@pwd", strSenha));

                FbDataReader fdDR = ECFLContext.GetDataReader(sql, lfb);

                return (fdDR.HasRows) ? true : false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public USUARIO ObterUsuario(string strLogin)
        {
            try
            {
                string sql = "select * from TB_USUARIO where ATIVO = 'S' and LOGIN = @login";

                List<FbParameter> lfb = new List<FbParameter>();
                lfb.Add(new FbParameter("@login", strLogin));
                FbDataReader fdDR = ECFLContext.GetDataReader(sql, lfb);

                USUARIO usu = new USUARIO();
                int ok = 0;
                while (fdDR.Read())
                {                    
                    usu._USUARIO_ID = fdDR.GetInt32(0);
                    usu._NOME = fdDR.GetString(1);
                    usu._LOGIN = fdDR.GetString(2);
                    ok++;
                }

                return usu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
