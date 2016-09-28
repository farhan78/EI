(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('PostersController', PostersController);

    PostersController.$inject = ['$rootScope', '$q', '$timeout', 'config', 'logger', '$stateParams', 'galleryDataService', '$anchorScroll'];
    /* @ngInject */
    function PostersController($rootScope, $q, $timeout, config, logger, $stateParams, galleryDataService, $anchorScroll) {

        var vm = this;
        vm.posters = [];
        vm.busy = false;
        vm.done = false;
        vm.after = 0;
        vm.getPosters = getPosters;

        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            vm.after = 0;
         
            return $q.all(promises)
                .then(function () {


                });
        }

        function getPosters() {

            if (vm.done) return;

            if (vm.busy) return;
            vm.busy = true;
            return galleryDataService.getPosters(vm.after)
                .then(function (data) {

                    if (data.length === 0) {
                        vm.done = true;
                        return;
                    }

                    if (data.length > 0) {
                        vm.after = data[data.length - 1].ID;
                    }

                    angular.forEach(data, function (item) {

                        vm.posters.push(item);
                    });

                    vm.busy = false;
                    return;
                });
        }


    }
})();
