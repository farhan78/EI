(function () {
    'use strict';

    angular
      .module('app.about')
      .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
                 {
                     state: 'content.about',
                     config: {
                         url: '/about',
                         templateUrl: 'app/about/about.html',
                         controller: 'AboutController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.about.what-we-do',
                     config: {
                         url: '/what-we-do',
                         templateUrl: 'app/about/what-we-do.html',
                         controller: 'AboutController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.about.portfolio',
                     config: {
                         url: '/portfolio',
                         templateUrl: 'app/about/portfolio.html',
                         controller: 'AboutController',
                         controllerAs: 'vm',
                     }
                 }
        ];
    }
})();
