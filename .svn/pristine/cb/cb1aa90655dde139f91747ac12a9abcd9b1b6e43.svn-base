(function () {
    "use strict";

    angular.module("admin").factory('AdminAnnouncementRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Admin/Announcements/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' },
            delete: { method: 'DELETE' }
        });
    });
}());