var app = angular.module('app');

app.factory('userServise', ['$http', function (http) {
    var httpRequestMgr = function (action, method, data) {
        return http({
            method: method || 'GET',
            url: '/api/ApiUsers/' + action,
            params: method == "GET" ? data : null,
            data: data
             
        });
    }


    var getAllUsers = function () {

        return httpRequestMgr('GetAllUsers');
    }

    var getUser = function (data) {
        return httpRequestMgr('GetUser', 'GET', data);
    }

    var updateUser = function (user) {
        return httpRequestMgr('UpdateUser', 'POST', user);
    }

    var deleteUser = function (user) {
        return httpRequestMgr('DeleteUser', 'POST', user);
    }

    var createUser = function (user) {
        return httpRequestMgr('CreateUser', 'POST', user);
    }

 
    return {
        getAllUsers: getAllUsers,
        getUser :getUser ,  
        updateUser: updateUser,
        deleteUser: deleteUser,
        createUser: createUser
    }
}])