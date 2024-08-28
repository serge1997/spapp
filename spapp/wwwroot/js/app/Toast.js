class Toast {

    success(message, timer = 3000) {
        this.handle(message, "success", timer);
    }

    error(message, timer = 3000) {
        this.handle(message, "error", timer);
    }

    handle(message, icon, timer) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: timer,
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
