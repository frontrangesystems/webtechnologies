angular.module("personService", ["ngResource"])
    .factory("person",
    [
        "$resource",
        function ($resource) {
            return $resource("api/person/:id/:action",
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
                        method: "UPDATE"
                    }
                }
            );
        }
    ]);