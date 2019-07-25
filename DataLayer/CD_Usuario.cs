using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CD_Usuario
    {
        public Usuario ChecarUsuario(Usuario user)
        {
            using (var contexto = new BDProyecto()) {
                int Existe = contexto.Usuario.Where(u => u.usuario1 == user.usuario1 && u.password == user.password).Count();

                if (Existe > 0)
                {
                    user = contexto.Usuario.Include("Venta").Where(u => u.usuario1 == user.usuario1 && u.password == user.password).FirstOrDefault();
                       
                }

                return user;
            }
        }

        public int CrearUsuario(Usuario usuario)
        {
            using(var contexto = new BDProyecto())
            {
                    var user = contexto.Usuario.Add(usuario);
                    var result = contexto.SaveChanges();
                    return result;
                    
            }
        }

        public int BorrarUsuario(Usuario usuario)
        {
            using (var contexto = new BDProyecto())
            {
                var user = contexto.Usuario.Remove(usuario);
                var result = contexto.SaveChanges();
                return result;
            }
        }

        public int BorrarUsuario(string nombreUsuario)
        {
            using(var contexto = new BDProyecto())
            {
                var user = contexto.Usuario.Where(u => u.usuario1 == nombreUsuario).First();
                contexto.Usuario.Remove(user);
                var result = contexto.SaveChanges();
                return result;
            }
        }

    }
}
