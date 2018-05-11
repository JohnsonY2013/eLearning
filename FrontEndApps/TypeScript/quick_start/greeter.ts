class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

interface Person {
    firstName: string;
    lastName: string;
}

function greeting(person: Person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}

function greeter(person: string) {
    return "Hello, " + person;
}

let user = "Jane Jack";
document.body.innerHTML = greeter(user);

// let person = { firstName: "Jane", lastName: "Bob" };
// document.body.innerHTML = greeting(person);

// let stu = new Student("Jane", "M.", "User");
// document.body.innerHTML = greeting(stu);