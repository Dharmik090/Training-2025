$.validator.addMethod("noSpaces", function (value) {
    return value.indexOf(" ") === -1;
}, "Spaces are not allowed");


$("#registerForm").validate({

    // RULES
    rules: {
        email: {
            required: true,
        },
        password: {
            required: true,
            minlength: 6
        },
        confirm: {
            required: true,
            equalTo: ".password"
        },
        username: {
            required: true,
            noSpaces: true
        }
    },

    // CUSTOM MESSAGES
    messages: {
        email: {
            required: "Email is required",
            email: "Custom: Enter a valid email"
        },
        password: {
            minlength: "Minimum 6 characters"
        },
        confirm: {
            equalTo: "Passwords must match"
        }
    },

    // STYLING OPTIONS
    errorClass: "error",
    validClass: "valid",

    // SUBMIT HANDLER
    submitHandler: function (form) {
        alert("Form is valid and ready to submit!");
        form.submit(); // form is valid, directly submit it

        // $(form).submit(); // IMPORTANT (not $(form).submit())
    }
});
