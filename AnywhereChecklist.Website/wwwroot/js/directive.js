(function () {
    'use strict';

    angular
        .module('app')
        .directive('submitTo', function() {
            return {
                restrict: 'A',
                scope: true,
                controller: function ($scope, $attrs, $http) {
                    $scope.send = function () {
                        var data = $scope.data;
                        $scope.data = {};
                        $http.post($attrs.submitTo, data);
                    };
                }
            };
        });


})();