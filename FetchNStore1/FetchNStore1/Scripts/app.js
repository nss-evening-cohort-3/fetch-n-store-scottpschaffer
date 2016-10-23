var app = angular.module("FNS", [])
    .controller('myController', function ($scope, $http) {

        $scope.fetch = function(){
            //$scope.data.qwert = 'qqaazzzxxsswwwww';
            $http({
                method : "GET",
                url : "http://httpstat.us/200"
            }).then(function successCallBack(response) {
                $scope.data.resp = response.data,
                $scope.data.qwert = response.headers;
            });
        };
    });
