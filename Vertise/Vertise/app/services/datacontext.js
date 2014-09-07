(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;
        var $http = common.$http;

        var service = {
            getMessages: getMessages,
            shout: postMessage
        };

        return service;

        function postMessage(msg) {
            return $http.post('/api/messages', { Body: msg });
        }

        function getMessages(id) {
            var filter = '&$top=20';
            if (id > 0) {
                filter += '&$filter=Id gt ' + id;
            }

            return $http.get('/api/messages?$inlinecount=allpages&$orderby=Id desc'+filter)
            .then(function (data, status, headers, config) {
                return $.when(data.data);
            });
        }   
    }
})();