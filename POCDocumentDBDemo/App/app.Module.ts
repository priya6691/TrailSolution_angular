/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
((): void=> {
    var app = angular.module("angularjsApp", ['ngRoute']);
    app.config(angularjsApp.Routes.configureRoutes);
})() 