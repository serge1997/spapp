class Toast {

    success(message) {
        this.handle(message, "success");
    }

    error(message) {
        this.handle(message, "error");
    }

    handle(message, icon) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (toast) => {
                toast.onmouseenter = Swal.stopTimer;
                toast.onmouseleave = Swal.resumeTimer;
            }
        });

        return Toast.fire({
            icon: icon,
            text: message
        });
    } 
}

const toastSpApi = new Toast();
