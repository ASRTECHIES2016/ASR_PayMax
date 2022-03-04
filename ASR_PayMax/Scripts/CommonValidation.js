
// For Only Number's
function OnlyNumber(e) {
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        ShowError('Please enter only number');
        return false;
    }
}

// For Only Character's
function OnlyCharacter(e) {
    var regex = new RegExp("^[a-zA-Z ]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (!regex.test(str)) {
        ShowError('Please enter only character');
        return false;
    }
}

// For Autocomplete TextBox
function IsNotSpecialChar(e) {
    var specialKeys = new Array();
    specialKeys.push(8); //Backspace
    specialKeys.push(9); //Tab
    specialKeys.push(36); //Home
    specialKeys.push(35); //End
    specialKeys.push(37); //Left
    specialKeys.push(39); //Right
    specialKeys.push(46); //Delete
    specialKeys.push(32); //Space
    var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
    var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode) || keyCode == "32" || keyCode == "45" || keyCode == "38");
    if (!ret) {
        ShowError('Special Characters not allowed');
    }
    return ret;
}

// For Minimum 8 Characters at least 1 UpperCase 1 LowerCase 1 number and 1 Special Character is required.

function validPassword(value) {
    var regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$@!%&*?])[A-Za-z\d#$@!%&*?]{8,20}$/;
    if (!regex.test(value)) {
        ShowError('Minimum 8 Characters at least 1 UpperCase 1 LowerCase 1 number and 1 Special Character is required .');
        return false;
    } else {
        return true;
    }
}


// For Message Popup's
function ShowSuccess(msg) {
    $('#DynamicMessage').remove();
    var div = document.createElement('div');
    div.setAttribute('id', 'DynamicMessage');
    div.className = 'position-fixed alert alert-dismissible fade show bg-success text-white';
    div.style.cssText = 'top: 60px; right: 3px; z-index: 5000;';
    div.setAttribute('role', 'alert');
    $(div).append('<h4 class="alert-heading">Success...!</h4>');
    $(div).append('<p>' + msg + '</p>');
    $(div).append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true" >&times;</span></button>');

    document.body.appendChild(div);
    fadeout();
    return true;
}
function ShowWarning(msg) {
    $('#DynamicMessage').remove();
    var div = document.createElement('div');
    div.setAttribute('id', 'DynamicMessage');
    div.className = 'position-fixed alert alert-dismissible fade show bg-warning text-white';
    div.style.cssText = 'top: 60px; right: 3px; z-index: 5000;';
    div.setAttribute('role', 'alert');
    $(div).append('<h4 class="alert-heading">Warning...!</h4>');
    $(div).append('<p>' + msg + '</p>');
    $(div).append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true" >&times;</span></button>');

    document.body.appendChild(div);
    fadeout();
    return true;
}
function ShowFailure(msg) {
    $('#DynamicMessage').remove();
    var div = document.createElement('div');
    div.setAttribute('id', 'DynamicMessage');
    div.className = 'position-fixed alert alert-dismissible fade show bg-dark text-white';
    div.style.cssText = 'top: 60px; right: 3px; z-index: 5000;';
    div.setAttribute('role', 'alert');
    $(div).append('<h4 class="alert-heading">Warning...!</h4>');
    $(div).append('<p>' + msg + '</p>');
    $(div).append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true" >&times;</span></button>');

    document.body.appendChild(div);
    fadeout();
    return true;
}
function ShowError(msg) {
    $('#DynamicMessage').remove();
    var div = document.createElement('div');
    div.setAttribute('id', 'DynamicMessage');
    div.className = 'position-fixed alert alert-dismissible fade show bg-danger text-white';
    div.style.cssText = 'top: 60px; right: 3px; z-index: 5000; max-width: 98vw;';
    div.setAttribute('role', 'alert');
    $(div).append('<h4 class="alert-heading">Not Found...!</h4>');
    $(div).append('<div>' + msg + '</div>');
    $(div).append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true" >&times;</span></button>');

    document.body.appendChild(div);
    fadeout();
    return true;
}
function ShowMessages(Messages, Seconds) {
    debugger;
    $('#DynamicMessage').remove();
    var div = document.createElement('div');
    div.setAttribute('id', 'DynamicMessage');
    div.className = 'position-fixed alert alert-dismissible fade show bg-info text-white';
    div.style.cssText = 'top: 60px; right: 3px; z-index: 5000; max-width: 98vw;';
    div.setAttribute('role', 'alert');
    $(div).append('<div><h4 class="alert-heading">' + Messages + '</h4></div>');
    $(div).append('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true" >&times;</span></button>');
    document.body.appendChild(div);
    setTimeout(function () { $('#DynamicMessage').fadeOut(); }, (Seconds * 1000));
    return true;
}
function fadeout() {
    setTimeout(function () { $('#DynamicMessage').fadeOut(); }, 5000);
}
function CheckDec(evt, maxlen, prec) {
    var key = (evt.which) ? evt.which : event.keyCode;


    if (key == 47)
        return false;


    if (evt.ctrlKey == true && key == 118)
        return true;


    if ((key > 31 && (key < 46 || key > 57)))
        return false;


    var test = evt.target || evt.srcElement;
    var parts = test.value.split('.');

    if (key == 46)
        return (parts.length == 1);


    if (test.value.length >= (maxlen - prec - 1) && parts.length == 1 && (key >= 48 && key <= 57))
        return false;


    if (key != 8 && key != 46) {
        if (parts[0].length == (maxlen - prec - 1)) {
            if (parts[1].length <= prec && test.selectionStart <= (maxlen - prec - 1))
                return false;
        }
        if (parts[0].length < (maxlen - prec - 1)) {
            if (parts[1] !== undefined) {
                if (parts[1].length == prec && test.selectionStart > parts[0].length)
                    // ShowWarning('Warning', 'Allow Only Decimal Value', 3000);
                    return false;
            }
        }
    }
}
// For Gridview

function GridPageLength(GridID_1, GridID_2, GridID_3, GridID_4, GridID_5, GridID_6, GridID_7, GridID_8, GridID_9, GridID_10, Length, Filter) {
    debugger;
    var len = 0;
    if (GridID_1 != '') {
        len = $("#" + GridID_1).find('tr').length;
        if (len > 1) {
                        $("#" + GridID_1 + ' thead').remove();
            $("#" + GridID_1).prepend($("<thead></thead>").append($("#" + GridID_1).find("tr:first"))).dataTable({
                destroy: true,
                pageLength: Length,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: Filter,
            });
        }
    }
}
function GridMasters(GridID_1, GridID_2, GridID_3, GridID_4, GridID_5, GridID_6, GridID_7, GridID_8, GridID_9, GridID_10) {
    var len = 0;
    if (GridID_1 != '') {

        len = $("#" + GridID_1).find('tr').length;
        if (len > 1) {

            $("#" + GridID_1 + ' thead').remove();
            $("#" + GridID_1).prepend($("<thead></thead>").append($("#" + GridID_1).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                stateSave: true,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_2 != '') {

        len = $("#" + GridID_2).find('tr').length;
        if (len > 1) {
            $("#" + GridID_2 + ' thead').remove();
            $("#" + GridID_2).prepend($("<thead></thead>").append($("#" + GridID_2).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_3 != '') {

        len = $("#" + GridID_3).find('tr').length;
        if (len > 1) {
            $("#" + GridID_3 + ' thead').remove();
            $("#" + GridID_3).prepend($("<thead></thead>").append($("#" + GridID_3).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_4 != '') {

        len = $("#" + GridID_4).find('tr').length;
        if (len > 1) {
            $("#" + GridID_4 + ' thead').remove();
            $("#" + GridID_4).prepend($("<thead></thead>").append($("#" + GridID_4).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_5 != '') {

        len = $("#" + GridID_5).find('tr').length;
        if (len > 1) {
            $("#" + GridID_5 + ' thead').remove();
            $("#" + GridID_5).prepend($("<thead></thead>").append($("#" + GridID_5).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_6 != '') {

        len = $("#" + GridID_6).find('tr').length;
        if (len > 1) {
            $("#" + GridID_6 + ' thead').remove();
            $("#" + GridID_6).prepend($("<thead></thead>").append($("#" + GridID_6).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_7 != '') {

        len = $("#" + GridID_7).find('tr').length;
        if (len > 1) {
            $("#" + GridID_7 + ' thead').remove();
            $("#" + GridID_7).prepend($("<thead></thead>").append($("#" + GridID_7).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_8 != '') {

        len = $("#" + GridID_8).find('tr').length;
        if (len > 1) {
            $("#" + GridID_8 + ' thead').remove();
            $("#" + GridID_8).prepend($("<thead></thead>").append($("#" + GridID_8).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_9 != '') {

        len = $("#" + GridID_9).find('tr').length;
        if (len > 1) {
            $("#" + GridID_9 + ' thead').remove();
            $("#" + GridID_9).prepend($("<thead></thead>").append($("#" + GridID_9).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
    len = 0;
    if (GridID_10 != '') {

        len = $("#" + GridID_10).find('tr').length;
        if (len > 1) {
            $("#" + GridID_10 + ' thead').remove();
            $("#" + GridID_10).prepend($("<thead></thead>").append($("#" + GridID_10).find("tr:first"))).dataTable({
                destroy: true,
                stateSave: true,
                pageLength: 10,
                responsive: true,
                pagingType: "first_last_numbers",
                bFilter: true,
            });
        }
    }
}
$(function () {
    AutoCompleteText();
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        AutoCompleteText();
    });
});

// For Date Picker
function AutoCompleteText() {
    $(".Date").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'dd-MMM-yyyy',
        Option: 'clip'
    });
    //$(".MonthDate").datepicker({
    //    changeMonth: true,
    //    changeYear: true,
    //    dateFormat: 'M-yy',
    //    Option: 'clip'
    //});




    $('#txtEmployeeCode').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_EmployeeDetailByCode",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtEmployeeCode').val() + "'}",
                dataType: "json",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Str_EmployeeCode, value: item.Str_EmployeeCode, ID: item.Str_EmployeeID
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 1,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {
                $('[id*=hddEmployeeID]').val(i.item.ID);
                BindDataByEmployeeID(i.item.ID, '#txtFirstName')
            }
        }
    });

    $('#txtEmployeeName').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_EmployeeDetailByFirstName",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtEmployeeName').val() + "'}",
                dataType: "json",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Str_EmployeeName, value: item.Str_EmployeeName, ID: item.Str_EmployeeID
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 1,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {
                $('[id*=hddEmployeeID]').val(i.item.ID);
                BindDataByEmployeeID(i.item.ID, '#txtEmployeeName')
            }
        }
    });




    $('#txtUnpostedCode').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_UnPostedEmployeeByCode",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtUnpostedCode').val() + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d != null) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.Str_EmployeeCode, value: item.Str_EmployeeCode, ID: item.Str_EmployeeID
                            }
                        }));
                    }
                    else {
                        response([{ label: 'No results found.', ID: "0" }]);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 1,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {
                $('[id*=hddEmployeeID]').val(i.item.ID);
                BindDataByEmployeeID(i.item.ID, '#txtUnpostedEmployee')
            }
        }
    });



    $('#txtUnpostedEmployee').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_UnPostedEmployeeByFirstName",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtUnpostedEmployee').val() + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d != null) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.Str_EmployeeName, value: item.Str_EmployeeName, ID: item.Str_EmployeeID, Code: item.Str_EmployeeCode
                            }
                        }));
                    }
                    else {
                        response([{ label: 'No results found.', ID: "0" }]);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 1,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {

                $('[id*=hddEmployeeID]').val(i.item.ID);
                $('[id*=txtUnpostedCode]').val(i.item.Code);
            }
        }
    });



    $('#txtUserName').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_UserByFullName",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtUserName').val() + "'}",
                dataType: "json",
                success: function (data) {

                    response($.map(data.d, function (item) {
                        return {
                            label: item.Str_UserName, value: item.Str_UserName, ID: item.Str_UserID
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 3,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {
                $('[id*=hddUserID]').val(i.item.ID);
                //     BindDataByEmployeeID(i.item.ID, '#txtUserName')
            }
        }
    });



    $('#txtPincode').autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "post",
                url: "/PayMaxDashboard.aspx/Get_Pincode",
                contentType: "application/json; charset=utf-8",
                data: "{ Prefix:'" + $('#txtPincode').val() + "'}",
                dataType: "json",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.Str_PincodeCode, value: item.Str_PincodeCode, ID: item.Str_PincodeID
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log('Please try again later.')
                }
            });
        },
        minLength: 3,
        select: function (e, i) {
            if (i.item == null || i.item == "") {
            } else {
                $('[id*=hddPincodeID]').val(i.item.ID);
                BindPincodeDataByID(i.item.ID);
            }
        }
    });




}

function BindDataByEmployeeID($Str_Value, $ControlName) {
    $.ajax({
        type: "post",
        url: "/PayMaxDashboard.aspx/Get_EmployeeDetailByID",
        contentType: "application/json; charset=utf-8",
        data: "{ Prefix:'" + $Str_Value + "'}",
        dataType: "json",
        success: function (data) {

            if (data != null) {
                $($ControlName).val(data.d[0].Str_EmployeeName);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log('Please try again later.');
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}



function BindPincodeDataByID($Str_Value, $ControlName) {
    $.ajax({
        type: "post",
        url: "/PayMaxDashboard.aspx/Get_Pincode",
        contentType: "application/json; charset=utf-8",
        data: "{ Prefix:'" + $Str_Value + "'}",
        dataType: "json",
        success: function (data) {

            if (data != null) {
                $('$ControlName').val(data.d[0].Str_Pincode);
                $('#ddlCity').val(data.d[0].Str_City);
                $('#ddlState').val(data.d[0].Str_State);
                $('#ddlCountry').val(data.d[0].Str_Country);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log('Please try again later.');
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}





