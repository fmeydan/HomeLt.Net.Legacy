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
		console.log(urParts.indexOf("Blog"))
		if (urParts.indexOf("Blog") != -1) {
			if ($(this).text() == "Blog") {
				$(this).parent().addClass("active nav-item")
            }
		}



	})


$("#ButtonSignUp").click(function () {


    var email = document.getElementsByName("UserEmail");
    var password = document.getElementsByName("Pssword");
    $.ajax({
        type: "POST",
        data: [email, password],
        url: "/User/Register",
        success: function (data) {
            console.log("Success Returned")
            //if (data == "Success") {
            //    window.location.href = "/Index/Home"
            //}
            if (data) {
                $("#msg").css("class", "alert alert-danger")
                $("#msg").html("Kayıt olurken bir hata oluştu lütfen tekrar deneyin");
            }
        }

    })
})


