//'use strict';
angular.module('TourneyTime')
.controller('HomeController', function ($scope, playerService, authService, ordersService) {

    playerService.getPlayers(function (data) {
        $scope.players = data;
    });

    $scope.logout = function () {
        authService.logOut();
        $scope.message = "Logged out successfully";
    }

});