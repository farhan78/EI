(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('EventsController', EventsController);

    EventsController.$inject = ['$rootScope', '$q', '$timeout', 'config', 'logger',
        '$stateParams', 'galleryDataService', '$anchorScroll'];
    /* @ngInject */
    function EventsController($rootScope, $q, $timeout, config, logger,
        $stateParams, galleryDataService, $anchorScroll) {

        var vm = this;
        vm.events = [];
        vm.loading = true;

        vm.maxSize = 18;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getEvents = getEvents;
        vm.goToTop = goToTop;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getEvents());

            return $q.all(promises)
                .then(function () {

                });
        }

        function getEvents() {
            return galleryDataService.getEvents()
                .then(function (data) {
                    vm.events = data;
                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#events'));
        }
    }
})();
