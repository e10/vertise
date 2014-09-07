(function () {
    'use strict';
    var controllerId = 'home';
    angular.module('app')
        .filter('msg', function () { return messageFormatter; })
        .controller(controllerId, ['$scope', 'common', 'datacontext', home]);


    function messageFormatter(msg) {
        var url = window.location.origin;
        return twttr.txt.autoLink(msg, {
            hashtagUrlBase: url + '/search?q=%23',
            cashtagUrlBase: url + '/search?q=%24',
            usernameUrlBase: url + '/',
            /*hashtagClass: 'badge',
            cashtagClass: 'badge',
            listClass: 'badge',
            usernameClass: 'badge',*/
            listUrlBase: url + '/',
        });
    }

    function home($scope, common, datacontext) {

        $scope.title = 'Vertise - Messages';

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