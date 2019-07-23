using Microsoft.Build.Utilities;
using ModelLayer;
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
        public UsuarioModel ChecarUsuario(UsuarioModel user)
        {
            using (var contexto = new BDProyectoMVCEntities()) {
                int Existe = contexto.Usuario.Where(u => u.usuario1 == user.Usuario && u.password == user.Password).Count();

                if (Existe > 0)
                {
                    user = contexto.Usuario.Where(
                        u => u.usuario1 == user.Usuario && u.password == user.Password)
                        .Select(usu => new UsuarioModel()
                        {
                            Usuario = usu.usuario1,
                            Password = usu.password,
                            Apellidos = usu.apellidos,
                            Nombre = usu.nombre,
                            Correo = usu.correo,
                            FechaNacimiento = usu.fechaNacimiento,
                            Genero = usu.genero
                        }).FirstOrDefault();
                }

                return user;
            }
        }

        public int CrearUsuario(Usuario usuario)
        {
            using(var contexto = new BDProyectoMVCEntities())
            {
                    var user = contexto.Usuario.Add(usuario);
                    var result = contexto.SaveChanges();
                    return result;
                    
            }
        }

        public int BorrarUsuario(Usuario usuario)
        {
            using (var contexto = new BDProyectoMVCEntities())
            {
                var user = contexto.Usuario.Remove(usuario);
                var result = contexto.SaveChanges();
                return result;
            }
        }

        public int BorrarUsuario(string nombreUsuario)
        {
            using(var contexto = new BDProyectoMVCEntities())
            {
                var user = contexto.Usuario.Where(u => u.usuario1 == nombreUsuario).First();
                contexto.Usuario.Remove(user);
                var result = contexto.SaveChanges();
                return result;
            }
        }

    }
}
