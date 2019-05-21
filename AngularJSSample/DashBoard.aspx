<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="AngularJSSample.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/default.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/ngStorage.min.js"></script>
    <link href="Styles/Sample.css" rel="stylesheet" />
</head>
<body ng-app="myApp">
    <div ng-controller="DashBoardCtrl" ng-init="GetListItems()">
        <input type="button" value="Add new" ng-click="FormOpen()" />
        <div class="dvtable-responsive">

            <table class="tblDashBoard">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Department</th>
                         <th colspan="2">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr ng-repeat="x in records">
                        <td>{{x.Name}}</td>
                        <td>{{x.Department}}</td>
                        <td><button type="button" rel="tooltip" title="Edit" class="" ng-click="EditClick(x)">
                                            <i class="material-icons">Edit</i>
                                        </button></td>
                        <td><button type="button" rel="tooltip" title="Delete" class="" ng-click="DeleteClick(x)" >
                                            <i class="material-icons">Delete</i>
                                        </button></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>
