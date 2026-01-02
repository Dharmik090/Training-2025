// LOCAL STORAGE
function saveLocal() {
    let value = document.getElementById("localInput").value;
    localStorage.setItem("localKey", value);
}

function loadLocal() {
    let value = localStorage.getItem("localKey");
    alert("Local Storage value: " + value);
}

// SESSION STORAGE
function saveSession() {
    let value = document.getElementById("sessionInput").value;
    sessionStorage.setItem("sessionKey", value);
}

function loadSession() {
    let value = sessionStorage.getItem("sessionKey");
    alert("Session Storage value: " + value);
}
