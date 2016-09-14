﻿(function () {
    "use strict";

    angular.module("vysaApp").controller('BoardMembersController', function ($scope, BoardMemberRepository) {

        BoardMemberRepository.query().$promise.then(function (data) {
            //console.log(data);
            $scope.boardMembers = data;
        }, function (error) {
            console.log(error.data.message);
        });
    });

}());