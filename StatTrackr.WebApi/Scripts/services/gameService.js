'use strict';
app.factory('gameService', ['$http','ngAuthSettings',  function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
  
    var gameServiceFactory = {};

    var _getGames = function () {

        return $http.get(serviceBase + 'api/game/').then(function (results) {
            return results;
        });
    };
    var _getGameById = function (id) {

        return $http.get(serviceBase + 'api/game/' + id).then(function (results) {
            return results;
        });
    };

    gameServiceFactory.getGames = _getGames;
    gameServiceFactory.getGameById = _getGameById;




    var _getTeamById = function (id) {
        return $http.get(serviceBase + 'api/team/' + id).then(function (results) {
            return results;
        });
    };

    //Team Functions
    var _saveTeam = function (team) {
        if (team.TeamId == null) {
            return $http.post(serviceBase + 'api/team/', team).then(function (results) {
                return results;
            }, function (error) { return error;});

        } else {
            return $http.put(serviceBase + 'api/team/' + team.TeamId, team).then(function (results) {
                return results;
            }, function (error) { return error; });
        }
    };

   

    gameServiceFactory.getTeamById = _getTeamById;
    gameServiceFactory.saveTeam = _saveTeam;


    //Player Functions

    var _addPlayerToTeam = function (teamid, player) {
        return $http.post(serviceBase + 'api/addplayertoteam/' + teamid, player).then(function (results) {
            return results;
        }, function (error) { return error; });
    }

    var _allPlayers = function () {
        return $http.get(serviceBase + 'api/player/').then(function (results) {
            return results;
        }, function (error) { return error; });
    }

    gameServiceFactory.addPlayerToTeam = _addPlayerToTeam;
    gameServiceFactory.getPlayers = _allPlayers;


    return gameServiceFactory;
}]);