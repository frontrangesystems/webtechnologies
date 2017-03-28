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
                templateUrl: "/app/angular1/directives/loading/loading.html"
            };
        }
    ]);