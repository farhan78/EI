(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('FreeDownloadsController', FreeDownloadsController);

    FreeDownloadsController.$inject = ['$rootScope', '$q', 'config', 'logger', 'storeDataService', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function FreeDownloadsController($rootScope, $q, config, logger, storeDataService, $stateParams, $anchorScroll) {

        var vm = this;
        vm.freeDownloads = [];
        vm.loading = true;

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getFreeDownloads = getFreeDownloads;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getFreeDownloads());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getFreeDownloads() {

            return storeDataService.getFreeDownloads()
                .then(function (data) {
                    vm.freeDownloads = data;
                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#free-downloads'));
        }
    }
})();
