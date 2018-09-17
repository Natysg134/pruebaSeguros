var EditarSeguroController = function ($scope, $uibModalInstance, data, Api) {
    $scope.Seguro = data;
    $scope.TipoRiesgos = null;
    $scope.Clientes = null;

    $scope.cambiarRiesgo = function (loc) {
        $scope.selected = loc;
        $scope.Seguro.Riesgo = loc.Id;
    }


    $scope.cambiarCliente = function (loc) {
        $scope.selectedCliente = loc;
        $scope.Seguro.ClienteAsociado = loc.Identificacion;
    }

    function GetTipoRiesgo() {
        Api.GetApiCall("Seguros", "GetTipoRiesgos", function (event) {
            if (event.hasErrors == true) {
                $scope.setError(event.error);
            } else {
                $scope.TipoRiesgos = event.result;
                $scope.selected = $scope.setRiesgoDefinido($scope.Seguro.Riesgo);
            }
        });
    }

    function GetClientes() {
        Api.GetApiCall("Seguros", "GetClientes", function (event) {
            if (event.hasErrors == true) {
                $scope.setError(event.error);
            } else {
                $scope.Clientes = event.result;
                $scope.selectedCliente = $scope.setClienteDefinido($scope.Seguro.Cliente);
            }
        });
    }

    $scope.PutSeguro = function () {
        Api.PutApicall("Seguros", "Put", $scope.Seguro, function (event) {
            
        });
        GetClientes();
    };

    $scope.setRiesgoDefinido = function (id) {
        var count = 0;
        while (true) {
            if ($scope.TipoRiesgos[count].Id == id) {
                return $scope.TipoRiesgos[count];
            }
            else {
               count += 1;
                }
        }
    };

    $scope.setClienteDefinido = function (id) {
        var count = 0;
        while (true) {
            if ($scope.Clientes[count].Id == id) {
                return $scope.Clientes[count];
            }
            else {
                count += 1;
            }
        }
    };

    GetClientes();
    GetTipoRiesgo();

}

