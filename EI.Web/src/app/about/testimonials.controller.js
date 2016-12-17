(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('TestimonialsController', TestimonialsController);

    TestimonialsController.$inject = ['$rootScope', '$q', 'config', 'logger', 'aboutDataService', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function TestimonialsController($rootScope, $q, config, logger, aboutDataService, $stateParams, $anchorScroll) {

        var vm = this;
        vm.news = [];
        vm.loading = true;

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getQuotes = getQuotes;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getQuotes());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getQuotes() {

            return aboutDataService.getQuotes()
                .then(function (data) {
                    vm.quotes = data;
                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#quotes'));
        }
    }
})();
