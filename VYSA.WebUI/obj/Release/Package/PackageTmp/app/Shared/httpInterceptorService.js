﻿(function () {
    "use strict";

    angular
        .module("vysa")
        .factory('httpInterceptorService', ['$q', '$location', '$cookieStore', '$rootScope','notifierService',
    function ($q, $location, $cookieStore, $rootScope, notifierService) {

        var numLoadings = 0;

        function checkAndHideLoader() {
            if ((--numLoadings) === 0) {
                $rootScope.$broadcast("loader_hide");
            };
        }

        return {

            // On request success
            request: function (config) {
                numLoadings++;

                config.headers = config.headers || {};
                var token = $cookieStore.get('_Token');
                if (token) {
                    config.headers.Authorization = 'Bearer ' + token;
                }

                // Show loader
                $rootScope.$broadcast("loader_show");

                //return config;
                return config || $q.when(config);
            },

            // On request failure
            requestError: function (response) {
                $rootScope.$broadcast("loader_hide");
                return $q.reject(response);
            },

            // On response success
            response: function (response) {
                checkAndHideLoader();
                return response || $q.when(response);
            },

            // On response failure
            responseError: function (response) {

                switch (response.status) {
                    case 401:
                        // handle the case where the user is not authenticated
                        //need to remove the cookie and log the person out
                        $cookieStore.remove('_Token');
                        console.log('401: cookie has been removed. User should have to re-authenticate');
                        notifierService.warn("You are not authorized");
                        break;
                    case 400:
                        //Redirect?
                        $rootScope.$broadcast("loader_hide"); //does this need to be here???
                        console.log('400 response returned');
                        break;
                    case 406:
                        console.log('406 response returned');
                        break;
                    default:
                        //reroute to a different page for other responses
                        break;
                }

                checkAndHideLoader();

                return $q.reject(response); //always return the rejected response, so error functions pick this up.
            }
        }
    }]);
}());