(function () {
    "use strict";

    angular
        .module("admin").factory('adContactUsDataDeliveryService', function ($resource, adminContactUsRepository) {
            return {
                getGridViewFilter: function (pageNo, recordsPerPage, sort) {
                    return adminContactUsRepository.filter
                        .post({
                            OrderByFieldName: sort.column,
                            Ascending: sort.ascending,
                            PageNum: pageNo,
                            NumofRecords: recordsPerPage,
                            GetCount: true
                        }).$promise;
                }
            };
        });
}());