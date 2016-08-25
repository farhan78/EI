(function () {
    'use strict';
   
    angular
      .module('app.layout')
      .directive('topNav', topNav);

    /* @ngInject */
    function topNav() {
        var directive = {
            bindToController: true,
            controller: TopNavController,
            controllerAs: 'vm',
            restrict: 'EA',
            scope: {
                'navline': '='
            },
            templateUrl: 'app/layout/top-nav.html',
            replace: true
        };

        TopNavController.$inject = ['$scope'];

        /* @ngInject */
        function TopNavController($scope) {
            var vm = this;
            $scope.isCollapsed = true;
            $('#stuck_container').TMStickUp({});
        }

        return directive;
    }
})();
