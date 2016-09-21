(function() {
  'use strict';

  angular
    .module('app.layout')
    .controller('HomeController', HomeController);

  HomeController.$inject = ['$rootScope', '$timeout', 'config', 'logger', '$compile', '$anchorScroll'];
  /* @ngInject */
  function HomeController($rootScope, $timeout, config, logger, $compile, $anchorScroll) {

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
     
    }

  }
})();
