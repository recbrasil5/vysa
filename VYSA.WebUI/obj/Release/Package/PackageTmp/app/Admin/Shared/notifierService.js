(function () {
    "use strict";

    //define toastr Service here (using value)
    angular.module("admin").value('toastr', toastr);

    angular.module("admin").factory('notifierService', function (toastr) {

        toastr.options = {
            "closeButton": true,
            "debug": false,
            //"positionClass": "toast-top-right",
            //"positionClass": "toast-bottom-right",
            "positionClass": "toast-top-center",
            "progressBar": true,
            //"tapToDismiss": false - not sure why this is set to false, but it causes button to appear
            //"preventDuplicates": true,
            "onclick": null,
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
                toastr.options.showDuration = "600";
                toastr.error(msg);
                //add 3rd party logging possibly??
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