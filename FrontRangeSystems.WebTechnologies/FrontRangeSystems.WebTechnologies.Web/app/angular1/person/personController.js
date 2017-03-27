"use strict";

app.controller("personController",
[
    "$scope", "$route", "$location", "person", "organization",
    function($scope, $route, $location, person, organization) {
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
            var count = 0;
            var id = $scope.id = $route.current.params.id;
            $scope.loading = true;

            if(id > 0) {
                count ++;
                $scope.model = person.get({ id: id },
                    function() {
                        count--;
                        $scope.loading = count > 0;
                    },
                    function(data) { handleError(data); });
                
            }

            count++;
            $scope.organizations = organization.list(null,
                function() {
                    count--;
                    $scope.loading = count > 0;
                },
                function(data) { handleError(data); });
        }

        function save(model) {
            if ($scope.id > 0) {
                person.update(model,
                    function() { goBack(); },
                    function(data) { handleError(data); });
            } else {
                person.create(model,
                    function () { goBack(); },
                    function (data) { handleError(data); });
            }
        }

        function goBack() {
            $location.path("angular1/person");
        }
    }
]);