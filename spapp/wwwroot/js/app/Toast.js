class Toast {

    success(message, timer = 3000) {
        this.handle(message, "success", timer);
    }

    error(message, timer = 3000) {
        this.handle(message, "error", timer);
    }

    info(message, timer = 3000) {
        this.handle(message, "info", timer);
    }

    warning(message, timer = 3000) {
        this.handle(message, "warning", timer);
    }

    handle(message, icon, timer) {
        const Toast = Swal.mixin({
            toast: true,
            position: "top-end",
            showConfirmButton: false,
            timer: timer,
            timerProgressBar: true,
            iconColor: 'white',
            customClass: {
                popup: 'colored-toast',
            },
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
