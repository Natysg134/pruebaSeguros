var CrearSeguroController = function ($scope, $uibModalInstance, Api) {
    $scope.Seguro = {
        Nombre: "",
        Descripcion: "",
        Cubrimiento: "",
        Cobertura: "",
        FechaInicio: "",
        Meses: "",
        Precio: "",
        Riesgo: "",
        ClienteAsociado: "",
    };
    $scope.TipoRiesgos = null;


    $scope.cambiarRiesgo = function (loc) {
        $scope.selected = loc;
        $scope.Seguro.Riesgo = loc.Id;
    }

    $scope.cambiarCliente = function (loc) {
        $scope.selectedCliente = loc;
        $scope.Seguro.Cliente = loc.Identificacion;
    }


    $scope.PostSeguro = function () {
        if ($scope.selected.Riesgo == "Alto" && $scope.Seguro.Cobertura > 50) {
            alert("Tipo de Riesgo Alto, cobertura no puede ser mayor a 50");
        }
        else {
            Api.PostApicall("Seguros", "Post", $scope.Seguro, function (event) {
                $uibModalInstance.dismiss('cancel');
                location.reload();
            });
        }
    };

    function GetTipoRiesgo() {
        Api.GetApiCall("Seguros", "GetTipoRiesgos", function (event) {
            if (event.hasErrors == true) {
                $scope.setError(event.error);
            } else {
                $scope.TipoRiesgos = event.result;
            }
        });
    }

    function GetClientes() {
        Api.GetApiCall("Seguros", "GetClientes", function (event) {
            if (event.hasErrors == true) {
                $scope.setError(event.error);
            } else {
                $scope.Clientes = event.result;
            }
        });
    }

    GetClientes();
    GetTipoRiesgo();

}