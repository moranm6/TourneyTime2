angular.module('TourneyTime', ['ionic', 'LocalStorageModule'])

.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/')


    $stateProvider.state('home', {
        url: '/home',
        views: {
            home: {
                templateUrl: 'home.html'
            }
        }
    })

    $stateProvider.state('help', {
        url: '/help',
        views: {
            help: {
                templateUrl: 'help.html',
                controller: 'loginController'
            }
        }
    })

    $stateProvider.state('register', {
        url: '/register',
        views: {
            register: {
                templateUrl: 'register.html',
                controller: 'homeController'
            }
        }
    })

    $stateProvider.state('profile', {
        url: '/profile',
        views: {
            profile: {
                templateUrl: 'profile.html',
                controller: 'profileController'
            }
        }
    })

})

.constant('SERVICE_BASE', 'http://localhost:56429/')



.constant('API_END_POINT', 'http://localhost:56429')


.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost:56429/',
    clientId: 'ngAuthApp'
})

.config(function($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    })

.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

var serviceBase = 'http://localhost:56429/'