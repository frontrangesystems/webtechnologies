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

            $scope.delete = deleteAction;
        };

        init();

        function loadData() {
            $scope.loading = true;
            $scope.organizations = organization.list(null,
                function() { $scope.loading = false; },
                function(data) { handleError(data); }
            );
        }

        function removeItem(item) {
            var index = $scope.organizations.indexOf(item);
            if (index >= 0) {
                $scope.organizations.splice(index, 1);
            }
        }

        function deleteAction(item) {
            if (confirm("Are you sure you want to delete the organization '" + item.name + "'?")) {
                organization.delete({ id: item.organizationId },
                    function() {removeItem(item)},
                    function(data) { handleError(data); });
            }
        }
    }
]);