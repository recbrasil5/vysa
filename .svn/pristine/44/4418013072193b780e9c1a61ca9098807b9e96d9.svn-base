(function () {
    "use strict";

    angular.module("vysaApp").controller('AdminAnnouncementsController',
        function ($scope, $location, notifierService, AdminAnnouncementRepository) {

            loadAnnouncements();

            function loadAnnouncements() {
                AdminAnnouncementRepository.query().$promise.then(function (data) {
                    if (data.length > 0) {
                        $scope.announcements = data;
                        $scope.noData = false;
                    } else {
                        $scope.noData = true;
                    }
                    
                }, function (error) {
                    //TODO
                    console.log('Failure to load announcements table' + error.message);
                });
            }


            $scope.delete = function (announcementId) {
                AdminAnnouncementRepository.delete({ id: parseInt(announcementId) })
                    .$promise.then(function () {
                        notifierService.success('Record has been removed!');
                        loadAnnouncements();
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };

        });
}());