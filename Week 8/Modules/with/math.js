function square(x) {
    return x * x;
}

function increment(x) {
    x++;
    return x;
}

function logarithm(x) {
    return Math.log(x);
}


// loads at first import
// not everytime when it gets imported
console.log("Math module loaded.");


// Named export example:
export { square, increment, logarithm };

/*
Default export example:
export default function square(x) {
    return x * x;
}

import square from './math.js';
*/