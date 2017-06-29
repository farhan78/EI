(function () {
    'use strict';

    angular
      .module('app.gallery')
      .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
                 {
                     state: 'content.gallery',
                     config: {
                         url: '/gallery',
                         templateUrl: 'app/gallery/gallery.html',
                         //controller: 'GalleryController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.events',
                     config: {
                         url: '/events',
                         templateUrl: 'app/gallery/events.html',
                         controller: 'EventsController',
                         controllerAs: 'vm'
                     }
                 },
                 {
                     state: 'content.gallery.posters',
                     config: {
                         url: '/posters',
                         templateUrl: 'app/other/comingsoon.html',
                         controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.models',
                     config: {
                         url: '/models',
                         templateUrl: 'app/other/comingsoon.html',
                         controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.publications',
                     config: {
                         url: '/publications',
                         templateUrl: 'app/other/comingsoon.html',
                         controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.facebook',
                     config: {
                         url: '/facebook',
                         templateUrl: 'app/other/comingsoon.html',
                         controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 }
         
        ];
    }
})();
