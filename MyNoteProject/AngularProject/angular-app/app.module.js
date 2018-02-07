(function () {
    'use strict';

    angular.module('MainApp', ['ui.sortable', 'ui.bootstrap']);

    angular.module('MainApp').config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push(function ($rootScope, $q, $injector, $window) {
            return {
                request: function (config) {
                    config.headers['X-Requested-With'] = 'XMLHttpRequest';
                    return config || $q.when(config);
                },
                requestError: function (rejection) {
                    return rejection;
                },

                response: function (response) {
                    return response || $q.when(response);
                },
                responseError: function (response) {
                    var result = response.data;

                    return $q.reject(response);
                }
            }
        });
    }]);
      angular.module('MainApp').run(['$rootScope', function ($rootScope) {
        $rootScope.onAllEvents = function () {
            var watchedEvents = {};
            return onAllEvents;

            function onAllEvents(events, fn) {
                if (!events || !events.length) return;

                events.forEach(function (evt) {
                    watchedEvents[evt] = false;
                    this.$on(evt, function () {
                        watchedEvents[evt] = true;
                        tryExecute(fn);
                    });
                }.bind(this));
            }

            function tryExecute(fn) {
                var shouldExecute = true;
                for (var evt in watchedEvents) {
                    if (watchedEvents.hasOwnProperty(evt) && !watchedEvents[evt]) {
                        shouldExecute = false;
                    }
                }

                if (shouldExecute) {
                    fn();
                    for (var evt in watchedEvents) {
                        if (watchedEvents.hasOwnProperty(evt)) {
                            watchedEvents[evt] = false;
                        }
                    }
                }
            }
        }();
    }]);
})();