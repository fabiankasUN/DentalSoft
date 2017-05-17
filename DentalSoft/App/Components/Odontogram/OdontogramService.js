angular.module('app').service('odontogramService', function ($http) {

    this.getOdontogram = function () {
        return $http.get('/Odontogram/GetOdontogram')
        .success(function (response) {
            return response;
        });
    };
});