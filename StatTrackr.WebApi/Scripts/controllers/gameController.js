'use strict';
app.controller('gameController', ['$scope', 'gameService', '$route', function ($scope, gameService, $route) {
    $scope.player = {};

    $scope.game = {};
    $scope.gameClock = 1200;
    $scope.countdownattr = 0;//seconds
    $scope.gameStats = {};

    $scope.homeTeam = [];
    $scope.awayTeam = [];

    $scope.currentPeriod = 1;

    $scope.$broadcast('timer-set-countdown', 1300);
    $scope.startTimer = function () {
        $scope.$broadcast('timer-start');
        $scope.timerRunning = true;
    };

    $scope.stopTimer = function () {
        $scope.$broadcast('timer-stop');
        $scope.timerRunning = false;
    };

    $scope.$on('timer-tick', function (event, data) {
        $scope.gameClock = (data.millis / 1000);
        //console.log('Timer tick - data = ', (data.millis / 1000));
    });
    
    $scope.loadGame = function () {
        gameService.getGameStats($route.current.params.id).then(function (results) {
            $scope.gameStats = results.data;
            if (!$scope.timerRunning) {
                $scope.$broadcast('timer-set-countdown', $scope.gameStats.ClockTime);
                $scope.gameClock = $scope.gameStats.ClockTime;
            }
           // $scope.$broadcast('timer-reset');

        }, function (error) {
            //alert(error.data.message);
        });
    }
   

    gameService.getGameById($route.current.params.id).then(function (results) {        
        $scope.game = results.data;

        $scope.homeTeam = $scope.game.HomeTeam;
        $scope.awayTeam = $scope.game.AwayTeam;
        $scope.GameTime = $scope.game.GameTime;

    }, function (error) {
        //alert(error.data.message);
    });
   
   
    $scope.takeStat = function (statId) {
        var stat = {
            'GameId': $scope.game.GameId,
            'StatTypeId': statId,
            'ClockTime': $scope.gameClock,
            'PlayerId': $scope.player.selected.PlayerId,
            'TeamId': $scope.player.selected.TeamId,
            'Period': $scope.currentPeriod
        };
        gameService.takeStat(stat).then(function (result) {
            $scope.team = result.data;
            $scope.loadGame();
        });
    };


    $scope.loadGame();

}]);