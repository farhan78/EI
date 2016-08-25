(function () {
    'use strict';

    angular
      .module('app.core')
      .run(appRun);

    /* @ngInject */
    function appRun(routerHelper) {
        var otherwise = '/home';
        routerHelper.configureStates(getStates(), otherwise);
    }

    function getStates() {

        return [
          {
              state: '404',
              config: {
                  url: '/404',
                  templateUrl: 'app/core/404.html',
                  title: '404'
              }
          },
          {
              state: 'home',
              config: {
                  url: '/home',
                  templateUrl: 'app/layout/home.html',
                  controller: 'HomeController',
                  controllerAs: 'vm',
                  title: 'home'
              }
          },
          {
               state: 'content',
               config: {
                   //url: '',
                   templateUrl: 'app/layout/content-shell.html',
                   controller: 'ContentShellController',
                   controllerAs: 'vm',
                   title: 'content'
               }
           },
        ];
    }
})();
