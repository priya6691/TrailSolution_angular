/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
///<reference path="../Interface/interfaces.ts"/>
///<reference path="../Model/Products.ts"/>

module angularjsApp.services {

    export class productServices implements Interfaces.IProducts
    {
        
       // public product= new Model.Product();
        httpService:ng.IHttpService;
        static $inject = ['$http']
        constructor($http) { this.httpService = $http }
        
        getall(successCallback: Function): void{
           
            this.httpService.get('/api/products').success(function (data, status) {
                successCallback(data);
                
            });
        }
        
        
        getProduct: (id: string, successCallback: any) => void


        post(obj: Model.Product, successCallback: Function): void{
            this.httpService.post('/api/products', obj).success(function () {
                successCallback();
            });
        }
        
        put: (obj: Model.Product, successCallback: any) => void;

        deleteProduct(id: string, successCallback: any): void {
            this.httpService.delete('/api/products/'+id).success(function () {
                successCallback();
            });

        }    

    }
                                           
   angular.module("angularjsApp").service("angularjsApp.services.productServices", productServices);
} 