"use strict";

app.controller("organizationController",
[
    "$scope", "$route", "organization",
    function($scope, $route, organization) {
        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function() {
            $scope.loading = true;
            $scope.organizationId = $route.current.params.id;
            loadData();
        };

        init();

        function loadData() {
            $scope.organization = organization.get({ id: $scope.organizationId },
                function() { $scope.loading = false; },
                function(data) { handleError(data); });
        }
    }
]);