/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
///<reference path="../Interface/interfaces.ts"/>
///<reference path="../Model/Products.ts"/>
var angularjsApp;
(function (angularjsApp) {
    var services;
    (function (services) {
        var productServices = (function () {
            function productServices($http) {
                this.httpService = $http;
            }
            productServices.prototype.getall = function (successCallback) {
                this.httpService.get('/api/products').success(function (data, status) {
                    successCallback(data);
                });
            };
            productServices.prototype.post = function (obj, successCallback) {
                this.httpService.post('/api/products', obj).success(function () {
                    successCallback();
                });
            };
            productServices.prototype.deleteProduct = function (id, successCallback) {
                this.httpService.delete('/api/products/' + id).success(function () {
                    successCallback();
                });
            };
            productServices.$inject = ['$http'];
            return productServices;
        })();
        services.productServices = productServices;
        angular.module("angularjsApp").service("angularjsApp.services.productServices", productServices);
    })(services = angularjsApp.services || (angularjsApp.services = {}));
})(angularjsApp || (angularjsApp = {}));
//# sourceMappingURL=Services.js.map