var App = angular.module('App', ['ngRoute', 'ui.bootstrap', 'chart.js']);

App.service('Api', ['$http', ApiService]);  

App.controller('MainController', MainController);
App.controller('GridController', GridController);
App.controller('EditarSeguroController', EditarSeguroController);
App.controller('CrearSeguroController', CrearSeguroController);

var configFunction = function ($routeProvider, $httpProvider) {
    $routeProvider.
        when('/grid', {
            templateUrl: 'SPA/Views/Grid.html',
            controller: GridController
        })
        .otherwise({
            redirectTo: function () {
                return '/grid';
            }
        });
}
configFunction.$inject = ['$routeProvider', '$httpProvider'];

App.config(configFunction);