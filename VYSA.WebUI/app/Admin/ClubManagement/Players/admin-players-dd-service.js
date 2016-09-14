(function () {
    "use strict";

    angular
        .module("vysaApp").factory('adPlayersDataDeliveryService', function ($resource, AdminPlayerRepository) {
            return {
                getPlayersGridView: function (pageNo, recordsPerPage, sort) {
                    return AdminPlayerRepository.filter
                        .post({
                            OrderByFieldName: sort.column,
                            Ascending: sort.ascending,
                            PageNum: pageNo,
                            NumofRecords: recordsPerPage,
                            GetCount: true
                        }).$promise;
                }
                //inUseCheck: function (category) {
                //    return adCategoriesService.inUseCheck
                //        .post({
                //            text: category //id not needed here
                //        }).$promise;
                //}
            };
        });
}());