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

    var _saveTeam = function (team) {
        if (team.TeamId == null) {
            $http.post(serviceBase + 'api/team/', team).then(function (response) {
                return respond;
            }, function (error) { return error;});

        } else {
            $http.put(serviceBase + 'api/team/' + team.TeamId, team).then(function (response) {
                return respond;
            }, function (error) { return error; });
        }
    };

   

    gameServiceFactory.getTeamById = _getTeamById;
    gameServiceFactory.saveTeam = _saveTeam;

    return gameServiceFactory;
}]);