angular.module('MyApp').controller('GridCtrl', function ($scope, api) {
    $scope.totalPages = 0;
    $scope.customersCount = 0;
    $scope.headers = [
    {
        title: 'Id',
        value: 'id'
    },
    {
        title: 'Name',
        value: 'name'
    },
    {
        title: 'Email',
        value: 'email'
    },
    {
        title: 'City',
        value: 'city'
    },
    {
        title: 'State',
        value: 'state'
    }];

    //Will make an ajax call to fill the drop down menu in the filter of the states
    $scope.states = api.states();

    //default criteria that will be sent to the server
    $scope.filterCriteria = {
        pageNumber: 1,
        sortDir: 'asc',
        sortedBy: 'id'
    };

    //The function that is responsible of fetching the result from the server and setting the grid to the new result
    $scope.fetchResult = function () {
        return api.customers.search($scope.filterCriteria).then(function (data) {
            $scope.customers = data.Customers;
            $scope.totalPages = data.TotalPages;
            $scope.customersCount = data.TotalItems;
        }, function () {
            $scope.customers = [];
            $scope.totalPages = 0;
            $scope.customersCount = 0;
        });
    };

    //called when navigate to another page in the pagination
    $scope.selectPage = function (page) {
        $scope.filterCriteria.pageNumber = page;
        $scope.fetchResult();
    };

    //Will be called when filtering the grid, will reset the page number to one
    $scope.filterResult = function () {
        $scope.filterCriteria.pageNumber = 1;
        $scope.fetchResult().then(function () {
            //The request fires correctly but sometimes the ui doesn't update, that's a fix
            $scope.filterCriteria.pageNumber = 1;
        });
    };

    //call back function that we passed to our custom directive sortBy, will be called when clicking on any field to sort
    $scope.onSort = function (sortedBy, sortDir) {
        $scope.filterCriteria.sortDir = sortDir;
        $scope.filterCriteria.sortedBy = sortedBy;
        $scope.filterCriteria.pageNumber = 1;
        $scope.fetchResult().then(function () {
            //The request fires correctly but sometimes the ui doesn't update, that's a fix
            $scope.filterCriteria.pageNumber = 1;
        });
    };

    //manually select a page to trigger an ajax request to populate the grid on page load
    $scope.selectPage(1);

});