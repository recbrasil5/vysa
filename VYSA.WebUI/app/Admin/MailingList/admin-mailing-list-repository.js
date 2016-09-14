(function () {
    "use strict";

    angular.module("vysaApp").factory('adminMailingListRepository',
        function ($resource, config) {

            return {
                mailingList: $resource(config.apiServerUri + 'Admin/MailingListMember/:id', { id: '@id' }, {
                    get: { method: 'GET' },
                    query: { method: 'GET', isArray: true },
                    post: { method: 'POST' },
                    update: { method: 'PUT' },
                    delete: { method: 'DELETE' }
                }),
                filter: $resource(config.apiServerUri + 'Admin/MailingListMember/filter/', {
                    pageNum: '@pageNum',
                    numRecs: '@numRecs',
                    getCount: '@getCount',
                }, {
                    post: { method: 'POST' },
                }),
                inbox: $resource(config.apiServerUri + 'Admin/ContactUs/filter/', {
                    pageNum: '@pageNum',
                    numRecs: '@numRecs',
                    getCount: '@getCount',
                }, {
                    post: { method: 'POST' },
                })
            }

        });

}());