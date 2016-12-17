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
                 },
                 {
                     state: 'content.about.news',
                     config: {
                         url: '/news',
                         templateUrl: 'app/about/news.html',
                         controller: 'NewsController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.about.reports',
                     config: {
                         url: '/reports',
                         templateUrl: 'app/about/reports.html',
                         controller: 'ReportsController',
                         controllerAs: 'vm',
                     }
                 },
                {
                    state: 'content.about.events',
                    config: {
                        url: '/events',
                        templateUrl: 'app/about/events.html',
                        controller: 'EventListController',
                        controllerAs: 'vm',
                    }
                },
                {
                    state: 'content.about.testimonials',
                    config: {
                        url: '/testimonials',
                        templateUrl: 'app/about/testimonials.html',
                        controller: 'TestimonialsController',
                        controllerAs: 'vm',
                    }
                }
        ];
    }
})();
