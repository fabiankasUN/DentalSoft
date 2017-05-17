angular.module('app').controller('odontogramCtrl', function ($scope, $http, $location, $route,odontogramService) {


    $scope.testFn = function () {
        alert("No wrodd");
    }


    $scope.getData = function () {
        odontogramService.getOdontogram().then(function (response) {
            $scope.upperTeeth = response.data.upperTeeth;
            $scope.upperTemporalTeeth = response.data.upperTemporalTeeth;
            $scope.lowerTemporalTeeth = response.data.lowerTemporalTeeth;
            $scope.lowerTeeth = response.data.lowerTeeth;
        });
        
    };


})
/*    .directive('myTooth', function () {
    return {
        restrict: 'EA',
        scope: {
            myt: '=info',
            testFn: '&'
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
*/