// 1.
window.onload = () => {
    console.log("loaded");
};

// 2.
// window.addEventListener("beforeunload", (e) => {
//     e.preventDefault();
// });

// 3.
// window.addEventListener("beforeunload", () => {
//     sessionStorage.setItem("reloading", "true");
// });

// window.addEventListener("load", () => {
//     if (sessionStorage.getItem("reloading")) {
//         alert("Page was reloaded");
//         sessionStorage.removeItem("reloading");
//     }
// });



window.addEventListener("resize", () => {
    console.log(window.innerWidth, window.innerHeight);
});

