'use strict';
app.controller('homeController', ['$scope', 'gameService', function ($scope, gameService, id) {
    $scope.currentGame = null;
    $scope.games = [];
    


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