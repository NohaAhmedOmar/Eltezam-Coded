﻿
$(document).ready(function () {
    BuildDropDown('gender', '/api/DropDowns/GetGenderDropDown', 'اختر الجنس')
    BuildDropDown('nation', '/api/DropDowns/GetNationDropDown', 'اختر الجنسية')
    BuildDropDown('bloodType', '/api/DropDowns/GetBloodTypeDropDown', 'اختر فصيلة الدم')
    BuildDropDown('religion', '/api/DropDowns/GetReligionTypeDropDown', 'اختر  الديانة')
    BuildDropDown('maritalStatus', '/api/DropDowns/GetMaritalStatusDropDown', 'اختر  الحالة الاجتماعية')
    BuildDropDown('healthstatus', '/api/DropDowns/GetHealthStatusDropDown', 'اختر  الحالة الصحية')
    BuildDropDown('employeeStatusCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز حالة الموظف ')
    BuildDropDown('jobClassCode', '/api/DropDowns/GetEmployeeStatusCodeDropDown', 'اختر  رمز سلسلة الفئات الوظيفية ')
    BuildDropDown('rankCode', '/api/DropDowns/GetRankCodeDropDown', 'اختر رمز المرتبة')
    BuildDropDown('employmentTypeCode', '/api/DropDowns/GetEmploymentTypeCodeDropDown', 'اختر رمز السلم الوظيفي')
    BuildDropDown('actualJobNameCode', '/api/DropDowns/GetActualJobNameCodeDropDown', 'اختر رمز مسمى الوظيفة الفعلية')
    BuildDropDown('TransactionCode', '/api/DropDowns/GetTransactionCodeDropDown', 'اختر رمز الإجراء الوظيفي')
    BuildDropDown('TerminationReasonCode', '/api/DropDowns/GetTerminationCodeDropDown', 'اختر رمز سبب الانتهاء')
    BuildDropDown('JobNameCode', '/api/DropDowns/GetActualJobNameCodeDropDown', 'اختر رمز مسمى الوظيفة')
    BuildDropDown('area', '/api/DropDowns/GetRegionsDropDown', 'اخترالمنطقة')
    $('#area').change(function () {
        BuildDropDownBasedOnSelection('area', 'gov', '/api/DropDowns/GetGovernoratesDropDown/', ' اختر المحافظة')
    })
    $('#gov').change(function () {
        BuildDropDownBasedOnSelection('gov', 'loaction', '/api/DropDowns/GetLocationCodesDropDown/', 'اخترالموقع')
    })

    $('.select2Class').select2({
        dir: "rtl",
    });
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
    debugger
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
function PostEmployee() {
    debugger
    //var isValid = ValidateForm();
    var isValid = $('form')[0].checkValidity();
    if (isValid) {
        var valid = true;
        var employeeDTO = new Object();
        $('#NationalID').val() != '' ? employeeDTO.nationalID = $('#NationalID').val() : employeeDTO.iqamaNumber = $('#IqamaNumber').val();
        employeeDTO.firstNameAr = $('#FirstNameAr').val();
        employeeDTO.secondNameAr = $('#SecondNameAr').val();
        employeeDTO.thirdNameAr = $('#ThirdNameAr').val();
        employeeDTO.lastNameAr = $('#LastNameAr').val();
        employeeDTO.firstNameEn = $('#FirstNameEn').val();
        employeeDTO.secondNameEn = $('#SecondNameEn').val();
        employeeDTO.thirdNameEn = $('#ThirdNameEn').val();
        employeeDTO.lastNameEn = $('#LastNameEn').val();
        employeeDTO.birthDate = '' + $('#birthyear').val() + '-' + $('#birthmonth').val() + '-' + $('#birthday').val();
        employeeDTO.gender = $('#gender').val();
        employeeDTO.nationalityCode = $('#nation').val();
        employeeDTO.religion = $('#religion').val() == "0" ? null : $('#religion').val();
        employeeDTO.bloodType = $('#bloodType').val() == "0" ? null : $('#bloodType').val();
        employeeDTO.mobile = $('#Phone').val();
        employeeDTO.emailAddress = $('#Email').val();
        employeeDTO.maritalStatus = $('#maritalStatus').val();
        employeeDTO.healthstatus = $('#healthstatus').val();
        employeeDTO.employeeStatusCode = $('#employeeStatusCode').val();
        employeeDTO.jobNumber = $('#JobNumber').val();
        employeeDTO.jobClassCode = $('#jobClassCode').val();
        employeeDTO.jobClassDescription = $('#jobClassDescription').val();
        employeeDTO.jobCatChain = $('#jobCatChain').val();
        employeeDTO.jobNameCode = $('#JobNameCode').val();
        employeeDTO.jobNameDescription = $('#jobNameDescription').val();
        employeeDTO.employmentTypeCode = $('#employmentTypeCode').val();
        employeeDTO.employmentTypeDescription = $('#employmentTypeDescription').val();
        employeeDTO.rankCode = $('#rankCode').val();
        employeeDTO.stepId = $('#stepID').val();
        employeeDTO.stepDate = '' + $('#birthyear').val() + '-' + $('#birthmonth').val() + '-' + $('#birthday').val();
        employeeDTO.firstGradeDate = '' + $('#gradeyear').val() + '-' + $('#grademonth').val() + '-' + $('#gradeday').val();
        employeeDTO.actualJobNameCode = $('#actualJobNameCode').val();
        employeeDTO.actualJobNameDescription = $('#actualJobNameDescription').val();
        employeeDTO.jobOrganizationId = $('#JobOrganizationID').val();
        employeeDTO.jobOrganizationName = $('#JobOrganizationName').val();
        employeeDTO.basicSalary = $('#basicSalary').val();
        employeeDTO.actualOrganizationId = $('#actualOrganizationID').val();
        employeeDTO.actualOrganizationName = $('#actualOrganizationName').val();
        employeeDTO.nextPromotionDate = '' + $('#Promotionyear').val() + '-' + $('#Promotionmonth').val() + '-' + $('#Promotionday').val();
        employeeDTO.governmentHireDate = $('#Hireyear').val() + '-' + $('#Hiremonth').val() + '-' + $('#Hireday').val();
        employeeDTO.locationCode = $('#loaction').val();
        employeeDTO.ministryHireDate = '' + $('#MinistryHireyear').val() + '-' + $('#MinistryHiremonth').val() + '-' + $('#MinistryHireday').val();
        employeeDTO.remainingAnnualBalance = $('#RemainingAnnualBalance').val();
        employeeDTO.remainingBusinessBalance = $('#RemainingBusinessBalance').val();
        employeeDTO.transactionCode = $('#TransactionCode').val();
        $('#IsActive').val() == "true" ? employeeDTO.isActive = true : employeeDTO.isActive = false
        employeeDTO.terminationReasonCode = $('#TerminationReasonCode').val();
        employeeDTO.terminationDate = '' + $('#Terminationyear').val() + '-' + $('#Terminationmonth').val() + '-' + $('#Terminationday').val();
        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployee",
            data: JSON.stringify(employeeDTO),
            contentType: "application/json",
            success: function (result) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'تمت الاضافة بنجاح ورقم الطلب' + result.requestNumber + '',
                    showConfirmButton: false,
                    timer: 20000
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
    if ($('#NationalID').val() == '' && $('#IqamaNumber').val() == '') {
        ValidationAlert('لابد من ادخال رقم الاقامة او الهوية الوطنية')
        return false;
    }
    else if ($('#NationalID').val() != '' && $('#IqamaNumber').val() != '') {
        ValidationAlert('لا يمكن ادخال رقم الاقامة و الهوية الوطنية معا')
        return false;
    }
    else if ($('#NationalID').val() != '') {
        var Id = $('#NationalID').val()
        if (Id.length > 10 || Id.length < 10) {
            ValidationAlert('لابد من ادخال  الهوية الوطنية صحيحة')
            return false;
        }
        else {
            if ($('#FirstNameAr').val() == '') {
                ValidationAlert('لابد من ادخال  إسم الأول ')
                return false;
            }
            else if ($('#SecondNameAr').val() == '') {
                ValidationAlert('لابد من ادخال إسم الأب ')
                return false;

            }
            else if ($('#LastNameAr').val() == '') {
                ValidationAlert('لابد من ادخال إسم العائلة  ')
                return false;

            }
            else if ($('#FirstNameEn').val() == '') {
                ValidationAlert(' لابد من ادخال  إسم الأول  بالانجليزية')
                return false;
            }
            else if ($('#SecondNameEn').val() == '') {
                ValidationAlert('لابد من ادخال إسم الأب  بالانجليزية')
                return false;
            }
            else if ($('#LastNameEn').val() == '') {
                ValidationAlert('لابد من ادخال إسم العائلة بالانجليزية  ')
                return false;
            }
            else if ($('#LastNameEn').val() == '') {
                ValidationAlert('لابد من ادخال إسم العائلة بالانجليزية  ')
                return false;
            }
            else if ($('#birthmonth').val() == '' || $('#birthyear').val() == '' || $('#birthday').val() == '') {
                ValidationAlert('لابد من ادخال تاريخ الميلاد  ')
                return false;
            }
            else if ($('#nation').val() == '0') {
                ValidationAlert('لابد من ادخال الجنسية  ')
                return false;
            }
            else if ($('#gender').val() == '0') {
                ValidationAlert('لابد من ادخال الجنس  ')
                return false;
            }
            else if ($('#religion').val() == '0') {
                ValidationAlert('لابد من ادخال الديانة  ')
                return false;
            }
            else if ($('#healthstatus').val() == '0') {
                ValidationAlert('لابد من ادخال الحالة الصحية   ')
                return false;
            }
            else if ($('#maritalStatus').val() == '0') {
                ValidationAlert('لابد من ادخال الحالة الاجتماعية  ')
                return false;
            }
            else if ($('#JobNumber').val() == '') {
                ValidationAlert('لابد من ادخال رقم الوظيفة  ')
                return false;
            }
            else if ($('#employeeStatusCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز حالة الموظف  ')
                return false;
            }
            else if ($('#jobClassCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز سلسلة الفئات الوظيفية   ')
                return false;
            }
            else if ($('#employmentTypeCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز السلم الوظيفي   ')
                return false;
            }
            else if ($('#rankCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز المرتبة    ')
                return false;
            }
            else if ($('#stepID').val() == '') {
                ValidationAlert('لابد من ادخال الدرجة    ')
                return false;
            }
            else if ($('#birthmonth').val() == '' || $('#birthyear').val() == '' || $('#birthday').val() == '') {
                ValidationAlert('لابد من ادخال تاريخ الحلول في المرتبة    ')
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
            else if ($('#JobNameCode').val() == '0') {
                ValidationAlert('لابد من ادخال رمز مسمى الوظيفة     ')
                return false;
            }
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
        }
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