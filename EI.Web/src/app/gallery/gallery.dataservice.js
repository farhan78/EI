(function () {
    'use strict';

    angular
        .module('app.gallery')
        .factory('galleryDataService', galleryDataService);

    galleryDataService.$inject = ['$http', '$q', 'routerHelper', 'exception', 'logger'];
    /* @ngInject */

    function galleryDataService($http, $q, routerHelper, exception, logger) {

        var primePromise;
        var promiseCache = {};
     
        var service = {
            getEvents: getEvents,
            getPosters: getPosters,
            getModels: getModels
        };

        return service;

        function getEvents(after) {
         
            //if (promiseCache['events']) {
            //    return promiseCache['events']
            //}
         
            return $http({
                    url: '../api/events/getGallery',
                    method: 'GET'
                })
                .then(success)
                .catch(fail);

            function success(response) {
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getEventsGallery')(e);
            }
        }

        function getPosters(after) {

            //if (promiseCache['events']) {
            //    return promiseCache['events']
            //}

            return $http({
                url: '../api/posters/get',
                method: 'GET',
                params: { after: after }
            })
                .then(success)
                .catch(fail);

            function success(response) {
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getPosters')(e);
            }
        }

        function getModels(after) {

            //if (promiseCache['events']) {
            //    return promiseCache['events']
            //}

            return $http({
                url: '../api/models/get',
                method: 'GET',
                params: { after: after }
            })
                .then(success)
                .catch(fail);

            function success(response) {
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getModels')(e);
            }
        }
    }



})();