(function () {
    "use strict";

    angular
        .module("admin")
        .controller('AdminSeasonSetupController',
        function ($scope, $state, $stateParams, notifierService, metaDataService, AdminSeasonRepository, AdminEventRepository, AdminTeamRepository) {

            var seasonId = $stateParams.id;
            $scope.editing = seasonId !== undefined;

            var setSelectedYear = function (year) {
                for (var i = 0; i < $scope.years.length; i++) {
                    if ($scope.years[i] === year) {
                        $scope.season.year = $scope.years[i];
                    }
                }
            }

            var setSelectedSeason = function (seasonType) {
                for (var i = 0; i < $scope.seasonTypes.length; i++) {
                    if ($scope.seasonTypes[i] === seasonType) {
                        $scope.season.seasonTypeStr = $scope.seasonTypes[i];
                    }
                }
            }

            //metadata
            $scope.years = metaDataService.getYears();
            $scope.seasonTypes = metaDataService.getSeasonTypes();

            if ($scope.editing) {
                AdminSeasonRepository.get({ id: seasonId }, function (data) {
                    data.registrationDate = new Date(data.registrationDate);
                    data.startDate = new Date(data.startDate);
                    data.endDate = new Date(data.endDate);

                    if (data.eventList != null) {
                        for (var i = 0; i < data.eventList.length; i++) {
                            data.eventList[i].startDate = new Date(data.eventList[i].startDate);
                            data.eventList[i].endDate = new Date(data.eventList[i].endDate);
                        }
                    }
                    $scope.season = data;
                    setSelectedYear(data.year);
                    setSelectedSeason(data.seasonTypeStr);
                });
            }

            $scope.create = function () {

                AdminSeasonRepository.save($scope.season, function (response) {
                    //$location.url('/Admin/Home/ClubManagement/SeasonManagement');
                    console.log(response);
                    $scope.season.id = response.id; //set season.id which is returned in response object
                    notifierService.success("The season has been created. You may now add Events and Teams to the season!");
                    $scope.editing = true;
                }, function (error) {
                    var duplicate = error.data.modelState.duplicate;
                    if (duplicate !== undefined) {
                        console.log(duplicate[0]);
                        notifierService.error("Error: " + duplicate[0]);
                    } else {
                        notifierService.error("Error while creating season!");
                    }
                });
            }

            $scope.save = function () {
                AdminSeasonRepository.update($scope.season, function () {
                    $state.go('clubmanagement.seasonmanagement.default'); //comment this line out while debugging so you don't move
                    notifierService.success("The season has been updated!");
                }, function () {
                    notifierService.error("Error while updating season!");
                }
                );
            }

            $scope.addNewEvent = function () {
                $state.go('clubmanagement.seasonmanagement.seasons.events.addedit', { eventId: -1, seasonId: $scope.season.id });
            }

            $scope.deleteEvent = function (idx) {

                var eventToDelete = $scope.season.eventList[idx];
                AdminEventRepository.events.delete({ id: eventToDelete.id })
                    .$promise.then(function () {
                        notifierService.success('Record has been removed!');
                        $scope.season.eventList.splice(idx, 1);
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };

            $scope.addNewTeam = function () {
                $state.go('clubmanagement.seasonmanagement.seasons.teams.setup', { teamId: -1, seasonId: $scope.season.id });
                //$location.url('/Admin/Home/ClubManagement/SeasonManagement/SeasonSetup/TeamSetup/-1/' + $scope.season.id);
            }

            $scope.deleteTeam = function (idx) {

                var teamToDelete = $scope.season.teamList[idx];
                AdminTeamRepository.delete({ id: teamToDelete.id })
                    .$promise.then(function () {
                        notifierService.success('The team and everything associated with it has been removed!');
                        $scope.season.teamList.splice(idx, 1);
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };

        });

}());