$(document).ready(function () {

    clearFields();
    $('#exampleModal').modal('show');
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('#txtStartDate').datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        language: "tr",
        todayHighlight: true,
        startDate: date
    });
    $('#txtEndDate').datepicker({
        changeMonth: true,
        changeYear: true,
        format: "dd/mm/yyyy",
        language: "tr",
        todayHighlight: true,
        startDate: date
    });
});

function clearFields()
{
    $('#place').val('e.g Cape Town');
     $('#txtStartDate').val('');
     $('#txtEndDate').val('');
     $('#guest').val('');
}


$('#hotelBtn').on('click', function () {
    alert('clicked');

    let place = $('#place').val();
    let sDate = $('#txtStartDate').val();
    let eDate = $('#txtEndDate').val();
    let guest = $('#guest').val();

    console.log(place);
    console.log(sDate);
    console.log(eDate);
    console.log(guest);

})