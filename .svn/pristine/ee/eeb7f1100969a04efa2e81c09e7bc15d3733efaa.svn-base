(function () {
    "use strict";

    angular.module("vysa")
    .controller('mailingListRegistrationController', function ($scope, mailingListMemberRepository, notifierService) {

        $scope.displayRegistrationControls = true;
        $scope.displayRegistrationPanel = true;

        $scope.register = function () {
            $scope.disableRegisterButton = true;
            mailingListMemberRepository.save($scope.memberToBe, function () {
                $scope.onSuccess = true;
                $scope.displayRegistrationControls = false;
            }, function (error) {
                $scope.onFailure = true;
                $scope.displayRegistrationControls = false;
                $scope.errorMsg = error.data.message;
            });
        }

        $scope.ok = function () {
            $scope.displayRegistrationControls = true;
            $scope.memberToBe = {};
            $scope.displayRegistrationPanel = false;
        }

        $scope.okError = function () {
            $scope.displayRegistrationControls = true;
            $scope.memberToBe = {};
        }
    });
}());