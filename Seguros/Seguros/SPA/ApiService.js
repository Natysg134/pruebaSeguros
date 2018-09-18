var ApiService = function ($http) {
    var result;
    this.GetApiCall = function (controllerName, method, callback) {
        result = $http.get('api/' + controllerName + '/' + method).success(
            function (data, status) {
                var event = {
                    result: data,
                    hasErrors: false
                };
                callback(event);
            }).error(
                function (data, status) {
                    var event = {
                        result: "",
                        hasErrors: true,
                        error: data
                    };
                    callback(event);
                }
            );
    }


    this.PostApicall = function (controllerName, method, obj, callback) {
        result = $http.post('api/' + controllerName + '/' + method, obj).then(function (response) {
            callback(response);
        });
    }

    this.PutApicall = function (controllerName, method, obj, callback) {
        result = $http.put('api/' + controllerName + '/' + method, obj).then(function (response) {
            callback( response);
        });
    }

    this.DeleteApicall = function (controllerName, method, obj, callback) {
        result = $http.delete('api/' + controllerName + '/' + obj).then(function (response) {
            callback(response);
        });
    }

}