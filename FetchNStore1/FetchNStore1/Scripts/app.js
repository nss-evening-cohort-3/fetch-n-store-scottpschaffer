var app = angular.module("FNS", [])
    .controller('myController', function ($scope, $http) {
        /*app.controller("MyController", ['$scope', '$http', function($scope, $http){ 
            $scope.fetch = function () {
                var time = Date.now();
                $scope.data.resTime = "sssss";
                $http({
                    method: $scope.data.singleMethod,
                    url : $scope.data.theURL
                }).then(function successCallBack(response) {
                    var time2 = Date.now();
                    $scope.data.resp = response.data;
                    $scope.data.resTime = time2 - time + " msec";
                });
            };
        });*/
        $scope.fetch = function () {
            $http.post('/api/Response', { "name": "Jurnell", "class": "E3" }).success(function (data, status, _headers) {
                $scope.data = data;
                $scope.status = status;
                $scope.headers = _headers();
            })
            .error(function (response) {
                alert("oh bad");
            });
            // $http.get('/api/Response');
        };
    });
