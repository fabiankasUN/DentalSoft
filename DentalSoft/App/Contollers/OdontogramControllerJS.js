angular.module('app').controller('odontogramControllerjs',  function ($scope, $http, $location) {


    $scope.getData = function () {
        $http.get('/Odontogram/GetOdontogram')
        .then(function (response) {
            $scope.data = response.data.tooth;
        });
    };


}).directive('myTeeth', function () {  
    return {
        restrict: 'EA',
        scope: {
            myt: '=info'
        },
        //templateUrl: '<h1> holas </h1>'
        templateUrl: '/Content/teeth.html'
    };
});