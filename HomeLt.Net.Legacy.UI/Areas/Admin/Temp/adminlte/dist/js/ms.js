﻿

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

