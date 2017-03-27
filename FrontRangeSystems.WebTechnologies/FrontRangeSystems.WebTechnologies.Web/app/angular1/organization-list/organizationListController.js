"use strict";

app.controller("organizationListController",
[
    "$scope", "$route", "organization",
    function($scope, $route, organization) {

        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function() {
            $scope.$watch("$routeChangeSuccess", loadData);
        };

        init();

        function loadData() {
            $scope.loading = true;
            $scope.organizations = organization.list(null,
                function() { $scope.loading = false; },
                function(data) { handleError(data); }
            );
        }
    }
]);