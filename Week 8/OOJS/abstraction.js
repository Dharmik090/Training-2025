// ----- Using ES5 -----
/*
// Abstract Class
function Vehicle(vehicleName) {
    // Prevent direct instantiation
    if (this.constructor === Vehicle) {
        throw new Error("You cannot create an instance of an abstract class");
    }

    this.vehicleName = vehicleName;
    console.log(vehicleName);
}

// Abstract Method
Vehicle.prototype.getVehicleDetail = function () {
    throw new Error("Abstract method must be implemented");
};

// Subclass
function Bike(name) {
    // Call parent constructor
    Vehicle.call(this, name);
}

// Inheritance
Bike.prototype = Object.create(Vehicle.prototype);
Bike.prototype.constructor = Bike;

// Implement abstract method
Bike.prototype.getVehicleDetail = function () {
    console.log("Vehicle name is: " + this.vehicleName);
};

// Instantiation
var bike = new Bike("Honda");
bike.getVehicleDetail();
*/


// ----- Using ES6 -----
/*
// Abstract Class
class Person {
    constructor(name) {
        this.name = name;

        // Prevent direct instantiation
        if (this.constructor === Person) {
            throw new Error("You cannot create an instance of an abstract class.");
        }
    }

    // Abstract method
    info() {
        throw new Error("Abstract method has no implementation.");
    }
}

class Teacher extends Person {
    info() {
        console.log("Teacher name is", this.name);
    }
}

// Instantiating subclass
const mahesh = new Teacher("Dharmik");
mahesh.info();

const person = new Person("John"); // Error: You cannot create an instance of an abstract class.
*/