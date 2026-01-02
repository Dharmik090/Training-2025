// Digital Clock
function updateClock() {
    const now = new Date();
    const time = now.toLocaleTimeString();
    document.getElementById("clock").innerText = time;
}

setInterval(updateClock, 1000);
updateClock();

// Random User ID
const userId = Math.floor(Math.random() * 9000) + 1000;
document.getElementById("userId").innerText = userId;

// Format messy string
let str = " heLLO woRLD ";
let formattedString = str
    .trim()
    .toLowerCase()
    .split(" ")
    .map(word => word.charAt(0).toUpperCase() + word.slice(1))
    .join(" ");

document.getElementById("formattedString").innerText = formattedString;
