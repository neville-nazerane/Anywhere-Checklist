(function () {
    'use strict';

    angular
        .module('app')
        .service('dataUpdates', function ($rootScope) {

            const connection = new signalR.HubConnectionBuilder()
                .withUrl("/dataUpdates")
                .configureLogging(signalR.LogLevel.Information)
                .build();

            connection.on("checkListAdded", function (added) {
                $rootScope.$broadcast("checkListAdded", added);
            });

            connection.on("checkListDeleted", function (id) {
                $rootScope.$broadcast("checkListDeleted", id);
            });

            connection.start().catch(function (err) {
                return console.error(err.toString());
            });

        });

})();