<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AngularJSSample.Login" %>


<html>
<head runat="server">
    <title></title>
    <script src="Scripts/angular.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/ngStorage.min.js"></script>
    <script src="Scripts/default.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.1/jquery.validate.js"></script>
    <link href="Styles/login.css" rel="stylesheet" />
    <script>
        function fnToggle() {
            $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
        }
    </script>
    <style>
        .has-error {
            border: solid 1px red;
        }
    </style>
</head>


<body>
    <div class="container">

        <div class="login-page">
            <div class="form">
                <form data-ng-app="myApp" data-ng-controller="LoginController" name="loginForm" data-ng-submit="Login()">
                    <input type="text" placeholder="username" data-ng-model="UserName" name="UserEmail" ng-class="{red: ((loginForm.UserEmail.$dirty) && loginForm.UserEmail.$error.required )}" required autofocus />
                    <input type="password" placeholder="password" name="UserPassword" data-ng-model="Password" ng-class="{red:(loginForm.UserPassword.$dirty || loginForm) && myForm.UserPassword.$error.required}" required autofocus />
                    <input type="submit" id="btnLogin" value="Login" class="btn-reg-log" />
                    <p class="message">Not registered? <a href="#" onclick="fnToggle()">Create an account</a></p>
                    <p class="message_error">{{ Loginerror }}</p>
                </form>

                <form name="registerForm" class="register-form" data-ng-submit="Regisetr()">
                    <input type="text" placeholder="username" data-ng-model="UserName" name="UserEmail" ng-class="{red: ((registerForm.UserEmail.$dirty|| submitted) &&registerForm.UserEmail.$error.required )}" required autofocus />
                    <input type="password" placeholder="password" name="UserPassword" data-ng-model="Password" ng-class="{red:(registerForm.UserPassword.$dirty || submitted) && registerForm.UserPassword.$error.required}" required autofocus />
                    <input type="email" placeholder="email address" data-ng-model="UserEmailAddress" name="UserEmailAddress" ng-class="{red: ((registerForm.UserEmailAddress.$dirty || submitted) && registerForm.UserEmailAddress.$error.required )}" required autofocus />
                    <input type="submit" id="btnRegisetr" value="create" class="btn-reg-log" />
                    <p class="message">Already registered? <a href="#" onclick="fnToggle()">Sign In</a></p>
                    <%--<p class="message_error">{{ Regerror }}</p>--%>
                </form>
            </div>
        </div>
    </div>
</body>
</html>







