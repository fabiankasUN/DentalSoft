angular.module('app').directive('myTooth', function () {
    return {
        restrict: 'EA',
        scope: {
            myt: '=info',
            testFn: '&'
        },
        //templateUrl: '<h1> holas </h1>'
        templateUrl: '/Content/tooth.html',
        link: function (scope, elm, attrs) {
            scope.callUpdate = function () {
                alert(scope.upperTeeth);
                //scope.testFn()("Directive Args");
            }
        }
    };
});