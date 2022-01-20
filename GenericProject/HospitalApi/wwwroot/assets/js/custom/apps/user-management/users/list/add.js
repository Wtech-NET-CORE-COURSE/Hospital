"use strict";
var KTSignupGeneral = function () {
    var e, t, a, s, r, theContact = function () {
        return 100 === s.getScore()
    };
    return {
        init: function () {
            e = document.querySelector("#kt_modal_add_user_form"),
                t = document.querySelector("#kt_sign_up_submit"),
                s = KTPasswordMeter.getInstance(e.querySelector('[data-kt-password-meter="true"]')),
                a = FormValidation.formValidation(e, {
                    fields: {
                        "Doctor_Name": { validators: { notEmpty: { message: "Ýsim alaný zorunludur" } } },
                        Hospital: {
                            validators: {
                                notEmpty: { message: "Hastane adý zorunludur" },
                            }
                        },
                                              
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger({ event: { password: !1 } }),
                        bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" })
                    }
                }),
                t.addEventListener("click", (function (r) {
                    r.preventDefault(),
                        a.validate().then((function (a) {
                            "Valid" == a ? (t.setAttribute("data-kt-indicator", "on"),
                                t.disabled = !0, setTimeout((function () {
                                    t.removeAttribute("data-kt-indicator"),
                                        t.disabled = !1,
                                        theContact = {
                                        Doctor_Name: $("[name='Doctor_Name']").val(),
                                        Hospital: $("[name='Hospital']").val(),
                                        Poliklinik: $("[name='Poliklinik']").val(),
                                        };

                                    $.ajax({
                                        type: "POST",
                                        url: "https://localhost:44358/api/doctor/createdoctor",
                                        contentType: "application/json; charset=utf-8",
                                        data: JSON.stringify(theContact),
                                        dataType: "json",
                                        success: function (data) {
                                            Swal.fire({
                                                text: "Kaydýnýz yapýlmýþtýr!",
                                                icon: "success", buttonsStyling: !1, confirmButtonText: "Tamam, Anladým!",
                                                customClass: { confirmButton: "btn btn-primary" }
                                            }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))
                                        },
                                        error: function (data) {

                                        }

                                    });

                                }), 1500)) : Swal.fire({
                                    text: "Üzgünüm, bir hata oluþtu, lütfen tekrar deneyin!",
                                    icon: "error", buttonsStyling: !1, confirmButtonText: "Tamam, anladým!",
                                    customClass: { confirmButton: "btn btn-primary" }
                                }).then((function (t) { t.isConfirmed && (e.reset(), s.reset()) }))
                        }))
                }))
        }
    }
}(); KTUtil.onDOMContentLoaded((function () { KTSignupGeneral.init() }));