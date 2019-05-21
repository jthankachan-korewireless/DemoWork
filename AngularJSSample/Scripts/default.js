var app = angular.module("myApp", ['ngRoute', 'ngStorage']);



app.controller('LoginController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

$scope.$watch("myForm.$valid", function (TrueOrFalse) {
    $scope.IsFormValid = TrueOrFalse;
});

    $scope.Login = function () {
        var user = {};
        user.userName = $scope.UserName;
        user.password = $scope.Password;
        


        if ($scope.UserName != undefined && $scope.Password != undefined) {
            var post = $http({
                method: "POST",
                url: "SampleData.asmx/GetLoginDetails",
                dataType: 'json',
                data: JSON.stringify(user),
                headers: { "Content-Type": "application/json" },
            });

            post.then(function (data) {
                if (data.data.d == "true") {
                    window.location.href = "DashBoard.aspx";
                }
                else {
                    $scope.Loginerror = "Incorrect username or password !";
                }
            }, function (err) {
                alert("An error occured during the current process. Please try again later.");
            });
        }
    }

    $scope.Regisetr = function () {
        var user = {};
        user.userName = $scope.UserName;
        user.password = $scope.Password;
        user.emailAddress = $scope.UserEmailAddress;

        if ($scope.UserName != undefined && $scope.Password != undefined && user.emailAddress != undefined) {
            var post = $http({
                method: "POST",
                url: "SampleData.asmx/UserRegisetration",
                dataType: 'json',
                data: JSON.stringify(user),
                headers: { "Content-Type": "application/json" },
            });

            post.then(function (data) {
                if (data.data.d == "true") {
                    window.location.href = "login.aspx";
                }     
                else {
                    $scope.Regerror = "Already have an account with username. Please try another!";
                }
            }, function (err) {
                alert("An error occured during the current process. Please try again later.");
            });
        }
    }
}]);

app.controller('DashBoardCtrl', ['$scope', '$http', '$rootScope', '$localStorage', function ($scope, $http, $rootScope, $localStorage) {
    $scope.GetListItems = function () {

        var post = $http({
            method: 'POST',
            url: "SampleData.asmx/GetDataForAngularGrid",
            dataType: 'json',
            data: '',
            headers: { "Content-Type": "application/json" }
        });
        post.then(function (data) {
            var data = JSON.parse(data.data.d);
            $scope.records = data;
        }, function (err) {
            alert("An error occured during the current process. Please try again later.");
        });
    }

    $scope.DeleteClick = function (records) {
        if (confirm("Do you want to delete?")) {
            if (records.ID > 0) {
                var user = {};
                user.id = records.ID;

                var post = $http({
                    method: "POST",
                    url: "SampleData.asmx/DeleteDepartment",
                    dataType: 'json',
                    data: JSON.stringify(user),
                    headers: { "Content-Type": "application/json" },
                });

                post.then(function (data) {
                    if (data.data.d == "true") {
                        alert("Deleted successfully");
                        location.reload()
                    }
                    else {
                        alert("An error occured during the current process. Please try again later.");
                    }
                }, function (err) {
                    alert("An error occured during the current process. Please try again later.");
                });
            }
        }
    }

    $scope.FormOpen = function () {
        window.location = "Form.aspx";
        localStorage.depUSerID = "";
        localStorage.name = "";
        localStorage.departmentID = "";
    }

    $scope.EditClick = function (records) {
        debugger;
        if (records.ID > 0) {
            localStorage.depUSerID = records.ID;
            localStorage.name = records.Name;
            localStorage.departmentID = records.DepartmentID;
            window.location = "Form.aspx";
        }
        else {
            alert("An error occured during the current process. Please try again later.");
        }
    }

}]);

app.controller('FromCtrl', ['$scope', '$http', '$rootScope', '$localStorage', function ($scope, $http, $rootScope, $localStorage) {
    debugger;

    $scope.GetDepartmentItems = function () {
        var post = $http({
            method: 'POST',
            url: "SampleData.asmx/GetDataForDepartment",
            dataType: 'json',
            data: '',
            headers: { "Content-Type": "application/json" }
        });
        post.then(function (data) {
            var data = JSON.parse(data.data.d);
            if (localStorage.depUSerID > 0) {
                $scope.Name = localStorage.name;
                $scope.Department = parseInt(localStorage.departmentID || 0);
            }
            else {
                $scope.Department = data[0].DepartmentID;
            }
            $scope.DepartmentList = data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.CancelForm = function () {
        window.location = "DashBoard.aspx";
    }

    $scope.AddForm = function () {
        debugger;
        var user = {};
        user.name = $scope.Name;
        user.department = $scope.Department;
        if (localStorage.depUSerID > 0) {
            user.id = localStorage.depUSerID
            var post = $http({
                method: "POST",
                url: "SampleData.asmx/DepartmentUsersUpdate",
                dataType: 'json',
                data: JSON.stringify(user),
                headers: { "Content-Type": "application/json" },
            });
        }

        else {
            var post = $http({
                method: "POST",
                url: "SampleData.asmx/DepartmentUsersInsert",
                dataType: 'json',
                data: JSON.stringify(user),
                headers: { "Content-Type": "application/json" },
            });
        }

        post.then(function (data) {
            if (data.data.d == "true") {
                window.location.href = "DashBoard.aspx";
            }
        }, function (err) {
            alert("An error occured during the current process. Please try again later.");
        });
    }

}]);