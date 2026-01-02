// -----ES5 style inheritance-----
/*
// Constructor function for Animal
function Animal(name) {
    this.name = name;
}

Animal.prototype.run = function() {
    console.log(`${this.name} is running.`);
}

Animal.prototype.stop = function() {
    console.log(`${this.name} has stopped.`);
}

const dog = new Animal("Jack");
dog.run();
dog.stop();

function Dog(name) {
    // (arg1, arg2, ...): arg1 = value for 'this' inside Animal
    // Inherits all properties and methods from Animal which are defined using 'this' keyword
    Animal.call(this, name);
}

Dog.prototype = Object.create(Animal.prototype);
Dog.prototype.constructor = Dog;

console.log(Dog.prototype.__proto__ === Animal.prototype); // true

Dog.prototype.bark = function() {
    console.log(`${this.name} is barking!`);
}

const dog1 = new Dog("Rocky");
dog1.run();  
dog1.bark();
*/


// -----ES6 class inheritance-----
/*
class Animal {
    constructor(name) {
        this.name = name;
    }

    run() {
        console.log(`${this.name} is running.`);
    }

    stop() {
        console.log(`${this.name} has stopped.`);
    }
}

class Dog extends Animal {
    constructor(name, breed) {
        // Calls the parent class constructor
        super(name);
        this.breed = breed;
    }

    bark() {
        console.log(`${this.name} is barking!`);
    }
}

const dog1 = new Dog("Rocky", "German Shepherd");
dog1.run();
dog1.bark();
*/


// -----ES6 composition using factory functions & closure functions-----
/*
function createAnimal(name) {
    return {
        speak() {
            return `${name} makes a sound`;
        }
    };
}

function createDog(name) {
    const animal = createAnimal(name);

    return {
        ...animal,
        bark() {
            return `${name} barks`;
        }
    };
}

const d = createDog("Buddy");
d.speak(); 
d.bark(); 
*/