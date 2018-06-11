using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularForm.Models.Dto
{
    public class UsuarioDto
    {
        //[Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe insertar el campo Nombre del usuario")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe insertar el campo Apellido del usuario")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Debe Insertar el campo Cedula del cliente")]
        [MinLength(11, ErrorMessage = "El minimo de caracteres debe ser 11, Favor verificar nuevamente")]
        [MaxLength(11, ErrorMessage = "El maximo de caracteres debe ser 11, Favor verificar nuevamente")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe insertar la direccion del usuario")]
        public string Direccion { get; set; }
    }
}
