
var Employees = new Array();
var checkeddata = new Array();
var idArray = new Array();
var ids = new Array();
var i = 0, j = 0;
let functionCalledFlag = true;

$(document).ready(function () {
    GetEmployees();
})
function GetEmployees() {
    debugger
    $.ajax({
        type: "Get",
        url: '/api/Employees/GetEmployeesPaysView',
        success: function (results) {
       
            $.each(results.data, function (i, result) {
                Employees.push({
                    id: result.id, name: result.name, elementClassification: result.elementClassification, netPay: result.netPay,
                    amount: result.amount, rankCode: result.rankCode, paidDate: result.paidDate, rankCodeKey: result.rankCodeKey,
                    elementCode: result.elementCode, employmentTypeCode: result.employmentTypeCode, stepId: result.stepId,
                    consolidationSetId: result.consolidationSetId, hijriMonth: result.hijriMonth, gregorianMonth: result.gregorianMonth,
                    hijriYear: result.hijriYear, gregorianYear: result.gregorianYear
                });
            });
            $('#employeeData').DataTable({
                'language': {
                    url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/ar.json',
                },
                'destroy': true,
                'data': Employees,
                'columns': [
                    { 'data': 'name' },
                    { 'data': 'elementClassification' },
                    { 'data': 'netPay' },
                    { 'data': 'amount' },
                    { 'data': 'rankCode' },
                    { 'data': 'paidDate' },
                    {
                        'data': 'id',
                        render: function (data) {
                            return '<input type="checkbox" id="check' + data + '" />';

                        }
                    }
                ]
            });

           // $('#employees').html(table)
        }
    })
}
function SubmitSheet() {
    if (document.getElementById("sheet").files[0] != null) {
var Sheet = new FormData();
    Sheet.append("Sheet", document.getElementById("sheet").files[0])
    console.log($('#sheet').val())
    $.ajax({
        type: "Post",
        url: '/api/UploadSheets/PostEmployeePaysExcelSheet',
        data: Sheet,
        processData: false,
        contentType: false,
        success: function (result) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'تمت الاضافة بنجاح ورقم الطلب ' + result.requestNumber + '',
                showConfirmButton: false,
                timer: 2000
            })



        },
        error: function (ex) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'هناك خطأ',
                showConfirmButton: false,
                timer: 2000
            })
        }
    });
    }
    else {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: ' لابد من اختيار الملف',
            showConfirmButton: false,
            timer: 2000
        })
    }
    
}
function sendToService(id) {
    debugger
    idArray = new Array();

    if (functionCalledFlag == true) {
        for (var i = 0; i < Employees.length; i++) {
            if ($('#check' + Employees[i].id + '').is(":checked")) {
                checkeddata.push(Employees[i].id)
            }
        }
        functionCalledFlag = false;
    }
    idArray.push(checkeddata[j]);

    if (checkeddata.length != 0) {
        $.ajax({
            type: "Post",
            url: "/api/SendToService/SendPayslipInfoToService",
            data: JSON.stringify(ids),
            contentType: "application/json",
            success: function (result) {
                j++;
                sendAllDataToService(idArray[j]);
                if (i == Employees.length - 1) {
                    i = 0;
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        title: 'تمت الاضافة بنجاح',
                        showConfirmButton: false,
                        timer: 20000
                    })
                }
            },
            error: function (ex) {
                j++;
                sendAllDataToService(idArray[j]);
                if (i == Employees.length - 1) {
                    i = 0;
                    Swal.fire({
                        position: 'center',
                        icon: 'error',
                        title: 'هناك خطأ',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
            }
        });
    }
    else {
        Swal.fire({
            position: 'center',
            icon: 'error',
            title: ' لابد من اختيار بيانات',
            showConfirmButton: false,
            timer: 2000
        })
    }
}

function sendAllDataToService(id) {
    debugger
    ids = new Array();
    ids.push(Employees[i].id);
    $.ajax({
        type: "Post",
        url: "/api/SendToService/SendPayslipInfoToService",
        data: JSON.stringify(ids),
        contentType: "application/json",
        success: function (result) {
            i++;
            sendAllDataToService(Employees[i].id);
            if (i == Employees.length - 1) {
                i = 0;
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'تمت الاضافة بنجاح',
                    showConfirmButton: false,
                    timer: 20000
                })
            }
        },
        error: function (ex) {
            i++;
            sendAllDataToService(Employees[i].id);
            if (i == Employees.length - 1) {
                i = 0;
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: 'هناك خطأ',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        }
    });
}

function BulkDelete() {
    var selectedToDelete = new Array();
    for (var i = 0; i < Employees.length; i++) {
        if ($('#check' + Employees[i].id + '').is(":checked")) {
            selectedToDelete.push(Employees[i].id)
        }
    }
    if (selectedToDelete.length != 0) {
        Swal.fire({
            title: 'هل تريد الاستمرار؟',
            text: "لن تتمكن من استعادة المحذوفات",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'الغاء',
            confirmButtonText: 'مسح'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "Post",
                    url: "/api/Employees/BulkDeleteEmployeePays",
                    data: JSON.stringify(selectedToDelete),
                    contentType: "application/json",
                    success: function (results) {
                        Swal.fire({
                            position: 'center',
                            icon: 'success',
                            title: 'تم الحذف بنجاح  ',
                            showConfirmButton: false,
                            timer: 2000
                        })

                        var data = except(selectedToDelete, Employees)
                        console.log(data)

                        $('#employeeData').DataTable().destroy();

                        BuildDataTable(data)

                        // $('#employeeData').DataTable().destroy()
                    }
                })
            }
        })
    }
    else {
        ValidationAlert('لابد من اختيار بيانات')

    }


}
function except(collection1, collection2) {
    debugger
    var result = new Array();
    for (var i = 0; i < collection1.length; i++) {
        for (var j = 0; j < collection2.length; j++) {
            if (collection1[i] != collection2[j].id) {
                result.push(collection2[j]);
            }
        }
    }
    console.log(result)
    return result;
}
function BuildDataTable(data) {
    $('#employeeData').DataTable({
        'language': {
            url: '//cdn.datatables.net/plug-ins/1.13.6/i18n/ar.json',
        },
        'destroy': true,
        'data': data,
        'columns': [
            { 'data': 'name' },
            { 'data': 'elementClassification' },
            { 'data': 'netPay' },
            { 'data': 'amount' },
            { 'data': 'rankCode' },
            { 'data': 'paidDate' },
            {
                'data': 'id',
                render: function (data) {
                    return '<input type="checkbox" id="check' + data + '" />'

                }
            }


        ]
    });
}
function renderDate(dayId, monthId) {
    var month = $("#" + monthId + "").val();
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 9 || month == 11) {
        $("#" + dayId + "").empty();
        for (var i = 1; i <= 30; i++) {

            $("#" + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else if (month == 2) {
        $("#" + dayId + "").empty();

        for (var i = 1; i <= 29; i++) {

            $("#" + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else {
        $("#" + dayId + "").empty();

        for (var i = 1; i <= 30; i++) {
            $("#" + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }

}
function SendAjaxToGetArray(collection, url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {


            $.each(results, function (i, result) {

                var obj = new Object();
                obj.Id = result.id; obj.Value = result.value;
                collection.push(obj);


            });
        }
    })
}
function BuildDropDown(dropdownId, url, Message) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {
            $("#" + dropdownId + '').empty();
            $("#" + dropdownId + '').append($('<option></option>').attr('value', 0).text(Message));

            $.each(results, function (i, result) {

                $("#" + dropdownId + '').append($('<option></option>').attr('value', result.id).text(result.value));


            });
        }
    })
}
function BuildDropDownBasedOnSelection(dropdownId, subDropDownId, url, message) {

    var subDropDown = $('#' + subDropDownId + '');
    var superDropDown = $('#' + dropdownId + '').val();
    subDropDown.empty();
    $.ajax({
        type: "Get",
        url: url + superDropDown + "",
        success: function (results) {
            subDropDown.append($('<option></option>').attr('value', 0).text(message));
            $.each(results, function (i, result) {


                subDropDown.append($('<option></option>').attr('value', result.id).text(result.value));


            });
        }
    })
}
function ValidationAlert(Message) {
    Swal.fire({
        title: Message,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}