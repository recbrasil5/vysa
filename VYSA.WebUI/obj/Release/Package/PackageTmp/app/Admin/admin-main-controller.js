(function () {
    "use strict";

    angular.module("admin").controller('AdminMainController',
        function ($scope, notifierService, authService) {

            //authorize the use of the landing page - other pages will make calls and the 401 should kick them out
            authService.performAuthCheck();

            $scope.goHome = function () {
                window.location.href = window.location.origin + '/index.html';                
            }
        });

}());