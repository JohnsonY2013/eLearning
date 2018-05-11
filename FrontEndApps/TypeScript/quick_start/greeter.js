var Student = /** @class */ (function () {
    function Student(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return Student;
}());
function greeting(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
function greeter(person) {
    return "Hello, " + person;
}
var user = "Jane Jack";
document.body.innerHTML = greeter(user);
// let person = { firstName: "Jane", lastName: "Bob" };
// document.body.innerHTML = greeting(person);
// let stu = new Student("Jane", "M.", "User");
// document.body.innerHTML = greeting(stu);
