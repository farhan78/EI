(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('PostersController', PostersController);

    PostersController.$inject = ['$scope', '$q', '$timeout', 'config', 'logger',
        '$stateParams', 'galleryDataService', '$anchorScroll', '$filter'];
    /* @ngInject */
    function PostersController($scope, $q, $timeout, config, logger,
        $stateParams, galleryDataService, $anchorScroll, $filter) {

        var vm = this;
        vm.posters = [];
        vm.filteredPosters = [];
        vm.loading = true;

        vm.maxSize = 20;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getPosters = getPosters;
        vm.goToTop = goToTop;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
            $scope.$watch('vm.search', searchChanged, true);

            var promises = [];
            var params = $stateParams.params;
            promises.push(getPosters());

            return $q.all(promises)
                .then(function () {
                    vm.filteredPosters = $filter('filter')(vm.posters, vm.search);
                });
        }

        function getPosters() {
            return galleryDataService.getPosters()
                .then(function (data) {
                    vm.posters = data;
                    vm.loading = false;
                });
        }

        function searchChanged() {

            vm.filteredPosters = $filter('filter')(vm.posters, vm.search);
        }

        function goToTop() {
            $anchorScroll($('#posters'));
        }
    }
})();
