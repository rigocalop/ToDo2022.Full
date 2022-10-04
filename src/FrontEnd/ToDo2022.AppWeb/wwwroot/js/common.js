window.MostrarToastr = (tipo, mensaje) => {
    if (tipo === "success") {
        toastr.success(mensaje, "Successful Operation");
    }

    if (tipo === "error") {
        toastr.error(mensaje, "Mensaje de Error");
    }
}
