
routerApp.controller('EstacionarCtrl', function ($scope, $http, $cookies) {


    $('#placa').mask('ZZZ-9999');

    if ($cookies.idEstacionamento) {
        $scope.estacionar = new { idEstacionamento: $cookies.idEstacionamento };
    }

    $scope.estacionarVeiculo = function() {

    };

});