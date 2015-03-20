'use strict';
app.controller('teamController', ['$scope', 'gameService', '$route', '$modal', function ($scope, gameService, $route, $modal) {
    $scope.master = {};
    $scope.team = {};
    $scope.player = {};


    $scope.showPlayerForm = false;

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

    $scope.addPlayer = function (player) {
        //$scope.team.Players.push(player);
        gameService.addPlayerToTeam($scope.team.TeamId, player).then(function (result) {
            $scope.team = result.data;
        });
    };

    $scope.openAddTeamModal = function (size) {
            $modal.open({
                templateUrl: '/Templates/addPlayerModal.html',
                size: size,
                controller: function ($scope, $modalInstance, team) {
                    $scope.team = team;
                    gameService.getPlayers().then(function (result) {
                        $scope.players = result.data;

                        $scope.selected = {
                            item: $scope.players[0]
                        };
                    });

                   
                    $scope.ok = function () {
                        gameService.addPlayerToTeam(team.TeamId, $scope.selected.item).then(function (result) {
                            $scope.team = result.data;
                            $modalInstance.close($scope.team);
                        });
                       
                    };

                    $scope.cancel = function () {
                        $modalInstance.dismiss('cancel');
                    };
                },
                resolve:  {
                    team: function () {
                        return $scope.team;
                    }
                }
            }).result.then(function (team) {
                //save player to team...create if you have to
                $scope.team = team;
                //gameService.addPlayerToTeam(team.TeamId, ).then(function (result) {
                //    $scope.team = result.data;
                //});
            });
    };



    $scope.openNewTeamModal = function (size) {
        var modelInstance = $modal.open({
            templateUrl: '/Templates/newPlayerModal.html',
            size: size,
            controller: function ($scope, $modalInstance, player, team) {
                $scope.player = player;
                $scope.team = team;
                $scope.submit = function () {
                    gameService.addPlayerToTeam(team.TeamId, player).then(function (result) {
                        $scope.team = result.data;
                        $modalInstance.close($scope.team);
                    });
                }
                $scope.cancel = function () {
                    $modalInstance.dismiss('cancel');
                };
            },
            resolve: {
                player: function () {
                    return $scope.player;
                },
                team: function () {
                    return $scope.team;
                }
            }

        });

        modelInstance.result.then(function(team){
            $scope.team = team;
        });
    };

}]);