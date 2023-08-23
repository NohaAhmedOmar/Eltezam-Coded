
$(document).ready(function () {
    $('#employees').select2()
    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
    BuildDropDown('EmployeeStatusCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز حالة الموظف ')
    BuildDropDown('JobClassCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز سلسلة الفئات الوظيفية ')
    BuildDropDown('RankCode', '/api/DropDowns/GetRankCodeDropDown', 'اختر رمز المرتبة')
    BuildDropDown('EmploymentTypeCode', '/api/DropDowns/GetEmploymentTypeCodeDropDown', 'اختر رمز السلم الوظيفي')
    BuildDropDown('JobNameCode', '/api/DropDowns/GetActualJobNameCodeDropDown', 'اختر رمز مسمى الوظيفة الفعلية')
    BuildDropDown('TransactionCode', '/api/DropDowns/GetTransactionCodeDropDown', 'اختر رمز الإجراء الوظيفي')
    BuildDropDown('TerminationReasonCode', '/api/DropDowns/GetTerminationCodeDropDown', 'اختر رمز سبب الانتهاء')

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
function PostEmployeeHistorical() {
    var isValid = ValidateForm();
    var employeeJobDTO = new Object();
    var employeevalue = $('#employees').val()

    if (isValid) {


        employeeJobDTO.employeeId = employeevalue.split(':')[0];
        employeeJobDTO.nationalID = employeevalue.split(':')[1];
        $('#JobClassDescription').val() != '' ? employeeJobDTO.jobClassDescription = $('#JobClassDescription').val() : $('#JobClassDescription').val();
        if ($('#stepyear').val() != '' && $('#stepmonth').val() != '' && $('#stepday').val() != '')
             employeeJobDTO.stepDate = '' + $('#stepyear').val() + '-' + $('#stepmonth').val() + '-' + $('#stepday').val() + 'T00:00:00'
        employeeJobDTO.jobNumber = $('#JobNumber').val()
        employeeJobDTO.jobClassCode = $('#JobClassCode').val()
        employeeJobDTO.jobCatChain = $('#JobCatChain').val() != '' ? employeeJobDTO.jobCatChain = $('#JobCatChain').val() : isValid;
        employeeJobDTO.jobNameCode = $('#JobNameCode').val()
        $('#JobNameDescription').val() != '' ? employeeJobDTO.jobNameDescription = $('#JobNameDescription').val() : $('#JobNameDescription').val();
        employeeJobDTO.employmentTypeCode = $('#EmploymentTypeCode').val()
        $('#EmploymentTypeDescription').val() != '' ? employeeJobDTO.employmentTypeDescription = $('#EmploymentTypeDescription').val() : $('#EmploymentTypeDescription').val();
        $('#RankDescription').val() != '' ? employeeJobDTO.descriptionType = $('#RankDescription').val() : $('#RankDescription').val();
        employeeJobDTO.rankCode = $('#RankCode').val()
        $('#StepID').val() != '' ? employeeJobDTO.stepId = $('#StepID').val() : isValid;
        $('#actualJobNameDescription').val() != '' ? employeeJobDTO.actualJobNameDescription = $('#actualJobNameDescription').val() : $('#actualJobNameDescription').val();
        employeeJobDTO.decisionNumber = $('#DecisionNumber').val()
        if ($('#Decisionyear').val() != '' && $('#Decisionmonth').val() != '' && $('#Decisionday').val() != '')
            employeeJobDTO.decisionDate = '' + $('#Decisionyear').val() + '-' + $('#Decisionmonth').val() + '-' + $('#Decisionday').val() + 'T00:00:00'

        if ($('#Gradeyear').val() != '' && $('#Grademonth').val() != '' && $('#Gradeday').val() != '')
        employeeJobDTO.gradeDate = '' + $('#Gradeyear').val() + '-' + $('#Grademonth').val() + '-' + $('#Gradeday').val() + 'T00:00:00'
         $('#BasicSalary').val() != '' ? employeeJobDTO.basicSalary = $('#BasicSalary').val() : isValid;
            employeeJobDTO.transactionCode = $('#TransactionCode').val()
        employeeJobDTO.locationCode = $('#TransactionCode').val()
        $('#transactionDescription').val() != '' ? employeeJobDTO.transactionDescription = $('#transactionDescription').val() : $('#transactionDescription').val();
        if ($('#TransactionEndyear').val() != '' && $('#TransactionEndmonth').val() != '' && $('#TransactionEndday').val() != '')
        employeeJobDTO.transactionEndDate = '' + $('#TransactionEndyear').val() + '-' + $('#TransactionEndmonth').val() + '-' + $('#TransactionEndday').val() + 'T00:00:00'
        employeeJobDTO.transactionStartDate = '' + $('#TransactionStartyear').val() + '-' + $('#TransactionStartmonth').val() + '-' + $('#TransactionStartday').val() + 'T00:00:00';

        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployeeHistoricalInfo",
            data: JSON.stringify(employeeJobDTO),
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
          else if ($('#JobClassCode').val() == '0') {
              ValidationAlert('لابد من ادخال رمز سلسلة الفئات الوظيفية  ')
                return false;
            }
          else if ($('#JobNameCode').val() == '0') {
              ValidationAlert('لابد من ادخال رمز مسمى الوظيفة  ')
                return false;
            }
          else if ($('#EmploymentTypeCode').val() == '0') {
              ValidationAlert('لابد من ادخال رمز السلم الوظيفي    ')
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
           
          else if ($('#TransactionStartmonth').val() == '' || $('#TransactionStartyear').val() == '' || $('#TransactionStartday').val() == '') {
              ValidationAlert('لابد من ادخالتاريخ بداية الإجراء    ')
                return false;
            }
            else if ($('#stepID').val() == '') {
                ValidationAlert('لابد من ادخال الدرجة    ')
                return false;
            }
            else if ($('#grademonth').val() == '' || $('#gradyear').val() == '' || $('#gradday').val() == '') {
                ValidationAlert('لابد من ادخال تاريخ الحلول في المرتبة    ')
                return false;
            }
            //else if ($('#actualJobNameCode').val() == '0') {
            //    ValidationAlert('لابد من ادخال رمز مسمى الوظيفة الفعلية    ')
            //    return false;
            //}
            else if ($('#JobOrganizationID').val() == '') {
                ValidationAlert('لابد من ادخال رمز الإدارة التي تتبعها الوظيفة    ')
                return false;
            }
            else if ($('#JobOrganizationName').val() == '') {
                ValidationAlert('لابد من ادخال مسمى الإدارة التي تتبعها الوظيفة     ')
                return false;
            }
            else if ($('#basicSalary').val() == '') {
                ValidationAlert('لابد من ادخال الراتب الأساسي     ')
                return false;
            }
            else if ($('#basicSalary').val() == '') {
                ValidationAlert('لابد من ادخال الراتب الأساسي     ')
                return false;
            }
            else if ($('#MinistryHiremonth').val() == '' || $('#MinistryHireyear').val() == '' || $('#MinistryHireday').val() == '') {
                ValidationAlert('لابد من ادخال تاريخ الحلول في المرتبة    ')
                return false;
            }
            //else if ($('#IsActive').val() != 'true' || $('#IsActive').val() != 'false') {
            //    ValidationAlert('لابد من ادخال حالة الموظف     ')
            //    return false;
            //}
            else if ($('#TerminationReasonCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز سبب الانتهاء     ')
                return false;
            }
            else if ($('#Terminationyear').val() == '' || $('#Terminationday').val() == '' || $('#MinistryHireday').val() == '') {
                ValidationAlert('لابد من ادخال تاريخ الانتهاء     ')
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