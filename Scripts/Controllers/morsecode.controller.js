(function () {
	'use strict';

	var app = angular.module('morseCodeApp');

	app.controller('MorseCodeController', ['$scope', 'MorseCodeRestApi', 'morseCodeConvertor', '$http', function ($scope, MorseCodeRestApi, morseCodeConvertor, $http) {

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

		$scope.addUserData = function () {

			if($scope.userData.name === '') {
				return null;
			}

			$http.post('/api/morsecode', {name: $scope.userData.name, gender: $scope.userData.gender})
				.success(function(data, status, headers, config) {
					$scope.otherUsers = data;
				})
				.error(function(data, status, headers, config) {
					throw data;
				});


			$scope.userData.name = '';


		};

		//this removes a name from mondoDB
		$scope.deleteName = function (nameID) {
			$http.delete('/api/morsecode/' + nameID);
		};

	}]);

})();
