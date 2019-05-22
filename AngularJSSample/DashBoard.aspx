<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="AngularJSSample.DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/default.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/ngStorage.min.js"></script>
    <link href="Styles/main.css" rel="stylesheet" />
    <link href="Styles/perfect-scrollbar.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.13.1/jquery.validate.js"></script>
    <script src="Scripts/perfect-scrollbar.min.js"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
    <script src="https://use.fontawesome.com/6ad8706a1a.js"></script>
    <script>
        $('.js-pscroll').each(function () {
            var ps = new PerfectScrollbar(this);

            $(window).on('resize', function () {
                ps.update();
            })
        });
    </script>

</head>
<body ng-app="myApp">
    <div ng-controller="DashBoardCtrl" ng-init="GetListItems()">
        <div class="limiter">
            <div class="rightbtn">
                <input type="button" value="Add new" ng-click="FormOpen()" class="btn-add-new" />

            </div>
            <div class="container-table100">
                <div class="wrap-table100">
                    <div class="table100 ver1 m-b-110">
                        <div class="table100-head">
                            <table>
                                <thead>
                                    <tr class="row100 head">
                                        <th class="cell100 head1">Name</th>
                                        <th class="cell100 head2">Department</th>
                                        <th class="cell100 head3" colspan="2">Actions</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                        <div class="table100-body js-pscroll">
                            <table>
                                <tbody>
                                    <tr ng-repeat="x in records" class="row100 body">
                                        <td class="cell100 column1">{{x.Name}}</td>
                                        <td class="cell100 column2">{{x.Department}}</td>
                                        <td class="cell100 column3">
                                            <button type="button" rel="tooltip" title="Edit" class="" ng-click="EditClick(x)">
                                                <i class="fa fa-pencil"></i>
                                            </button>
                                        </td>
                                        <td class="cell100 column4">
                                            <button type="button" rel="tooltip" title="Delete" class="" ng-click="DeleteClick(x)">
                                                <i class="fa fa-trash"></i>
                                            </button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <%----------------------------%>
    </div>
</body>
</html>
