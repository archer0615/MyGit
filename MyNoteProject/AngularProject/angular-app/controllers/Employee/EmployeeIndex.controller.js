(function () {
    'use strict';

    angular.module('MainApp').controller('EmployeeIndexCtrl', EmployeeIndexCtrl);
    EmployeeIndexCtrl.$inject = ['$scope', '$window', 'EmployeeIndexService'];

    function EmployeeIndexCtrl($scope, $window, EmployeeIndexService) {
        $scope.init = Init;
        $scope.clear = Clear;
        $scope.search = Search;
        $scope.getAll = GetAll;

        $scope.init();
        /**
         * 初始查詢畫面ViewModel
         */
        function Init() {
            try {
                $scope.dataList = [];
                GetAll()
            } catch (e) {
                console.log(e);
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
                var modalOptions = {
                    headerText: '錯誤訊息',
                    bodyText: response
                };
            });
        }


        function Clear() {

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
    }
})();