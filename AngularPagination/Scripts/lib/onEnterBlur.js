﻿angular.module('MyApp').directive('onEnterBlur', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                element.blur();
                event.preventDefault();
            }
        });
    };
});