(function () {
    'use strict';

    angular
        .module('app')

        .controller('checkListContents', function ($scope, dataUpdates, $rootScope) {

            $rootScope.$on("checkListAdded", function (event, added) {
                $scope.$apply(function () {
                    $scope.checkLists.push(added);
                });
            });

            $rootScope.$on("checkListUpdated", function (event, updated) {
                $scope.$apply(function () {
                    $scope.checkLists = $scope.checkLists.map(function (list) {
                        if (list.id === updated.id) return updated;
                        else return list;
                    });
                });
            });

            $rootScope.$on("checkListDeleted", function (event, id) {
                $scope.$apply(function () {
                    $scope.checkLists = $scope.checkLists.filter(function (list) {
                        return list.id !== id;
                    });
                });
            });

        })

        .controller("checkListItemContents", function ($scope, dataUpdates, $rootScope) {

            $rootScope.$on("checkListItemAdded", function (event, added) {
                $scope.$apply(function () {
                    $scope.items.push(added);
                });
            });

            $rootScope.$on("checkListItemUpdated", function (event, updated) {
                $scope.$apply(function () {
                    $scope.items = $scope.items.map(function (item) {
                        if (item.id === updated.id) return updated;
                        else return item;
                    });
                });
            });

            $rootScope.$on("checkListItemDeleted", function (event, id) {
                $scope.$apply(function () {
                    $scope.items = $scope.items.filter(function (item) {
                        return item.id !== id;
                    });
                });
            });

        });

})();
