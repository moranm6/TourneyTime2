//'use strict';
angular
.module('TourneyTime').controller('profileController', ['$scope', '$location', 'playerService', 'authService', 'ngAuthSettings', 'ordersService', 'gameService',
    function ($scope, $location, playerService, authService, ngAuthSettings, ordersService, gameService) {
    
    $scope.authentication = authService.authentication;

    $scope.orders = [];

    ordersService.getOrders(authService.authentication.userName).then(function (results) {

        $scope.loggedInUser = results.data;

    }, function (error) {
        //alert(error.data.message);
        $scope.ordersError = error.data.message;
    });

        var testGame = {
            title: 'testGame',
            id: 7
        }

    $scope.addGameToPlayer = function() {
        gameService.addGameToPlayer(testGame, authService.authentication);
        $scope.message = "Added " + testGame.title + " to " + authService.authentication.userName;
        console.log("Added " + testGame.title + " to " + authService.authentication.userName);
        }

    $scope.addGame = function () {
        gameService.addGame(testGame);
        $scope.message = "Added " + testGame.title + " to ";// + loggedInUser.firstName;
        console.log("Added " + testGame.title + " to ");// + loggedInUser.firstName);
    }

    $scope.logout = function () {
        authService.logOut();
        $scope.message = "Logged out successfully";
    }

}]);