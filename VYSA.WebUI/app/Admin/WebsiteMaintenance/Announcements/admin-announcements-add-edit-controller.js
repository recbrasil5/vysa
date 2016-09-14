﻿(function () {
    "use strict";

    angular
        .module("vysaApp")
        .controller('AdminAnnouncementsAddEditController',
        function ($scope, $state, $location, $stateParams, notifierService, AdminAnnouncementRepository) {
            
            var announcementId = $stateParams.id;
            $scope.editing = announcementId !== undefined;

            if ($scope.editing) {
                AdminAnnouncementRepository.get({ id: announcementId }, function (data) {
                    data.to = new Date(data.to);
                    data.from = new Date(data.from);
                    $scope.announcement = data;
                });
            }

            $scope.save = function () {

                if ($scope.editing) {
                    
                    AdminAnnouncementRepository.update($scope.announcement, function () {
                        $state.go('websitemaintenance.announcements.list');
                        notifierService.success("The announcement with the title '" + $scope.announcement.title + "' has been updated!");
                    }, function () {
                        notifierService.error("Error while updating announcement!");
                    });
                } else {
                    AdminAnnouncementRepository.save($scope.announcement, function () {
                        $state.go('websitemaintenance.announcements.list');
                        notifierService.success("The announcement with the title '" + $scope.announcement.title + "' has been added!");
                    }, function () {
                        notifierService.error("Error while adding announcement!");
                    });
                }
            }

        });

}());