(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('BooksController', BooksController);

    BooksController.$inject = ['$rootScope', '$q', 'config', 'logger', 'storeDataService', '$state', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function BooksController($rootScope, $q, config, logger, storeDataService, $state, $stateParams, $anchorScroll) {

        var vm = this;
        vm.books = [];
        vm.loading = true;

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getBooks = getBooks;
        vm.addToBasket = addToBasket;
        vm.goToTop = goToTop;

        activate();
        function activate() {

            $anchorScroll($('#mainContentDiv'));
            var promises = [];
            var params = $stateParams.params;
            promises.push(getBooks());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getBooks() {

            return storeDataService.getBooks()
                .then(function (data) {
                    vm.books = data;
                    vm.loading = false;
                });
        }

        function addToBasket(book, type) {

            return storeDataService.addToBasket(book, type)
                .then(function (data) {
                    logger.success("Added to Basket", null, null);

                    // Then go to that state (closing child view)
                    $state.reload();

                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#books'));
        }
    }
})();
