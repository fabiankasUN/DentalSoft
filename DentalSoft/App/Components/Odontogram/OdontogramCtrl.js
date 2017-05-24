angular.module('app').controller('odontogramCtrl', function ($scope, $http, $location, $route,odontogramService) {


    $scope.testFn = function () {
        alert("No wrodd");
    }

    $scope.otherFn = function () {
        alert("otehr function");
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