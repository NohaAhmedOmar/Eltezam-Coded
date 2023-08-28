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
    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
    SendAjaxToGetArray(Nations, '/api/DropDowns/GetNationDropDown')
    SendAjaxToGetArray(Grades, '/api/DropDowns/GetGradesDropDown')
    SendAjaxToGetArray(Universities, '/api/DropDowns/GetUniversitiesDropDown')
    SendAjaxToGetArray(Major, '/api/DropDowns/GetQualificationCodeDropDown')
    SendAjaxToGetArray(Qualifications, '/api/DropDowns/GetQualificationCodeDropDown')
    SendAjaxToGetArray(QualificationStatus, '/api/DropDowns/GetQualificationStatusDropDown')
})
function renderDate(dayId, monthId) {
    var month = $("#" + gradmonth + monthId + "").val();
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 9 || month == 11) {
        $("#" + dayId + "").empty();
        for (var i = 1; i <= 30; i++) {

            $("#" + gradday + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else if (month == 2) {
        $("#" + gradday + dayId + "").empty();

        for (var i = 1; i <= 29; i++) {

            $("#" + gradday + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else {
        $("#" + dayId + "").empty();

        for (var i = 1; i <= 30; i++) {
            $("#" + gradday + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }

}
function SendAjaxToGetArray(collection, url) {
    debugger
    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {

            collection.push({ Id: 0, Value: 'اختر' })
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
function drawQualification() {
    blocknumber++;
    var perviousblock = blocknumber - 1
    var Date = '<div class="col-lg-3"><select class="form-control select2Class" id="gradday' + blocknumber + '" name="val-skill"><option value="0">اختر يوم التخرج</option></select></div><div class="col-lg-3"><select class="form-control select2Class" id="gradyear' + blocknumber + '" name="val-skill"><option value="0">اختر سنة التخرج</option></select></div><div class="col-lg-3"><select class="form-control select2Class" onchange="renderDate(' + blocknumber + ',' + blocknumber + ')" id="gradmonth' + blocknumber + '" name="val-skill"><option value="0">اختر شهر التخرج</option><option value="01">محرم</option><option value="02">صفر</option><option value="03">ربيع الأول</option><option value="04">ربيع الآخر</option><option value="05">جمادى الأولى</option><option value="06">جمادى الآخرة</option><option value="07">رجب</option><option value="08">شعبان</option><option value="09">رمضان</option><option value="10">شوال</option><option value="11">ذو القعدة</option><option value="12">ذو الحجة</option></select></div>'
    var Div = '<div id="Qualification' + blocknumber + '"></div>'
    var input = '<div class="form-group row"><div class="col-lg-4 d-flex flex-row"><span style="color:red">*</span><select class="form-control select2Class" id="QualificationCode' + blocknumber + '" name="val-skill" required></select></div><div class="col-lg-4 d-flex flex-row"><span style="color:red">*</span><select class="form-control select2Class" id="MajorCode' + blocknumber + '" name="val-skill" required></select></div><div class="col-lg-4 d-flex flex-row"><span style="color:red">*</span><select class="form-control select2Class" id="UniversityCode' + blocknumber + '" name="val-skill" required></select></div><div class="col-lg-4"><select class="form-control select2Class" id="CountryCode' + blocknumber + '" name="val-skill"></select></div><div class="col-lg-4"><select class="form-control select2Class" id="Grade' + blocknumber + '" name="val-skill"></select></div><div class="col-lg-4"><input type="text" class="form-control" id="Score' + blocknumber + '" placeholder=" المعدل"></div><div class="col-lg-6"><input type="text" class="form-control" id="ScoreOutOf' + blocknumber + '" placeholder="المعدل من  "></div><div class="col-lg-6"><input type="text" class="form-control" id="City' + blocknumber + '" placeholder=" اسم المدينة "></div><div class="col-lg-3 d-flex flex-row"><span style="color:red">*</span><select class="form-control select2Class" id="QualificationStatus' + blocknumber + '" name="val-skill" required></select></div>' + Date + '</div>';
    if (blocknumber > 1) {
        $('#Qualification' + perviousblock + '').html(Div + '<hr>' + input);
        for (var i = 1300; i <= $('#year').val(); i++) {
            $('#gradyear' + perviousblock + '').append('<option value="' + i + '">' + i + '</option>')
            $('#gradyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
        }
        for (var i = 0; i < Nations.length; i++) {
            $('#CountryCode' + perviousblock + '').append('<option value="' + Nations[i].Id + '">' + Nations[i].Value + '</option>')
            $('#CountryCode' + blocknumber + '').append('<option value="' + Nations[i].Id + '">' + Nations[i].Value + '</option>')

        }
        for (var i = 0; i < Grades.length; i++) {
            $('#Grade' + perviousblock + '').append('<option value="' + Grades[i].Id + '">' + Grades[i].Value + '</option>')
            $('#Grade' + blocknumber + '').append('<option value="' + Grades[i].Id + '">' + Grades[i].Value + '</option>')
        }
        for (var i = 0; i < Universities.length; i++) {
            $('#UniversityCode' + perviousblock + '').append('<option value="' + Universities[i].Id + '">' + Universities[i].Value + '</option>')
            $('#UniversityCode' + blocknumber + '').append('<option value="' + Universities[i].Id + '">' + Universities[i].Value + '</option>')
        }
        for (var i = 0; i < Major.length; i++) {
            $('#MajorCode' + perviousblock + '').append('<option value="' + Major[i].Id + '">' + Major[i].Value + '</option>')
            $('#MajorCode' + blocknumber + '').append('<option value="' + Major[i].Id + '">' + Major[i].Value + '</option>')
        }
        for (var i = 0; i < Qualifications.length; i++) {
            $('#QualificationCode' + perviousblock + '').append('<option value="' + Qualifications[i].Id + '">' + Qualifications[i].Value + '</option>')
            $('#QualificationCode' + blocknumber + '').append('<option value="' + Qualifications[i].Id + '">' + Qualifications[i].Value + '</option>')
        }
        for (var i = 0; i < QualificationStatus.length; i++) {
            $('#QualificationStatus' + perviousblock + '').append('<option value="' + QualificationStatus[i].Id + '">' + QualificationStatus[i].Value + '</option>')
            $('#QualificationStatus' + blocknumber + '').append('<option value="' + QualificationStatus[i].Id + '">' + QualificationStatus[i].Value + '</option>')
        }
    }
    else {
        $('#Qualification').html(Div + input);
        for (var i = 1300; i <= $('#year').val(); i++) {
            $('#gradyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
        }
        for (var i = 0; i < Nations.length; i++) {
            $('#CountryCode' + blocknumber + '').append('<option value="' + Nations[i].Id + '">' + Nations[i].Value + '</option>')
        }
        for (var i = 0; i < Grades.length; i++) {
            $('#Grade' + blocknumber + '').append('<option value="' + Grades[i].Id + '">' + Grades[i].Value + '</option>')
        }
        for (var i = 0; i < Universities.length; i++) {
            $('#UniversityCode' + blocknumber + '').append('<option value="' + Universities[i].Id + '">' + Universities[i].Value + '</option>')
        }
        for (var i = 0; i < Major.length; i++) {
            $('#MajorCode' + blocknumber + '').append('<option value="' + Major[i].Id + '">' + Major[i].Value + '</option>')
        }
        for (var i = 0; i < Qualifications.length; i++) {
            $('#QualificationCode' + blocknumber + '').append('<option value="' + Qualifications[i].Id + '">' + Qualifications[i].Value + '</option>')
        }
        for (var i = 0; i < QualificationStatus.length; i++) {
            $('#QualificationStatus' + blocknumber + '').append('<option value="' + QualificationStatus[i].Id + '">' + QualificationStatus[i].Value + '</option>')
        }
    }

    debugger
    $('.select2Class').select2({
        dir: "rtl",
    });
}
function PostEmployeeQualification() {
    //var isValid = ValidateForm();
    var isValid = $('form')[0].checkValidity();
    if (isValid) {
        var employeevalue = $('#employees').val()
        var employeeQualificationDTOs = new Array();
        for (var i = 1; i <= blocknumber; i++) {
            var employeeQualificationDTO = new Object();

            employeeQualificationDTO.employeeId = employeevalue.split(':')[0];
            employeeQualificationDTO.nationalID = employeevalue.split(':')[1];
            employeeQualificationDTO.qualificationCode = $('#QualificationCode' + i + '').val();
            employeeQualificationDTO.majorCode = $('#MajorCode' + i + '').val();
            employeeQualificationDTO.universityCode = $('#UniversityCode' + i + '').val();
            $('#CountryCode' + i + '').val() != '0' ? employeeQualificationDTO.countryCode = $('#CountryCode' + i + '').val() : isValid;
            $('#City' + i + '').val() != '' ? employeeQualificationDTO.cityName = $('#City' + i + '').val() : isValid;
            $('#Grade' + i + '').val() != '0' ? employeeQualificationDTO.grade = $('#Grade' + i + '').val() : isValid;
            $('#Score' + i + '').val() != '' ? employeeQualificationDTO.score = $('#Score' + i + '').val() : isValid;
            $('#ScoreOutOf' + i + '').val() != '' ? employeeQualificationDTO.scoreOutOf = $('#ScoreOutOf' + i + '').val() : isValid;
            employeeQualificationDTO.qualificationStatus = $('#QualificationStatus' + i + '').val();
            debugger
            if ($('#gradyear' + i + '').val() != '0' && $('#gradmonth' + i + '').val() != '0' && $('#gradday' + i + '').val() != '0')
                employeeQualificationDTO.graduationDate = '' + $('#gradyear' + i + '').val() + '-' + $('#gradmonth' + i + '').val() + '-' + $('#gradday' + i + '').val() + 'T00:00:00';

            employeeQualificationDTOs.push(employeeQualificationDTO);
        }

        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployeeQualifications",
            data: JSON.stringify(employeeQualificationDTOs),
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
    for (var i = 1; i <= blocknumber; i++) {
        if ($('#MajorCode' + i + '').val() == '0') {
            ValidationAlert('لابد من ادخال رمز التخصص  ')
            return false;
        }
        else if ($('#QualificationCode' + i + '').val() == '0') {
            ValidationAlert('لابد من ادخال رمز المؤهل  ')
            return false;
        }
        else if ($('#UniversityCode' + i + '').val() == '0') {
            ValidationAlert('لابد من ادخال رمز الجامعة   ')
            return false;
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