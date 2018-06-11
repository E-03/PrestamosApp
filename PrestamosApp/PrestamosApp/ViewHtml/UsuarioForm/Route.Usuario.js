'use strict';
PrestamosApp.config(function ($routeProvider) {
    $routeProvider
        .when("/Home", {
            templateUrl: "/ViewHtml/UsuarioForm/Usuario-Home.html",
            controller: "HomeController"
        })
        .when("/UsuarioNew", {
            templateUrl: "/ViewHtml/UsuarioForm/Usuario-New.html",
            controller: "HomeController"
        })
        .when("/UsuarioEdit/:id", {
            templateUrl: "/ViewHtml/UsuarioForm/Usuario-Edit.html",
            controller: "HomeController"
        })
        .otherwise({
            redirectTo: "/Home"
        });
});
