// Cookie consent banner
const cookieBtn = document.getElementById('acceptCookies');
const cookieBanner = document.getElementById('cookieBanner');

function getCookie(name) {
    return document.cookie.
        split('; ').
        find(str => str.startsWith(name + '='));
}

cookieBtn.addEventListener('click', function () {

    if (!getCookie('consent')) {
        document.cookie = "consent=true; expires=" + 60 * 60 * 24 * 7 + "; path=/";

        cookieBanner.style.display = 'none';
    }
});


// Remember username using localStorage
const username = document.getElementById('username');
const saveBtn = document.getElementById('save-btn');

saveBtn.addEventListener('click', function () {
    const name = username.value;

    localStorage.setItem('username', name);
});

// Load saved username on page load if exist
username.value = localStorage.getItem('username') || '';


// Reset when tab/browser closes - Session Storage
const clickBtn = document.querySelector("#clickBtn");
const clickCountDisplay = document.querySelector("#clickCount");

let sessionClicks = sessionStorage.getItem("clicks");

if (!sessionClicks) {
    sessionClicks = 0;
} else {
    sessionClicks = Number(sessionClicks);
}

clickCountDisplay.innerText = sessionClicks;

clickBtn.addEventListener("click", () => {
    sessionClicks++;
    sessionStorage.setItem("clicks", sessionClicks);
    
    clickCountDisplay.innerText = sessionClicks;
});
