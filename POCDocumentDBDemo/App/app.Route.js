/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />
var angularjsApp;
(function (angularjsApp) {
    var Routes = (function () {
        function Routes() {
        }
        Routes.configureRoutes = function ($routeProvider) {
            //      $routeProvider.when("/home", { controller: "productController", templateUrl: "/app/views/playlist.html", controllerAs: "playList" });
            $routeProvider.when("/home", { controller: "productController", templateUrl: "/App/view/productlist.html" });
            $routeProvider.otherwise({ redirectTo: "/home" });
        };
        Routes.$inject = ["$routeProvider"];
        return Routes;
    })();
    angularjsApp.Routes = Routes;
})(angularjsApp || (angularjsApp = {}));
//# sourceMappingURL=app.Route.js.map