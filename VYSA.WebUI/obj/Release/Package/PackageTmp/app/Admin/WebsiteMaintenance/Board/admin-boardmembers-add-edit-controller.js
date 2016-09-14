(function () {
    "use strict";

    angular
        .module("admin")
        .controller('AdminBoardMembersAddEditController',
        function ($scope, $state, $stateParams, notifierService, AdminBoardMemberRepository) {

            var boardMemberId = $stateParams.id;
            $scope.editing = boardMemberId !== undefined;

            if ($scope.editing) {
                AdminBoardMemberRepository.get({ id: boardMemberId }, function (data) {
                    $scope.boardMember = data;
                });
            }

            $scope.save = function () {

                if ($scope.editing) {
                    //update
                    AdminBoardMemberRepository.update($scope.boardMember, function () {
                        $state.go('websitemaintenance.boardmembers.list');
                        notifierService.success("The board member with the name '" + $scope.boardMember.name + "' has been updated!");
                    }, function () {
                        notifierService.error("Error while updating board member!");
                    });
                } else {
                    //add
                    AdminBoardMemberRepository.save($scope.boardMember, function () {
                        $state.go('websitemaintenance.boardmembers.list');
                        notifierService.success("The board member with the name '" + $scope.boardMember.name + "' has been added!");
                    }, function () {
                        notifierService.error("Error while adding board member!");
                    });
                }
            }
            
        });

}());