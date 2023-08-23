var blocknumber = 0;
var startday = 'startday';
var startmonth = 'startmonth';
var endmonth = 'endmonth';
var endday = 'endday';
var Vacations = new Array();
$(document).ready(function () {
    $('#employees').select2()
    BuildDropDown('employees', '/api/Employees/GetEmployees', 'اختر الموظف')
    SendAjaxToGetArray(Vacations, '/api/DropDowns/GetVacationTypeDropDown')

})
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

function renderDate(dayId, monthId,isEnd) {
    debugger
    var day;
    var month;
    if (isEnd == true) {
        day = endday
        month = endmonth
    }
    else {
        day = startday
        month = startmonth
    }
    var month = $("#" + month + monthId + "").val();
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 9 || month == 11) {
        $("#" + dayId + "").empty();
        for (var i = 1; i <= 30; i++) {

            $("#" +day + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else if (month == 2) {
        $("#" + dayId + "").empty();

        for (var i = 1; i <= 29; i++) {

            $("#" + day + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
        }
    }
    else {
        $("#" + day + dayId + "").empty();

        for (var i = 1; i <= 30; i++) {
            $("#" + day + dayId + "").append("<option value='" + i + "'>" + i + "</option>");
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
function PostEmployeeVacation() {
    var isValid = ValidateForm();
    if (isValid) {

        var employeevalue = $('#employees').val()

        var employeeVacationDTOs = new Array();
        for (var i = 1; i <= blocknumber; i++) {
            var employeeVacationDTO = new Object();
            employeeVacationDTO.startDate = '' + $('#startyear' + i + '').val() + '-' + $('#startmonth' + i + '').val() + '-' + $('#startday' + i + '').val() + 'T00:00:00'
            employeeVacationDTO.endDate = '' + $('#endyear' + i + '').val() + '-' + $('#endmonth' + i + '').val() + '-' + $('#endday' + i + '').val() + 'T00:00:00'
            employeeVacationDTO.vacationCode = $('#VacationCode' + i + '').val();
            $('#DecisionNumber' + i + '').val() != '' ? employeeVacationDTO.decisionNumber = $('#DecisionNumber' + i + '').val() : isValid;
            employeeVacationDTO.empoyeeId = employeevalue.split(':')[0];;
            employeeVacationDTO.nationalID = employeevalue.split(':')[1];;
            employeeVacationDTOs.push(employeeVacationDTO);
        }
        $.ajax({
            type: "Post",
            url: "/api/Employees/PostEmployeeVacations",
            data: JSON.stringify(employeeVacationDTOs),
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
                    title: '' + ex.statusDescription + '',
                    showConfirmButton: false,
                    timer: 2000
                })
            }

        });
    }
}
function drawVacation() {
    
    console.log(Vacations)
    blocknumber++;
    var perviousblock = blocknumber - 1
    var Div = '<div id="Vacation' + blocknumber + '"></div>'
    var input = '<div class="form-group row"><div class="col-lg-4"><select class="form-control" id="startday' + blocknumber + '" name="val-skill"><option value="">اختر يوم بداية الاجازة</option></select></div><div class="col-lg-4"><select class="form-control" id="startyear' + blocknumber + '" name="val-skill"><option value="">اختر سنة بداية الاجازة</option></select></div><div class="col-lg-4"><select class="form-control" onchange="renderDate(' + blocknumber + ',' + blocknumber + ',false)" id="startmonth' + blocknumber + '" name="val-skill"><option value="">اختر شهر بداية الاجازة</option><option value="01">محرم</option><option value="02">صفر</option><option value="03">ربيع الأول</option><option value="04">ربيع الآخر</option><option value="05">جمادى الأولى</option><option value="06">جمادى الآخرة</option><option value="07">رجب</option><option value="08">شعبان</option><option value="09">رمضان</option><option value="10">شوال</option><option value="11">ذو القعدة</option><option value="12">ذو الحجة</option></select></div><div class="col-lg-4"><select class="form-control" id="endday' + blocknumber + '" name="val-skill"><option value="">اختر يوم نهاية الاجازة</option></select></div><div class="col-lg-4"><select class="form-control" id="endyear' + blocknumber + '" name="val-skill"><option value="">اختر سنة نهاية الاجازة</option></select></div><div class="col-lg-4"><select class="form-control" onchange="renderDate(' + blocknumber + ', ' + blocknumber + ',true)" id="endmonth' + blocknumber + '" name="val-skill"><option value="">اختر شهر نهاية الاجازة</option><option value="01">محرم</option><option value="02">صفر</option><option value="03">ربيع الأول</option><option value="04">ربيع الآخر</option><option value="05">جمادى الأولى</option><option value="06">جمادى الآخرة</option><option value="07">رجب</option><option value="08">شعبان</option><option value="09">رمضان</option><option value="10">شوال</option><option value="11">ذو القعدة</option><option value="12">ذو الحجة</option></select></div><div class="col-lg-9"><select class="form-control" id="VacationCode' + blocknumber + '" name="val-skill"></select></div><label class="col-lg-3 col-form-label" for="val-username">رمز الاجازة<span class="text-danger">*</span></label><div class="col-lg-9"><input type="number" class="form-control" id="DecisionNumber' + blocknumber + '" name="val-username" placeholder="رقم القرار "></div><label class="col-lg-3 col-form-label" for="val-username">رقم القرار</label></div>'
    if (blocknumber > 1) {
        $('#Vacation' + perviousblock + '').html(Div + '<hr>' + input);
        for (var i = 1300; i <= $('#year').val(); i++) {
            $('#startyear' + perviousblock + '').append('<option value="' + i + '">' + i + '</option>')
            $('#endyear' + perviousblock + '').append('<option value="' + i + '">' + i + '</option>')
            $('#startyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
            $('#endyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
        }
        debugger
        for (var i = 0; i < Vacations.length; i++) {
            $('#VacationCode' + perviousblock + '').append('<option value="' + Vacations[i].Id + '">' + Vacations[i].Value + '</option>')
            $('#VacationCode' + blocknumber + '').append('<option value="' + Vacations[i].Id + '">' + Vacations[i].Value + '</option>')
        }
    }
    else {
        $('#Vacation').html(Div + input);
        for (var i = 1300; i <= $('#year').val(); i++) {
            $('#startyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
            $('#endyear' + blocknumber + '').append('<option value="' + i + '">' + i + '</option>')
        }
        for (var i = 0; i < Vacations.length; i++) {
            $('#VacationCode' + blocknumber + '').append('<option value="' + Vacations[i].Id + '">' + Vacations[i].Value + '</option>')
        }

    }

}
function ValidateForm() {
    if ($('#employees').val() == '0') {
        ValidationAlert('لابد من اختيار الموظف')
        return false;
    }
    for (var i = 1; i <= blocknumber; i++) {
        if ($('#VacationCode' + i + '').val() == '0') {
            ValidationAlert('لابد من ادخال رمز الاجازة  ')
            return false;
        }
        else if ($('#startyear' + i + '').val() == '' && $('#startmonth' + i + '').val() == '' && $('#startday' + i + '').val() == '') {
            ValidationAlert('لابد من ادخال تاريخ بداية الاجازة  ')
            return false;
        }
        else if ($('#endyear' + i + '').val() == '' && $('#endmonth' + i + '').val() == '' && $('#endday' + i + '').val() == '') {
            ValidationAlert('لابد من ادخال تاريخ نهاية الاجازة  ')
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