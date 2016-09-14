(function () {
    "use strict";

    angular.module("vysa").controller('MainController', function ($scope, authService, notifierService) {

        var onAuthenticated = function () {

            var promise = authService.getUserInfo();
            promise.then(function (data) {
                $scope.accountInfo = data;
                $scope.isAdmin = data.role === "Admin";
            },
            function (err) {
                console.log(err.message);
            });
        };

        $scope.authenticated = authService.authTokenExists();
        if ($scope.authenticated) {
            onAuthenticated();
        }

        $scope.login = function () {
            $scope.username = $("#username").val();
            $scope.password = $("#password").val();
            var promise = authService.performLogin($scope.username, $scope.password);
            promise.then(function (data) {
                //console.log(data);
                $scope.authenticated = data.access_token !== undefined;
                if ($scope.authenticated) {
                    onAuthenticated();
                }
            },
                function (err) {

                    console.log('login err:', err);
                    console.log(JSON.stringify(err))
                    if (err === null) {
                        notifierService.error("Check to see if WebApi is running!");
                    } else {
                        notifierService.error(err.error_description);
                    }
                });
        };

        $scope.logoff = function () {
            authService.removeAuthCookie();
            $scope.authenticated = false;
            $scope.isAdmin = false;
        };

    });

}());