

function infoMessage(type, msg) {
    
   
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000
        });
       
            Toast.fire({
                icon: type,
                title: msg
            })
    
    
};

$(document).ready(function () {


    var file = $(":file");
    file.change(function () {
        var parent = $(this).parent()

        if ($(this).prop("files").length > 1) {
            parent.find("label").text("Selected Multiple File")
        } else {
            parent.find("label").text(file.val())
        }


    })

})


