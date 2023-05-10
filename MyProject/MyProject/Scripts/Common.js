var Id = 0;
$(document).ready(function () {
    ShowRegistrationData();

    $("#CountryName").change(function () {
        StateBind();
        return false;
    })

    $("#Number").keyup(function () {
        this.value = this.value.replace(/[^0-9\.]/g, '');
    });

    $("#Submit").click(function () {

        var select = $("#CountryName").val();
        if (select == null || select == '') {
            $("#dv1").slideDown();
            $("#CountryName").css("border-color", "red");
            return false;
        }
        else {
            $("#dv1").hide();
            $("#CountryName").css("border-color", "black");
        }
        //-------------------------------------------------------------------
        var select = $("#StateName").val();
        if (select == null || select == '') {
            $("#dv2").slideDown();
            $("#StateName").css("border-color", "red");
            return false;
        }
        else {
            $("#dv2").hide();
            $("#StateName").css("border-color", "black");
        }
        //-------------------------------------------------------------------

        var City = $("#CityName").val();
        if (City == null || City == '') {
            $("#CityName").css("border-color", "red");
            $("#dv3").slideDown();
            $("#CityName").focus();
            return false;
        }
        else {
            $("#CityName").css("border-color", "black");
            $("#dv3").hide();
        }
        ////------------------------------------------------------------------------

        var Name = $("#Name").val();
        if (Name == null || Name == '') {
            $("#Name").css("border-color", "red");
            $("#dv4").slideDown();
            $("#Name").focus();
            return false;
        }
        else {
            $("#Name").css("border-color", "black");
            $("#dv4").hide();
        }
        ///----------------------------------------------------------------------------
        var Father = $("#FatherName").val();
        if (Father == null || Father == '') {
            $("#FatherName").css("border-color", "red");
            $("#dv5").slideDown();
            $("#Father").focus();
            return false;
        }
        else {
            $("#FatherName").css("border-color", "black");
            $("#dv5").hide();
        }
        //---------------------------------------------------------------------------------
        var Father = $("#MotherName").val();
        if (Father == null || Father == '') {
            $("#MotherName").css("border-color", "red");
            $("#dv6").slideDown();
            $("#Father").focus();
            return false;
        }
        else {
            $("#MotherName").css("border-color", "black");
            $("#dv6").hide();
        }
        //---------------------------------------------------------------------------------


        var Address = $("#Address").val();
        if (Address == null || Address == '') {
            $("#Address").css("border-color", "red");
            $("#dv7").slideDown();
            $("#Address").focus();
            return false;
        }
        else {
            $("#Address").css("border-color", "black");
            $("#dv7").hide();
        }
        //------------------------------------------------------------------------------
        var Number = $("#Number").val();
        if (Number == null || Number == '') {
            $("#Number").css("border-color", "red");
            $("#dv8").slideDown();
            $("#Number").focus();
            return false;
        }
        else {
            $("#Number").css("border-color", "black");
            $("#dv8").hide();
        }

        ////////-------------------------------------------------------------------------
        var Email = $("#Email").val();
        if (Email == null || Email == '') {
            $("#Email").css("border-color", "red");
            $("#dv9").slideDown();
            $("#Email").focus();
            return false;
        }
        else {
            $("#Email").css("border-color", "black");
            $("#dv9").hide();
        }
        ////////-------------------------------------------------------------------//
        var Password = $("#Password").val();
        if (Password == null || Password == '') {
            $("#Password").css("border-color", "red");
            $("#dv10").slideDown();
            $("#Password").focus();
            return false;
        }
        else {
            $("#Password").css("border-color", "black");
            $("#dv10").hide();
        }

        //--------------------------------------------------------------------------//
        var Password = $("#DOB").val();
        if (Password == null || Password == '') {
            $("#DOB").css("border-color", "red");
            $("#dv11").slideDown();
            $("#DOB").focus();
            return false;
        }
        else {
            $("#DOB").css("border-color", "black");
            $("#dv11").hide();
        }

        //------------------------------------------------------------------------------//

        var Gender = $("input[name='Gender']:checked").val();
        if (Gender == null || Gender == '') {
            $("#Gender").css("border-color", "red");
            $("#dv12").slideDown();
            $("#Gender").focus();
            return false;
        }
        else {
            $("#Gender").css("border-color", "black");
            $("#dv12").hide();
        }

        IU_New_Reistration();
        return false;
    })

    // Dropdown on mouse hover
    const $dropdown = $(".dropdown");
    const $dropdownToggle = $(".dropdown-toggle");
    const $dropdownMenu = $(".dropdown-menu");
    const showClass = "show";

    $(window).on("load resize", function () {
        if (this.matchMedia("(min-width: 992px)").matches) {
            $dropdown.hover(
            function () {
                const $this = $(this);
                $this.addClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "true");
                $this.find($dropdownMenu).addClass(showClass);
            },
            function () {
                const $this = $(this);
                $this.removeClass(showClass);
                $this.find($dropdownToggle).attr("aria-expanded", "false");
                $this.find($dropdownMenu).removeClass(showClass);
            }
            );
        } else {
            $dropdown.off("mouseenter mouseleave");
        }
    });


})


function IU_New_Reistration() {
    try {
        $.post("/User/IU_New_Reistration", {
            Id: $("#Id").val(),
            CountryName: $("#CountryName").val(),
            StateName: $("#StateName").val(),
            CityName: $("#CityName").val(),
            Name: $("#Name").val(),
            FatherName: $("#FatherName").val(),
            MotherName: $("#MotherName").val(),
            Address: $("#Address").val(),
            Number: $("#Number").val(),         
            Email: $("#Email").val(),
            Password: $("#Password").val(),
            DOB: $("#DOB").val(),
            IsActive: $("#IsActive").is(":checked"),
            Gender: $("input[name='Gender']:checked").val(),
        },
          function (data) {
              if (data.Message != "") {
                  alert(data.Message);
                  ShowRegistrationData();
                  ClearReistration();               
              }
          })
    }
    catch (e) {
        alert("Error In InsertUpdateCity " + e.Message)
    }
}

function ClearReistration() {
    $("#id").val(0);
    $("#CountryName").val("");
    $("#StateName").val("");
    $("#CityName").val("");
    $("#Name").val("");
    $("#FatherName").val("");
    $("#MotherName").val("");
    $("#Address").val("");
    $("#Number").val(""); 
    $("#Email").val("");
    $("#Password").val("");
    $("#DOB").val("");
    $("input[name='Gender']:checked").attr("checked", false);
    $("input[type='checkbox']:checked").prop("checked", false);
}

function ShowRegistrationData() {
    try {
        $.post("/User/ShowRegistrationData", {},
        function (data) {
            if (data.message != "") {
                // alert(data.message)
            }
            if (data.Grid != "") {
                $("#dvGrid1").html(data.Grid)
            }
        })
    }
    catch (e) {
        alert("error in ShowRegistrationData" + e.message)
    }

}

function EditRecord(Id) {
    try {
        $.post("/User/EditRecord", { Id: Id },
        function (data) {
            if (data.Message != "")
            {
                alert(data.Message);
          
            }
            else {
                $("#Id").val(data.Id);
                //alert(data.CountryName)
                $("#CountryName").val(data.CountryName);
                StateBind();
                $("#CityName").val(data.CityName);
                $("#Name").val(data.Name);
                $("#FatherName").val(data.FatherName);
                $("#MotherName").val(data.MotherName);               
                $("#Address").val(data.Address);
                $("#Number").val(data.Number);
                $("#Email").val(data.Email);
                $("#Password").val(data.Password)
                $("#DOB").val(data.DOB);
                //$("#Gender").val(data.Gender);

                if (data.Gender == "Male") {
                    $("#female").removeAttr("checked")
                    $("#male").attr("checked", "checked")
                }
                else {
                    $("#male").removeAttr("checked")
                    $("#female").attr("checked", "checked")
                }

                //$("input[name='Gender']:checked").val(data.Gender);
                if (data.IsActive == "True") {
                    $("#IsActive").prop("checked", true);
                }
                else {
                    $("#IsActive").prop("checked", false);
                }
                setTimeout(function () { $("#StateName").val(data.StateName); }, 100)
            }


        })
    }
    catch (e) {
        alert("Error in Edit " + e.message);
    }
}


function DeleteRecord(Id) {
    if (confirm("do you want delete this data")) {
        try {
            $.post("/User/DeleteRecord", { Id: Id },
            function (data) {
                if (data.Message != "") {
                    alert(data.Message);
                    ShowRegistrationData();
                }
            });
        }
        catch (e) {
            alert("Error in delete " + e.message);
        }
    }
    else {
        return false;
    }
}

function StateBind() {
    try {
        $.post("/User/StateBind", {
            CountryName: $("#CountryName").val(),
        },
            function (data) {
                if (data.Status == "1") {
                    $("#StateName").html(data.StateName);
                }
                else {
                    $("#StateName").html("<option value=''>---------Select State --------</option>");
                }

            })
    }

    catch (e) {
        alert("Error in state" + e);
    }
}

function Logout() {

    try {
        $.post("User/UserLoin", {},
            function (data) {
                if (data.Status == "0") {

                    sessionStorage.clear
                }
                else {

                }
            })
    }
    catch (e) {
        alert("errror in logout")
    }
}