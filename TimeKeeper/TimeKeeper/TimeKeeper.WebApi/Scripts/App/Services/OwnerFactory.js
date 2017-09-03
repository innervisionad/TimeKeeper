app.factory('OwnerFactory', ['$http', function ($http) {
    var Ownerfactory = {};

    Ownerfactory.UpdateProjectOwner = function UpdateProjectOwner(projectOwner) {
        return $http.post('api/ProjectOwner/UpdateProjectOwner', projectOwner);
    }


    return Ownerfactory;
}]);