angular
.module('TourneyTime').service("gameService", function ($http, API_END_POINT) {
    // public methods

    function addGame(game) {
        //$http.post(API_END_POINT + "/Players", data);
        $http.post(API_END_POINT + '/api/Account/AddGame', game);
    }

    function addGameToPlayer(game, auth) {
        //$http.post(API_END_POINT + "/Players", data);
        $http.post(API_END_POINT + '/api/Account/AddGameToPlayer', game, auth);
    }

    // public api
    return {
        addGame: addGame,
        addGameToPlayer : addGameToPlayer
    }
})