(function () {
    'use strict';

    angular
        .module('app')

        .controller('checkListContents', function ($scope, dataUpdates, $rootScope) {

            $rootScope.$on('checkListAdded', function (event, added) {
                $scope.$apply(function () {
                    $scope.checkLists.push(added);
                });
            });

        });

})();
