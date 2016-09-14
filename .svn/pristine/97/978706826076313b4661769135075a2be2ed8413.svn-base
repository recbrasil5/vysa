(function () {
    angular.module('vysa', ['ngRoute', 'ngResource', 'ngCookies'])
        .config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide',
        function ($routeProvider, $locationProvider, $httpProvider, $provide) {
            
            //================================================
            // Routes
            //================================================
            $routeProvider
                //.when("/", {
                //    templateUrl: "/Templates/Home/Home.html",
                //    controller: "hmHomeController"
                //})                
                .otherwise({ redirectTo: "/" });

            $httpProvider.interceptors.push('httpInterceptorService');
        }
        ])
        .run(['$http', '$cookies', '$cookieStore', 'authService', function ($http, $cookies, $cookieStore, authService) {
            /*if authToken (cookie) exists, get it and add to request headers when the app is loaded 
             note: the user may leave and come back and as long as the cookie exists and is valid, then they are allowed to navigate inside the site*/
            authService.fillAuthData();
        }]);
}());
