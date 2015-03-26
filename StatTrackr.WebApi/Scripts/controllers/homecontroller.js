'use strict';
app.controller('homeController', ['$scope', 'gameService','$route', function ($scope, gameService, $route) {
    $scope.currentGame = null;
    $scope.games = [];
    if ($route.current.params.id) {
        gameService.getGameById($route.current.params.id).then(function (results) {

            $scope.currentGame = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }


    $scope.setGame = function (id) {
        gameService.getGameById(id).then(function (results) {

            $scope.currentGame = results.data;

        }, function (error) {
            //alert(error.data.message);
        });
    }

    gameService.getGames().then(function (results) {

        $scope.games = results.data;

    }, function (error) {
        //alert(error.data.message);
    });
  


}]);