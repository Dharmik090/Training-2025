let text = "Hello World!!\nhello everyone.";

// ----- Flags & String Methods -----

// .search() 
console.log(text.search(/World/));
console.log(text.search(/wORld/i));

// .match()
console.log(text.match(/Hello/gi));

console.log(text.match(/Hello/i));

// .replace()
console.log(text.replace(/Hello/, "Hi"));

console.log(text.replace(/Hello/ig, "Hi"));

// .split() using regex
console.log("apple,banana;orange|mango".split(/[,;|]/));



// ----- Character Classes -----

// Matches ONE character from the set
console.log("bat cat rat".match(/[cr]at/g));

// Negation: anything except abc
console.log("abc123".match(/[^abc]/g));

// Ranges
console.log("A9z".match(/[A-Za-z0-9]/g));

// same as
console.log("A9z".match(/\w/g));

console.log("A9z".match(/[A-Za-z0-9]+/g));

// Exclude digits
console.log("abc123".match(/[^0-9]/g));



// ----- Meta Characters -----

let metaText = "User_01 @ mail";

console.log(metaText.match(/\d/g));
console.log(metaText.match(/\w+/g));



// ----- Quantifiers -----

console.log("heeyyyyy".match(/he*/));
console.log("he".match(/ey+/));

let phone = "999-888-7777";
console.log(phone.match(/\d{3}-\d{3}-\d{4}/));



// ----- Anchors -----

// text = "Hello World!!\nhello everyone."
console.log(/^Hello/.test(text));
console.log(/everyone\.$/.test(text));



// ----- Groups & Capturing -----

let date = "2025-12-23";
let result = date.match(/(\d{4})-(\d{2})-(\d{2})/);

console.log(result[0]);
console.log(result[1]);
console.log(result[2]);
console.log(result[3]);



// ----- Lookaheads -----

// Password must contain a digit and be 6+ chars
console.log(/(?=.*\d).{6,}/.test("abc123"));
console.log(/(?=.*\d).{6,}/.test("abcdef"));



// ----- Regex Objects -----

let reg1 = /hello/i;
let reg2 = new RegExp("hello", "i");

console.log(reg1.test("Hello world")); // true
console.log(reg2.test("HELLO"));       // true


// exec()
let execText = "I have 2 apples and 3 bananas";
let regex = /(\d+)/g;

console.log(regex.exec(execText)); // ["2"]
console.log(regex.exec(execText)); // ["3"]
console.log(regex.exec(execText)); // null



// Email validation
let emailRegex = /^[\w.-]+@[\w.-]+\.\w{2,}$/;
console.log(emailRegex.test("user@mail.com")); // true

// Remove extra spaces
let messy = "Hello     World     !!";
console.log(messy.replace(/\s+/g, " "));



// Capturing vs Matching
let match = "2025-12-23".match(/(\d{4})-(\d{2})-(\d{2})/);
// let match = "2025-12-23".match(/\d{4}-\d{2}-\d{2}/);

console.log(match);

