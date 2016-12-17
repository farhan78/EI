(function () {
    'use strict';

    angular
      .module('app.layout')
      .controller('HomeController', HomeController);

    HomeController.$inject = ['$rootScope', '$q', 'config', 'logger', '$compile', '$anchorScroll', 'storeDataService', 'aboutDataService'];
    /* @ngInject */
    function HomeController($rootScope, $q, config, logger, $compile, $anchorScroll, storeDataService, aboutDataService) {

        var vm = this;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.invoice = null;
        vm.basket = [];
        vm.totalItems = 0;
        vm.quote = null;
     
        vm.navline = {
            title: config.appTitle,
            text: 'Created by Hartech Solutions Ltd.',
            link: 'http://twitter.com/john_papa'
        };

        activate();

        function activate() {

            $('#stuck_container').TMStickUp({});

            var element = angular.element('.stuck_container.isStuck');
            $compile(element.contents())($rootScope);

            $('.sf-menu').superfish();

            $().UItoTop({
                easingType: 'easeOutQuart',
                containerClass: 'toTop fa fa-angle-up'
            });

            if (angular.element('.rd-mobilemenu').length === 0) {
                RDMobilemenu_autoinit('[data-type="navbar"]');

                var mobileMenu = angular.element('.rd-mobilemenu');
                $compile(mobileMenu.contents())($rootScope);
            }

            $anchorScroll($('#mainDiv'));

            var promises = [];
            promises.push(getBasketContent(), getQuote());

            return $q.all(promises)
                .then(function () {


                });
        }

        function getBasketContent() {

            return storeDataService.getBasketContent()
            .then(function (data) {

                vm.invoice = data;
                vm.basket = data.InvoiceItems;

                angular.forEach(vm.basket, function (item) {

                    vm.totalItems += item.Quantity;
                });

            });
        };

        function getQuote() {
            return aboutDataService.getRandomQuote()
            .then(function (data) {

                vm.quote = data;
            });
        }
    }
})();
