﻿(function () {
    "use strict";

    angular.module("vysa").factory('AnnouncementRepository', function ($resource, config) {
        return $resource(config.apiServerUri + 'Announcements/:id', { id: '@id' }, {
            get: { method: 'GET' },
            query: { method: 'GET', isArray: true },
            post: { method: 'POST' },
            update: { method: 'PUT' }
        });
    });
}());