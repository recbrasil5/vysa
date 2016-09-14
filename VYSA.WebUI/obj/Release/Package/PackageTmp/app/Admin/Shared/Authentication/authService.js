(function () {
    "use strict";

    angular.module("admin")
        .factory('authService', ['$http', '$q', '$cookieStore', '$location', '$window', 'config',
            function ($http, $q, $cookieStore, $location, $window, config) {

                function getAuthToken () {
                    return $cookieStore.get('_Token');
                };
                
                function tokenExists() {
                    return getAuthToken() !== undefined;
                };

                function removeToken() {
                    $cookieStore.remove('_Token');
                };

                function getTokenInfo() {
                    var deferred = $q.defer();
                    $http.get(config.apiServerUri + '/account/info')
                    .success(function (data, status, headers, config) {
                        if (data !== undefined) {
                            deferred.resolve(data);
                        } else
                            deferred.resolve(undefined);
                    })
                    .error(function (err, status) {
                        deferred.reject(err);
                    });

                    return deferred.promise;
                }

                return {
                    authTokenExists: function () {
                        return tokenExists();
                    },
                    performAuthCheck: function () {

                        var passedAuthorization = false;

                        var promise = getTokenInfo();
                        promise.then(function (data) {
                            //make sure the Role is either Admin or SuperAdmin
                            passedAuthorization = (data.role === 'Admin' || data.role === 'SuperAdmin');
                        },
                        function (err) {
                            console.log(err.message);
                        });

                        
                    },
                    performLogin: function (username, password) {

                        var params = "grant_type=password" + "&username=" + username + "&password=" + password;
                        var deferred = $q.defer();

                        $http({
                            url: config.apiServerUri + '/Token', //'http://api.holmenvysa.com/Token',
                            method: "POST",
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: params
                        })
                            .success(function (response) {
                                //console.log(response);
                                $cookieStore.put('_Token', response.access_token);
                                
                                $http.defaults.headers.common.Authorization = 'Bearer ' + response.access_token;
                                deferred.resolve(response);
                            })
                            .error(function (err, status) {
                                deferred.reject(err);
                            });

                        return deferred.promise;
                    },
                    removeAuthCookie: function () {
                        removeToken();
                    },
                    getUserInfo: function () {
                        return getTokenInfo();
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