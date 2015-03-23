var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap']);
app.config(function ($routeProvider) {

    $routeProvider.when("/home/:id?", {
        controller: "homeController",
        templateUrl: "/Templates/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/Templates/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/Templates/signup.html"
    });

    $routeProvider.when("/game/:id", {
        controller: "gameController",
        templateUrl: "/Templates/game.html"
    });
    $routeProvider.when("/team/:id", {
        controller: "teamController",
        templateUrl: "/Templates/team.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});


var serviceBase = 'http://localhost:44272/';
//var serviceBase = 'http://stattrackerwebapi.azurewebsites.net/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});