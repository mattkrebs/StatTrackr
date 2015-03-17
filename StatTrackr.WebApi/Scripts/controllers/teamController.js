'use strict';
app.controller('teamController', ['$scope', 'gameService', '$route', function ($scope, gameService, $route) {
    $scope.master = {};
    $scope.team = {};

    gameService.getTeamById($route.current.params.id).then(function (results) {

        $scope.team = results.data;

    }, function (error) {
        alert(error.data.message);
    });

    

    $scope.update = function (team) {
        gameService.saveTeam(team).then(function (result) {
            $scope.team = result.data;
        });


        $scope.master = angular.copy($scope.team)
    };

    $scope.reset = function () {
        $scope.team = angular.copy($scope.master)
    }



}]);