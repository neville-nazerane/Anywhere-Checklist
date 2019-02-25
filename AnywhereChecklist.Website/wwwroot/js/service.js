(function () {
    'use strict';

    angular
        .module('app')
        .service('dataUpdates', function ($rootScope, httpClient) {

            const connection = new signalR.HubConnectionBuilder()
                .withUrl(httpClient.getBase() + "/dataUpdates")
                .configureLogging(signalR.LogLevel.Information)
                .build();

            connection.on("checkListAdded", function (added) {
                $rootScope.$broadcast("checkListAdded", added);
            });

            connection.on("checkListUpdated", function (updated) {
                $rootScope.$broadcast("checkListUpdated", updated);
            });

            connection.on("checkListDeleted", function (id) {
                $rootScope.$broadcast("checkListDeleted", id);
            });

            connection.on("checkListItemAdded", function (added) {
                $rootScope.$broadcast("checkListItemAdded", added);
            });

            connection.on("checkListItemDeleted", function (id) {
                $rootScope.$broadcast("checkListItemDeleted", id);
            });

            connection.on("checkListItemUpdated", function (updated) {
                $rootScope.$broadcast("checkListItemUpdated", updated);
            });

            connection.start().catch(function (err) {
                return console.error(err.toString());
            });

        })

        .service('httpClient', function ($http) {

            var base = "";

            this.setBase = function (b) {
               // base = b;
            };

            this.getBase = function () {
                return base;
            };

            this.setJwt = function (jwt) {
                //if (typeof jwt !== "undefined")
                //    $http.defaults.headers.common['Authorization'] = 'Bearer ' + jwt;
            };

            this.get = function (url) {
                return $http.get(base + url);
            };

            this.post = function (url, data) {
                return $http.post(base + url, data);
            };
            
            this.put = function (url, data) {
                return $http.put(base + url, data);
            };
            
            this.delete = function (url) {
                return $http.delete(base + url);
            };


        });
        
})();