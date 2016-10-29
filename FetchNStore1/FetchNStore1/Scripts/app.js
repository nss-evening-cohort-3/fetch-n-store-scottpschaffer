var app = angular.module("FNS", [])
    .controller('myController', function ($scope, $http) {
        /*app.controller("MyController", ['$scope', '$http', function($scope, $http){ */
        $scope.fetch = function () {
            var time = Date.now();
            $http({
                method: $scope.data.HTTPMethod,
                url : $scope.data.URL
            }).then(function successCallBack(response) {
                var time2 = Date.now();
                console.log(response.status);
                $scope.data.StatusCode = response.status;
                $scope.data.ResponseTime = time2 - time;
                $scope.data.RequestTime = (new Date()).toISOString();
                    //Date.now().toUTCString();
            });
        };

        $scope.store = function () {
            //console.log($scope.data);
           /* $http.post('/api/Response', $scope.data).success(function (data, status, _headers) {
                alert("Yay! It worked!");
            })*/
            $http({
                method: $scope.data.HTTPMethod,
                url: '/api/Response',
                data: $scope.data
            }).then(function (data, status, headers) {
                console.log(data);
                alert("Yay! It worked!");
            }, function error(response){
                alert("oh bad");
            });
            // $http.get('/api/Response');
        };
    });
