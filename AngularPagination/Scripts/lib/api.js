//We are using Restangular here, the code bellow will just make an ajax request to /api/states & /api/customers?{filtercriteria}
angular.module('MyApp')
    .factory('api', function (Restangular) {

      //prepend /api before making any request with restangular
        //RestangularProvider.setBaseUrl('/home');
        Restangular.setBaseUrl('/home');
        
      return {
          states: function () {
              return Restangular.all("states").post();
          },
          customers: {
              search: function (query) {
                  return Restangular.all('customers').post(query);
              }
          },
      };
    });
