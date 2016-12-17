(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('LeafletsController', LeafletsController);

    LeafletsController.$inject = ['$scope', '$q', 'config', 'logger', 'storeDataService', '$state', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function LeafletsController($scope, $q, config, logger, storeDataService, $state, $stateParams, $anchorScroll) {

        var vm = this;
        vm.leaflets = [];
        vm.loading = true;

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getLeaflets = getLeaflets;
        vm.addToBasket = addToBasket;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getLeaflets());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getLeaflets() {
          
            return storeDataService.getLeaflets()
                .then(function (data) {
                    vm.leaflets = data;
                    vm.loading = false;
                });
        }

        function addToBasket(leaflet, type) {
         
            return storeDataService.addToBasket(leaflet, type)
                .then(function (data) {
                    logger.success("Added to Basket", null, null);
                   
                    // Then go to that state (closing child view)
                    $state.reload();

                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#leaflets'));
        }
    }
})();
