(function () {
    "use strict";

    angular.module("vysaApp").factory('adminContactUsRepository',
        function ($resource, config) {

            return {
                contactUs: $resource(config.apiServerUri + 'Admin/ContactUsMember/:id', { id: '@id' }, {
                    //get: { method: 'GET' },
                    //query: { method: 'GET', isArray: true },
                    //post: { method: 'POST' },
                    update: { method: 'PUT' },
                    //delete: { method: 'DELETE' }
                }),
                filter: $resource(config.apiServerUri + 'Admin/ContactUs/filter/', {
                    pageNum: '@pageNum',
                    numRecs: '@numRecs',
                    getCount: '@getCount',
                }, {
                    post: { method: 'POST' },
                })
            }

        });

}());