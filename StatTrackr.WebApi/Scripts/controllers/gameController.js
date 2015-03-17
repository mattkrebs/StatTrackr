'use strict';
app.controller('gameController', ['$scope', 'gameService', '$route', function ($scope, gameService, $route) {

    $scope.game = {};

    gameService.getGameById($route.current.params.id).then(function (results) {
        
        $scope.game = results.data;

    }, function (error) {
        //alert(error.data.message);
    });


    $scope.buttonClick = function () {
        console.log($scope.game);
    };

}]);