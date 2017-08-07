angular.module('app').directive('myTooth', function () {
    return {
        restrict: 'EA',
        scope: {
            tooth: '=info',
            colors: '=c',
            actionFn: '&',
        },
        //templateUrl: '<h1> holas </h1>'
        templateUrl: '/App/Components/Odontogram/tooth.html',
        link: function (scope, elm, attrs) {
            scope.callUpdate = function () {
                alert(scope.upperTeeth);
                alert("xd");
                //scope.testFn()("Directive Args");
            }
        }
    };
});