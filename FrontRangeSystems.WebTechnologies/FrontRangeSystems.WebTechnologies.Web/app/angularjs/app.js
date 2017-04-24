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
        var prefix = "/angularjs";
        $routeProvider
            .when(prefix,
            {
                title: "Home",
                templateUrl: "/app/angularjs/home/index.html",
                controller: "homeController"
            })
            .when(prefix + "/person/:id",
            {
                title: "Person",
                templateUrl: "app/angularjs/person/index.html",
                controller: "personController"
            })
            .when(prefix + "/person",
            {
                title: "People",
                templateUrl: "app/angularjs/person-list/index.html",
                controller: "personListController"
            })
            .when(prefix + "/organization/:id",
            {
                title: "Organization",
                templateUrl: "app/angularjs/organization/index.html",
                controller: "organizationController"
            })
            .when(prefix + "/organization",
            {
                title: "Organizations",
                templateUrl: "app/angularjs/organization-list/index.html",
                controller: "organizationListController"
            })
            .otherwise({
                redirectTo: prefix
            });

        $locationProvider.html5Mode(true);
    }
]);