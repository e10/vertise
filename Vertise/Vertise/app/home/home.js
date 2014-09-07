(function () {
    'use strict';
    var controllerId = 'home';
    angular.module('app').controller(controllerId, ['common', 'datacontext', home]);

    function home(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.messageCount = 0;
        vm.message = '';
        vm.lastID = 0;
        vm.messages = [];
        vm.title = 'Home';
        vm.shout = shout;

        activate();

        function shout() {
            datacontext.shout(vm.message).then(function () {
                vm.message = '';
                return getMessages();
            });
        }

        function activate() {
            var promises = [getMessages()];
            common.activateController(promises, controllerId)
                .then(function () { log('Welcome!'); });
        }

        function getMessages() {
            return datacontext.getMessages(vm.lastID).then(function (data) {
                vm.messageCount = data.Count;
                if (data.Items.length > 0) { vm.lastID = data.Items[0].Id; }
                return vm.messages = data.Items.concat(vm.messages);
            });
        }
    }
})();