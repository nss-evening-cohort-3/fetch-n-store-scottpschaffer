var app = angular.module("FNS", [])
    .controller('myController', function ($scope, $http) {

        $scope.fetch = function () {
            $scope.data.resTime = "sssss";
            $http({
                method: $scope.data.singleMethod,
                url : $scope.data.theURL
            }).then(function successCallBack(response) {
                $scope.data.resp = response.data;
            });
        };
    });
