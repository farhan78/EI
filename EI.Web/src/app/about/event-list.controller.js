(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('EventListController', EventListController);

    EventListController.$inject = ['$scope', '$q', 'config', 'logger', 'aboutDataService', '$stateParams', '$anchorScroll', '$filter'];
    /* @ngInject */
    function EventListController($scope, $q, config, logger, aboutDataService, $stateParams, $anchorScroll, $filter) {

        var vm = this;
        vm.events = [];
        vm.filteredEvents = [];
        vm.loading = true;
        vm.years = [];

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;
        vm.selectedEventPeriod = 'All';

        vm.getEvents = getEvents;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            //$scope.$watch('vm.selectedEventPeriod', selectedEventPeriodChanged, true);
            //$scope.$watch('vm.selectedPastYear', selectedPastYearChanged, true);
            $scope.$watch('vm.search', searchChanged, true);


            var promises = [];
            var params = $stateParams.params;
            promises.push(getEvents());

            return $q.all(promises)
                .then(function () {
                    var currentYear = moment().year();

                    var x;
                    for (x=currentYear; x >= 2003; x--)
                    {
                        vm.years.push(x);
                    }

                    vm.selectedPastYear = moment().year().toString();

                    vm.filteredEvents = $filter('filter')(vm.events, vm.search);
                });
        }

        function getEvents() {

            return aboutDataService.getEvents()
                .then(function (data) {
                    vm.events = data;
                    vm.loading = false;
                });
        }

        function filterEvents(event)
        {      
            if (vm.selectedEventPeriod === 'All')
            {
                return event.EventPeriod === 'Past' || event.EventPeriod === 'Ongoing' || event.EventPeriod === 'Forthcoming';
            }
            else if (vm.selectedEventPeriod==='Past')
            {
                return (event.EventPeriod==='Past') && (moment(event.EndDate).year().toString() === vm.selectedPastYear)
            }
            else
            {
                return event.EventPeriod === vm.selectedEventPeriod;
            }
        }

        function searchChanged() {
            vm.filteredEvents = $filter('filter')(vm.events, vm.search);
     //       vm.filteredEvents = $filter('filter')(vm.filteredEvents, vm.filterEvents);
        }

        function goToTop() {
            $anchorScroll($('#events'));
        }
    }
})();
