(function () {
    "use strict";

    angular
        .module("vysaApp").factory('adUsersDataDeliveryService', function ($resource, adminUserRepository) {
            return {
                getUsersGridView: function (pageNo, recordsPerPage, sort) {
                    return adminUserRepository.filter
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