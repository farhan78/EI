(function () {
    'use strict';

    angular
      .module('app.services')
      .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
           {
               state: 'content.services',
               config: {
                   url: '/services',
                   templateUrl: 'app/services/services.html',
                   controller: 'ServicesController',
                   controllerAs: 'vm',
               }
           },
            {
                state: 'content.services.exhibition-hire',
                config: {
                    url: '/exhibition-hire',
                    templateUrl: 'app/services/exhibition-hire.html',
                    controller: 'ServicesController',
                    controllerAs: 'vm',
                }
            },
            {
                state: 'content.services.graphic-design',
                config: {
                    url: '/graphic-design',
                    templateUrl: 'app/services/graphic-design.html',
                    controller: 'ServicesController',
                    controllerAs: 'vm',
                }
            },
            {
                state: 'content.services.permanent-build',
                config: {
                    url: '/permanent-build',
                    templateUrl: 'app/services/permanent-build.html',
                    controller: 'ServicesController',
                    controllerAs: 'vm',
                }
            },
            {
                state: 'content.services.design-and-printing',
                config: {
                    url: '/design-and-printing',
                    templateUrl: 'app/services/design-and-printing.html',
                    controller: 'ServicesController',
                    controllerAs: 'vm',
                }
            }
        ];
    }
})();
