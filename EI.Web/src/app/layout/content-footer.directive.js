(function () {
    'use strict';

    angular
      .module('app.layout')
      .directive('contentFooter', contentFooter);

    /* @ngInject */
    function contentFooter() {
        var directive = {
            bindToController: true,
            controller: ContentFooterController,
            controllerAs: 'vm',
            restrict: 'EA',
            scope: {
                'navline': '='
            },
            templateUrl: 'app/layout/content-footer.html',
            replace: true
        };

        ContentFooterController.$inject = ['$scope', 'dataservice', 'logger'];

        /* @ngInject */
        function ContentFooterController($scope, dataservice, logger) {
            var vm = this;
            vm.email = null;
            vm.submitEmail = submitEmail;

            function submitEmail() {
              
                return dataservice.submitEmail(vm.email)
                .then(function (data) {
                    logger.success("Subscription successful", null, null);

                });
            }

            $scope.isCollapsed = true;
        }

        return directive;
    }
})();
