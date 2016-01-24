var app = angular.module('shopCart', []);

app.controller('FormCtrl', function ($scope, $http) {

    $scope.devs = []
    $scope.showDevs = true;

    var formData = {
        orgName: ""
    };

    $scope.submitForm = function () {
        formData = $scope.form;

        $http.get("/api/api/shop/organization/",{
            params:{org: $scope.orgName}
        }
        ).success(function (data, status, headers, config) {
            $scope.showDevs = true;
            $scope.devs = data;
        }).error(function (data, status, headers, config) {
            $scope.showDevs = false;
        });
    };
});