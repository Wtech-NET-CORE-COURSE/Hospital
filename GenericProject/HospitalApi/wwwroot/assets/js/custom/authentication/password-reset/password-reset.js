"use strict";
var KTPasswordResetGeneral = function () {
    var t, e, i; return {
        init: function () {
            t = document.querySelector("#kt_password_reset_form"),
                e = document.querySelector("#kt_password_reset_submit"),
                i = FormValidation.formValidation(t, {
                    fields: {
                        email: {
                            validators: {
                                notEmpty: { message: "Email adresi zorunludur." },
                                emailAddress: { message: "Girilen ifade bir email deðildir." }
                            }
                        }
                    }, plugins: { trigger: new FormValidation.plugins.Trigger, bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) }
                }),
                e.addEventListener("click", (function (o) {
                    o.preventDefault(),
                        i.validate().then((function (i) {
                            "Valid" == i ? (e.setAttribute("data-kt-indicator", "on"),
                                e.disabled = !0, setTimeout((function () {
                                    e.removeAttribute("data-kt-indicator"),
                                        e.disabled = !1, Swal.fire({
                                            text: "Baþarýyla Giriþ Yaptýnýz!", icon: "success", buttonsStyling: !1,
                                            confirmButtonText: "Tamam, anladým!", customClass: { confirmButton: "btn btn-primary" }
                                        }).then((function (e) { e.isConfirmed && (t.querySelector('[name="email"]').value = "") }))
                                }),
                                    1500)) : Swal.fire({
                                        text: "Üzgünüm, bir hata oluþtu, lütfen tekrar deneyin.", icon: "error",
                                        buttonsStyling: !1, confirmButtonText: "Tamam, Anladým!",
                                        customClass: { confirmButton: "btn btn-primary" }
                                    })
                        }))
                }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTPasswordResetGeneral.init() }));