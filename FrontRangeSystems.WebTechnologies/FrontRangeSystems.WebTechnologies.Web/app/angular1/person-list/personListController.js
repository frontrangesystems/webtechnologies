"use strict";

app.controller("personListController",
[
    "$scope", "$route", "person",
    function($scope, $route, person) {

        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function() {
            $scope.$watch("$routeChangeSuccess", loadData);
            $scope.delete = deleteAction;
        };

        init();

        function removeItem(item) {
            var index = $scope.data.indexOf(item);
            if (index >= 0) {
                $scope.data.splice(index, 1);
            }
        }

        function deleteAction(item) {
            if (confirm("Are you sure you want to delete '" + item.firstName + " " + item.lastName + "'?")) {
                person.delete({ id: item.personId },
                    function() { removeItem(item); },
                    function(data) { handleError(data); });
            }
        }

        function loadData() {
            $scope.loading = true;
            $scope.data = person.list(null,
                function() { $scope.loading = false; },
                function(data) { handleError(data); });
        }
    }
]);