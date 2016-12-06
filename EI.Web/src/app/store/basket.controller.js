(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('BasketController', BasketController);

    BasketController.$inject = ['$scope', '$q', 'config', 'logger', 'storeDataService', '$stateParams','$state', '$anchorScroll'];
    /* @ngInject */
    function BasketController($scope, $q, config, logger, storeDataService, $stateParams,$state, $anchorScroll) {

        var vm = this;
        vm.invoice = null;
        vm.basket = [];
        vm.subTotal = 0;
        vm.postage = 0;
        vm.totalItems = 0;
        vm.loading = true;
        vm.updateTotals = updateTotals;
        vm.updateQuantity = updateQuantity;
        vm.removeItem = removeItem;
        vm.clearBasket = clearBasket;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));
         
        
            var promises = [];
            var params = $stateParams.params;
            promises.push(getBasketContent());

            return $q.all(promises)
                .then(function () {

                    if ($state.current.name === 'content.store.thankyou') {

                        if ($state.params.invoiceId === vm.invoice.InvoiceId) {
                            clearBasket();
                        }
                        else {
                            $state.go('home');
                        }
                    }
                });       
        }

        function getBasketContent() {

            return storeDataService.getBasketContent()
            .then(function (data) {
                vm.invoice = data;
                vm.basket = data.InvoiceItems;
                vm.postage = data.HandlingCost;
                updateTotals();

            });
        }

        function clearBasket() {

            return storeDataService.clearBasket()
            .then(function (data) {
               

            });
        }

        function updateTotals() {
            vm.subTotal = 0;
            vm.totalItems = 0;
            angular.forEach(vm.basket, function (item) {
              
                vm.subTotal += item.UnitPrice * Number(item.Quantity);
                vm.totalItems += Number(item.Quantity);
            });
        }

        function updateQuantity(item) {
            return storeDataService.updateQuantity(item.ProductId, item.Quantity, item.Type)
           .then(function (data) {
               logger.success("Quantity updated", null, null);

               // Then go to that state (closing child view)
               $state.reload();
           });
        }

        function removeItem(item) {
          
            return storeDataService.removeItem(item.ProductId, item.Type)
           .then(function (data) {
               logger.success("Item removed", null, null);

               // Then go to that state (closing child view)
               $state.reload();
           });
        }

        function goToTop() {
            $anchorScroll($('#basket'));
        }
    }
})();
