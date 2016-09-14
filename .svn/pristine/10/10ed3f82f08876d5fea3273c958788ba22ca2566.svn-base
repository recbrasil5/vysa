(function () {
    "use strict";

    angular.module("vysaApp").controller('mainController',
        function ($scope, notifierService, authenticationService) {
            //authorize the use of the landing page - other pages will make calls and the 401 should kick them out
            authenticationService.performAuthCheck();

            $scope.goHome = function () {
                window.location.href = window.location.origin + '/index.html';                
            }
        });

}());