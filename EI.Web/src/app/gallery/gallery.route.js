﻿(function () {
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
                         controller: 'GalleryController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.events',
                     config: {
                         url: '/events',
                         templateUrl: 'app/gallery/events.html',
                         controller: 'GalleryController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.gallery.posters',
                     config: {
                         url: '/posters',
                         templateUrl: 'app/gallery/posters.html',
                         controller: 'GalleryController',
                         controllerAs: 'vm',
                     }
                 }
         
        ];
    }
})();