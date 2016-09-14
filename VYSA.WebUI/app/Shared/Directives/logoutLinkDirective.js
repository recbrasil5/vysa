(function () {
    "use strict";

    angular
        .module("vysaApp")
        .directive('logoutLink', ['$state', 'authenticationService', function ($state, authenticationService) {

            return {
                restrict: 'A',
                replace: true,
                template: '<a ng-click="logout()"><i class="fa fa-sign-out"></i> Log out</a>',
                link: function (scope, element, attrs) {
                    scope.logout = function () {
                        authenticationService.removeAuthCookie();
                        $state.go('login');
                    }
                }
            }
        }]);
}());