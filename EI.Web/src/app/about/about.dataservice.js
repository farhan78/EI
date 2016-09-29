(function () {
    'use strict';

    angular
        .module('app.about')
        .factory('aboutDataService', aboutDataService);

    aboutDataService.$inject = ['$http', '$q', 'routerHelper', 'exception', 'logger'];
    /* @ngInject */

    function aboutDataService($http, $q, routerHelper, exception, logger) {

        var primePromise;
        var promiseCache = {};

        var service = {
            getNews: getNews
        };

        return service;

        function getNews() {

            //if (promiseCache['events']) {
            //    return promiseCache['events']
            //}

            return $http({
                url: '../api/news/',
                method: 'GET'
            })
                .then(success)
                .catch(fail);

            function success(response) {
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getNews')(e);
            }
        }
    }
})();