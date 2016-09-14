(function () {
    "use strict";

    angular.module("vysaApp").controller('AdminClubManagementController',
        function ($scope) {
            $scope.selected = 'Player';

            $scope.getTemplate = function () {
                if ($scope.selected == 'Coach')
                    return '/templates/Admin/ClubManagement/Coaches/coaches.html';
                else if ($scope.selected == 'ParentRep')
                    return '/templates/Admin/ClubManagement/ParentReps/parent-reps.html';
                else
                    return '/templates/Admin/ClubManagement/Players/players.html';
            }
            
        });

}());