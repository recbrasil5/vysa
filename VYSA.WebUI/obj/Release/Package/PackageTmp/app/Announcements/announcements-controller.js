(function () {
    "use strict";

    angular.module("vysa").controller('AnnouncementsController', function ($scope, AnnouncementRepository) {
        AnnouncementRepository.query().$promise.then(function (data) {
            $scope.returnCallback = true;
            $scope.announcements = data;
        }, function (error) {
            console.log(error.toString());
        });
    });
    
}());