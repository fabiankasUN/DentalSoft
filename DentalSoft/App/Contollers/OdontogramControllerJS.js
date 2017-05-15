angular.module('app').controller('odontogramControllerjs',  function ($scope, $http, $location) {


    $scope.testFn = function () {
        alert("test complete");
    }


    $scope.getData = function () {
        $http.get('/Odontogram/GetOdontogram')
        .then(function (response) {
            $scope.upperTeeth = response.data.upperTeeth;
            $scope.upperTemporalTeeth = response.data.upperTemporalTeeth;
            $scope.lowerTemporalTeeth = response.data.lowerTemporalTeeth;
            $scope.lowerTeeth = response.data.lowerTeeth;
            
        });
    };


}).directive('myTooth', function () {  
    return {
        restrict: 'E',
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