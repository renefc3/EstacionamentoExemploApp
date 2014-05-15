routerApp.controller('RetirarCtrl', function ($scope) {

    if ($cookies.idEstacionamento) {
        $scope.estacionar = new { idEstacionamento: $cookies.idEstacionamento };
    }

    $scope.estacionarVeiculo = function () {

    };


});