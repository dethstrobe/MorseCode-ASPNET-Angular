(function () {
	'use strict';

	var app = angular.module('morseCodeApp', ['ngResource', 'ngRoute']);

	app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
		$routeProvider
		.when('/', {
			templateUrl: '/Views/AngularPartials/morseCode.html',
			controller: 'MorseCodeController'
		})
		.otherwise({
			redirectTo: '/'
		});

		$locationProvider.html5Mode(true);
	}]);
})();
