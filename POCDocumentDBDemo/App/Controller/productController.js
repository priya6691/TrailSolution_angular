/// <reference path="../Service/Services.ts" />
/// <reference path="../Interface/Interfaces.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
var angularjsApp;
(function (angularjsApp) {
    var controllers;
    (function (controllers) {
        var productController = (function () {
            function productController(productService, $scope) {
                // this.scope = $scope
                var product = new angularjsApp.Model.Product();
                // $scope.abc = "testing";
                this.productService = productService;
                this.productService.getall(function (data) { $scope.productList = data; });
                //  $scope.
                $scope.addProduct = function () {
                    //var product = new Model.Product();
                    product.Name = $scope.Name;
                    product.Price = $scope.Price;
                    productService.post(product, function () {
                        productService.getall(function (data) { $scope.productList = data; });
                    });
                };
                $scope.deleteProducts = function (productId) {
                    productService.deleteProduct(productId, function () {
                        productService.getall(function (data) { $scope.productList = data; });
                    });
                };
            }
            //  scope: ng.IScope;
            productController.$inject = ['angularjsApp.services.productServices', '$scope'];
            return productController;
        })();
        controllers.productController = productController;
        angular.module("angularjsApp").controller("productController", productController);
    })(controllers = angularjsApp.controllers || (angularjsApp.controllers = {}));
})(angularjsApp || (angularjsApp = {}));
//# sourceMappingURL=productController.js.map