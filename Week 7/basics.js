// ----------USE dom.html----------


/*
// -----VAR-----
var a = 10;
console.log("var a:", a);

a = 20;  
console.log("Reassignment:", a);

var a = 30; 
console.log("Redeclare:", a);


// -----LET-----
let b = 10;
console.log("let b:", b);

b = 20;  
console.log("Reassignment:", b);

// let b = 30; // Cannot redeclare let


// -----CONST-----
const c = 10;
console.log("const c:", c);

// c = 20;  // Cannot reassign const
// const c = 30; // Cannot redeclare const

const obj = { name: "Dharmik" };
obj.name = "Parmar";  

console.log("const object:", obj);
*/


// -----DATA TYPES-----
/*

// 1. Number
let num = 10;
let floatNum = 10.5;
console.log("Number:", num, typeof num);
console.log("Float:", floatNum, typeof floatNum);

// 2. String
let str = "Hello ";
let str2 = 'World';
console.log("String:", str, typeof str);
console.log("String:", str2, typeof str2);

// 3. Boolean
let b1 = true;
console.log("Boolean:", b1, typeof b1);

// 4. Undefined
let x;
console.log("Undefined:", x, typeof x);

// 5. Null
let y = null;
console.log("Null:", y, typeof y); 

// 6. Symbol (unique values)
let sym1 = Symbol("id");
let sym2 = Symbol("id");
console.log("Symbol:", sym1, typeof sym1);
console.log("Symbols equal?", sym1 === sym2);

// 7. BigInt
let big = 123456789012345678901234567890n;
console.log("BigInt:", big, typeof big);

// 8. Object
let person = {
    name: "Dharmik",
    age: 21
};
console.log("Object:", person, typeof person);

// 9. Array
let numbers = [1, 2, 3, 4];
console.log("Array:", numbers, typeof numbers);
console.log("Is Array?", Array.isArray(numbers));

// 10. Function
function greet1() {
    return "Hello!";
}

const greet2 = function() {
    return "Hi!";
};
console.log(greet1(), typeof greet1);
console.log(greet2(), typeof greet2);
*/


// -----DATE-----
/*
const d = new Date(2024, 11, 21); // December 21, 2024
console.log("Date:", d);

console.log("Year:", d.getFullYear());
console.log("Month:", d.getMonth() + 1); // Months are 0-indexed
console.log("Date:", d.getDate());
console.log("Day:", d.getDay()); // 0 (Sun) to 6 (Sat)


// zero time = 1970-01-01
const milli = new Date(86400000);
console.log("Milliseconds Date:", milli);

// new Date()
// new Date(date string)

// new Date(year,month)
// new Date(year,month,day)
// new Date(year,month,day,hours)
// new Date(year,month,day,hours,minutes)
// new Date(year,month,day,hours,minutes,seconds)
// new Date(year,month,day,hours,minutes,seconds,ms)

// new Date(milliseconds)

// setDate()	
// setFullYear()	
// setHours()	
// setMilliseconds()	
// setMinutes()	
// setMonth()	
// setSeconds()	
// setTime()
*/


// -----MATH-----
/*
// Math.E        returns Euler's number
// Math.PI       returns PI
// Math.SQRT2    returns the square root of 2
// Math.SQRT1_2  returns the square root of 1/2
// Math.LN2      returns the natural logarithm of 2
// Math.LN10     returns the natural logarithm of 10
// Math.LOG2E    returns base 2 logarithm of E
// Math.LOG10E   returns base 10 logarithm of E

console.log("Math.random():", Math.random() * 10); // 0 to 9 
console.log("Math.PI:", Math.PI);
console.log("Math.E:", Math.E);

console.log("Math.round(4.5):", Math.round(4.5));
console.log("Math.ceil(4.2):", Math.ceil(4.2));
console.log("Math.floor(4.7):", Math.floor(4.7));
console.log("Math.trunc(4.9):", Math.trunc(4.9));
*/


// -----STRING-----
/*
let text = "Hello World";
console.log(text.length); // 11

console.log(text.charAt(4)); 

console.log(text.slice(0, 4));

console.log(text.toUpperCase()); // HELLO

console.log(text.replace("apples", "bananas"));
*/


// -----SLICE vs SPLICE-----
/*
let arr1 = [10, 20, 30, 40, 50];

let result = arr1.slice(1, 4);

console.log(result); // [20, 30, 40]
console.log(arr1);

let arr2 = [10, 20, 30, 40, 50];

arr2.splice(1, 2);

console.log(arr2); 
*/


// -----call vs applly vs bind-----
/*

// call and apply invokes the function immediately
// bind returns a new function

// call & apply
const person = {
    display: function (city, country) {
        return this.firstName + " " + this.lastName + "," + city + "," + country;
    }
}

const person1 = {
    firstName: "John",
    lastName: "Doe"
}

const person2 = {
    firstName: "Mary",
    lastName: "Smith"
}

person.display.call(person1, "Oslo", "Norway");

person.display.apply(person2, ["Oslo", "Norway"]);


// bind: object can borrow method
const person3 = {
    firstName: "Jack",
    lastName: "Sparrow",
    fullName: function () {
        return this.firstName + " " + this.lastName;
    }
}

let fullName = person3.fullName.bind(person2);
fullName();


// this will be undefined
const p1 = {
    firstName: "John",
    lastName: "Doe",
    display: function () {
        let x = document.getElementById("demo");
        x.innerHTML = this.firstName + " " + this.lastName;
    }
}

setTimeout(p1.display, 3000);

// using bind to set this
setTimeout(p1.display.bind(p1), 3000);
*/