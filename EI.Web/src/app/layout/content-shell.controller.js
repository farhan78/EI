(function () {
    'use strict';

    angular
      .module('app.layout')
      .controller('ContentShellController', ContentShellController);

    ContentShellController.$inject = ['config', 'logger','storeDataService','$q'];
    /* @ngInject */
    function ContentShellController(config, logger, storeDataService, $q) {
       
        var vm = this;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.basket = [];

        //vm.getBasketContent = getBasketContent;


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

            //var promises = [];
            //promises.push(getBasketContent());

            //return $q.all(promises)
            //    .then(function () {


            //    });
          
        }

        function getBasketContent()
        {
            return storeDataService.getBasketContent()
               .then(function (data) {
                   debugger;
                   vm.basket = data;
                   vm.loading = false;
               });
        }

    }
})();
