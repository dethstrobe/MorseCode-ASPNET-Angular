(function () {
	'use strict';

	var app = angular.module('morseCodeApp', ['ngResource', 'ngRoute']);

	app.controller('MorseCodeController', ['$scope', 'MorseCodeRestApi', 'morseCodeConvertor', function ($scope, MorseCodeRestApi, morseCodeConvertor) {

		$scope.userData = {
			'name': '',
			'gender': 'female'
		};

		//holds names that have already been submitted
		$scope.otherUsers = MorseCodeRestApi.query();

		//converts names to morse code
		$scope.convertTo = function (name) {
			return morseCodeConvertor.convertTo(name);
		};

	}]);

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
