(function () {
	'use strict';

	angular.module('morseCodeApp')

	.factory('MorseCode', ['$resource', function ($resource) {
		return $resource('/api/morsecode', {}, {
			query: {method: 'GET', params: {}, isArray: true}
		});
	}]);

})();