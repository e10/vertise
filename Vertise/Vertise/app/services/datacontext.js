(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;
        var $http = common.$http;

        var service = {
            getPeople: getPeople,
            getMessageCount: getMessageCount
        };

        return service;


        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            return $http({ method: 'GET', url: '/api/messages?$inlinecount=allpages' })
            .then(function (data, status, headers, config) {
                return $.when(data.data.Items);
            });
        }
    }
})();