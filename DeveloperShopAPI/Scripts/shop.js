var app = angular.module('shopList', []);

app.controller('FormCtrl', function ($scope, $http) {

    $scope.devs = []
    $scope.showDevs = true;
    $scope.showCart = false;

    var formData = {
        orgName: ""
    };

    $scope.submitForm = function () {
        formData = $scope.form;

        $http.get("/api/shop/GetDevelopersFromOrganization/", {
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
            var cartItem = { 
                'devuser': username,
                'hours': hours
            };
            $http
               .post("/api/shop/AddDeveloperToCart/", JSON.stringify(cartItem))
               .success(function (data, status, headers, config) {
                   data.forEach(function (item) {
                       var devToRemove = $.grep($scope.devs, function (e) { return e.Username === item.Username; });
                       if (devToRemove.length > 0) {
                           var indexOfItem = $scope.devs.indexOf(devToRemove[0]);
                           if (indexOfItem > -1) {
                               $scope.devs.splice(indexOfItem, 1);
                           }
                       }
                   });
                   $scope.watchCart();
                   alert("Developer added successfully added to cart.")
               })
                .error(function (data, status, headers, config) {
                    alert("It was not possible to add developer to cart.")
                });
        }
    }
    
    $scope.watchCart = function () {

        $http.get("/api/shop/GetShopCart"
        ).success(function (data, status, headers, config) {
            $scope.showCart = true;
            $scope.cart = data;
        }).error(function (data, status, headers, config) {
            $scope.showCart = false;
        });
    };
});