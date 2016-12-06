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

        ContentTopNavController.$inject = ['$scope', '$location', '$compile','$state','storeDataService'];

        /* @ngInject */
        function ContentTopNavController($scope, $location, $compile,$state, storeDataService) {
            var vm = this;
            //vm.linkTo = linkTo;
       
            vm.invoice = null;
            vm.basket = [];
            vm.totalItems = 0;
            getBasketContent();

            function getBasketContent() {
              
                return storeDataService.getBasketContent()
                .then(function (data) {
                   
                    if ($state.current.name !== 'content.store.thankyou') {
                        vm.invoice = data;
                        vm.basket = data.InvoiceItems;

                        angular.forEach(vm.basket, function (item) {

                            vm.totalItems += item.Quantity;
                        });
                    }
                        
                });
            };
       
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
