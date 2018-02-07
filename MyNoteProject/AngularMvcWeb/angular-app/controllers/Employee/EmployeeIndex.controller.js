(function () {
    'use strict';

    angular.module('MainApp').controller('EmployeeIndexCtrl', EmployeeIndexCtrl);
    EmployeeIndexCtrl.$inject = ['$scope', '$window', 'EmployeeIndexService'];

    function EmployeeIndexCtrl($scope, $window, EmployeeIndexService) {
        $scope.init = Init;
        $scope.clear = Clear;
        $scope.search = Search;
        $scope.detail = Detail;
        $scope.getAll = GetAll;

        $scope.init();
        /**
         * 初始查詢畫面ViewModel
         */
        function Init() {
            try {
                $scope.isDetail = false;
                $scope.dataList = [];
                GetAll()
            } catch (e) {
                var modalOptions = {
                    headerText: '錯誤訊息',
                    bodyText: '頁面初始化失敗，請連絡相關系統人員!'
                };
            }
        }
        function GetAll() {
            EmployeeIndexService.getAll().then(function (response) {
                if (response.Success) {
                    $scope.dataList = response.Data.data;
                }
            }, function (response) {
                ShowErrorModel(response);
            });
        }
        function Detail(id) {
            EmployeeIndexService.get(id).then(function (response) {
                if (response.Success) {
                    $scope.isDetail = true;
                    $scope.EmployeeID = response.Data.data.EmployeeID;
                    $scope.EmpName = response.Data.data.EmpName;
                    $scope.Country = response.Data.data.Country;
                    $scope.Title = response.Data.data.Title;
                }
            }, function (response) {
                ShowErrorModel(response);
            });
        }

        function Clear() {
            $scope.EmployeeID = '';
            $scope.EmpName = '';
            $scope.Country = '';
            $scope.Title = '';
            $scope.isDetail = false;
        }

        function Search() {

            //if ($scope.BAC_000_R_0009Form.$valid) {
            //    var cids;
            //    if ($scope.category != null) {
            //        if ($scope.category.length > 0) {
            //            cids = $scope.extractCategoryIds($scope.category);
            //        }
            //    }
            //    var modelOptions = {
            //        StartItemBar: startItemBar,
            //        EndItemBar: endItemBar,
            //        Category: cids,
            //        ItemSNM: $scope.itemSNM,
            //        ItemENM: $scope.itemENM,
            //    };

            //    BAC_000_R_0009Service.getReportView(modelOptions).then(function (response) {
            //        angular.element('#div_Report').html(response);
            //    }, function (response) {
            //        var modalOptions = {
            //            headerText: '錯誤訊息',
            //            bodyText: response
            //        };
            //        modalService.showModal(modalOptions);
            //    });
            //}
            //else {
            //    $scope.hasError = true;
            //}
        }

        function ShowErrorModel(response) {
            var modalOptions = {
                headerText: '錯誤訊息',
                bodyText: response.Message
            };
        }
    }
})();