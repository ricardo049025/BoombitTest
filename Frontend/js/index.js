var endPointUser = "https://localhost:7192/api/user";
var endPointActivity = "https://localhost:7192/api/activity";
var endPointCountry = "https://localhost:7192/api/country";

$( document ).ready(function() {
    
    getAllUsers();
    getAllCountries();

    $("#btnEdit").click(function(){
        
        if(arenotvalidFields()){
            return;
        };

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


    });

});

function getAllUsers(){
    $.getJSON( endPointUser, {
        tagmode: "any",
        format: "json"
      })
        .done(function( data ) {
            $.each(data,function(i,item){
                $('#sampleTable > tbody').append(`
                <tr>
                    <td class="tdid">${item.id}</td>
                    <td>${item.name} ${item.lastName}</td> 
                    <td class="tdemail">${item.email}</td>
                    <td class="tdemail">${item.birthday}</td>
                    <td>${item.phoneNumber}</td>
                    <td>${item.country}</td>
                    <td>
                        <div class="text-center">
                            <div class="animated-checkbox">
                            <label>
                                ${item.needInformation ? ("<input type='checkbox' checked><span class='label-text'></span>") :("<input type='checkbox'><span class='label-text'></span>") } 
                            </label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <button idItem=${item.id}  onclick="viewActivity(this);" class="btn btn-sm btn-info viewActivity" data-toggle="modal" data-target="#modelActivities"><i class="fa fa-eye" aria-hidden="true"></i> view</button>    
                        <button class="btn btn-sm btn-warning" onclick="selectUser(this);"  data-toggle="modal" data-target="#modelUser"><i class="fa fa-pencil" aria-hidden="true"></i> edit</button>  
                        <button class="btn btn-sm btn-danger" onclick="deleteUser(this);"><i class="fa fa-trash-o" aria-hidden="true"></i> delete</button>    
                    </td>
                </tr>`);

            })
            $('#sampleTable').DataTable();
        });
}

function viewActivity(evt)
{
    $("#tableActivity > tbody tr").remove();

    var idUser =  $(evt).attr("idItem");
    
    $.getJSON(`${endPointActivity}/getActivitiesByUserId/${idUser}`, {
        tagmode: "any",
        format: "json"
      })
      .done(function( data ) {
        $.each(data,function(i,item){
            $('#tableActivity > tbody').append(`
            <tr>
                <td>${item.fullName}</td>
                <td>${item.description}</td>
                <td>${item.createdDate}</td>
            </tr>`);

        })
        
    });
}

function selectUser(evt){
    var id = $(evt).parent().parent().find(".tdid").html();
    
    $.getJSON(`${endPointUser}/GetUserById/${id}`, {
        tagmode: "any",
        format: "json"
      })
        .done(function( data ) {
            $("#txtId").val(data.id);
            $("#txtName").val(data.name);
            $("#txtLastName").val(data.lastName);
            $("#txtemail").val(data.email);
            $("#txtBirthday").val(data.birthday);
            $("#txtPhone").val(data.phoneNumber);
            $("#txtcountry").val(data.country);
            $("#txtInformation").prop('checked', data.needInformation);

            $('#txtBirthday').datepicker({
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                endDate: "currentDate",
                maxDate: "currentDate"
            });
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

    return ($("#txtName").hasClass("is-invalid") || $("#txtLastName").hasClass("is-invalid") || $("#txtemail").hasClass("is-invalid") ||
            $("#txtBirthday").hasClass("is-invalid") || $("#txtcountry").hasClass("is-invalid") 
    )

}

function updateUser(user){

    $.ajax({
        type: 'post',
        url: `${endPointUser}/ExecuteUser`,
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        traditional: true,
        success: function (data) {
            alert("Updated !!")
            location.reload();  
        },
    });

}


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

function deleteUser(evt){

    var id = $(evt).parent().parent().find(".tdid").html();

    $.ajax({
        url: `${endPointUser}/DeleteUser/${id}`,
        type: 'DELETE',
        success: function(result) {

            if(result) alert("The user has been deleted ! ")
            else alert("The user couldn't been deleted ! ")
            window.location.reload();
        }
    });

}

