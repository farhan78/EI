(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('EventListController', EventListController);

    EventListController.$inject = ['$rootScope', '$q', 'config', 'logger', 'aboutDataService', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function EventListController($rootScope, $q, config, logger, aboutDataService, $stateParams, $anchorScroll) {

        var vm = this;
        vm.news = [];
        vm.loading = true;

        vm.maxSize = 10;
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

            return aboutDataService.getEvents()
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
