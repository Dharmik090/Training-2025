// ----- Ad-hoc polymorphism -----
/*
function calculateArea(shape, arg1, arg2) {
    if (shape === "rectangle") {
        return arg1 * arg2;
    }
    else if (shape === "circle") {
        return Math.PI * Math.pow(arg1, 2);
    }
    else {
        throw new Error("Unsupported shape");
    }
}

console.log(calculateArea("rectangle", 5, 3));
console.log(calculateArea("circle", 4));
*/


// ----- Parametric Polymorphism -----
/*
function getLength(input) {
    if (input != null && typeof (input.length) === 'number')
        return input.length;
    else
        throw new Error("Input does not have a length property");
}

console.log(getLength([1, 2, 3]));
console.log(getLength("Hello"));
*/


// ----- Overriding -----
/*
class Shape {
    draw() {
        console.log("Drawing a shape");
    }
}

class Circle extends Shape {
    draw() {
        console.log("Drawing a circle");
    }
}

class Square extends Shape {
    draw() {
        console.log("Drawing a square");
    }
}

const circle = new Circle();
const square = new Square();

circle.draw();
square.draw();
*/



// ---------- Design Patterns Leveraging Polymorphism ----------

// ----- 1. Strategy Pattern -----
/*
// Strategy Interface
class PaymentStrategy {
    pay(amount) { }
}

// Concrete Strategies
class CreditCardPayment extends PaymentStrategy {
    pay(amount) {
        console.log(`Paid $${amount} using Credit Card`);
    }
}

class PaytmPayment extends PaymentStrategy {
    pay(amount) {
        console.log(`Paid $${amount} using PayPal`);
    }
}


class ShoppingCart {
    constructor(paymentStrategy) {
        this._paymentStrategy = paymentStrategy;
    }

    checkout(amount) {
        this._paymentStrategy.pay(amount);
    }
}

const cart = new ShoppingCart(new CreditCardPayment());
cart.checkout(100);

cart._paymentStrategy = new PaytmPayment();
cart.checkout(200);
*/


// ----- 2. Template Method Pattern -----
/*
class DataParser {
    parse(data) {
        this.readData(data);
        this.processData();
        this.saveData();
    }

    readData(data) {
        throw new Error("This method must be overridden!");
    }

    processData() {
        throw new Error("This method must be overridden!");
    }

    saveData() {
        throw new Error("This method must be overridden!");
    }
}

class CSVParser extends DataParser {
    readData(data) {
        console.log("Reading CSV data:", data);
    }
    processData() {
        console.log("Processing CSV data");
    }
    saveData() {
        console.log("Saving CSV data");
    }
}
class JSONParser extends DataParser {
    readData(data) {
        console.log("Reading JSON data:", data);
    }
    processData() {
        console.log("Processing JSON data");
    }
    saveData() {
        console.log("Saving JSON data");
    }
}

const csvParser = new CSVParser();
csvParser.parse("name,age\nDharmik,21");

const jsonParser = new JSONParser();
jsonParser.parse('{"name": "John", "age": 25}');
*/


// ----- 3. Visitor Pattern -----
/*
// Visitor Interface
class Visitor {
    visit(element) { }
}

// Concrete Visitor
class TaxVisitor extends Visitor {
    visit(element) {
        if (element instanceof Liquor) {
            return element.price * 0.18; // Liquor tax rate: 18%
        } else if (element instanceof Tobacco) {
            return element.price * 0.25; // Tobacco tax rate: 25%
        } else if (element instanceof Necessity) {
            return element.price * 0.05; // Necessity tax rate: 5%
        }
    }
}

// Visitable Interface
class Visitable {
    accept(visitor) { }
}

// Concrete Visitable Elements
class Liquor extends Visitable {
    constructor(price) {
        super();
        this.price = price;
    }

    accept(visitor) {
        return visitor.visit(this);
    }
}

class Tobacco extends Visitable {
    constructor(price) {
        super();
        this.price = price;
    }

    accept(visitor) {
        return visitor.visit(this);
    }
}

class Necessity extends Visitable {
    constructor(price) {
        super();
        this.price = price;
    }

    accept(visitor) {
        return visitor.visit(this);
    }
}

// Usage
const items = [new Liquor(20), new Tobacco(30), new Necessity(50)];
const visitor = new TaxVisitor();

const totalTaxes = items.reduce((acc, item) => acc + item.accept(visitor), 0);
console.log(`Total Taxes: $${totalTaxes.toFixed(2)}`);
*/