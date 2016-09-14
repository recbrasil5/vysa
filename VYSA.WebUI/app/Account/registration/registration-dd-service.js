(function () {
    "use strict";

    angular
        .module("vysaApp").factory('registrationDataDeliveryService', function ($resource, accountRepository) {
            return {
                exists: function (emailAddr) {
                    return accountRepository.exists
                        .post({
                            email: emailAddr
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