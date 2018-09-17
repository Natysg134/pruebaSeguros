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
        Cliente: "",
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
        Api.PostApicall("Seguros", "Post", $scope.Seguro, function (event) {
 
        });
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