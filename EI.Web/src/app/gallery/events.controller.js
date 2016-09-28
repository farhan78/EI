(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('EventsController', EventsController);

    EventsController.$inject = ['$rootScope', '$q', '$timeout', 'config', 'logger', '$stateParams', 'galleryDataService', '$anchorScroll'];
    /* @ngInject */
    function EventsController($rootScope, $q, $timeout, config, logger, $stateParams, galleryDataService, $anchorScroll) {

        var vm = this;
        vm.events = [];
        vm.busy = false;
        vm.done = false;
        vm.after = 0;
        vm.getEvents = getEvents;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            vm.after = 0;
           // promises.push(getEvents());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getEvents() {
          
            if (vm.done) return;

            if (vm.busy) return;
            vm.busy = true;
            return galleryDataService.getEvents(vm.after)
                .then(function (data) {
                
                    if (data.length === 0)
                    {
                        vm.done = true;
                        return;
                    }

                    if (data.length > 0) {
                        vm.after = data[data.length - 1].ID;
                    }

                    angular.forEach(data, function (item) {

                        vm.events.push(item);
                    });

                    vm.busy = false;
                    return;
                });
        }


    }
})();
