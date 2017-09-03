app.controller('HomeController', ['$scope', '$http', '$timeout', 'ProjectFactory',
    function ($scope, $http, $timeout, ProjectFactory) {

        $scope.init = function () {
            $scope.message = "";
            $scope.showMessage = false;
            $scope.GetProjects();
            

        };

        $scope.GetProjects = function () {
            ProjectFactory.GetProjects()
            .success(function (data) {
                $scope.projects = data;
            })
            .error(function (data) {
                $scope.errorMessage = data;
            })
        }

    // Modal for adding a new project //
        var modal = document.getElementById("addNewJobModal");
        var btn = document.getElementById("addJobButton");
        var modalClose = document.getElementsByClassName("close")[0];

        $scope.showModal = function () {
            modal.style.display = "block";
        }
        $scope.closeModal = function () {
            $scope.newProject = {};
            modal.style.display = "none";
        }

    // Add new Project // 
        $scope.addNewProject = function (project) {
            ProjectFactory.AddNewProject(project)
            .success(function (data) {
                $('#message').css('background-color', '#7AFF9C');
                $scope.message = data;
                $scope.showMessage = true;
                $timeout(function () {
                    $scope.closeModal();
                    $scope.init();
                }, 3000);
            })
            .error(function (data) {
                $('#message').css('background-color', '#FF7566');
                $scope.message = data;                
            })
        }
        // Delete Project // 
        $scope.deleteProject = function (id) {
            ProjectFactory.DeleteProject(id)
            .success(function (data) {
                $('#message').css('background-color', '#7AFF9C');
                $scope.message = data;
                $scope.showMessage = true;
               $timeout(function () {
                   $scope.init();
                   
               }, 3000);
            })
            .error(function (data) {
                $('#message').css('background-color', '#FF7566');
                $scope.message = data;
                $scope.showMessage = true;
                $timeout(function () {
                    $scope.showMessage = false;
                }, 5000)
            })
        }


        $scope.init();
    }]);