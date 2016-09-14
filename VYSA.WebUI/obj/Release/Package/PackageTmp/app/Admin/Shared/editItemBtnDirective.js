(function () {
    "use strict";

    angular
        .module("admin")
        .directive('editItemBtn', ['$state', '$stateParams', 'directiveRoutingService', function ($state, $stateParams, directiveRoutingService) {
            
            return {
                restrict: 'A',
                replace: true,
                template: '<a><span class="glyphicon glyphicon-pencil"></span></a>',
                scope: {
                    itemToEdit: '='  //isolated-scope
                },
                link: function (scope, element, attrs) {
                    element.on('click', function () {
                        var type = attrs.type2.toLowerCase();
                        var state = directiveRoutingService.getState(type);
                        if (type != 'event' && type != 'team') {
                            $state.go(state, { id: scope.itemToEdit.id });
                        } else if (type == 'event') {
                            $state.go(state, { eventId: scope.itemToEdit.id, seasonId: scope.itemToEdit.seasonId });
                        }
                        else if (type == 'team') {
                            $state.go(state, { teamId: scope.itemToEdit.id, seasonId: scope.itemToEdit.seasonId });
                        }
                    });
                }
            }
        }]);
}());