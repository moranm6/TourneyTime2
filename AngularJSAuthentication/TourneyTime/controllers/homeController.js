//'use strict';
angular.module('TourneyTime').controller('homeController', ['$scope', 'playerService', 'authService', 'ordersService', function ($scope, playerService, authService, ordersService) {

    playerService.getPlayers(function (data) {
        $scope.players = data;
    });

    $scope.authentication = authService.authentication;

    $scope.registerUser = playerService.registerUser;

    $scope.register = function (firstName, lastName, username, email, password, confirmPassword) {

        var user = {
            FirstName: firstName,
            LastName: lastName,
            UserName: username,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword
        }
        $scope.registerUser(user);
        authService.saveRegistration($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;
            $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
            //startTimer();

        },
        function (response) {
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            $scope.message = "Failed to register user due to:" + errors.join(' ');
        });

    }

    $scope.logout = function () {
        authService.logOut();
        $scope.message = "Logged out successfully";
    }

}]);