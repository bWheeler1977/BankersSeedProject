'use strict';

/* Controllers */

angular.module('myApp.controllers', [])
    .controller('mainCtrl', function ($scope, $window) {
        $scope.empGrid = {
            data: 'employees',
            columnDefs: [
                { field: 'id', visible: false },
                { field: 'name', displayName: 'Name' },
                { field: 'salary', displayName: 'Salary' },
                { field: 'department', displayName: 'Department' },
                { field: 'project', displayName: 'Project' },
                { field: 'edit', displayName: '', cellTemplate: '<div class="ngCellText" ng-class="col.colIndex()"><a ng-click="loadEmpEdit(row)">Edit</a></div>' }
            ]
        }; $scope.deptGrid = {
            data: 'departments',
            columnDefs: [
                { field: 'id', visible: false },
                { field: 'deptName', displayName: 'Name' },
                { field: 'location', displayName: 'Location' },
                { field: 'budget', displayName: 'Budget' },
                { field: 'edit', displayName: '', cellTemplate: '<div class="ngCellText" ng-class="col.colIndex()"><a ng-click="loadDeptEdit(row)">Edit</a></div>' }
            ]
        }; $scope.projGrid = {
            data: 'projects',
            columnDefs: [
                { field: 'id', visible: false },
                { field: 'projName', displayName: 'Name' },
                { field: 'budget', displayName: 'Budget' },
                { field: 'department', displayName: 'Department' },
                { field: 'edit', displayName: '', cellTemplate: '<div class="ngCellText" ng-class="col.colIndex()"><a ng-click="loadProjEdit(row)">Edit</a></div>' }
            ]
        };
        $scope.loadEmpEdit = function (row) {
            $window.location.href = '#/editEmp/' + row.entity.id;
        };
        $scope.loadDeptEdit = function (row) {
            $window.location.href = '#/editDept/' + row.entity.id;
        };
        $scope.loadProjEdit = function (row) {
            $window.location.href = '#/editProj/' + row.entity.id;
        };
    })
    .controller('SeedPartialCtrl', ['$scope', '$http', function ($scope, $http) {
        $http.get('/api/Employee').success(function (data) {
            $scope.employees = data;
        });
        $http.get('/api/Department').success(function (data) {
            $scope.departments = data;
        });
        $http.get('/api/Project').success(function (data) {
            $scope.projects = data;
        });
    }])
    .controller('ViewCtrl', ['$scope', '$http', function ($scope, $http) {
        $http.get('/api/Message').success(function (data) {
            $scope.messages = data;
        });
    }])
    .controller('CreateCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.submit = function () {

            $http.post('/api/Message', {text:$scope.message}).success(function (data) {
                $scope.messages.add(data);
            });
          
        };
    }])
    .controller('NewEmpCtrl', ['$scope', '$http', '$location', function($scope, $http, $location) {
        $scope.save = function() {
            // Call post function to add data.
            $http.post('/api/Employee', $scope.employees ).success(function() {
                $location.path('/');
            });
        };
    }])
    .controller('EditEmpCtrl', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $http.get('/api/Employee/' + $routeParams.empId).success(function(data) {
            $scope.employees = data;
        });
        $scope.destroy = function () {
            $http.delete('/api/Employee/' + $routeParams.empId).success(function() {
                $location.path('/');
            });
        }
        $scope.submit = function () {
            $http.post('/api/Employee/' + $routeParams.empId, $scope.employees).success(function() {
                $location.path('/');
            });
        }
    }])
    .controller('NewDeptCtrl', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        $scope.save = function () {
            // Call post function to add data.
            $http.post('/api/Department', $scope.departments).success(function () {
                $location.path('/');
            });
        };
    }])
    .controller('EditDeptCtrl', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $http.get('/api/Department/' + $routeParams.deptId).success(function (data) {
            $scope.departments = data;
        });
        $scope.destroy = function () {
            $http.delete('/api/Department/' + $routeParams.deptId).success(function () {
                $location.path('/');
            });
        }
        $scope.submit = function () {
            $http.post('/api/Department/' + $routeParams.deptId, $scope.departments).success(function () {
                $location.path('/');
            });
        }
    }])
    .controller('NewProjCtrl', ['$scope', '$http', '$location', function ($scope, $http, $location) {
        $scope.save = function () {
            // Call post function to add data.
            $http.post('/api/Project', $scope.projects).success(function () {
                $location.path('/');
            });
        };
    }])
    .controller('EditProjCtrl', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $http.get('/api/Project/' + $routeParams.projId).success(function (data) {
            $scope.projects = data;
        });
        $scope.destroy = function () {
            $http.delete('/api/Project/' + $routeParams.projId).success(function () {
                $location.path('/');
            });
        }
        $scope.submit = function () {
            $http.post('/api/Project/' + $routeParams.projId, $scope.projects).success(function () {
                $location.path('/');
            });
        }
    }]);

