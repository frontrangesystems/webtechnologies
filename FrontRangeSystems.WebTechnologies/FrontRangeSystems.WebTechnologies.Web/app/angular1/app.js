"use strict";

var app = angular.module("app",
[
    "ngResource",
    "ngRoute",
    "ui.router",
    "organizationService",
    "personService"
]);

app.config([
    "$routeProvider", "$locationProvider", "$httpProvider",
    function ($routeProvider, $locationProvider, $httpProvider) {
        var prefix = "/angular1";
        $routeProvider
            .when(prefix,
            {
                title: "Home",
                templateUrl: "/app/angular1/home/index.html",
                controller: "homeController"
            })
            .when(prefix + "/person/:id",
            {
                title: "Person",
                templateUrl: "app/angular1/person/index.html",
                controller: "personController"
            })
            .when(prefix + "/person",
            {
                title: "People",
                templateUrl: "app/angular1/person-list/index.html",
                controller: "personListController"
            })
            .when(prefix + "/organization/:id",
            {
                title: "Organization",
                templateUrl: "app/angular1/organization/index.html",
                controller: "organizationController"
            })
            .when(prefix + "/organization",
            {
                title: "Organizations",
                templateUrl: "app/angular1/organization-list/index.html",
                controller: "organizationListController"
            })
            .otherwise({
                redirectTo: prefix
            });

        $locationProvider.html5Mode(true);
    }
]);