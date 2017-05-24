angular.module('app').controller('calendarCtrl', function ($scope, $http, $location, $route) {

    $scope.events = [];
    $scope.eventSources = [$scope.events]
    $scope.uiConfig = {
        calendar: {
            height: 450,
            editable: true,
            header: {
                left: 'agendaWeek month agendaDay',
                center: 'title',
                right: 'today prev,next'
            },

            eventClick: $scope.alertEventOnClick,
            eventDrop: $scope.alertOnDrop,
            eventResize: $scope.alertOnResize
        }
    };

})