(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('PaypalController', PaypalController);

    PaypalController.$inject = ['$scope', '$q', 'config', 'logger', 'storeDataService', '$stateParams', '$timeout', '$anchorScroll'];
    /* @ngInject */
    function PaypalController($scope, $q, config, logger, storeDataService, $stateParams, $timeout, $anchorScroll) {

        var vm = this;
      
        vm.invoice = $stateParams.invoice;
        vm.returnUrl = null;
        vm.loading = true;
        vm.goToTop = goToTop;
        activate();
        function activate() {
            $anchorScroll($('#mainContentDiv'));
            vm.returnUrl = window.location.origin + window.location.pathname + '#/store/thankyou?invoiceId=' + vm.invoice.InvoiceId;
            //document.Paypal.submit();

        }

        $scope.$on('$viewContentLoaded', function (event) {
            $timeout(function () {
               
                document.Paypal.submit();
            }, 100);
        });

        function goToTop() {
            $anchorScroll($('#Paypal'));
        }
    }
})();
