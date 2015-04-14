(function () {
	'use strict';

	var app = angular.module('morseCodeApp', ['ngResource']);

	app.controller('MorseController', ['$scope', 'MorseCode', function ($scope, MorseCode) {
		$scope.morseCode = MorseCode.query();

		console.log($scope.morseCode);
	}])
})();