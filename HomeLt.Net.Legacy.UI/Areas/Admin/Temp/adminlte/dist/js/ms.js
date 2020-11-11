

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
                    districtSelect.append('<option value=' + v["DistrictId"] + '>' + v["Name"] + '</option>');

                })

            }
        })

    })
    var sellingType = $("#sellingType")
    sellingType.change(function () {
        if (sellingType.val() != false) {
            $("#ticketSection").removeAttr("hidden");
        }
        else {
            $("#ticketSection").attr("hidden");
        }

    })

})


