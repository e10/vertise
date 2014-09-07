(function () {
    'use strict';
    var controllerId = 'home';
    angular.module('app').controller(controllerId, ['common', 'datacontext', home]);

    function home(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.messageCount = 0;
        vm.messages = [];
        vm.title = 'Home';

        activate();

        function activate() {
            var promises = [getMessageCount(), getMessages()];
            common.activateController(promises, controllerId)
                .then(function () { log('Welcome!'); });
        }

        function getMessageCount() {
            return datacontext.getMessageCount().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getMessages() {
            return datacontext.getMessages().then(function (data) {
                vm.messageCount=data.Count;
                return vm.messages = data.Items;
            });
        }
    }
})();