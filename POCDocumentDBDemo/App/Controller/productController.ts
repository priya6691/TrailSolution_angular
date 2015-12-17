/// <reference path="../Service/Services.ts" />
/// <reference path="../Interface/Interfaces.ts" />
/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module angularjsApp.controllers {

    export interface Iscopes {

        Name: string;
        Price: number;
        addProduct:() => void;
        deleteProducts: (id: string) => void;
        productList: Model.Product;
    }

    export class productController {

        productService: angularjsApp.services.productServices;
      //  scope: ng.IScope;
        static $inject = ['angularjsApp.services.productServices', '$scope'];
        constructor(productService: angularjsApp.services.productServices, $scope)
        //constructor()
        {
           // this.scope = $scope
            var product = new Model.Product() 
            // $scope.abc = "testing";
            this.productService = productService;
            this.productService.getall(function (data) { $scope.productList = data; });
            //  $scope.
            
            $scope.addProduct = function () {
                //var product = new Model.Product();
                product.Name = $scope.Name;
                product.Price = $scope.Price;
                productService.post(product, function () {
                    productService.getall(function (data) { $scope.productList = data; })
                });
            }

            $scope.deleteProducts = function (productId) {
                productService.deleteProduct(productId, function () {
                    productService.getall(function (data) { $scope.productList = data; })
                });
            }
        }

       // addProducts():void {alert("this is fired")};

    }
    
    angular.module("angularjsApp").controller("productController",productController);
}
