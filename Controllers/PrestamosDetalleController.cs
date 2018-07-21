using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrestamosApp.Service.Service;
using PrestamosApp.Model.Dto;

namespace PrestamosApp.Controllers
{
    public class PrestamosDetalleController : Controller
    {
        PrestamosDetalleService service = new PrestamosDetalleService();
        // GET: PrestamosDetalle
        public JsonResult prestamoList()
        {
            var obtener = service.prestamosList();
            return Json(obtener,JsonRequestBehavior.AllowGet);
        }
        public JsonResult prestamoById(int id)
        {
            var obtener = service.prestamosById(id);
            return Json(obtener,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Guardarprestamo(PrestamosDetalleDto.Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                var obtener = service.GuardarPrestamo(prestamo);
                return Json(new
                {
                    HasError = false,
                    obtener,
                    status = "El registro ha sido insertado exitosamente!!!"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    HasError = false,
                    status = "Error al guardar el registro, Favor verificar!!!"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}