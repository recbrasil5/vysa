(function () {
    "use strict";

    angular.module("admin").controller('AdminBoardMembersController',
        function ($scope, $location, notifierService, AdminBoardMemberRepository) {

            function loadBoardMembers() {
                AdminBoardMemberRepository.query().$promise.then(function (data) {
                    if (data.length > 0) {
                        $scope.boardMembers = data;
                        $scope.noData = false;
                    } else {
                        $scope.noData = true;
                    }
                }, function (error) {
                    console.log('Failure to load boardMembers table: ' + error.message);
                });
            }

            loadBoardMembers();

            $scope.delete = function (boardMemberId) {
                AdminBoardMemberRepository.delete({ id: parseInt(boardMemberId) })
                    .$promise.then(function () {
                        notifierService.success('Record has been removed!');
                        loadBoardMembers();
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };
        });

}());