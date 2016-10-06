(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('NewsController', NewsController);

    NewsController.$inject = ['$rootScope','$q', 'config', 'logger','aboutDataService', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function NewsController($rootScope, $q, config, logger,aboutDataService, $stateParams, $anchorScroll) {

        var vm = this;
        vm.news = [];
        vm.loading = true;

        vm.maxSize = 10;
        vm.currentPage = 1;
        vm.totalItems = 0;

        vm.getNews = getNews;
        vm.goToTop = goToTop;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getNews());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getNews() {
          
            return aboutDataService.getNews()
                .then(function (data) {
                    vm.news = data;
                    vm.loading = false;
                });
        }

        function goToTop() {
            $anchorScroll($('#news'));
        }
    }
})();
