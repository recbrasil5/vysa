﻿(function () {
    "use strict";

    angular.module("vysaApp")
        .factory('authenticationService', ['$http', '$q', '$cookieStore', '$state', '$window', 'config',
            function ($http, $q, $cookieStore, $state, $window, config) {

                function getAuthToken() {
                    return $cookieStore.get('_Token');
                };

                function tokenExists() {
                    return getAuthToken() !== undefined;
                };

                function removeToken() {
                    $cookieStore.remove('_Token');
                };


                return {
                    authTokenExists: function () {
                        return tokenExists();
                    },
                    performAuthCheck: function () {
                        if (tokenExists() === false) {
                            $state.go('login'); //$location.url vs $location.path??
                        }
                    },
                    performLogin: function (email, password) {

                        var params = "grant_type=password" + "&username=" + email + "&password=" + password;
                        var deferred = $q.defer();

                        $http({
                            url: config.apiServerUri + '/Token',
                            method: "POST",
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: params
                        }).success(function (response) {
                                $cookieStore.put('_Token', response.access_token);
                                $http.defaults.headers.common.Authorization = 'Bearer ' + response.access_token;
                                deferred.resolve(response);
                            })
                            .error(function (err, status) {
                                //console.log(status);
                                deferred.reject(err);
                            });

                        return deferred.promise;
                    },
                    removeAuthCookie: function () {
                        removeToken();
                    },
                    fillAuthData: function () {
                        if (tokenExists()) {
                            //headers.Authorization vs headers.common.Authorization see authInterceptorService Request code??
                            $http.defaults.headers.common.Authorization = 'Bearer ' + getAuthToken();
                        }
                    }
                }
            }]);
}());