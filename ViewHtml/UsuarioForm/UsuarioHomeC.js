'use strict';
PrestamosApp.controller('HomeController', function ($scope, UsuarioService, $window, $routeParams, $location, $timeout) {
    var vm = this;
    var id = $routeParams.id;
    $scope.ver = "Funciona";
    
    vm.GetAll = function() {
        UsuarioService.GetAll().then(function (response) {
            $scope.usuario = response.data;
        });
    }
    vm.GetById = function (id) {
        if (id > 0) {
            UsuarioService.GetById(id).then(function (response) {
                $scope.usuario = response.data.usuario;
            });
        } else {
            $scope.usuario = { id: 0 };
        }
    }
    vm.GetById(id);//Aqui estoy ejecutando la funcion....
    
    vm.GuardarUsuario = function () {       
        
        if (Validaciones() == null) {
            return;
        } else {
            var confirmar = confirm("Desea agregar el registro???");
            if (confirmar) {
            var user = {
                Nombre: vm.Nombre,
                Apellido: vm.Apellido,
                Cedula: vm.Cedula,
                Direccion: vm.Direccion
            }
            var Guardar = UsuarioService.GuardarUsuario(user);
                Guardar.then(function (response) {
                toastr.success(response.data.status,"Guardado!!!")
                console.log(response.data.status + "\n");              
                //Reload();
                }, function (response) {
                    if (response.HasError) {
                        toastr.error(response.data.Error, "Error");
                        console.log(response.data.Error);
                    }                
            });
            $window.location = "#/Home";
        } else {
                toastr.info("El usuario no se guardo, <Cancelado>", "Informacion");
            }
        }
        $timeout(Reload, 2000);
    }
    vm.ActualizarUsuario = function () {     
        var Confirmar = confirm("Desea Actualizar este registro!");
        if (Confirmar) {
            var actualizar = UsuarioService.ActualizarUsuario($scope.usuario);
            actualizar.then(function (response) {
                toastr.success(response.data.status,"Actualizado");
            }, function (response) {
                console.log("Error al actualizar, Favor verificar!!! \n" + response.data.Error)
            });
        } else {
            toastr.info("El usuario no se actualizo, <Cancelado>","Informacion");
        }
            $window.location = "#/Home";
        
        $timeout(Reload, 1000);//Actualiza la pagina en un segundo.
    }
    vm.EliminarUsuario = function (id) {
        var Confirmar = confirm("Desea Eliminar este registro!");
        if (Confirmar) {
            var Eliminar = UsuarioService.EliminarUsuario(id);
            Eliminar.then(function (response) {
                toastr.success(response.data.status, "Eliminado");
                console.log(response.data.status + "\n");
            }, function (response) {
                if (response.HasError) {
                    toastr.error(response.data.Error, "Error");
                }               
            });
            //$window.location = "#/Home";
        }
        else {
            toastr.info("El usuario no se elimino, <Cancelado>");
        }
        //Reload();
        $window.location = "#/Home";
        $timeout(Reload, 2000);
    }

    function Reload() {
        $window.location.reload();
    }

    function Validaciones() {
        if (vm.Nombre == null) { toastr.warning("Favor rellenar el campo nombre", "Campo Nombre"); return; }
        if (vm.Apellido == null) { toastr.warning("Favor rellenar el campo apellido", "Campo Apellido"); return; }
        if (vm.Cedula == null || vm.Cedula.length <= 10 || vm.Cedula.length > 11 ) { toastr.warning("El numero de Cedula debe ser de 11 Digitos!!!", "Campo Cedula"); return; }
        if (vm.Direccion == null) { toastr.warning("Favor rellenar el campo direccion","Campo Direccion"); return; }
        return false;
    }
});





