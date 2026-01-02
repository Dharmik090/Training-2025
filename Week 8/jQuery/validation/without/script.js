document.getElementById("registerForm").addEventListener("submit", function (e) {
    e.preventDefault();

    // clear errors
    emailError.textContent = "";
    passwordError.textContent = "";
    confirmError.textContent = "";

    let valid = true;

    if (email.value === "") {
        emailError.textContent = "Email is required";
        valid = false;
    } else if (!email.value.includes("@")) {
        emailError.textContent = "Invalid email";
        valid = false;
    }

    if (password.value.length < 6) {
        passwordError.textContent = "Password must be at least 6 characters";
        valid = false;
    }

    if (password.value !== confirm.value) {
        confirmError.textContent = "Passwords do not match";
        valid = false;
    }

    if (valid) {
        alert("Form submitted!");
    }
});