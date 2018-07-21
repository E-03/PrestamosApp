using PrestamosApp.Model.Model;
using PrestamosApp.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrestamosApp.Model.Util;
using System.Web.Security;

namespace PrestamosApp.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioService service = new UsuarioService();
        ErrorMessage errorValidation = new ErrorMessage();
        // GET: Usuario
     
        public JsonResult GetAll()
        {
            var usuario = service.GetAll();
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(int id)
        {
            var usuario = service.GetById(id);
            return Json(new { usuario, HasError = false }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GuardarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var Guardar = service.GuardarUsuario(usuario);     
                return Json(new
                {
                    HasError = false,
                    Guardar,
                    status = "El usuario ha sido insertado exitosamente!!!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    HasError = true,
                    status = "Error al insertar el registro, Favor verificar!!!",
                    Error = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult ActualizarUsuario(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var Actualizar = service.ActualizarUsuario(id, usuario);
                return Json(new
                {
                    HasError = false,
                    Actualizar,
                    status = "El usuario ha sido Actualizado exitosamente!!!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    HasError = true,
                    status = "Error al Actualizar el registro, Favor verificar!!!",
                    Error = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult EliminarUsuario(int id)
        {
            if (id > 0)
            {
                var Eliminar = service.EliminaUsuario(id);
                return Json(new
                {
                    HasError = false,
                    Eliminar,
                    status = "El usuario ha sido Eliminado exitosamente!!!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    HasError = true,
                    status = "Error al eliminar el registro, Favor verificar!!!",
                    Error = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}