// let para = document.getElementById("demo");
// setTimeout(() => (para.style.color = "blue"), 3000);
// para.innerHTML = "<b>Example of Asynchronous JS Program</b>";


// let img = document.getElementById("im");
// img.src = "office.jpg";
// img.addEventListener("load", function () {
//     img.classList.add("fadeIn");
// });

// img.style.width = "300px";
// img.style.height = "400px";


let para = document.getElementById("demo");
para.innerHTML = "A picture is being loaded";

function myDisplayer(some) {
    document.getElementById("demo").innerHTML = some;
}

function getFile(myCallback) {
    
    let req = new XMLHttpRequest();
    
    req.open("GET", "mycar.html");
    
    req.onload = function () {
        if (req.status == 200) {
            myCallback(req.responseText);
        } else {
            myCallback("Error: " + req.status);
        }
    };
    
    req.send();
}

setTimeout(() => getFile(myDisplayer), 3000);
