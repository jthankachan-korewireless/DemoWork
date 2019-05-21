function fnShowRegisterForm() {
    window.location.replace("DepartmentForm.aspx");
}

function fnValidate() {
    var status = false;

    if ($("#txtName").val().trim() == "") {
        $("#txtName").addClass("input-validation-error")
    }
    else {
        $("#txtName").removeClass("input-validation-error")
    }

    if ($("#ddlDepartment").val() == "Select") {
        $("#ddlDepartment").addClass("input-validation-error")
    }
    else {
        $("#ddlDepartment").removeClass("input-validation-error")
    }

    if ($("#txtName").val().trim() != "" && $("#ddlDepartment").val() != "Select") {
        status = true;        
    }
   
    return status;
}

function fnEditDepartmentUser(departmentID, id) {
    window.location.replace("DepartmentForm.aspx?id=" + id);
}

function fnCancel() {
    window.location.replace("DashBoard.aspx");
}

function fnValidateLogin() {
    var status = false;

    if ($("#txtUserName").val().trim() == "") {
        $("#txtUserName").addClass("input-validation-error")
    }
    else {
        $("#txtUserName").removeClass("input-validation-error")
    }

    if ($("#txtPassword").val().trim() == "") {
        $("#txtPassword").addClass("input-validation-error")
    }
    else {
        $("#txtPassword").removeClass("input-validation-error")
    }

    if ($("#txtUserName").val().trim() != "" && $("#txtPassword").val().trim() != "") {
        status = true;
    }

    return status;
}