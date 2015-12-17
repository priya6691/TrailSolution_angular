/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />
module angularjsApp {
    export class Routes {
        static $inject = ["$routeProvider"];
        static configureRoutes($routeProvider: ng.route.IRouteProvider) {
      //      $routeProvider.when("/home", { controller: "productController", templateUrl: "/app/views/playlist.html", controllerAs: "playList" });
            $routeProvider.when("/home", { controller: "productController", templateUrl: "/App/view/productlist.html"});
            $routeProvider.otherwise({ redirectTo: "/home" });
        }
    }
} 