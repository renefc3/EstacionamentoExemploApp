var routerApp = angular.module('meuEstacionamento', ['ngRoute']);


routerApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'views/home.html',
            controller: 'HomeCtrl'
        })
        .when('/estacionar', {
            templateUrl: 'views/estacionar/estacionar-veiculo.html',
            controller: 'EstacionarCtrl'
        })

        .when('/retirar', {
            templateUrl: 'views/estacionar/retirar-veiculo.html',
            controller: 'RetirarCtrl'
        })
        .when('/estacionamento', {
                templateUrl: 'views/estacionamento/busca.html',
                controller: 'EstacionamentoBuscaCtrl'
        })
    ;


}]);


