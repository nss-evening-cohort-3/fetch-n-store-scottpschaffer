var app = angular.module("FNS", [])
    .controller('myController', function ($scope, $http) {

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
    });
