///<reference path="../Model/products.ts"/>
module angularjsApp.Interfaces {
    export interface IProducts

    {
        getall: (successCallback: any) => void;
        getProduct: (id: string,successCallback: any) => void;
        post: (obj: Model.Product, successCallback: any ) => void;
        put: (obj: Model.Product, successCallback: any) => void;
        deleteProduct: (id: string, successCallback: any) => void;        

    }

}