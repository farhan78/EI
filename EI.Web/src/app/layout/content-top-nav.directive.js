(function () {
    'use strict';

    angular
      .module('app.layout')
      .directive('contentTopNav', contentTopNav);

    /* @ngInject */
    function contentTopNav() {
        var directive = {
            bindToController: true,
            controller: ContentTopNavController,
            controllerAs: 'vm',
            restrict: 'EA',
            scope: {
                'navline': '='
            },
            templateUrl: 'app/layout/content-top-nav.html',
            replace: true
        };

        ContentTopNavController.$inject = ['$scope', '$location', '$compile'];

        /* @ngInject */
        function ContentTopNavController($scope, $location, $compile) {
            var vm = this;
            //vm.linkTo = linkTo;

            $('#stuck_container').TMStickUp({});
            var element = angular.element('.stuck_container.isStuck');
            $compile(element.contents())($scope);

            if (angular.element('.rd-mobilemenu').length === 0) {

                RDMobilemenu_autoinit('[data-type="navbar"]');

                var mobileMenu = angular.element('.rd-mobilemenu');
                $compile(mobileMenu.contents())($scope);
            }

            $('.sf-menu').superfish();
         
        }

        return directive;
    }
})();
