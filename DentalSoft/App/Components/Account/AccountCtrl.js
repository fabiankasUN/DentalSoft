angular.module('app').controller('accountCtrl', function ($scope, $http, $location) {

    $scope.value = "testtasdaest";

    $scope.test = function () {
        alert("aaa");
    }

    $scope.getData = function () {
        $http.get('/Odontogram/GetOdontogram')
        .then(function (response) {
            $scope.data = response.data.tooth;
        });

        
    };

    $scope.LogOff = function () {
        $http({
            method: "POST",
            url: "/Account/LogOff",
        }).then( function mySuccces(response){
            window.location.href = "/Account/Login";
        },function myError(response){

        });
    }

});