//'use strict';
angular
.module('TourneyTime').factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    //var _getOrders = function () {

    //    return $http.get(serviceBase + 'api/orders').then(function (results) {
    //        return results;
    //    });
    //};

    var _getOrders = function (username) {

        return $http.get(serviceBase + 'api/orders/' + username).then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getOrders = _getOrders;

    return ordersServiceFactory;

}])