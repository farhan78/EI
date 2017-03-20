(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('EventsController', EventsController);

    EventsController.$inject = ['$scope', '$q', '$timeout', 'config', 'logger',
        '$stateParams', 'galleryDataService', '$anchorScroll','$filter'];
    /* @ngInject */
    function EventsController($scope, $q, $timeout, config, logger,
        $stateParams, galleryDataService, $anchorScroll, $filter) {

        var vm = this;
        vm.events = [];
        vm.filteredEvents = [];
        vm.loading = true;

        vm.maxSize = 20;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getEvents = getEvents;
        vm.goToTop = goToTop;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
            $scope.$watch('vm.search', searchChanged, true);

            var promises = [];
            var params = $stateParams.params;
            promises.push(getEvents());

            return $q.all(promises)
                .then(function () {
                    vm.filteredEvents = $filter('filter')(vm.events, vm.search);
                });
        }

        function getEvents() {
            return galleryDataService.getEvents()
                .then(function (data) {
                    vm.events = data;
                    vm.loading = false;
                });
        }

        function searchChanged() {
          
            vm.filteredEvents = $filter('filter')(vm.events, vm.search);
        }

        function goToTop() {
            $anchorScroll($('#events'));
        }
    }
})();
