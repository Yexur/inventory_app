
var app = angular.module('app', ['ngRoute', 'ui.bootstrap', 'ngGrid']);

app.config(["$routeProvider", "$locationProvider",
    function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "app/Home/Home.html",
                controller: "mainController"
            })
            .when("/category", {
                templateUrl: "app/Category/Category.html",
                controller: "categoryController"
            })
            .when("/videoGames", {
                templateUrl: "app/VideoGame/VideoGame.html",
                controller: "videoGameController"
            })
            .when("/boardGames", {
                templateUrl: "app/BoardGame/BoardGame.html",
                controller: "boardGameController"
            })
            .when("/budget", {
                templateUrl: "app/Budget/Budget.html",
                controller: "budgetController"
            })
            .when("/tracking", {
                templateUrl: "app/Tracking/Tracking.html",
                controller: "trackingController"
            })
            .when("/schedule", {
                templateUrl: "app/Schedule/Schedule.html",
                controller: "scheduleController"
            })
            .otherwise({
                redirectTo: "/home"
            });
        //$locationProvider.html5Mode(true);
    }]);

//.when("/updateEmployeeForm/:id", {
//    templateUrl: "app/EmployeeForm/efTemplate.html",
//    controller: "efController"
//})