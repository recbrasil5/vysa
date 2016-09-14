(function () {
    "use strict";

    angular.module("admin").factory('AdminCoachRepository', 
        function ($resource, config) {

            return {
                coaches: $resource(config.apiServerUri + 'Admin/Coaches/:id', { id: '@id' }, {
                    get: { method: 'GET' },
                                query: { method: 'GET', isArray: true },
                                post: { method: 'POST' },
                                update: { method: 'PUT' },
                                delete: { method: 'DELETE' }
                }),

                coachDropdownVms: $resource(config.apiServerUri + 'Admin/Coaches/GetCoachDropdownVms/', {
                    id: '@id'
                }, {
                    get: { method: 'GET' },
                    post: { method: 'POST' },
                    update: { method: 'PUT' }

                })
            }

        });

}());