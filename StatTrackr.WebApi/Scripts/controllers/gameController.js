'use strict';
app.controller('gameController', ['$scope', 'gameService', function ($scope, gameService) {

    $scope.orders = "";

    gameService.getGame(1).then(function (results) {

        $scope.game = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);