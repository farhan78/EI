(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('AboutController', AboutController);

    AboutController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$stateParams'];
    /* @ngInject */
    function AboutController($rootScope, $timeout, config, logger, $stateParams) {

        var vm = this;
        activate();

        function activate() {
            //debugger;
            //vm.params =  $stateParams;
        }

    }
})();
