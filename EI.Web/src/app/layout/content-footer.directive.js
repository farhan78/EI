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

        ContentFooterController.$inject = ['$scope'];

        /* @ngInject */
        function ContentFooterController($scope) {
            var vm = this;
            $scope.isCollapsed = true;
        }

        return directive;
    }
})();
