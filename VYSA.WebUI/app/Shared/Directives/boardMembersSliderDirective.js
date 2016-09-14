(function () {
    "use strict";

    angular
        .module("vysaApp")
        .directive('boardMembersSlider', ['boardMemberRepository', function (boardMemberRepository) {

            function link(scope, element, attrs) {
                scope.isData = false;
                boardMemberRepository.query().$promise.then(function (data) {
                    $scope.boardMembers = data;
                    scope.isData = true;
                }, function (error) {
                    console.log(error.data.message);
                });
            };

            return {
                restrict: 'A',
                templateUrl: 'templates/board-members.html',
                link: link
            }
        }]);
}());