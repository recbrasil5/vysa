(function () {
    "use strict";

    angular
        .module("admin").factory('adMailingListDataDeliveryService', function ($resource, adminMailingListRepository) {
            return {
                getMailingListMemberGridViewAll: function (pageNo, recordsPerPage, sort) {
                    return adminMailingListRepository.filter
                        .post({
                            OrderByFieldName: sort.column,
                            Ascending: sort.ascending,
                            PageNum: pageNo,
                            NumofRecords: recordsPerPage,
                            GetCount: true,
                            MailingList: true,
                            Guardians: true,
                            Coaches: true,
                            ParentReps: true,
                            BoardMembers: true
                        }).$promise;
                },
                getMailingListMemberGridViewFilter: function (pageNo, recordsPerPage, sort, roles) {
                    return adminMailingListRepository.filter
                        .post({
                            OrderByFieldName: sort.column,
                            Ascending: sort.ascending,
                            PageNum: pageNo,
                            NumofRecords: recordsPerPage,
                            GetCount: true,
                            MailingList: roles[1].isChecked,
                            Guardians: roles[2].isChecked,
                            Coaches: roles[3].isChecked,
                            ParentReps: roles[4].isChecked,
                            BoardMembers: roles[5].isChecked
                        }).$promise;
                },
                getMailingListInboxGridViewFilter: function (pageNo, recordsPerPage, sort) {
                    return adminMailingListRepository.inbox
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