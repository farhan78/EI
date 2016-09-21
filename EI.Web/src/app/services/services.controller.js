(function () {
    'use strict';

    angular
      .module('app.services')
      .controller('ServicesController', ServicesController);

    ServicesController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$anchorScroll'];
    /* @ngInject */
    function ServicesController($rootScope, $timeout, config, logger, $anchorScroll) {

        var vm = this;
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
        }

    }
})();
