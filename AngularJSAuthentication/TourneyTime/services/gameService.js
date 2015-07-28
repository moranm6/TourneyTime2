angular
.module('TourneyTime').service("gameService", function ($http, API_END_POINT) {
    // public methods

    function addGameToPlayer(game, user) {
        //$http.post(API_END_POINT + "/Players", data);
        $http.post(API_END_POINT + 'api/Account/AddGameToPlayer', game, user);
    }

    // public api
    return {
        addGameToPlayer: addGameToPlayer
    }
})