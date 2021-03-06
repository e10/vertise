﻿(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());
    
    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                link:'#/',
                config: {
                    templateUrl: 'app/home/home.html',
                    title: 'Home',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Home'
                    }
                }
            }, {
                url: '/account/logout',
                link: '/account/logout',
                config: {
                    title: 'Logout',
                    templateUrl: 'app/out/home.html',
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-sign-out"></i> Logout'
                    }
                }
            }
        ];
    }
})();