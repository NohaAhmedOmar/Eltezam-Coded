
$(document).ready(function () {
    $('.select2Class').select2({
        dir: "rtl",
    });
    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
    BuildDropDown('EmployeeStatusCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز حالة الموظف ')
    BuildDropDown('JobClassCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز سلسلة الفئات الوظيفية ')
    BuildDropDown('RankCode', '/api/DropDowns/GetRankCodeDropDown', 'اختر رمز المرتبة')
    BuildDropDown('EmploymentTypeCode', '/api/DropDowns/GetEmploymentTypeCodeDropDown', 'اختر رمز السلم الوظيفي')
    BuildDropDown('JobNameCode', '/api/DropDowns/GetActualJobNameCodeDropDown', 'اختر رمز مسمى الوظيفة الفعلية')
    BuildDropDown('TransactionCode', '/api/DropDowns/GetTransactionCodeDropDown', 'اختر رمز الإجراء الوظيفي')
    BuildDropDown('PositionStatus', '/api/DropDowns/GetPositionStatusDropDown', 'اختر حالة الوظيفة')

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
function PostJob() {

    var isValid = ValidateForm();
    if (isValid) {
        var employeevalue = $('#employees').val()

      
        var jobDTO = new Object();
        jobDTO.employeeId = employeevalue.split(':')[0];
        jobDTO.nationalID = employeevalue.split(':')[1]

        jobDTO.jobNumber = $('#JobNumber').val()
        jobDTO.jobClassCode = $('#JobClassCode').val()
        jobDTO.jobCatChain = $('#JobCatChain').val()
        jobDTO.jobNameCode = $('#JobNameCode').val()
        $('#JobNameDescription').val() != '' ? jobDTO.jobNameDescription = $('#JobNameDescription').val() : $('#JobNameDescription').val();
        jobDTO.employmentTypeCode = $('#EmploymentTypeCode').val()
        jobDTO.rankCode = $('#RankCode').val()
        jobDTO.stepId = $('#StepID').val()
        jobDTO.startDate = '' + $('#startyear').val() + '-' + $('#startmonth').val() + '-' + $('#startday').val() 
        jobDTO.endDate = '' + $('#endyear').val() + '-' + $('#endmonth').val() + '-' + $('#endday').val() 
        jobDTO.positionOrganizationID = $('#PositionOrganizationID').val()
        jobDTO.positionOrganizationName = $('#PositionOrganizationName').val()
        jobDTO.positionStatus = $('#PositionStatus').val()
        jobDTO.jobTransactionCode = $('#TransactionCode').val()
        jobDTO.locationCode = $('#PositionStatus').val()
        jobDTO.vacantDate = '' + $('#Vacantyear').val() + '-' + $('#Vacantmonth').val() + '-' + $('#Vacantday').val() 
        $('#TransactionDescription').val() != '' ? jobDTO.transactionDescription = $('#TransactionDescription').val() : $('#TransactionDescription').val();


        $.ajax({
            type: "Post",
            url: "/api/Employees/PostJob",
            data: JSON.stringify(jobDTO),
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
        ValidationAlert('لابد من ادخال الموظف   ')
        return false;
    }
    else if ($('#JobNumber').val() == '') {
        ValidationAlert('لابد من ادخال رقم الوظيفة  ')
        return false;
    }
    else if ($('#JobClassCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز سلسلة الفئة الوظيفة  ')
        return false;
    }
    else if ($('#JobNameCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز مسمى الوظيفة    ')
        return false;
    }
    else if ($('#RankCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز المرتبة  ')
        return false;
    }
    else if ($('#TransactionCode').val() == '') {
        ValidationAlert('لابد من ادخال رمز الإجراء الوظيفي  ')
        return false;
    }

    else if ($('#startmonth').val() == '' || $('#startyear').val() == '' || $('#startday').val() == '') {
        ValidationAlert('لابد من ادخال تاريخ البداية     ')
        return false;
    }
    //else if ($('#endmonth').val() == '' || $('#endyear').val() == '' || $('#endday').val() == '') {
    //    ValidationAlert('لابد من ادخال تاريخ النهاية     ')
    //    return false;
    //}
    else if ($('#PositionOrganizationID').val() == '') {
        ValidationAlert('لابد من ادخال رمز الإدارة التي تتبعها الوظيفة    ')
        return false;
    }
    else if ($('#PositionOrganizationName').val() == '') {
        ValidationAlert('لابد من ادخال وصف الإدارة التي تتبعها الوظيفة    ')
        return false;
    }
    else if ($('#PositionStatus').val() == '0') {
        ValidationAlert('لابد من ادخال حالة الوظيفة    ')
        return false;
    }
    else if ($('#EmploymentTypeCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز السلم الوظيفي    ')
        return false;
    }
    else if ($('#RankCode').val() == '0') {
        ValidationAlert('لابد من ادخال رمز المرتبة    ')
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