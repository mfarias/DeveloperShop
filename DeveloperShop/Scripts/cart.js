var app = angular.module('shopCart', []);

app.controller('FormCtrl', function ($scope, $http) {

    $scope.devs = []

    var formData = {
        orgName: ""
    };

    $scope.submitForm = function () {
        formData = $scope.form;

        $http.get("/api/api/shop/organization/",{
            params:{org: $scope.orgName}
        }
        ).success(function (data, status, headers, config) {
            $scope.devs = data;
        }).error(function (data, status, headers, config) {
            alert("data:" + data + " " + "status:" + status + " " + "headers:" + headers + " " + "config:" + config);
        });
    };
});