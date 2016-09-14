(function () {
    "use strict";

    angular.module("vysaApp").factory('accountRepository',
        function ($resource, config) {

            return {
                forgotPassword: $resource(config.apiServerUri + 'Account/forgotpassword', {
                    email: '@email'
                }, {
                    post: { method: 'POST' }
                }),
                exists: $resource(config.apiServerUri + 'Account/exists', {
                    email: '@email'
                }, {
                    post: { method: 'POST' }
                }),
                tokenInfo: $resource(config.apiServerUri + 'Account/tokeninfo/', {}, {
                    get: { method: 'GET' }
                })
            }

        });

}());