(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('GalleryController', GalleryController);

    GalleryController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$stateParams', '$anchorScroll'];
    /* @ngInject */
    function GalleryController($rootScope, $timeout, config, logger, $stateParams, $anchorScroll) {

        var vm = this;
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
        }

    }
})();
