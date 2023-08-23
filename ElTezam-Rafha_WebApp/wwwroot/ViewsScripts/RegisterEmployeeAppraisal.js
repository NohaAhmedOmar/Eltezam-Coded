var blocknumber = 0;
var gradday = 'gradday'
var gradmonth = 'gradmonth'
var Nations = new Array();
var Emlpoyees = new Array();
var Grades = new Array();
var Universities = new Array();
var Major = new Array();
var Qualifications = new Array();
var QualificationStatus = new Array();
$(document).ready(function () {
    $('#employees').select2()
    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
   // SendAjaxToGetArray(Emlpoyees, '/api/Employees/GetEmployees')
  //  console.log(Emlpoyees)
 //   BuildDropDownFromArray('employees', Emlpoyees, 'اختر الموظف')
    BuildDropDown('AppraisalTypeCode', '/api/DropDowns/GetAppraisalTypesDropDown', 'اختر نوع التقييم')
    BuildDropDown('RatingCode', '/api/DropDowns/GetGradesDropDown', 'اختر التقدير')



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
function BuildDropDownFromArray(dropdownId, collection, Message) {
    debugger
    $("#" + dropdownId + '').change();
    $("#" + dropdownId + '').empty();
    $("#" + dropdownId + '').append($('<option></option>').attr('value', 0).text(Message));
    for (var i = 0; i < collection.length; i++) {
        $("#" + dropdownId + '').append($('<option></option>').attr('value', collection[i].Id).text(collection[i].Value));

    }
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
function PostEmployeeAppraisal() {
    var isValid = ValidateForm();
    if (isValid) {
        var employeevalue = $('#employees').val();
        var employeeAppraisalInfoDTO = new Object()
        employeeAppraisalInfoDTO.employeeId = employeevalue.split(':')[0];
        employeeAppraisalInfoDTO.appraisalTypeCode = $('#AppraisalTypeCode').val()
        employeeAppraisalInfoDTO.nationalID = employeevalue.split(':')[1]
        employeeAppraisalInfoDTO.result = $('#Result').val()
        employeeAppraisalInfoDTO.ratingCode = $('#RatingCode').val()
        employeeAppraisalInfoDTO.startDate = '' + $('#startyear').val() + '-' + $('#startmonth').val() + '-' + $('#startday').val() + 'T00:00:00'
        employeeAppraisalInfoDTO.endDate = '' + $('#endyear').val() + '-' + $('#endmonth').val() + '-' + $('#endday').val() + 'T00:00:00'
        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployeeAppraisal",
            data: JSON.stringify(employeeAppraisalInfoDTO),
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
    else if ($('#startmonth').val() == '' || $('#startyear').val() == '' || $('#startday').val() == '') {
        ValidationAlert('لابد من ادخال تاريخ بداية التقييم  ')
        return false;
    }
    else if ($('#endmonth').val() == '' || $('#endyear').val() == '' || $('#endday').val() == '') {
        ValidationAlert('لابد من ادخال تاريخ نهاية التقييم  ')
        return false;
    }
    else if ($('#AppraisalTypeCode').val() == '0') {
        ValidationAlert('لابد من ادخال نوع التقييم  ')
        return false;
    }
    else if ($('#RatingCode').val() == '0') {
        ValidationAlert('لابد من ادخال التقدير  ')
        return false;
    }
    else if ($('#Result').val() == '0') {
        ValidationAlert('لابد من ادخال النتيجة   ')
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