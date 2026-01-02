
// ----- Web Workers -----
const btn = document.getElementById("btn");
const p = document.getElementById("status");

btn.addEventListener("mouseenter", () => {
    alert("Mouse entered!");
});


// ----- Without Web Workers -----
// function heavyTask() {
//     p.innerText = "Processing...";

//     // Heavy blocking loop
//     let sum = 0;
//     for (let i = 0; i < 10e9; i++) {
//         sum += i;
//     }

//     p.innerText = "Done: " + sum;
// }


// function heavyTask() {
//     p.innerText = "Processing...";

//     // Simulate heavy work without freezing UI
//     setTimeout(() => {
//         let sum = 0;
//         for (let i = 0; i < 10e9; i++) {
//             sum += i;
//         }
//         p.innerText = "Done: " + sum;
//     }, 0);
// }


// ----- Using Web Workers -----

const worker = new Worker("worker.js");

function heavyTask() {
    p.innerText = "Processing...";

    // uses structured clone algorithm to send data
    // .structuredClone() : deep copy

    // From main thread to worker thread
    // postMessage from main thread 
    // then onmessage in worker thread
    worker.postMessage("any type of data");
}

worker.onmessage = function (e) {
    p.innerText = "Done: " + e.data;
};
