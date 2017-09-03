app.controller('ProjectDetailController', ['$scope', '$http', '$timeout', '$routeParams', 'moment', 'ProjectFactory', 'TimeFactory', 'OwnerFactory',
    function ($scope, $http, $timeout, $routeParams, moment, ProjectFactory, TimeFactory, OwnerFactory) {

        $scope.init = function () {
            $scope.projectId = parseInt($routeParams.id, 10);
            $scope.totalHours = 0;

            $scope.showMessage = false;
            $scope.message = "";

            $scope.ownerDisabled = true;
            $scope.projectDisabled = true;

            $scope.getProjectById();
            $scope.GetProjectTimeRecords();

        };

        $scope.getProjectById = function () {
            ProjectFactory.GetProjectById($scope.projectId)
            .success(function (data) {
                $scope.project = data;
            })
            .error(function (data) {
                $('#message').css('background-color', '#FF7566');
                $scope.message = data;
            })
        }

        $scope.GetProjectTimeRecords = function () {
            TimeFactory.GetProjectTimeRecords($scope.projectId)
            .success(function (data) {
                $scope.times = data;
                angular.forEach(data, function (value, key) {            
                    $scope.totalHours += value.hoursSpent;
                });
            })
            .error(function (data) {
                $('#message').css('background-color', '#FF7566');
                $scope.message = data;
     
            })
        }

        // Modal for adding a new project //
        var modal = document.getElementById("addNewTimeModal");
        var btn = document.getElementById("addNewTimeBtn");
        var modalClose = document.getElementsByClassName("close")[0];

        $scope.showModal = function () {
            modal.style.display = "block";
        }
        $scope.closeModal = function () {
            modal.style.display = "none";
        }

        $scope.addTime = function (time) {
            if (time.timeStart != null) {
                time.timeStart = time.timeStart._i;
            }
            if (time.timeEnd != null) {
                time.timeEnd = time.timeEnd._i;
            }
            time.project_id = $scope.project.id;
            TimeFactory.AddTime(time)
            .success(function (data) {
                $scope.setSuccessMessage(data);
                $scope.closeModal();
            })
            .error(function (data) {
                $scope.setErrorMessage(data);
            })
        }

        $scope.updateProject = function (project) {
            $scope.projectDisabled = true;
            ProjectFactory.UpdateProject(project)
            .success(function (data) {
                $scope.setSuccessMessage(data);
            })
            .error(function (data) {
                $scope.setErrorMessage(data);
            })
        }

        $scope.updateProjectOwner = function (projectOwner) {
            projectOwner.project_id = $scope.project.id;
            $scope.ownerDisabled = true;
            OwnerFactory.UpdateProjectOwner(projectOwner)
            .success(function (data) {
                $scope.setSuccessMessage(data);
            })
            .error(function (data) {
                $scope.setErrorMessage(data);    
            })
        }

        $scope.updateTime = function (time) {
            TimeFactory.UpdateTime(time)
            .success(function (data) {
                $scope.setSuccessMessage(data);
            })
            .error(function (data) {
                $scope.setErrorMessage(data);
            })
        }


        $scope.deleteTime = function (time) {
            TimeFactory.DeleteTime(time)
            .success(function (data) {
                $scope.setSuccessMessage(data);
            })
            .error(function (data) {
                $scope.setErrorMessage(data);
            })
        }


        $scope.setSuccessMessage = function (message) {
            $('#message').css('background-color', '#7AFF9C');
            $scope.message = message;
            $scope.showMessage = true;
            $timeout(function () {
                $scope.init();
              
            }, 3000);
        }

        $scope.setErrorMessage = function (message) {
            $('#message').css('background-color', '#FF7566');
            $scope.message = data;
            $scope.showMessage = true;
            $timeout(function () {
                $scope.showMessage = false;
                $scope.message = "";
            }, 3000)
        }

        $scope.setProjectOwnerdisable = function () {
            $scope.ownerDisabled = !$scope.ownerDisabled;
        }

        $scope.setProjectDisable = function () {
            $scope.projectDisabled = !$scope.projectDisabled;
        }

        $scope.init();
    }]);