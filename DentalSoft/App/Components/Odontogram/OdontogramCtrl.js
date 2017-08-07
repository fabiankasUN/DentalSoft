angular.module('app').controller('odontogramCtrl', function ($scope, $http, $location, $route,odontogramService) {


    $scope.init = function () {
        $scope.lastPressed = ' ';
        $scope.array = ['blue', 'red', 'green'];
        $scope.getData();
    }
    

    $scope.actionFn = function (id_tooth, type) {

        alert("last pressed = " + id_tooth + " " + type + " " + $scope.lastPressed.key);
    }

    $scope.keyPress = function (e) {
        console.log(e);
        alert(e);
        $scope.lastPressed = e;
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