"use strict";

app.controller("personController", [
    "$scope", "$route", "person",
    function($scope, $route, person) {
        function handleError(data) {
            alert(JSON.stringify(data));
        }

        var init = function () {
            $scope.personId = $route.current.params.id;
            $scope.person = person.get({ id: $scope.personId}, function () { }, function (data) { handleError(data); });
        };

        init();
    }
]);