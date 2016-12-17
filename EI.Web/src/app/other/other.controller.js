(function () {
    'use strict';

    angular
      .module('app.about')
      .controller('OtherController', OtherController);

    OtherController.$inject = ['$anchorScroll'];
    /* @ngInject */
    function OtherController($anchorScroll) {

        var vm = this;
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
        }

    }
})();
