(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('BookDetailController', BookDetailController);

    BookDetailController.$inject = ['$scope', '$q', 'config', 'logger', 'storeDataService', '$state', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function BookDetailController($scope, $q, config, logger, storeDataService, $state, $stateParams, $anchorScroll) {

        var vm = this;
        vm.addToBasket = addToBasket;

        if (!$stateParams.book)
        {
            $state.go('content.store.books');
        }

        vm.book = $stateParams.book;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

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
