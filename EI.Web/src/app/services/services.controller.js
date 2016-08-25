(function () {
    'use strict';

    angular
      .module('app.services')
      .controller('ServicesController', ServicesController);

    ServicesController.$inject = ['$rootScope', '$timeout', 'config', 'logger'];
    /* @ngInject */
    function ServicesController($rootScope, $timeout, config, logger) {

        var vm = this;
        activate();

        function activate() {
           
        }

    }
})();
