/**
 * Created by nturner on 11/26/2014.
 */
(function () {
    "use strict";

    angular
        .module("admin")
        .directive('loader', ['$rootScope', function ($rootScope) {
            return function ($scope, element, attrs) {
                $scope.$on("loader_show", function () {
                    return element.show();
                });
                $scope.$on("loader_hide", function () {
                    //return $scope.$on("loader_hide", function(){
                    return element.hide();
                });
            }
        }]);
}());