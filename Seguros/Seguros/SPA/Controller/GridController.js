var GridController = function ($scope, $uibModal, $log, Api) {
    $scope.datos = {
        seguros: {
            totalitems: 0,
            paginaActual: 1,
            itemsporpagina: 10,
            datos: []
        }
    };


    function GetSeguros() {
        Api.GetApiCall("Seguros", "GetSeguros", function (event) {
            if (event.hasErrors == true) {
                $scope.setError(event.error);
            } else {
                $scope.datos.seguros.datos = event.result;             
            }
        });
    }

    GetSeguros();



    $scope.abrirSeguro = function (seguro) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/SPA/Views/EditarSeguro.html',
            controller: 'EditarSeguroController',
            size: "",
            resolve: {
                data: seguro
            }
        });

    }

    $scope.crearSeguro = function (seguro) {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/SPA/Views/CrearSeguro.html',
            controller: 'CrearSeguroController',
            size: "",
            resolve: {
                data: seguro
            }
        });

    }

    $scope.DeleteApicall = function (Id) {
        Api.DeleteApicall("Seguros", "Delete", Id, function (event) {
            location.reload();
        });
    };

}

GridController.$inject = ['$scope', '$uibModal', '$log', 'Api'];