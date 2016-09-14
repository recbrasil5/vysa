(function () {
    "use strict";

    angular.module("vysa").factory('mailingListMemberRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'MailingListMember/:id', { id: '@id' }, {
            post: { method: 'POST' },
        });
    });
}());