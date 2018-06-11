using AngularForm.Models.Dto;
using PrestamosApp.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosApp.Service.Service
{
    public class UsuarioService
    {
        private readonly dbPracticaEntities _db;
        public UsuarioService()
        {
            _db = new dbPracticaEntities();
        }

        public List<UsuarioDto> GetAll()
        {
            //List<UsuarioDto> usuarioDto = new List<UsuarioDto>();
            var usuario = _db.Usuario.Select(p => new UsuarioDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Cedula = p.Cedula,
                Direccion = p.Direccion
            }).ToList();
            //var number = page == 1 ? 0 : page - 1;
            //return new { usuario.Count, usuario = usuario.OrderBy(p => p.Id).Skip(number * 10).Take(10)};
            return usuario;
        }
        public Usuario GetById(int id)
        {
            var usuario = _db.Usuario.Where(p => p.Id == id).FirstOrDefault();
            return usuario;
        }
        public string GuardarUsuario(Usuario usuario)
        {
            string Guardado = "Error";
            if (usuario != null)
            {
                var Usuario = _db.Usuario.Add(new Usuario()
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Cedula = usuario.Cedula,
                    Direccion = usuario.Direccion
                });
                _db.SaveChanges();
                return Guardado = "Guardado";
            }
            return Guardado;
        }
        public string ActualizarUsuario(int id, Usuario usuario)
        {
            string Actualizar = "Error";
            if (id > 0)
            {
                var user = _db.Usuario.Where(p => p.Id == id).FirstOrDefault();
                user.Nombre = usuario.Nombre;
                user.Apellido = usuario.Apellido;
                user.Cedula = usuario.Cedula;
                user.Direccion = usuario.Direccion;
                //_db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Actualizar = "Actualizado";
            }
            return Actualizar;
        }
        public string EliminaUsuario(int id)
        {
            string Eliminar = "Error";
            if (id > 0)
            {
                var user = _db.Usuario.Where(p => p.Id == id).FirstOrDefault();
                _db.Usuario.Remove(user);
                _db.SaveChanges();

                return Eliminar = "Eliminado";
            }
            return Eliminar;
        }
    }
}

