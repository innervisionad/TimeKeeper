var app;
(function () {
    'use strict';
    app = angular.module('app', ['ngRoute', 'angularMoment', 'moment-picker']);
})();

app.config(['$httpProvider', '$routeProvider', '$compileProvider', '$locationProvider',
  function ($httpProvider, $routeProvider, $compileProvider, $locationProvider) {
     
      $routeProvider
      //route for Homepage
      .when('/', {
          templateUrl: 'Scripts/App/Views/Home.html',
          controller: 'HomeController',
      })
        .when('/Project/:id', {
            templateUrl: 'Scripts/App/Views/ProjectDetail.html',
            controller: 'ProjectDetailController'
        })
      .otherwise({
          redirectTo: '/'
      });


  }]);

app.constant("apiUrl", "api/files/");

app.run(function (amMoment) {
    amMoment.changeLocale('en-gb');
})