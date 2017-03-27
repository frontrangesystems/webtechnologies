"use strict";

app.controller("personListController", [
    "$scope", "$route", "person",
    function($scope, $route, person) {

        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function () {
            $scope.$watch("$routeChangeSuccess", loadData);
        };

        init();

        function loadData() {
            $scope.loading = true;
            $scope.data = person.list(null,
                function() { $scope.loading = false; },
                function(data) { handleError(data); });
        }
    }
]);