(function () {
    angular.module('admin', [
        'angular-clipboard',            //used in mailing-list.html & /Admin/MailingList/admin-mailing-list-controller.js
        'angularFileUpload',            //https://github.com/nervgh/angular-file-upload/wiki/Module-API/
        'ngFileUpload',                 //https://github.com/danialfarid/ng-file-upload
        'ngResource',
        'ngSanitize',
        'oc.lazyLoad',                  // ocLazyLoad
        'ngCookies',
        'ui.router',
        'angularjs-dropdown-multiselect',
        'ui.filters',
        'AxelSoft',
        'angularUtils.directives.dirPagination']);
}());