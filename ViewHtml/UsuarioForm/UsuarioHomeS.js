PrestamosApp.service("UsuarioService", function ($http) {
    var vm = this;
    var EndPoint = 'http://localhost:51619/Usuario/';

    vm.GetAll = function () {
        var Obtener = $http.get(EndPoint + 'GetAll');
        return Obtener;
    }
    vm.GetById = function (id) {
        var Obtener = $http.get(EndPoint + 'GetById', { params: { id : id } });
        return Obtener;
    }
    vm.GuardarUsuario = function (usuario) {
        var Guardar = $http.post(EndPoint + "GuardarUsuario", usuario);
        return Guardar;
    }
    vm.ActualizarUsuario = function (usuario) {
        var Obtener = $http.post(EndPoint + "ActualizarUsuario", usuario);
        return Obtener;
    }
    vm.EliminarUsuario = function (id) {
        var Obtener = $http.post(EndPoint + "EliminarUsuario?id=" + id);
        return Obtener;
    }
});