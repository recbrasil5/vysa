(function () {
    "use strict";

    angular
        .module("vysaApp")
        .controller('AdminEventsAddEditController',
        function ($scope, $state, $stateParams, notifierService, AdminEventRepository) {

            var eventId = parseInt($stateParams.eventId);
            //pass -1 when adding (second routeParam will then be seasonId)
            //go to AdminSeasonSetupController to see the path
            $scope.editing = eventId !== -1;
            var seasonId;

            if ($scope.editing) {
                AdminEventRepository.events.get({ id: eventId }, function (data) {
                    data.startDate = new Date(data.startDate);
                    data.endDate = new Date(data.endDate);
                    $scope.event = data;
                });
            } else {
                //get seasonId only if its adding a new Event
                seasonId = $stateParams.seasonId;
            }

            $scope.save = function () {

                if ($scope.editing) {
                    AdminEventRepository.events.update($scope.event, function () {
                        $state.go('clubmanagement.seasonmanagement.seasons.setup', { id: $scope.event.seasonId });
                        //$location.url('/Admin/Home/ClubManagement/SeasonManagement/SeasonSetup/' + $scope.event.seasonId);
                        notifierService.success("The event with the title '" + $scope.event.name + "' has been updated!");
                    }, function () {
                        notifierService.error("Error while updating event!");
                    });
                } else {
                    $scope.event.seasonId = seasonId;
                    AdminEventRepository.events.save($scope.event, function () {
                        $state.go('clubmanagement.seasonmanagement.seasons.setup', { id: $scope.event.seasonId });
                        //$location.url('/Admin/Home/ClubManagement/SeasonManagement/SeasonSetup/' + $scope.event.seasonId);
                        notifierService.success("The event with the title '" + $scope.event.name + "' has been added!");
                    }, function () {
                        notifierService.error("Error while adding event!");
                    });
                }
            }

            $scope.cancel = function () {
                if ($scope.editing) {
                    $state.go('clubmanagement.seasonmanagement.seasons.setup', { id: $scope.event.seasonId });
                } else {
                    $state.go('clubmanagement.seasonmanagement.seasons.setup', { id: seasonId });
                }
            }

        });

}());