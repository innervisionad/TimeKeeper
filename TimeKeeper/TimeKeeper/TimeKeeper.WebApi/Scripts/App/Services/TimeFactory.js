app.factory('TimeFactory', ['$http', function ($http) {
    var TimeFactory = {}

    TimeFactory.GetProjectTimeRecords = function GetProjectTimeRecords(id) {
        return $http.post('api/Time/GetProjectTimeRecords', id);
    }

    TimeFactory.AddTime = function Addtime(time) {
        return $http.post('api/Time/AddTime', time);
    }

    TimeFactory.UpdateTime = function UpdateTime(time) {
        return $http.put('api/Time/UpdateTime', time);
    }

    TimeFactory.DeleteTime = function DeleteTime(time) {
        return $http.post('api/Time/DeleteTime', time);
    }

    return TimeFactory;
}])