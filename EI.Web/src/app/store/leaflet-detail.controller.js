(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('LeafletDetailController', LeafletDetailController);

    LeafletDetailController.$inject = ['$scope', '$q', 'config', 'logger', 'storeDataService', '$state', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function LeafletDetailController($scope, $q, config, logger, storeDataService, $state, $stateParams, $anchorScroll) {

        var vm = this;
        vm.addToBasket = addToBasket;
      
        if (!$stateParams.leaflet)
        {
            $state.go('content.store.leaflets');
        }

        vm.leaflet = $stateParams.leaflet;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

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
