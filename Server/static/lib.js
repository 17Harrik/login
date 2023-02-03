const hints = document.getElementById("hints");
const form = document.getElementById("login");
function reset() {
    console.log("Reset");
}

function createUser() {
    console.log("Create");
}

function login() {

    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    try {
        presenceCheck(username, "Please enter your username");
        presenceCheck(password, "Please enter your password");

        lengthCheck(password, 5, 10, "Please enter a password between 5 and 10 characters");
        hints.innerText = "Attempting login";
        form.submit();
    } catch (e) {
        hints.innerText = e;
    }
}

function lengthCheck(input, minLength, maxLength, message) {
    if (input, input.length > maxLength || input.length < minLength) {
        throw message;
    }
}

function presenceCheck(input, message) {

    if (input == "") {
        throw message;
    }
}