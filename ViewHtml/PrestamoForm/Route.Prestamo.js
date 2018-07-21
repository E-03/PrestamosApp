'use strict';
PrestamosApp.config(function ($routeProvider) {
    $routeProvider
        //.when("/PrestamoHome", {
        //    templateUrl: "/ViewHtml/PrestamoForm/Prestamo-Home.html",
        //    controller: "PrestamoController"
        //})
        .when("/PrestamoNew", {
            templateUrl: "/ViewHtml/PrestamoForm/Prestamo-New.html",
            controller: "PrestamoController"
        });
        //.when("/PrestamoEdit/:id", {
        //    templateUrl: "/ViewHtml/PrestamoForm/Prestamo-Edit.html",
        //    controller: "PrestamoController"
        //})
        //.otherwise({
        //    redirectTo: "/PrestamoHome"
        //});
});
