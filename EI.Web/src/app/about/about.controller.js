(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('AboutController', AboutController);

    AboutController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function AboutController($rootScope, $timeout, config, logger, $stateParams, $anchorScroll) {

        var vm = this;
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
        }

    }
})();
