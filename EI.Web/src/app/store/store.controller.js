(function () {
    'use strict';

    angular
      .module('app.store')
      .controller('StoreController', StoreController);

    StoreController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function StoreController($rootScope, $timeout, config, logger, $stateParams, $anchorScroll) {

        var vm = this;
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
        }

    }
})();
