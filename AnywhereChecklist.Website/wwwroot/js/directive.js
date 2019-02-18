(function () {
    'use strict';

    angular
        .module('app')
        .directive('submitTo', function () {
            return {
                restrict: 'A',
                scope: true,
                controller: function ($scope, $attrs, httpClient) {
                    $scope.send = function () {
                        var data = $scope.data;
                        $scope.data = {};
                        httpClient.post($attrs.submitTo, data);
                    };
                }
            };
        })

        .directive('updateTo', function () {
            return {
                restrict: 'A',
                scope: true,
                controller: function ($scope, $attrs, httpClient) {
                    $scope.send = function () {
                        var data = $scope.data;
                        $scope.data = {};
                        httpClient.put($attrs.updateTo, data);
                    };
                }
            };
        })

        .directive('deleteTo', function () {
            return {
                restrict: 'A',
                scope: true,
                controller: function ($element, $attrs, httpClient) {

                    $element.click(function () {
                        httpClient.delete($attrs.deleteTo);
                    });

                }
            };
        })

        .directive("apiBase", function () {
            return {
                restrict: 'A',
                controller: function ($attrs, httpClient) {
                    httpClient.setBase($attrs.apiBase);
                    httpClient.setJwt($attrs.Jwt);
                }
            };
        });

})();