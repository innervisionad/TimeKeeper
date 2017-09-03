app.factory('ProjectFactory', ['$http', function ($http) {

    var ProjectFactory = {}

    ProjectFactory.GetProjects = function GetProjects() {
        return $http.get('api/Project/GetProjects');
    }

    ProjectFactory.GetProjectById = function GetProjectById(id) {
        return $http.post('api/Project/GetProjectById', id);
    }
   
    ProjectFactory.AddNewProject = function AddNewProject(project) {
        return $http.post('api/Project/AddNewProject', project);
    }

    ProjectFactory.DeleteProject = function DeleteProject(id) {
        return $http.post('api/Project/DeleteProject', id);
    }

    ProjectFactory.UpdateProject = function UpdateProject(project) {
        return $http.put('api/Project/UpdateProject', project);
    }

    return ProjectFactory;
}])