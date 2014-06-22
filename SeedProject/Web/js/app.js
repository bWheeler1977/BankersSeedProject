'use strict';


// Declare app level module which depends on filters, and services
angular.module('myApp', [
  'ngRoute',
  'myApp.filters',
  'myApp.services',
  'myApp.directives',
  'myApp.controllers',
  'ui.bootstrap',
  'ngGrid'
]).
config(['$routeProvider', function($routeProvider) {
    //$routeProvider.when('/view', { templateUrl: 'partials/view.html', controller: 'ViewCtrl' });
    $routeProvider.when('/view', { templateUrl: 'partials/seedPartial.html', controller: 'SeedPartialCtrl' });
    $routeProvider.when('/create', { templateUrl: 'partials/create.html', controller: 'CreateCtrl' });
    $routeProvider.when('/newEmp', { templateUrl: 'partials/newEmpPartial.html', controller: 'NewEmpCtrl' });
    $routeProvider.when('/editEmp/:empId', { templateUrl: 'partials/editEmpPartial.html', controller: 'EditEmpCtrl' });
    $routeProvider.when('/newDept', { templateUrl: 'partials/newDeptPartial.html', controller: 'NewDeptCtrl' });
    $routeProvider.when('/editDept/:deptId', { templateUrl: 'partials/editDeptPartial.html', controller: 'EditDeptCtrl' });
    $routeProvider.when('/newProj', { templateUrl: 'partials/newProjPartial.html', controller: 'NewProjCtrl' });
    $routeProvider.when('/editProj/:projId', { templateUrl: 'partials/editProjPartial.html', controller: 'EditProjCtrl' });
    $routeProvider.otherwise({redirectTo: '/view'});
}]);
