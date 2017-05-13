(function () {
    'use strict';

    angular
        .module('App')
        .controller('OdontogramController', OdontogramController);

    OdontogramController.$inject = ['$location']; 

    function OdontogramController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'OdontogramController';

        activate();

        function activate() { }
    }
})();
