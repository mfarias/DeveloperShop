var app = angular.module('shopCart', []);

app.controller('FormCtrl', function ($scope, $http) {

    $scope.Developers = []

    var formData = {
        username: "",
        price: ""
    };

    $scope.submitForm = function () {
        formData = $scope.form;
        $scope.Developers.push({
            "Username": $scope.username,
            "Price": $scope.price,
            "Hours": $scope.hours,
            "TotalPrice": $scope.price * $scope.hours
        });
    };

    $scope.getCartTotalPrice = function () {
        var total = 0;
        for (var i = 0; i < $scope.Developers.length; i++) {
            var dev = $scope.Developers[i];
            total += dev.TotalPrice;
        }
        return total;
    };

});