var routerApp = angular.module('meuEstacionamento', ['ngRoute']);


routerApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'views/home.html',
            controller: 'HomeCtrl',
            JsFiles: ['/js/app/controllers/HomeCtrl.js']
        });


}]);


