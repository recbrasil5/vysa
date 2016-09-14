﻿(function () {
    "use strict";

    angular.module("admin").controller('AdminCoachesController',
        function ($scope, $location, notifierService, AdminCoachRepository) {

            $scope.newRow = false;
            $scope.selected = {};
            $scope.newCoach = {};
            loadCoaches();

            $scope.getTemplate = function (coach) {
                if ($scope.selected.id !== undefined && coach.id === $scope.selected.id)
                    return '/templates/Admin/ClubManagement/Coaches/coach-edit-view.html';
                else
                    return '/templates/Admin/ClubManagement/Coaches/coach-list-view.html';
            }

            $scope.addNew = function () {
                $scope.newRow = true;
            };

            $scope.cancel = function () {
                $scope.newRow = false;
                $scope.newCoach = {};
            };

            $scope.edit = function (coach) {
                $scope.selected = angular.copy(coach);
            };

            $scope.reset = function () {
                $scope.selected = {};
            };

            function loadCoaches() {
                AdminCoachRepository.coaches.query().$promise.then(function (data) {
                    $scope.coaches = data;
                    $scope.totalRecords = data.length;
                }, function (error) {
                    //TODO
                    console.log('Failure to load coaches table' + error.message);
                });
            }

            //function isValidForm(coach) {
            //    var valid = true;
            //    //if (coach.firstName === undefined || coach.firstName !)
            //        return true;
            //}

            /*CRUD OPERATIONS*/
            $scope.create = function (newCoach) {
                //if (isValidForm()) {
                AdminCoachRepository.coaches.save(newCoach, function () {
                        notifierService.success("The coach '" + newCoach.firstName + "' has been added!");
                        $scope.newCoach = {};
                        $scope.newRow = false;
                        loadCoaches();
                    }, function (error) {
                        var modelState = error.data.modelState;
                        notifierService.error("Error while adding coach. Note: FirstName, LastName and Email are required fields.");
                    });
                //} else {
                //    notifierService.error("Form is not valid!");
               // }
                
            };

            $scope.update = function (coach) {
                AdminCoachRepository.coaches.update(coach, function () {
                    notifierService.success("The coach '" + coach.firstName + "' has been updated!");
                    $scope.selected = {};
                }, function () {
                    notifierService.error("Error while updating coach!");
                });
            };

            //$scope.delete = function (coachId) {
            //    AdminCoachRepository.coaches.delete({ id: parseInt(coachId) })
            //        .$promise.then(function () {
            //            notifierService.success('Record has been removed!');
            //            loadCoaches();
            //        }, function (error) {
            //            notifierService.error('Ex: ' + error.message);
            //        });
            //};

        });

}());