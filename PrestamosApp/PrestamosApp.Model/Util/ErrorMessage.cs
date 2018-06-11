using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestamosApp.Model.Model;

namespace PrestamosApp.Model.Util
{
    public class ErrorMessage
    {
        public string ValidationField(Usuario usuario) {
            string msj = "Error de Validacion";
            if (usuario.Nombre == null)
            {
                var nombre = string.Format("El campo nombre no puede estar vacio, Favor llenarlo");
                return nombre;
            }
            if (usuario.Apellido == null)
            {
                var apellido = string.Format("El campo apellido no puede estar vacio, Favor llenarlo");
                return apellido;
            }
            if (usuario.Cedula.Length > 11 || usuario.Cedula.Length <= 10)
            {
                var cedula = string.Format("El campo cedula debe tener de 11 caracteres, Favor verificar que no sobrepase el limite!!!");
                return cedula;
            }
            if (usuario.Direccion == null)
            {
                var direccion = string.Format("El campo Direccion no puede estar vacio, Favor llenarlo");
                return direccion;
            }
            return msj;
        }
    }
}
