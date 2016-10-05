(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('ReportsController', ReportsController);

    ReportsController.$inject = ['$rootScope', '$q', 'config', 'logger', 'aboutDataService', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function ReportsController($rootScope, $q, config, logger, aboutDataService, $stateParams, $anchorScroll) {

        var vm = this;
        vm.reports = [];
        vm.getReports = getReports;

        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));

            var promises = [];
            var params = $stateParams.params;
            promises.push(getReports());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getReports() {

            return aboutDataService.getReports()
                .then(function (data) {
                    vm.reports = data;
                });
        }


    }
})();
