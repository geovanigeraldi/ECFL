using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessObject;
using DataAccessObject.Model;

namespace BusinessLogics
{
    public class UsuarioBL
    {
        public bool ValidarLogin(string strLogin, string strSenha)
        {
            return new UsuarioDAO().ValidarLogin(strLogin, strSenha);
        }

        public USUARIO ObterUsuario(string strLogin)
        {
            return new UsuarioDAO().ObterUsuario(strLogin);
        }
    }
}
