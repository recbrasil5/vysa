(function () {
    "use strict";

    angular.module("vysaApp").factory('mailingListMemberRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'MailingListMember/:id', { id: '@id' }, {
            post: { method: 'POST' },
        });
    });
}());