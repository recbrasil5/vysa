(function () {
    "use strict";

    angular.module("vysa")
    .controller('ContactUsController', function ($scope, ContactUsRepository, notifierService) {
        $scope.sendMsg = function () {
            if ($scope.msg !== undefined) {
                ContactUsRepository.save($scope.msg, function () {
                    notifierService.success('Thanks for your feedback. Your message has been sent!');
                    $scope.msg = {};
                }, function () {
                    notifierService.error('There was an error and this message was not sent. Please make sure you filled out all of the fields!');
                });
            }            
        }
    });
}());