//'use strict';
angular.module('TourneyTime').controller('profileController', ['$scope', '$location', 'authService', 'ngAuthSettings', function ($scope, playerService, authService, ordersService) {

    $scope.orders = [];

    ordersService.getOrders(authService.authentication.userName).then(function (results) {

        $scope.loggedInUser = results.data;

    }, function (error) {
        //alert(error.data.message);
        $scope.ordersError = error.data.message;
    });

    $scope.logout = function () {
        authService.logOut();
        $scope.message = "Logged out successfully";
    }

}]);