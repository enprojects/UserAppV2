var app = angular.module('app');

app.controller('mainController', ['$scope', 'userServise', '$modal', function (scope, userServise, $modal) {

    scope.users = [];
    scope.searchUser = function (search) {
  
        if (search && search.length > 0) {
            userServise.getUser({ search: search }).then(function (result) {
                if (result && result.status == 200) {
                    scope.users = result.data;
                }

            });
        }
    }
    scope.init = function () {

        userServise.getAllUsers()
            .then(function (result) {
                scope.users = result.data;
            });

    };

    scope.init();

    scope.addUser = function () {

        scope.crudOperation(null, scope.init);
    }

    scope.crudOperation = function (user) {
        $modal.open({
            templateUrl: '/HtmlTemplets/DialogHtml1.html',
            windowClass: 'modal', // windowClass - additional CSS class(es) to be added to a modal window template
            controller: function ($scope, $modalInstance, user, userServise) {
                $scope.user = user || {};
                $scope.callback = scope.init;
               

                if (!user) {
                    $scope.isHide = true;

                }

                $scope.createUser = function (form) {


                    if (form.$invalid) {
                        angular.forEach(form.$error.required, function (field) {
                            field.$dirty = true;
                        });

                        return true;
                    }


                    userServise.createUser($scope.user)
                                  .then(function (result) {

                                      if (result.data) {
                                          if (!result.data.Success) {
                                              alert('User has been inserted ..')
                                          }

                                      }

                                      $scope.callback();
                                      $modalInstance.close();
                                  });
                }

                $scope.deleteUser = function () {

                    userServise.deleteUser($scope.user)

                            .then(function (result) {
 
                                if (result && result.status == 200) {
                                    
                                    $scope.callback();
                                    $modalInstance.close();
                                }
                                else {
                                    alert('Record has not changed')
                                }
 
                            });

                }

                $scope.updateUser = function (form) {

                    if (form.$invalid) {

                        angular.forEach(form.$error.required, function (field) {
                            field.$dirty = true;
                        });

                        return true;
                    }

                    userServise.updateUser($scope.user)

                        .then(function (result) {
                            if (result && result.status == 200) {
                                $scope.callback();
                                $modalInstance.close();
                            } else {
                                alert('Fatal Error')
                            }
                        });
                }
                $scope.cancel = function () {
                    $modalInstance.dismiss('cancel');
                };
            },
            resolve: {
                user: function () {
                    return user;
                }
            }
        });


    }

}]);
