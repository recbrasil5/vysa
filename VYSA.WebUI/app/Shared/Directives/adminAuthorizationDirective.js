(function () {
    "use strict";

    angular
        .module("vysaApp")
        .directive('adminAuthorization', ['$state', 'accountRepository', 'authenticationService',
            function ($state, accountRepository, authenticationService) {

                return {
                    restrict: 'A',
                    replace: true,
                    link: function (scope, element, attrs) {
                        var promise = accountRepository.tokenInfo.get().$promise;
                        promise.then(function (data) {
                            if ($.inArray('Admin', data.roles) > -1 || $.inArray('SuperAdmin', data.roles) > -1) {
                                // they may stay
                            } else {
                                authenticationService.removeAuthCookie();
                                $state.go('login');
                            }
                        },
                        function (error) {
                            console.log(error.data.message);
                        });
                        //authenticationService.removeAuthCookie();
                    }
                }
            }]);
}());