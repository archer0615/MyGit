(function () {
    'use strict';

    angular.module('MainApp').directive('selectList', SelectList);
    SelectList.$inject = ['$uibModal'];

    function SelectList($uibModal) {
        return {
            restrict: 'E',
            replace: true,
            priority: 2,
            scope: {
                data: '=',
                selected: '='
            },
            template:
                ('<div class="giSelectList">' +
                    '<div class="paneList">' +
                    '<select class="form-control"' +
                    ' ng-options="myItem.text for myItem in data | orderBy:\'value\' track by myItem.value"' +
                    ' ng-model="dataSet"' +
                    ' multiple="multiple">' +
                    '</select>' +
                    '</div>' +
                    '<div class="divider">' +
                    '<button class="btn btn-default" ng-click="selectAll()" ><i class="glyphicon glyphicon-forward"></i></button><br/>' +
                    '<button class="btn btn-default" ng-click="addSelected()" ><i class="glyphicon glyphicon-chevron-right"></i></button><br/>' +
                    '<br/><br/>' +
                    '<button class="btn btn-default" ng-click="removeSelected()" ><i class="glyphicon glyphicon-chevron-left"></i></button><br/>' +
                    '<button class="btn btn-default" ng-click="deselectAll()" ><i class="glyphicon glyphicon-backward"></i></button><br/>' +
                    '</div>' +
                    '<div class="paneList">' +
                    '<select class="form-control"' +
                    ' ng-options="myItem.text for myItem in selected | orderBy:\'value\' track by myItem.value"' +
                    ' ng-model="selectedSet"' +
                    ' multiple="multiple">' +
                    '</select>' +
                    '</div>' +
            '</div>'),
            link: function (scope, element) {
                //remove any selected elements from the list data
                //scope.data = _.difference(scope.data, scope.selected);

                //sort both lists
                //scope.data = _.sortBy(scope.data, function (num) { return num; });
                //scope.selected = _.sortBy(scope.selected, function (num) { return num; });
            },
            controller: function ($scope) {

                $scope.addSelected = function () {
                    if ($scope.dataSet) {
                        if ($scope.dataSet.length > 0) {
                            var selValue = [];
                            for (var i = 0; i < $scope.dataSet.length; i++) {
                                selValue.push($scope.dataSet[i].value);
                            }

                            //合併
                            $scope.selected = $scope.selected.concat($scope.dataSet);

                            var newData = $scope.data.filter(function (element) {
                                return $.inArray(element.value, selValue) == -1
                            });

                            if (newData.length > 0)
                            {
                                $scope.data = newData;
                            }
                            else
                            {
                                $scope.data = [];
                            }
                        }
                    }
                }

                $scope.removeSelected = function () {

                    if ($scope.selectedSet) {
                        if ($scope.selectedSet.length > 0) {
                            var selValue = [];
                            for (var i = 0; i < $scope.selectedSet.length; i++) {
                                selValue.push($scope.selectedSet[i].value);
                            }

                            //合併
                            $scope.data = $scope.data.concat($scope.selectedSet);

                            var newSelected = $scope.selected.filter(function (element) {
                                return $.inArray(element.value, selValue) == -1
                            });

                            if (newSelected.length > 0) {
                                $scope.selected = newSelected;
                            }
                            else {
                                $scope.selected = [];
                            }
                        }
                    } 
                }

                $scope.selectAll = function () {

                    if ($scope.data.length > 0) {
                        for (var i = 0; i < $scope.data.length; i++) {
                            $scope.selected.push($scope.data[i]);
                        }
                        $scope.data.length = 0;
                    }
                }

                $scope.deselectAll = function () {

                    if ($scope.selected.length > 0) {
                        for (var i = 0; i < $scope.selected.length; i++) {
                            $scope.data.push($scope.selected[i]);
                        }
                        $scope.selected.length = 0;
                    }
                }
            }
        };
    }
})();
