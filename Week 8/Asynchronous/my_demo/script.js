// --------------------------------------------
function myDisplayer(some) {
    document.getElementById("demo").innerHTML = some;
}

let myPromise = new Promise(function (myResolve, myReject) {
    let x = 0;

    // The producing code (this may take some time)

    if (x == 0) {
        myResolve("OK");
    } else {
        myReject("Error");
    }
});

myPromise.then(
    function (value) { myDisplayer(value); },
    function (error) { myDisplayer(error); }
);


// --------------------------------------------
Promise.resolve(10)
    .then(value => {
        console.log("First then:", value);
        return value * 2;
    })
    .then(value => {
        console.log("Second then:", value);
    })
    .catch(err => {
        console.log("Catch:", err);
    });


Promise.resolve("OK")
    .then(value => {
        console.log("Then:", value);
        throw new Error("Something went wrong");
    })
    .then(() => {
        console.log("This will NOT run");
    })
    .catch(err => {
        console.log("Caught:", err.message);
    });


Promise.reject("Failed")
    .then(value => {
        console.log("This will NOT run:", value);
    })
    .catch(err => {
        console.log("Caught:", err);
    });



// --------------------------------------------
async function abc() {
    return 10;
}

function abc() {
    return Promise.resolve(10);
}
// BOTH ARE SAME, async automatically return Promise

abc(); // Promise { fulfilled: 10 }


// --------------------------------------------
async function abc() {
    const data = await fetch("https://api.example.com");
    return data;
}

function abc() {
    return fetch("https://api.example.com")
        .then(data => data);
}
// BOTH ARE SAME, await waits for Promise to resolve


// --------------------------------------------
async function abc() {
    try {
        const data = await fetch("bad-url");
        return data;
    } catch (err) {
        console.error(err);
    }
}

fetch("bad-url")
    .then(data => { })
    .catch(err => console.error(err));
