"use strict";

app.controller("organizationListController",
[
    "$scope", "$route", "organization",
    function($scope, $route, organization) {

        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function() {
            $scope.loading = true;
            loadOrganizations();
        };

        init();

        function loadOrganizations() {
            console.log('waited');
            $scope.organizations = organization.list(null,
                function() { $scope.loading = false; },
                function(data) { handleError(data); }
            );
        }
    }
]);