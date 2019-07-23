using DataLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoClase.Controllers
{
    public class UsuarioController : Controller
    {
        //GET: Usuario/AgregarUsuario
        public ActionResult AgregarUsuario()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Login");
        }


        //POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario) {
            var result = new JObject();
            if (Session["Usuario"] != null)
            {
                try
                {
                    CD_Usuario CdUsuario = new CD_Usuario();
                    var creado = CdUsuario.CrearUsuario(usuario);
                    if (creado >= 1)
                    {
                        result["success"] = true;
                        result["error"] = false;
                    } else
                    {
                        result["success"] = true;
                        result["error"] = "No se guardaron cambios a la base de datos";
                    }
                }
                catch (DbEntityValidationException e)
                {
                    result["success"] = false;
                    result["error"] = "Error de validación";
                    result["log"] = e.Message;
                } catch (DbUpdateException e)
                {
                    result["success"] = false;

                    if (e.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY"))
                    {
                        result["log"] = e.InnerException.InnerException.Message;
                        result["error"] = "El nombre de usuario ya existe";
                    } else
                    {
                        result["log"] = e.InnerException.InnerException.Message;
                        result["error"] = "No se pudo guardar el usuario";
                    }
                     
                    
                } catch (ObjectDisposedException e)
                {
                    result["success"] = false;
                    result["log"] = e.InnerException.InnerException.Message;
                    result["error"] = "Error en la transferencia de datos";
                } catch (InvalidOperationException e)
                {
                    result["success"] = false;
                    result["log"] = e.InnerException.InnerException.Message;
                    result["error"] = "La operación no se pudo completar";
                }
            } else
            {
                result["success"] = false;
                result["error"] = "No se tienen los permisos necesarios para realizar esta acción";
            }
            return Content(result.ToString());

        }

        //POST: Usuario/Delete/
        [HttpPost]
        public ActionResult Delete(string nombreUsuario)
        {
            var result = new JObject();
            if (Session["Usuario"] != null)
            {
                try
                {
                    CD_Usuario CdUsuario = new CD_Usuario();
                    var eliminado = CdUsuario.BorrarUsuario(nombreUsuario);
                    if (eliminado >= 1)
                    {
                        result["success"] = true;
                        result["error"] = false;
                    }
                    else
                    {
                        result["success"] = true;
                        result["error"] = "No se guardaron cambios a la base de datos";
                    }
                }
                catch (DbEntityValidationException e)
                {
                    result["success"] = false;
                    result["error"] = "Error de validación";
                    result["log"] = e.Message;
                }
                catch (DbUpdateException e)
                {
                    result["success"] = false;

                    if (e.InnerException.InnerException.Message.Contains("Violation of PRIMARY KEY"))
                    {
                        result["log"] = e.InnerException.InnerException.Message;
                        result["error"] = "El nombre de usuario no existe";
                    }
                    else
                    {
                        result["log"] = e.InnerException.InnerException.Message;
                        result["error"] = "No se pudo eliminar el usuario";
                    }


                }
                catch (ObjectDisposedException e)
                {
                    result["success"] = false;
                    result["log"] = e.InnerException.InnerException.Message;
                    result["error"] = "Error en la transferencia de datos";
                }
                catch (InvalidOperationException e)
                {
                    result["success"] = false;
                    result["log"] = e.InnerException.InnerException.Message;
                    result["error"] = "La operación no se pudo completar";
                }
            }
            else
            {
                result["success"] = false;
                result["error"] = "No se tienen los permisos necesarios para realizar esta acción";
            }
            return Content(result.ToString());
        }


    
        

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
    }
}