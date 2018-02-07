(function () {
    'use strict';

    angular.module('MainApp').factory('EmployeeIndexService', EmployeeIndexService);
    EmployeeIndexService.$inject = ['$http', '$q'];

    function EmployeeIndexService($http, $q) {
        return {
            getAll: function () {
                var deferred = $q.defer();
                $http.post('/Employee/Employee/GetAll')
                .success(deferred.resolve)
                .error(deferred.reject);
                return deferred.promise;
            },
            get: function (id) {
                var deferred = $q.defer();
                $http.post('/Employee/Employee/Get', {id : id})
                .success(deferred.resolve)
                .error(deferred.reject);
                return deferred.promise;
            }
        }
    }
})();