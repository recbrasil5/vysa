﻿
function adminConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider, $ocLazyLoadProvider) {
    var adminRootPath = '/templates/Admin';
    $locationProvider.html5Mode({ enabled: true, requireBase: false }); //hash signs no-longer needed in href

    $urlRouterProvider.otherwise('/admin/home');
    $httpProvider.interceptors.push('httpInterceptorService');
    //$ocLazyLoadProvider.config({
    //    // Set to true if you want to see what and when is dynamically loaded
    //    debug: false
    //});

    $stateProvider
        .state('admin', {
            abstract: true,
            url: "/admin",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('admin.home', {
            url: "/home",
            templateUrl: adminRootPath + "/home.html"
        })

        //clubmanagement
        .state('clubmanagement', {
            abstract: true,
            url: "/admin/clubmanagement",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('clubmanagement.nav', {
            // Using an empty url means that this child state will become active
            // when its parent's url is navigated to. Urls of child states are
            // automatically appended to the urls of their parent. So this state's
            // url is '/clubmanagement' 
            url: "",
            // IMPORTANT: Now we have a state that is not a top level state. Its
            // template will be inserted into the ui-view within this state's
            // parent's template; so the ui-view within index.html. This is the
            // most important thing to remember about templates.
            templateUrl: adminRootPath + "/ClubManagement/main.html"
        })
        .state('clubmanagement.default', {
            url: "",
            templateUrl: adminRootPath + "/ClubManagement/main.html"
        })
        .state('clubmanagement.players', {
            abstract: true,
            url: "/players",
            template: '<div ui-view></div>'
        })
        .state('clubmanagement.players.addedit', {
            url: "/addedit",
            params: { id: { value: -1 } },
            templateUrl: adminRootPath + "/ClubManagement/Players/player-add-edit.html",
            controller: 'AdminPlayersAddEditController'
        })
        .state('clubmanagement.seasonmanagement', {
            abstract: true,
            url: "/seasonmanagement",
            template: '<div ui-view></div>'
        })
        .state('clubmanagement.seasonmanagement.default', {
            url: "",
            templateUrl: adminRootPath + "/ClubManagement/SeasonManagement/season-management.html",
            controller: 'AdminSeasonsController'
        })
        .state('clubmanagement.seasonmanagement.seasons', {
            abstract: true,
            url: "/seasons",
            template: '<div ui-view></div>'
        })
        .state('clubmanagement.seasonmanagement.seasons.setup', {
            url: "/setup",
            params: { id: { value: -1 } },
            templateUrl: adminRootPath + "/ClubManagement/SeasonManagement/season-setup.html",
            controller: 'AdminSeasonSetupController'
        })
        .state('clubmanagement.seasonmanagement.seasons.events', {
            abstract: true,
            url: "/events",
            template: '<div ui-view></div>'
        })
        .state('clubmanagement.seasonmanagement.seasons.events.addedit', {
            url: "/addedit",
            params: { eventId: { value: -1 }, seasonId: { value: -1 } },
            templateUrl: adminRootPath + "/ClubManagement/SeasonManagement/Events/event-setup.html",
            controller: 'AdminEventsAddEditController'
        })
        .state('clubmanagement.seasonmanagement.seasons.teams', {
            abstract: true,
            url: "/teams",
            template: '<div ui-view></div>'
        })
        .state('clubmanagement.seasonmanagement.seasons.teams.setup', {
            url: "/setup",
            params: { teamId: { value: -1 }, seasonId: { value: -1 } },
            templateUrl: adminRootPath + "/ClubManagement/SeasonManagement/Teams/team-setup.html",
            controller: 'AdminTeamSetupController'
        })
        //fileupload
        .state('fileupload', {
            abstract: true,
            url: "/admin/fileupload",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('fileupload.fileonly', {
            /*https://github.com/nervgh/angular-file-upload/wiki/Module-API/*/
            url: "/fileonly",
            templateUrl: adminRootPath + "/FileUpload/fileonly.html",
            data: { pageTitle: 'File upload' },
            controller: 'adminFileUploadController'
        })
        //.state('fileupload.fileandvideo', {
        //    /*https://github.com/danialfarid/ng-file-upload/*/
        //    url: "/fileandvideo",
        //    templateUrl: adminRootPath + "/FileUpload/fileandvideo.html",
        //    data: { pageTitle: 'File & Video upload' },
        //    controller: 'adminUploadController'
        //})
        //mailingList
        .state('mailingList', {
            abstract: true,
            url: "/admin/mailingList",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('mailingList.default', {
            url: "/mailingList",
            templateUrl: adminRootPath + "/MailingList/mailing-list.html",
            controller: 'adminMailingListMemberController'
        })
        .state('mailingList.inbox', {
            url: "/inbox",
            templateUrl: adminRootPath + "/MailingList/inbox.html",
            controller: 'adminContactUsController'
        })
        //websitemaintenance
        .state('websitemaintenance', {
            abstract: true,
            url: "/admin/websitemaintenance",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('websitemaintenance.nav', {
            url: "",
            templateUrl: adminRootPath + "/ClubManagement/main.html"
        })
        .state('websitemaintenance.announcements', {
            abstract: true,
            url: '/announcements',
            template: '<div ui-view></div>'
        })
        .state('websitemaintenance.announcements.list', {
            url: '/list',
            templateUrl: adminRootPath + "/WebsiteMaintenance/Announcements/announcements.html",
            controller: 'AdminAnnouncementsController'
        })
        .state('websitemaintenance.announcements.addedit', {
            url: '/addedit',
            params: { id: { value: -1 } },
            templateUrl: adminRootPath + "/WebsiteMaintenance/Announcements/announcements-add-edit.html",
            controller: 'AdminAnnouncementsAddEditController'
        })
        .state('websitemaintenance.boardmembers', {
            abstract: true,
            url: '/boardmembers',
            template: '<div ui-view></div>'
        })
        .state('websitemaintenance.boardmembers.list', {
            url: '/list',
            templateUrl: adminRootPath + "/WebsiteMaintenance/BoardMembers/boardmembers.html",
            controller: 'AdminBoardMembersController'
        })
        .state('websitemaintenance.boardmembers.addedit', {
            url: '/addedit',
            params: { id: { value: -1 } },
            templateUrl: adminRootPath + "/WebsiteMaintenance/BoardMembers/boardmembers-add-edit.html",
            controller: 'AdminBoardMembersAddEditController'
        })
        //users
        .state('users', {
            abstract: true,
            url: "/admin/users",
            templateUrl: adminRootPath + "/Common/content.html"
        })
        .state('users.default', {
            url: "/users",
            templateUrl: adminRootPath + "/Users/users.html",
            controller: 'adminUsersController'
        });
}
angular
    .module('admin')
    .config(adminConfig)
    .run(['$rootScope', '$state', '$stateParams', '$http', '$cookies', '$cookieStore', 'authService',
        function ($rootScope, $state, $stateParams, $http, $cookies, $cookieStore, authService) {

            /*if authToken (cookie) exists, get it and add to request headers when the app is loaded 
            note: the user may leave and come back and as long as the cookie exists and is valid, then they are allowed to navigate inside the site*/
            authService.fillAuthData();

            // It's very handy to add references to $state and $stateParams to the $rootScope
            // so that you can access them from any scope within your applications.
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            //prevent scrolling to ui-view on click
            $rootScope.$on('$stateChangeSuccess', function () {
                $("html, body").animate({ scrollTop: 0 }, 200);
            });
        }]);
