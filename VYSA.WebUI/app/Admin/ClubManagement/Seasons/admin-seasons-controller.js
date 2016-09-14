(function () {
    "use strict";

    angular.module("vysaApp").controller('AdminSeasonsController',
        function ($scope, $location, notifierService, AdminSeasonRepository) {

            function loadSeasons() {
                AdminSeasonRepository.query().$promise.then(function (data) {
                    $scope.seasons = data;
                }, function (error) {
                    //TODO
                    console.log('Failure to load seasons table' + error.message);
                });
            }

            loadSeasons();

            $scope.addNew = function () {
                $location.url('/Admin/Home/ClubManagement/SeasonManagement/SeasonSetup');
            }

            $scope.delete = function (seasonId) {
                AdminSeasonRepository.delete({ id: parseInt(seasonId) })
                    .$promise.then(function () {
                        notifierService.success('Record has been removed!');
                        loadSeasons();
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };

        });

}());