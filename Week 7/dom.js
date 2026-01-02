// -----Select-----
const heading = document.getElementById("heading");

const paragraphs = document.getElementsByClassName("para");

const listItems = document.getElementsByTagName("li");

// querySelector
// for css like selection, we can use combinations like (class + id), attributes
const firstPara = document.querySelector(".para"); 

// document.querySelector("div.box button#toggleBtn");

const allPara = document.querySelectorAll(".para");


// -----Properties-----
console.log(heading.tagName);
console.log(document.getElementById("div1")); // Inner content as it is
console.log(document.getElementById("div1").innerText); // Text that is displayed on screen


// -----First child vs Last child-----
const list = document.getElementById("items");

console.log(list.firstElementChild.innerText);
console.log(list.lastElementChild.innerText);


// -----Attributes-----
heading.setAttribute("title", "This is heading");
console.log(heading.getAttribute("title"));
console.log(heading.getAttribute("class"));
console.log(heading.getAttribute("id"));


// -----Insert elements-----
function addItem() {
    const li1 = document.createElement("li");

    li1.innerText = "Append Item";
    list.append(li1);

    const li2 = document.createElement("li");

    li2.innerText = "Prepend Item";
    list.prepend(li2);
}

list.after(document.createElement("hr"));
list.before(document.createElement("hr"));


// -----Change Style-----
function changeText() {
    heading.innerText = "New heading";
    document.getElementById("text").innerHTML = "<b>New paragraph text</b>";
}

function changeColor() {
    heading.style.color = "red";
}


// -----Events-----
heading.addEventListener("click", () => {
    heading.classList.toggle("highlight");
});

heading.addEventListener("dblclick", () => {
    alert("Double click");
});


const input = document.getElementById("nameInput");

input.addEventListener("keydown", (e) => {
    console.log("Key down:", e.target.value);
});

input.addEventListener("keyup", (e) => {
    document.getElementById("output").innerText = e.target.value;
});

input.addEventListener("focus", () => {
    document.getElementById("output").innerText = "Input focused";
});

input.addEventListener("focusout", () => {
    document.getElementById("output").innerText = input.value;
});

document.getElementById("toggleBtn")
    .addEventListener("click", () => {
        document.body.classList.toggle("dark");
    });


// -----Event Bubbling-----
document.getElementById("child").addEventListener("click", () => {
    alert("Child clicked");
});

document.getElementById("parent").addEventListener("click", () => {
    alert("Parent clicked");
});

// To stop bubbling
document.getElementById("child").addEventListener("click", (e) => {
    e.stopPropagation();
    alert("Child clicked - propagation stopped");   
});
