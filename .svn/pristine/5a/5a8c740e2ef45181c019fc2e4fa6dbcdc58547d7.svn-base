(function () {
    "use strict";

    angular.module("vysaApp").controller('forgotPasswordController', function ($scope, $resource, $state, accountRepository, notifierService) {
        $scope.emailAddress = '';

        $scope.send = function() {
            accountRepository.forgotPassword.post({
                email: $scope.emailAddress
            }).$promise.then(function (data) {
                console.log(data);
                notifierService.success('A new password has been sent to the following email address: ' + $scope.emailAddress);
            }, function (error) {
                notifierService.error("The email address '" + $scope.emailAddress + "'was not found in the system. Please contact the administrator.");
            });
            //$state.go('login');
        };

    });

}());