﻿


var path = window.location.href;
var urParts = path.split("/");


	$(".nav li a").each(function () {
		
		if (this.href === path) {

			$(this).parent().addClass("active")
			if ($(this).parents() != null) {
			$(this).parent().parent().parent().addClass("active")
			}
		}

		if (urParts.indexOf("Blog") != -1) {
			if ($(this).text() == "Blog") {
				$(this).parent().addClass("active nav-item")
            }
		}



	})

$(document).ready(function () {

	$("#CitySelect").change(function () {
		
		var cityId = $("#CitySelect").val();
		var districtSelect = $("#DistrictSelect");
		
		$.ajax({
			method: "POST",
			url: "/Adress/GetDistricts/",
			data: { id: cityId },
			success: function (model) {
				districtSelect.empty();
				var data = $.parseJSON(model);
				$.each(data, function (k, v) {
					districtSelect.append('<option value=' + v["DistrictId"]  + '>' + v["Name"] + '</option>');
					
                })
				
            }
        })

	})


	







	var path = window.location.href;
	var urParts = path.split("/");


	$(".nav li a").each(function () {

		if (this.href === path) {

			$(this).parent().addClass("active")
			if ($(this).parents() != null) {
				$(this).parent().parent().parent().addClass("active")
			}
		}
		console.log(urParts.indexOf("Blog"))
		if (urParts.indexOf("Blog") != -1) {
			if ($(this).text() == "Blog") {
				$(this).parent().addClass("active nav-item")
			}
		}



	});


	

	var file = $(":file");
	file.change(function () {
		var parent = $(this).parent()
	
		if ($(this).prop("files").length>1) {
			parent.find("label").text("Selected Multiple File")
		} else {
			parent.find("label").text(file.val())
        }
		
		
    })


})




//$(document).ready(function (event) {
//    var loginForm = $("#LoginForm");
//    loginForm.submit(function (ev) {
//        ev.preventDefault();
//        var email = $("#LoginUserMail").val();
//        var password = $("#LoginUserPassword").val();
//        $.ajax({
//            type: "POST",
//            data: { "Email": email, "Password": password },
//            url: /User/Login,
//            success: function (data) {
//                console.log(data)
//                //if (data == false) {
//                //    $("#msg").addClass("alert alert-danger")
//                //    $("#msg").html("Kayıt olurken bir hata oluştu lütfen tekrar deneyin");
//                //} else {
//                //    window.location = "/";
//                //}

//            }
       
//    })
//    })
//})


//$("#ButtonSignUp").click(function () {


//    var email = document.getElementById("signupmail").value;
//    var password = document.getElementById("signuppassword").value;
//    var passwordagain = document.getElementById("signuppasswordagain").value;
   
//    console.log(email)
//    console.log(password)
   

//    if (email != null && password != null && password == passwordagain) {

    
//    $.ajax({
//        type: "POST",
//        data: { "Email": email, "Password": password },
//        url: "/User/Register",
//        success: function (data) {
//            console.log("Success Returned")
//            if (data == "Success") {
//                window.location.href = "/Index/Home"
//            }
//            else {
//                $("#msg").addClass("alert alert-danger")
//                $("#msg").html("Kayıt olurken bir hata oluştu lütfen tekrar deneyin");
//            }
//        }

//    })
//    }
//})


