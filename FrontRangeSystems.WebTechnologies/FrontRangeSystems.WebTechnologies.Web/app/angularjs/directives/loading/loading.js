"use strict";

angular.module("app")
    .directive("loading",
    [
        function() {
            return{
                restrict: "E",
                scope: {
                    loading: "="
                },
                templateUrl: "/app/angularjs/directives/loading/loading.html"
            };
        }
    ]);