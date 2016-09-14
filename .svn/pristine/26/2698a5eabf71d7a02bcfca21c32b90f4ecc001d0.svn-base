(function () {
    "use strict";

    //define toastr Service here (using value)
    angular.module("vysa").value('toastr', toastr);        

    angular.module("vysa").factory('notifierService', function (toastr) {

        toastr.options = {
            "closeButton": true,
            "debug": false,
            //"positionClass": "toast-top-right",
            //"positionClass": "toast-bottom-right",
            "positionClass": "toast-top-center",
            //"progressBar": true,
            //"tapToDismiss": false, //not sure why this is set to false, but it causes button to appear
            //"preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "2000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        return {
            success: function (msg) {
                toastr.success(msg);
            },
            error: function (msg) {
                toastr.error(msg);
            },
            warn: function (msg) {
                toastr.warning(msg);
            },
            clear: function () {
                toastr.clear(); //clears the current list of toasts
            }

        }
    });
}());