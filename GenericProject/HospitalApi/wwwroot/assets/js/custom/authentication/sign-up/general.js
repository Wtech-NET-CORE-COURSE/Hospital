"use strict";
var KTSignupGeneral = function () {
    var e, t, a, s, r, theContact = function () {
        return 100 === s.getScore()
    };
    return {
        init: function () {
            e = document.querySelector("#kt_sign_up_form"),
                t = document.querySelector("#kt_sign_up_submit"),
                s = KTPasswordMeter.getInstance(e.querySelector('[data-kt-password-meter="true"]')),
                a = FormValidation.formValidation(e, {
                    fields: {
                        "full-name": { validators: { notEmpty: { message: "�sim alan� zorunludur" } } },                       
                        email: {
                            validators: {
                                notEmpty: { message: "Email adresi zorunludur" },
                                emailAddress: { message: "Girilen ifade bir email de�ildir." }
                            }
                        },
                        password: {
                            validators: {
                                notEmpty: { message: "�ifre alan� zorunludur." },
                                callback: { message: "L�tfen �ifrenizi do�ru giriniz.", callback: function (e) { if (e.value.length > 0) return r() } }
                            }
                        },
                        "confirm-password": {
                            validators: {
                                notEmpty: { message: "�ifre do�rulama gereklidir." },
                                identical: { compare: function () { return e.querySelector('[name="password"]').value }, message: "Girilen �ifreler ayn� de�ildir." }
                            }
                        },
                        toc: { validators: { notEmpty: { message: "�artlar� kabul ediniz." } } }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger({ event: { password: !1 } }),
                        bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" })
                    }
                }),
                t.addEventListener("click", (function (r) {

                    r.preventDefault(), a.revalidateField("password"),
                        a.validate().then((function (a) {
                            "Valid" == a ? (t.setAttribute("data-kt-indicator", "on"),
                                t.disabled = !0, setTimeout((function () {
                                    t.removeAttribute("data-kt-indicator"),
                                        t.disabled = !1,
                                        theContact = {
                                            fullname: $("[name='full-name']").val(),
                                            email: $("[name='email']").val(),
                                            password: $("[name='password']").val()
                                        };

                                    $.ajax({
                                        type: "POST",
                                        url: "https://localhost:44358/api/login/create",
                                        contentType: "application/json; charset=utf-8",
                                        data: JSON.stringify(theContact),
                                        dataType: "json",
                                        success: function (data) {
                                            Swal.fire({
                                                text: "Kayd�n�z yap�lm��t�r!",
                                                icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam, Anlad�m!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))
                                        },
                                        error: function (data) {

                                        }

                                    });

                                }), 1500)) : Swal.fire({
                                    text: "�zg�n�m, bir hata olu�tu, l�tfen tekrar deneyin!",
                                    icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam, anlad�m!",
                                    customClass: { confirmButton: "btn btn-primary" }
                                }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))
                        }))
                })),
                e.querySelector('input[name="password"]').addEventListener("input", (function () { this.value.length > 0 && a.updateFieldStatus("password", "NotValidated") }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTSignupGeneral.init() }));