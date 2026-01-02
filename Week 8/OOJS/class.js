// -------------------------------------------
class Student {
    // private field
    #score = 0;

    // static property (shared by all students)
    static schoolName = "Brilliant School";

    constructor(name) {

        // each instance has its own name
        this.name = name;
    }

    // instance method
    addMarks(marks) {
        if (marks <= 0) {
            console.log("Marks must be positive");
            return;
        }
        this.#score += marks;
    }

    get score() {
        return this.#score;
    }

    set score(value) {
        if (value < 0) {
            console.log("Score cannot be negative");
        } else {
            this.#score = value;
        }
    }

    static getSchoolInfo() {
        return `Welcome to ${Student.schoolName}`;
    }
}


const student = new Student("Dharmik");

student.addMarks(50);

// getter as property
console.log(student.score); // 50

// setter as assignment
student.score = 80;
console.log(student.score); // 80

console.log(Student.schoolName);

console.log(Student.getSchoolInfo());

// console.log(student.#score); // SyntaxError



// -------------------------------------------
class ClassWithPrivateField {
    #privateField;

    constructor() {
        delete this.#privateField; // Syntax error: cannot delete a private field

        // this.#undeclaredField = 42; // Syntax error: cannot create a private field directly
    }
}

const instance = new ClassWithPrivateField();
// instance.#privateField; // Syntax error
