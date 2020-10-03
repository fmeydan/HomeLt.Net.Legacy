
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


