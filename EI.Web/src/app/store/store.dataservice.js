(function () {
    'use strict';

    angular
        .module('app.store')
        .factory('storeDataService', storeDataService);

    storeDataService.$inject = ['$http', '$q', 'routerHelper', 'exception', 'logger'];
    /* @ngInject */

    function storeDataService($http, $q, routerHelper, exception, logger) {

        var primePromise;
        var promiseCache = {};

        var service = {
            getBooks: getBooks,
            getLeaflets: getLeaflets,
            addToBasket: addToBasket,
            getBasketContent: getBasketContent,
            updateQuantity: updateQuantity,
            removeItem: removeItem,
            clearBasket: clearBasket
        };

        return service;

        function getBooks() {
          
            if (promiseCache['books']) {
                return promiseCache['books']
            }

            promiseCache['books'] = $http({
                url: '../api/books/get',
                method: 'GET'
            })
                .then(success)
                .catch(fail);

            return promiseCache['books'];

            function success(response) {
              
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getBooks')(e);
            }
        }

        function getLeaflets() {

            if (promiseCache['leaflets']) {
                return promiseCache['leaflets']
            }

            promiseCache['leaflets'] = $http({
                url: '../api/leaflets/get',
                method: 'GET'
            })
                .then(success)
                .catch(fail);

            return promiseCache['leaflets'];

            function success(response) {

                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getBooks')(e);
            }
        }

        function getBasketContent() {
           return $http({
                url: '../api/sessions/basket/get',
                method: 'GET'
            })
                .then(success)
                .catch(fail);
      
            function success(response) {
             
                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getBooks')(e);
            }
        }


        function addToBasket(book, type) {

            //if (promiseCache['events']) {
            //    return promiseCache['events']
            //}
         
            return $http({
                url: '../api/sessions/basket/add',
                method: 'POST',
                params: {
                    id: book.ID,
                    type: type,
                    qty: 1
                }
            })
                .then(success)
                .catch(fail);

            function success(response) {

                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for getBooks')(e);
            }
        }

        function updateQuantity(productId, quantity, type) {
         
            return $http({
                url: '../api/sessions/basket/updateQuantity',
                method: 'POST',
                params: {
                    productId: productId,
                    qty: quantity,
                    type: type
                }
            })
              .then(success)
              .catch(fail);

            function success(response) {

                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for updateQuantity')(e);
            }
        }
            
        function removeItem(productId, type) {
          
            return $http({
                url: '../api/sessions/basket/removeItem',
                method: 'POST',
                params: {
                    productId: productId,
                    type: type
                }
            })
              .then(success)
              .catch(fail);

            function success(response) {

                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for removeItem')(e);
            }
        }

        function clearBasket() {

            return $http({
                url: '../api/sessions/basket/clear',
                method: 'POST'
            })
              .then(success)
              .catch(fail);

            function success(response) {

                return response.data;
            }

            function fail(e) {
                return exception.catcher('XHR Failed for clearBasket')(e);
            }
        }

    }
})();