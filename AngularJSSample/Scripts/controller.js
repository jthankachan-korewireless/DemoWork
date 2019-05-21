/// <reference path="angular.js" />


myApp.controller('LoginController', function ($scope) {
    $scope.Submited = false;
    $scope.IsLoggedIn = false;
    $scope.IsFormValid = false;
    $scope.IsShowError = true;

    $scope.$watch("myForm.$valid", function (TrueOrFalse) {
        $scope.IsFormValid = TrueOrFalse;
    });

    $scope.LoginForm = function () {
        alert();
        $scope.Submited = true;
        if ($scope.IsFormValid) {
            document.getElementById("litheader").className = "poweron";
            document.getElementById("go").className = "";
            document.getElementById("go").value = "Initializing...";
           // LoginService.getUserDetails($scope.UserModel).then(function (d) {



          
        }
        else {
            $scope.IsShowError = false;
        }
    }
});

myApp.controller('PasswordReset', function ($scope, LoginService, $location) {

    $scope.setPassword = function () {

        LoginService.SetPassword($scope.UserModel).then(function (d) {
            alert(d.data);
           
        }
        );
       
    }

});












