var blocknumber = 0;
var gradday = 'gradday'
var gradmonth = 'gradmonth'
var Nations = new Array();
var Grades = new Array();
var Universities = new Array();
var Major = new Array();
var Qualifications = new Array();
var QualificationStatus = new Array();
$(document).ready(function () {
    $('.select2Class').select2({
        dir: "rtl",
    });


    //$('#employees').select2({
    //    dir: "rtl",
    //});
    //$('#EmploymentTypeCode').select2({
    //    dir: "rtl",
    //});
    //$('#RankCode').select2({
    //    dir: "rtl",
    //});
    //$('#ConsolidationSetID').select2({
    //    dir: "rtl",
    //});
    //$('#ElementCode').select2({
    //    dir: "rtl",
    //});
    //$('#ElementClassification').select2({
    //    dir: "rtl",
    //});
    //$('#payday').select2({
    //    dir: "rtl",
    //});
    //$('#payyear').select2({
    //    dir: "rtl",
    //});
    //$('#paymonth').select2({
    //    dir: "rtl",
    //});

    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
    BuildDropDown('EmploymentTypeCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر رمز السلم الوظيفي')
    BuildDropDown('RankCode', '/api/DropDowns/GetRankCodeDropDown', 'اختر رمز المرتبة')
    BuildDropDown('ConsolidationSetID', '/api/DropDowns/GetConsolidationSetDropDown', 'اختر رمز نوع المسير')
    BuildDropDown('ElementCode', '/api/DropDowns/GetElementCodeDropDown', 'اختر رمز عنصر الصرف')
    BuildDropDown('ElementClassification', '/api/DropDowns/GetElementClassificationTypeDropDown', 'اختر تصنيف العنصر')
})
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
function PostEmployeePayment() {
    //var isValid = ValidateForm();
    var isValid = $('form')[0].checkValidity();
    if (isValid) {
        var employeevalue = $('#employees').val();
        var employeePaymentDTO = new Object()
        employeePaymentDTO.employeeId = employeevalue.split(':')[0];
        employeePaymentDTO.nationalId = employeevalue.split(':')[1]
        employeePaymentDTO.employeeName = $('#employees option:selected').text()
        employeePaymentDTO.employmentTypeCode = $('#EmploymentTypeCode').val()
        employeePaymentDTO.rankCode = $('#RankCode').val()
        employeePaymentDTO.stepId = $('#StepID').val()
        employeePaymentDTO.consolidationSetId = $('#ConsolidationSetID').val()
        $('#ConsolidationSetDescription').val() != '' ? employeePaymentDTO.consolidationSetDescription = $('#ConsolidationSetDescription').val() : employeevalue;
        employeePaymentDTO.elementCode = $('#ElementCode').val()
        employeePaymentDTO.amount = $('#Amount').val()
        employeePaymentDTO.elementClassification = $('#ElementClassification').val()
        employeePaymentDTO.netPay = $('#NetPay').val()
        employeePaymentDTO.hijriMonth = $('#HijriMonth').val()
        employeePaymentDTO.hijriYear = $('#HijriYear').val()
        employeePaymentDTO.gregorianYear = $('#GregorianYear').val()
        employeePaymentDTO.gregorianMonth = $('#GregorianMonth').val()
        employeePaymentDTO.paidDate = '' + $('#payyear').val() + '-' + $('#paymonth').val() + '-' + $('#payday').val() + 'T00:00:00'
        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployeePays",
            data: JSON.stringify(employeePaymentDTO),
            contentType: "application/json",
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

}
function ValidateForm() {
    if ($('#employees').val() == '0') {
        ValidationAlert('لابد من اختيار الموظف')
        return false;
    }
  

    else if ($('#EmploymentTypeCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز السلم الوظيفي  ')
        return false;
    }
    else if ($('#RankCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز المرتبة  ')
        return false;
    }
    else if ($('#StepID').val() == '') {
        ValidationAlert('لابد من ادخال الدرجة   ')
        return false;
    }
    else if ($('#ElementCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز عنصر الصرف   ')
        return false;
    }
    else if ($('#Amount').val() == '') {
        ValidationAlert('لابد من ادخال القيمة   ')
        return false;
    }
    else if ($('#ElementClassification').val() == '0') {
        ValidationAlert('لابد من ادخال تصنيف العنصر   ')
        return false;
    }
    else if ($('#ElementClassification').val() == '0') {
        ValidationAlert('لابد من ادخال تصنيف العنصر   ')
        return false;
    }
    else if ($('#NetPay').val() == '') {
        ValidationAlert('لابد من ادخال صافي المبلغ المدفوع   ')
        return false;
    }
    else if ($('#HijriMonth').val() == '') {
        ValidationAlert('لابد من ادخال الشهر بالهجري   ')
        return false;
    }
    else if ($('#GregorianMonth').val() == '') {
        ValidationAlert('لابد من ادخال الشهر بالميلادي   ')
        return false;
    }
    else if ($('#HijriYear').val() == '') {
        ValidationAlert('لابد من ادخال السنة بالهجري   ')
        return false;
    }
    else if ($('#GregorianYear').val() == '') {
        ValidationAlert('لابد من ادخال السنة بالميلادي   ')
        return false;
    }
    else if ($('#paymonth').val() == '' || $('#payyear').val() == '' || $('#payday').val() == '') {
        ValidationAlert('لابد من ادخال تاريخ تنفيذ المسير   ')
        return false;
    }
    return true;
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