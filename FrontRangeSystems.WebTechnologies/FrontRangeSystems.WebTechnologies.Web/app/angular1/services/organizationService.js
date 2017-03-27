angular.module("organizationService", ["ngResource"])
    .factory("organization",
    [
        "$resource",
        function($resource) {
            return $resource("api/organization/:id/:action",
                {
                    action: "@action",
                    id: "@id"
                },
                {
                    list: {
                        method: "GET",
                        isArray: true
                    },
                    get: {
                        method: "GET"
                    },
                    "delete": {
                        method: "DELETE"
                    },
                    create: {
                        medhot: "POST"
                    },
                    update: {
                        method: "PUT"
                    }
                }
            );
        }
    ]);