﻿(function () {
    "use strict";

    angular.module("vysaApp").controller('AdminParentRepsController',
        function ($scope, $location, notifierService, AdminParentRepRepository) {

            $scope.newRow = false;
            $scope.selected = {};
            $scope.newParentRep = {};
            loadParentReps();

            $scope.getTemplate = function (parentRep) {
                if ($scope.selected.id !== undefined && parentRep.id === $scope.selected.id)
                    return '/templates/Admin/ClubManagement/ParentReps/parent-rep-edit-view.html';
                else
                    return '/templates/Admin/ClubManagement/ParentReps/parent-rep-list-view.html';
            }

            $scope.addNew = function () {
                $scope.newRow = true;
            };

            $scope.cancel = function () {
                $scope.newRow = false;
                $scope.newParentRep = {};
            };

            $scope.edit = function (parentRep) {
                $scope.selected = angular.copy(parentRep);
            };

            $scope.reset = function () {
                $scope.selected = {};
            };

            function loadParentReps() {
                AdminParentRepRepository.parentReps.query().$promise.then(function (data) {
                    $scope.parentReps = data;
                    $scope.totalRecords = data.length;
                }, function (error) {
                    //TODO
                    console.log('Failure to load parentReps table' + error.message);
                });
            }

            //function isValidForm(parentRep) {
            //    var valid = true;
            //    //if (parentRep.firstName === undefined || parentRep.firstName !)
            //        return true;
            //}

            /*CRUD OPERATIONS*/
            $scope.create = function (newParentRep) {
                //if (isValidForm()) {
                AdminParentRepRepository.parentReps.save(newParentRep, function () {
                    notifierService.success("The parentRep '" + newParentRep.firstName + "' has been added!");
                    $scope.newParentRep = {};
                    $scope.newRow = false;
                    loadParentReps();
                }, function (error) {
                    var modelState = error.data.modelState;
                    notifierService.error("Error while adding parentRep. Note: FirstName, LastName and Email are required fields.");
                });
                //} else {
                //    notifierService.error("Form is not valid!");
                // }

            };

            $scope.update = function (parentRep) {
                AdminParentRepRepository.parentReps.update(parentRep, function () {
                    notifierService.success("The parentRep '" + parentRep.firstName + "' has been updated!");
                    $scope.selected = {};
                }, function () {
                    notifierService.error("Error while updating parentRep!");
                });
            };

            //$scope.delete = function (parentRepId) {
            //    AdminParentRepRepository.parentReps.delete({ id: parseInt(parentRepId) })
            //        .$promise.then(function () {
            //            notifierService.success('Record has been removed!');
            //            loadParentReps();
            //        }, function (error) {
            //            notifierService.error('Ex: ' + error.message);
            //        });
            //};

        });

}());