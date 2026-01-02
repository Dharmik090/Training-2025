function setCookie() {
    document.cookie = "user=Dharmik; expires=Fri, 31 Dec 2027 23:59:59 GMT; path=/";
    alert("Cookie Set!");
}

function showCookies() {
    alert("Cookies: " + document.cookie);
}

function deleteCookie() {
    document.cookie = "user=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/";
    alert("Cookie Deleted!");
}
