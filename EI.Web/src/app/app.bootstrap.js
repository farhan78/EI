(function () {
    bootstrapApplication();

    function bootstrapApplication() {
        angular.element(document).ready(function () {
            angular.bootstrap(document, ['app']);
        });
    }
}());