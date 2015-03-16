'use strict';
app.factory('gameService', ['$http', function ($http) {
    var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
    var gameServiceFactory = {};

    var _getGame = function (id) {

        return $http.get(serviceBase + 'api/game/' + id).then(function (results) {
            return results;
        });
    };

    gameServiceFactory.getGame = _getGame;

    return gameServiceFactory;
}]);