﻿(function () {
    "use strict";

    angular.module("vysaApp").controller('loginController', function ($scope, $state, accountRepository, authenticationService, notifierService) {

        var onAuthenticated = function () {
            var promise = accountRepository.tokenInfo.get().$promise;
            promise.then(function (data) {
                $scope.tokenInfo = data;
                if ($.inArray('Admin', data.roles) > -1 || $.inArray('SuperAdmin', data.roles) > -1) {
                    $state.go('admin.home');
                } else {
                    $state.go('landing');
                }
            },
            function (err) {
                notifierService.success('Login Failure: ',err);
            });
        };

        if (authenticationService.authTokenExists()) {
            onAuthenticated();
        }

        $scope.login = function () {
            var promise = authenticationService.performLogin($scope.email, $scope.password);
            promise.then(function (data) {
                $scope.authenticated = data.access_token !== undefined;
                if ($scope.authenticated) {
                    onAuthenticated();
                }
            },
                function (response) {
                    if (response === null) {
                        notifierService.error("The server is down. Please try again later.");
                    } else if (response.error === "invalid_client") {
                        console.log('we are here')
                        notifierService.error("The username and/or password is incorrect!");
                    } else {
                        notifierService.error(response.error);
                    }
                });
        };

    });

}());