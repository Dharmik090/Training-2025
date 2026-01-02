let count = 0;

const container = document.querySelector('.container');
const btn = document.querySelector('#light-switch');

function toggleLight(e) {
    // e.stopPropagation();

    container.classList.toggle('light-on');

    if (btn.innerText === "Turn On") {
        btn.innerText = "Turn Off";
    }
    else {
        btn.innerText = "Turn On";
    }
}

document.querySelector('body').addEventListener('click', function () {
    count++;
    console.log("Body clicked " + count + " times");
});