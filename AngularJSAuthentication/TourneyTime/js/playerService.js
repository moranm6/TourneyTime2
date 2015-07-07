angular
.module('TourneyTime').service("playerService", function ($http, API_END_POINT) {
    // public methods

    // takes a callback that takes one parameter data
    function getPlayers(callback) {
        $http({
            method: "GET",
            url: API_END_POINT + "/Players"
        }).success(callback);
    }

    function addPlayer(data) {
        //$http.post(API_END_POINT + "/Players", data);
        $http.post(API_END_POINT + '/Players', data);   
    }

    function registerUser(data) {
        
        $http.post(API_END_POINT + '/api/Account/Register', data);
    }

    function loginUser(data) {

        $http.post(API_END_POINT + '/Token', data);
    }

    // public api
    return {
        getPlayers: getPlayers,
        addPlayer: addPlayer,
        registerUser: registerUser,
        loginUser: loginUser
       
    }
})