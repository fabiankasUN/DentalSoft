angular.module('app').directive('myTooth', function () {
    return {
        restrict: 'EA',
        scope: {
            myt: '=info',
            testFn: '&',
            otherFn: '&'
        },
        //templateUrl: '<h1> holas </h1>'
        templateUrl: '/App/Components/Odontogram/tooth.html',
        link: function (scope, elm, attrs) {
            scope.callUpdate = function () {
                alert(scope.upperTeeth);
                //scope.testFn()("Directive Args");
            }
        }
    };
});