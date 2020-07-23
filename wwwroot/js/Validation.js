$.validator.setDefaults({
    submitHandler: function () {
        alert("submitted!");
    }
});

$().ready(function () {
    // validate signup form on keyup and submit
    $(".myform").validate({
        rules: {
            Brand: "required",
            Model: "required",
            ReleaseDate: "required",
            RegDate: "required",
            CarNumber: {
                required: true,
                minlength: 6
            },
            InspDate: "required",
            InspNote: "required"
        },
        messages: {
            Brand: "Обязательное поле.",
            Model: "Обязательное поле.",
            CarNumber: {
                required: "Обязательное поле.",
                minlength: "Длина ГРЗ минимум 6 знаков."
            },
            ReleaseDate: "Обязательное поле.",
            RegDate: "Обязательное поле.",
            InspDate: "Обязательное поле.",
            InspNote: "Обязательное поле."
        }
    });
});