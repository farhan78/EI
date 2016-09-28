(function() {
  'use strict';

  angular
    .module('app.core', [
      'ngAnimate', 'ngSanitize',
      'blocks.exception', 'blocks.logger', 'blocks.router',
      'ui.router', 'ngplus', 'angular-include-replace', 'ui.bootstrap', 'ngAnimate','infinite-scroll'
    ]);
})();
