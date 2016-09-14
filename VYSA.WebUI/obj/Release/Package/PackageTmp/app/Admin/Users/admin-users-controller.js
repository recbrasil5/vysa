(function () {
    "use strict";

    angular.module("admin").controller('adminUsersController',
        function ($scope, $location, metaDataService, notifierService, adminUserRepository, adUsersDataDeliveryService) {

            loadForm();

            function loadForm() {
                setupScopeVars();
                getGridData(1);
            }

            function getGridData(pageNo) {

                pageNo = pageNo || $scope.pagination.current;
                // loadAll
                handleDataCallback(adUsersDataDeliveryService.getUsersGridView(pageNo, $scope.recordsPerPage, $scope.sort));
            }

            function handleDataCallback(promise) {
                promise.then(function (data) {
                    if (data.count > 0) {
                        $scope.gridData = data.users;
                        $scope.totalRecords = data.count;
                        togglePagingDisplaySettings(data.count);
                    }
                },
                    function (error) {
                        $scope.gridContent = false;
                        $scope.gridData = [];
                        console.log(error);
                        notifierService.error('There was an error loading the gird');
                    }
                );
            }

            function setupScopeVars() {
                $scope.gridContent = true;
                $scope.gridData = [];
                setupPagingScopeVars();
                $scope.gridHeaderItems = metaDataService.getUserGridHeaders;
            }

            function setupPagingScopeVars() {
                $scope.totalRecords = 0;
                $scope.recordsPerPage = 15;
                $scope.pagination = { current: 1 };
                $scope.sort = {
                    column: '',
                    ascending: false
                };
            }

            function togglePagingDisplaySettings(count) {
                if (count > 50) {
                    $scope.equals100Records = true;
                    $scope.under50Records = true;
                    $scope.under25Records = true;
                    $scope.under15Records = true;
                } else if (count > 25) {
                    $scope.equals100Records = false;
                    $scope.under50Records = true;
                    $scope.under25Records = true;
                    $scope.under15Records = true;
                } else if (count > 15) {
                    $scope.equals100Records = false;
                    $scope.under50Records = false;
                    $scope.under25Records = true;
                    $scope.under15Records = true;
                } else if (count < 15) {
                    $scope.equals100Records = false;
                    $scope.under50Records = false;
                    $scope.under25Records = false;
                    $scope.under15Records = false;
                }
            }

            $scope.delete = function (UserId) {
                AdminUserRepository.Users.delete({ id: parseInt(UserId) })
                    .$promise.then(function () {
                        notifierService.success('Record has been removed!');
                        getGridData(1);
                    }, function (error) {
                        notifierService.error('Ex: ' + error.message);
                    });
            };

            $scope.orderBy = function (column) {
                this.sort.column = column;
                this.sort.ascending = !this.sort.ascending;
                getGridData(1);
            }

            $scope.pageChanged = function (pageNo) {
                getGridData(pageNo);
            };

            //Export
            //$scope.exportGridContent = function () {
            //    adCategoriesService.exportCategories($scope.pagination.current, 100, $scope.sort)
            //        .then(function (data) {
            //            window.open(data, "_self");
            //        });
            //}

            //Modal Method (delete click)
            //$scope.displayModal = function (category) {
            //    var desc = category.leadSourceCategory;
            //    ModalService.showModal({
            //        templateUrl: '/Templates/Shared/Modals/ConfirmModal.html',
            //        controller: "confirmModalController",
            //        inputs: {
            //            title: "Delete Confirmation",
            //            body: "Are you sure you would like to delete the category '" + desc + "'?"
            //        }
            //    }).then(function (modal) {
            //        modal.element.modal();
            //        modal.close.then(function (result) {
            //            //result is not currently used, but you can pass scope variables through the result from the modal controller
            //            adCategoriesService.categories.delete({ id: category.id }, function () {
            //                notifierService.success("The category '" + desc + "' has been successfully deleted");
            //                getGridData(1);
            //            }, function () {
            //                notifierService.error('There was an error deleting the ' + desc);
            //            });
            //        });
            //    });
            //};

        });
}());