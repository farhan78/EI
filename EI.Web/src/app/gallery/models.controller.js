(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('ModelsController', ModelsController);

    ModelsController.$inject = ['$scope', '$q', '$timeout', 'config', 'logger',
        '$stateParams', 'galleryDataService', '$anchorScroll', '$filter'];
    /* @ngInject */
    function ModelsController($scope, $q, $timeout, config, logger,
        $stateParams, galleryDataService, $anchorScroll, $filter) {

        var vm = this;
        vm.models = [];
        vm.filteredModels = [];
        vm.loading = true;

        vm.maxSize = 20;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getModels = getModels;
        vm.goToTop = goToTop;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
            $scope.$watch('vm.search', searchChanged, true);

            var promises = [];
            var params = $stateParams.params;
            promises.push(getModels());

            return $q.all(promises)
                .then(function () {
                    vm.filteredModels = $filter('filter')(vm.models, vm.search);
                });
        }

        function getModels() {
            return galleryDataService.getModels()
                .then(function (data) {
                    vm.models = data;
                    vm.loading = false;
                });
        }

        function searchChanged() {

            vm.filteredModels = $filter('filter')(vm.models, vm.search);
        }

        function goToTop() {
            $anchorScroll($('#models'));
        }
    }
})();
