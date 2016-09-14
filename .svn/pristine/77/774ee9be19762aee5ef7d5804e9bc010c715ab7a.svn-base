(function () {
    "use strict";

    angular.module("admin").factory('AdminGuardianRepository',
        function ($resource, config) {

            return {
                guardians: $resource(config.apiServerUri + 'Admin/Guardians/:id', { id: '@id' }, {
                    get: { method: 'GET' },
                    query: { method: 'GET', isArray: true },
                    post: { method: 'POST' },
                    update: { method: 'PUT' },
                    delete: { method: 'DELETE' }
                }),
                autoComplete: $resource(config.apiServerUri + 'Admin/Guardians/AutoComplete', {
                    lookupId: '@lookupId',
                    searchTerm: '@searchTerm'
                }, {
                    post: { method: 'POST' }
                })
            }

        });

}());