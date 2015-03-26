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

    var _getTeams = function () {
        return $http.get(serviceBase + 'api/team/').then(function (results) {
            return results;
        });
    }

    gameServiceFactory.getTeamById = _getTeamById;
    gameServiceFactory.saveTeam = _saveTeam;
    gameServiceFactory.getTeams = _getTeams;

    //Player Functions

    var _addPlayerToTeam = function (teamid, player) {
        return $http.post(serviceBase + 'api/addplayertoteam/' + teamid, player).then(function (results) {
            return results;
        }, function (error) { return error; });
    }

    var _allPlayers = function (id) {
        return $http.get(serviceBase + 'api/GetAvailablePlayers/' + id).then(function (results) {
            return results;
        }, function (error) { return error; });
    }

    gameServiceFactory.addPlayerToTeam = _addPlayerToTeam;
    gameServiceFactory.getAvailablePlayers = _allPlayers;


    //Game Play Functions

    var _takeStat = function (stat) {
        return $http.post(serviceBase + 'api/statline/',stat).then(function (results) {
            return results;
        }, function (error) { return error; });
    }

    var _getGameStatsByGameId = function (id) {
        return $http.get(serviceBase + 'api/GetStatsForGame/' + id).then(function (results) {
            return results;
        });
    };


    gameServiceFactory.takeStat = _takeStat;
    gameServiceFactory.getGameStats = _getGameStatsByGameId;
    return gameServiceFactory;
}]);