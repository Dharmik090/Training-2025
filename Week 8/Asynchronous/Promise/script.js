"use strict";

/*
// Example 1:

let promise = new Promise(function (resolve, reject) {
  if (Math.random() >= 0.5) {
    setTimeout(() => resolve("done!"), 1000);
  } else {
    setTimeout(() => reject(new Error("Whoops!")), 1000);
  }
  // setTimeout(() => reject(new Error("Whoops!")), 1000);
});

// resolve runs the first function in .then
// promise.then(
//   (result) => (document.getElementById("msg").textContent = result), // shows "done!" after 1 second
//   (error) => (document.getElementById("msg").textContent = error) // doesn't run
// );

// OR

// Not the proper way

// promise.then(
//   (result) => (document.getElementById("msg").textContent = result),
//   null
// );
// setTimeout(() => {
//   promise.catch(
//     (error) => (document.getElementById("msg").textContent = error)
//   );
//   promise.finally(() => console.log("Promise is settled"));
// }, 3000);

// OR

promise
  .then((result) => (document.getElementById("msg").textContent = result))
  .catch((error) => (document.getElementById("msg").textContent = error))
  .finally(() => console.log("Promise is settled"));

*/

/*
 */
// Example 2:

// new Promise((resolve, reject) => {
//   setTimeout(() => resolve("result"), 2000);
// })
//   .finally(() => alert("Promise ready"))
//   .then((result) => alert(result)); // <-- .then handles the result

/*
// Example 3:

new Promise((resolve, reject) => {
  throw new Error("error");
})
  .finally(() => alert("Promise ready"))
  .catch((err) => alert(err)); // <-- .catch handles the error object

*/

/*
// Example 4:

var i = 1;
let promise = new Promise(function (resolve, reject) {
  setTimeout(() => resolve(`${i++} second passed`), 1000);
});

promise
  .then((value) => {
    console.log(value);
    return new Promise(function (resolve, reject) {
      setTimeout(() => resolve(`${i++} second passed`), 1000);
    });
  })
  .then((value) => console.log(value));
*/
