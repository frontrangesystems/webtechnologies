"use strict";

app.controller("organizationController",
[
    "$scope", "$route", "$location", "organization",
    function($scope, $route, $location, organization) {
        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function () {
            $scope.$watch("$routeChangeSuccess", loadData);

            $scope.save = save;
            $scope.goBack = goBack;
        };

        init();

        function loadData() {
            $scope.loading = true;
            var id = $route.current.params.id;
            $scope.model = organization.get({ id: id },
                function() { $scope.loading = false; },
                function(data) { handleError(data); });
        }

        function save(model) {
            organization.update(model,
                function() { goBack(); },
                function(data) { handleError(data); });
        }

        function goBack() {
            $location.path("angular1/organization");
        }
    }
]);