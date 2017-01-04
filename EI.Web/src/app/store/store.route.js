(function () {
    'use strict';

    angular
      .module('app.store')
      .run(appRun);

    appRun.$inject = ['routerHelper'];
    /* @ngInject */
    function appRun(routerHelper) {
        var otherwise = '/404';
        routerHelper.configureStates(getStates(), otherwise);
    }

    function getStates() {
        return [
                 {
                     state: 'content.store',
                     config: {
                         url: '/store',
                         templateUrl: 'app/store/store.html',
                         controller: 'StoreController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.books',
                     config: {
                         url: '/publications',
                         templateUrl: 'app/store/books.html',
                         controller: 'BooksController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.book-detail',
                     config: {
                         url: '/publication-detail',
                         templateUrl: 'app/store/book-detail.html',
                         controller: 'BookDetailController',
                         controllerAs: 'vm',
                         params: {
                             book: {
                                 value: null,
                                 squash: true,
                             }
                         }
                     }
                 },
                 {
                     state: 'content.store.leaflets',
                     config: {
                         url: '/leaflets',
                         templateUrl: 'app/store/leaflets.html',
                         controller: 'LeafletsController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.leaflet-detail',
                     config: {
                         url: '/leaflet-detail',
                         templateUrl: 'app/store/leaflet-detail.html',
                         controller: 'LeafletDetailController',
                         controllerAs: 'vm',
                         params: {
                             leaflet: {
                                 value: null,
                                 squash: true,
                             }
                         }
                     }
                 },
                 {
                     state: 'content.store.posters',
                     config: {
                         url: '/posters',
                         templateUrl: 'app/other/comingsoon.html',
                         //controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.stock-photos',
                     config: {
                         url: '/stock-photos',
                         templateUrl: 'app/other/comingsoon.html',
                         //controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.hardware',
                     config: {
                         url: '/hardware',
                         templateUrl: 'app/other/comingsoon.html',
                         //controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                     state: 'content.store.free-downloads',
                     config: {
                         url: '/free-downloads',
                         templateUrl: 'app/other/comingsoon.html',
                         //controller: 'PostersController',
                         controllerAs: 'vm',
                     }
                 },
                 {
                      state: 'content.store.basket',
                      config: {
                          url: '/shopping-basket',
                          templateUrl: 'app/store/basket.html',
                          controller: 'BasketController',
                          controllerAs: 'vm'
                      }
                 },
                  {
                      state: 'content.store.paypal-processing',
                      config: {
                          url: '/paypal-processing',
                          templateUrl: 'app/store/paypal-processing.html',
                          controller: 'PaypalController',
                          controllerAs: 'vm',
                          params: {
                              invoice: {
                                  value: null,
                                  squash: true,
                              }
                          }
                      }
                  },
                  {
                      state: 'content.store.thankyou',
                      config: {
                          url: '/thankyou?invoiceId',
                          templateUrl: 'app/store/thankyou.html',
                          controller: 'BasketController',
                          controllerAs: 'vm'
                      }
                  },
                
        ];
    }
})();
