//////////////////////////////////////////////////////////////
////                 Async - Await              //////////////
//////////////////////////////////////////////////////////////



// Example 1:

function myDisplayer(some) {
  document.getElementById("demo").innerHTML = some;
}

async function myFunction() {
  // throw new Error("Test");
  return "Hello";
}

myFunction().then(
  (value) => myDisplayer(value),
  (error) => myDisplayer(`MyError : ${error.message}`)
);



/* 

// Example 2:

async function myDisplay() {
  let myPromise = new Promise(function (myResolve, myReject) {
    setTimeout(function () {
      myResolve("Hello World !!");
    }, 3000);
  });
  document.getElementById("demo").innerHTML = await myPromise;
}

myDisplay();
console.log("First");

*/
