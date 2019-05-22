<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="AngularJSSample.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/angular.min.js"></script>
    <script src="Scripts/default.js"></script>
    <script src="Scripts/angular-route.min.js"></script>
    <script src="Scripts/ngStorage.min.js"></script>
</head>
<body ng-app="myApp">
    <div ng-controller="FromCtrl" ng-init="GetDepartmentItems()">

        <div class="form">
            <form name="formEdit" data-ng-submit="AddForm()" >
            <table style="margin: auto;">
                <tr>
                    <td>
                        <label id="lblName">Name</label>
                    </td>
                    <td>
                        <input type="text" id="txtName" ng-model="Name" required  ng-model="Name" required/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label id="lblDepartment">Department</label>
                    </td>
                    <td>
                        <select ng-model="Department"  ng-options="x.DepartmentID as x.DepartmentName for x in DepartmentList" required>                        
                        </select>
                    </td>
                </tr>
                 <tr>
                    <td></td>
                    <td>
                        <input type="submit" value="Submit"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type="button" value="Cancel" ng-click="CancelForm()" />
                    </td>
                </tr>
            </table>
                </form>
        </div>

        <%------------------%>

        <!DOCTYPE html>



	



        <%-----------------------------%>
    </div>
</body>
</html>
