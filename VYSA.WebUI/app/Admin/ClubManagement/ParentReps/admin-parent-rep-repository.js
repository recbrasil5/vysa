(function () {
    "use strict";

    angular.module("vysaApp").factory('AdminParentRepRepository',
        function ($resource, config) {

            return {
                parentReps: $resource(config.apiServerUri + 'Admin/ParentReps/:id', { id: '@id' }, {
                    get: { method: 'GET' },
                    query: { method: 'GET', isArray: true },
                    post: { method: 'POST' },
                    update: { method: 'PUT' },
                    delete: { method: 'DELETE' }
                }),

                parentRepDropdownVms: $resource(config.apiServerUri + 'Admin/ParentReps/GetParentRepDropdownVms/', {
                    id: '@id'
                }, {
                    get: { method: 'GET' },
                    post: { method: 'POST' },
                    update: { method: 'PUT' }

                })
            }

        });
        //return $resource(config.apiServerUri + 'Admin/ParentReps/:id', { id: '@id' }, {
        //    get: { method: 'GET' },
        //    query: { method: 'GET', isArray: true },
        //    post: { method: 'POST' },
        //    update: { method: 'PUT' },
        //    delete: { method: 'DELETE' }
        //});
    //});
}());