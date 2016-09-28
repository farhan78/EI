(function () {
    'use strict';

    angular
      .module('app.layout')
      .controller('ContentShellController', ContentShellController);

    ContentShellController.$inject = ['config', 'logger'];
    /* @ngInject */
    function ContentShellController(config, logger) {

        var vm = this;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;

        vm.navline = {
            title: config.appTitle,
            text: 'Created by Hartech Solutions Ltd.',
            link: 'http://twitter.com/john_papa'
        };

        activate();

        function activate() {

            $().UItoTop({
                easingType: 'easeOutQuart',
                containerClass: 'toTop fa fa-angle-up'
            });
          
        }

   
    }
})();
