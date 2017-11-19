var app = angular.module('app');

app.directive('ngUsers', [function () {

    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/HtmlTemplets/Users.html',
        scope: {
            users: '=',
            callback: '&',
            getUser: '&'
        },
        link: function (scope, element, attrs) {
             
            scope.cb = function (user) {
                var callback = scope.callback();
                if (callback) {
                    callback(user)
                }
            }
        }
    }

}]);