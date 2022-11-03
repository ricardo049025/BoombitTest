var endPointUser = "https://localhost:7192/api/user";
var endPointActivity = "https://localhost:7192/api/activity";
var endPointCountry = "https://localhost:7192/api/country";

$( document ).ready(function() {
    getAllCountries();

    $('#txtBirthday').datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        todayHighlight: true,
        endDate: "currentDate",
        maxDate: "currentDate"
    });

});

function getAllCountries()
{
    $.getJSON( endPointCountry, {
        tagmode: "any",
        format: "json"
      })
        .done(function( data ) {
            $.each(data,function(i,item){
                $('#txtcountry').append(`<option value="${item.code}">${item.name}</option>`);

            })
        });
}

function arenotvalidFields()
{
    if($("#txtName").val() == ""){ 
        $("#txtName").addClass("is-invalid");
    } else{
        $("#txtName").removeClass("is-invalid");
    }
    if($("#txtLastName").val() == ""){
        $("#txtLastName").addClass("is-invalid");
    } else{
        $("#txtLastName").removeClass("is-invalid");
    }

    if($("#txtemail").val() == ""){ 
        $("#txtemail").addClass("is-invalid");
    }else{
        $("#txtemail").removeClass("is-invalid");
    }
    if($("#txtBirthday").val() == ""){
        $("#txtBirthday").addClass("is-invalid");
    }else{
        $("#txtBirthday").removeClass("is-invalid");
    }
    if($("#txtcountry").val() == ""){ 
        $("#txtcountry").addClass("is-invalid");
    } else{
        $("#txtcountry").removeClass("is-invalid");        
    }
    if(isNaN($("#txtPhone").val())){ 
        $("#txtPhone").removeClass("is-invalid");        
    }else{
        $("#txtPhone").removeClass("is-invalid");               
    }

    return ($("#txtName").hasClass("is-invalid") || $("#txtLastName").hasClass("is-invalid") || $("#txtemail").hasClass("is-invalid") ||
            $("#txtBirthday").hasClass("is-invalid") || $("#txtcountry").hasClass("is-invalid") 
    )

}

function addUser()
{
    var notValid = arenotvalidFields();

    if(notValid) alert("invalid form");

    var id = $("#txtId").val();
    var name = $("#txtName").val();
    var last = $("#txtLastName").val();
    var email = $("#txtemail").val();
    var birthday = $("#txtBirthday").val();
    var phone = $("#txtPhone").val();
    var country =   $("#txtcountry").val();
    var information = $("#txtInformation").prop('checked');

    var user = {id: id, name: name, last: last, email: email, birthday: birthday, phone: phone, country: country, information: information}
    updateUser(user);

}


function updateUser(user){

    $.ajax({
        type: 'post',
        url: `${endPointUser}/ExecuteUser`,
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        traditional: true,
        success: function (data) {
            alert("Created !!")
            location.reload();  
        },
    });

}