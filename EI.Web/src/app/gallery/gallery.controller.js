(function () {
    'use strict';

    angular
      .module('app.gallery')
      .controller('GalleryController', GalleryController);

    GalleryController.$inject = ['$rootScope','$q', '$timeout', 'config', 'logger', '$stateParams','galleryDataService', '$anchorScroll'];
    /* @ngInject */
    function GalleryController($rootScope, $q, $timeout, config, logger, $stateParams, galleryDataService, $anchorScroll) {

        var vm = this;
        vm.events = null;
       
        activate();

        function activate() {
            $anchorScroll($('#mainContentDiv'));
            vm.params = $stateParams;
         
            new juicebox({
                baseUrl: 'app/gallery/'+vm.params.galleryType + '/'  + vm.params.id + '/',
                containerId: 'juicebox-container',
                galleryWidth: '100%',
                galleryHeight: '100%',
                backgroundColor: 'rgba(0,0,0,1)'
            });
        }

       
    }
})();
