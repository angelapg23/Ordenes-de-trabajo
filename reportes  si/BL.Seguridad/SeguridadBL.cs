using BL.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL.Seguridad

{


    public class SeguridadBL
    {

        Contexto _contexto;


        public SeguridadBL()
        {
            _contexto = new Contexto();
           
        }

        public Usuario Autorizar(string nombreUsuario, string contrasena)
        {
            var usuarios = _contexto.Usuarios.ToList();

            foreach (var usuarioDB in usuarios)
            {
                if (nombreUsuario == usuarioDB.Nombre && contrasena == usuarioDB.Contrasena)
                {
                    return usuarioDB;
                }
            }

            return null;


        }

    }
    }
    
