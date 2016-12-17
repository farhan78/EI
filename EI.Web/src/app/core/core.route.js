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
                  settings: {
                      external:false
                  },
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
          {
               state: 'gallery-viewer',
               config: {
                   url: '/gallery-viewer/:galleryType/:id',
                   templateUrl: 'app/gallery/index.html',
                   controller: 'GalleryController',
                   controllerAs: 'vm',
                   title: 'gallery'
               }
          },
          {
              state: 'content.disclaimer',
              config: {
                  url: '/disclaimer',
                  templateUrl: 'app/other/disclaimer.html',
                  controller: 'OtherController',
                  controllerAs: 'vm',
              }
          },
          {
              state: 'content.privacy-policy',
              config: {
                  url: '/privacy-policy',
                  templateUrl: 'app/other/privacy-policy.html',
                  controller: 'OtherController',
                  controllerAs: 'vm',
              }
          },
          {
              state: 'content.contact',
              config: {
                  url: '/contact',
                  templateUrl: 'app/other/contact.html',
                  controller: 'OtherController',
                  controllerAs: 'vm',
              }
          },
          {
              state: 'content.support',
              config: {
                  url: '/support-us',
                  templateUrl: 'app/other/support.html',
                  controller: 'OtherController',
                  controllerAs: 'vm',
              }
          }
        ];
    }
})();
