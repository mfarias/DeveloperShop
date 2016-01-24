var app = angular.module('shopCart', []);

app.controller('FormCtrl', function ($scope, $http) {

    $scope.devs = []
    $scope.showDevs = true;

    var formData = {
        orgName: ""
    };

    $scope.submitForm = function () {
        formData = $scope.form;

        $http.get("/api/api/shop/organization/", {
            params: { org: $scope.orgName }
        }
        ).success(function (data, status, headers, config) {
            $scope.showDevs = true;
            $scope.devs = data;
        }).error(function (data, status, headers, config) {
            $scope.showDevs = false;
        });
    };

    $scope.addToCart = function (username, hours) {

        if (hours <= 0)
            alert("Number of hours must be a positive value.");
        else {
            $http.post("/api/api/shop/addtocart/", {
                params: {
                    dev: username,
                    hours: hours
                },
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                }
            }).success(function (data, status, headers, config) {
                alert("Developer added successfully added to cart.")
            }).error(function (data, status, headers, config) {
                alert("It was not possible to add developer to cart.")
            });
        }
    }
});