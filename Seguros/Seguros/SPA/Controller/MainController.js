var MainController = function ($scope, Api) {
    $scope.models = {
        locations: [
            
        ]
    };
    $scope.selectedLocation = null;

    $scope.changeLocation = function (loc) {
        $scope.selectedLocation = loc;
    }

    function GetSeguros() {
        Api.GetApiCall("Seguros", "GetLetters", function (event) {

            if (event.hasErrors == true) {
                alert("Error Cargando Seguros: " + event.error);
            } else {
                $scope.models.locations = event.result;
                if ($scope.models.locations.length > 0) {
                    $scope.selectedLocation = $scope.models.locations[0];
                }
            }
        });
    }

    GetSeguros();
}

MainController.$inject = ['$scope', 'Api'];