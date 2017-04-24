"use strict";

app.controller("organizationController",
[
    "$scope", "$route", "$location", "organization",
    function($scope, $route, $location, organization) {
        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function() {
            $scope.$watch("$routeChangeSuccess", loadData);

            $scope.save = save;
            $scope.goBack = goBack;
        };

        init();

        function loadData() {
            $scope.id = $route.current.params.id;
            if ($scope.id > 0) {
                $scope.loading = true;
                $scope.model = organization.get({ id: $scope.id },
                    function() { $scope.loading = false; },
                    function(data) { handleError(data); });
            }
        }

        function save(model) {
            if ($scope.id > 0) {
                organization.update(model,
                    function() { goBack(); },
                    function(data) { handleError(data); });
            } else {
                organization.create(model,
                    function() { goBack(); },
                    function(data) { handleError(data); });
            }
        }

        function goBack() {
            $location.path("angularjs/organization");
        }
    }
]);