

var LivingEnity = function (location) {
    this.x = location.x;
    this.y = location.y;
    this.z = location.z;
}

var dog = new LivingEnity({ x: 10, y: 10, z: 10 });

LivingEnity.prototype.moveWest = function () {
    this.x--;
    console.log("x:" + this.x + ", y:" + this.y + ", z:" + this.z);
}

dog.moveWest();

LivingEnity.prototype.moveWest = function () {
    this.x = 99;
    console.log("x:" + this.x + ", y:" + this.y + ", z:" + this.z);
}

dog.moveWest();

////////////////////////////////////////////////////////////
var helloStr = 'world';
var sayHello = function (name) {
    return function () {
        console.log('Hello ' + name + '!');
    }
}

var sayGreeting = sayHello(helloStr);
sayGreeting();

helloStr = 'Bob';
sayGreeting();

/////////////////////////////////////////////////////////////
for (var i = 0; i <= 3; i++) {
    console.log(i * i);
}
//0,1,4,9

function count() {
    var arr = [];
    for (var i = 0; i <= 3; i++) {
        arr.push(function () { return i * i });
    }
    return arr;
}

var result = count();
var f1 = result[0];
var f2 = result[1];
var f3 = result[2];
var f4 = result[3];

console.log(f1());
console.log(f2());
console.log(f3());
console.log(f4());


function count2() {
    var arr = [];
    for (var i = 0; i <= 3; i++) {
        arr.push((function (n) {
            return function () {
                return n * n;
            }
        })(i));
    }
    return arr;
}


var result = count2();
var f1 = result[0];
var f2 = result[1];
var f3 = result[2];
var f4 = result[3];

console.log(f1());
console.log(f2());
console.log(f3());
console.log(f4());

///////////////////////////////////////////////////////////////
//匿名函数
(function (x) { return x * x; }(3));

///////////////////////////////////////////////////////////////
//闭包就是携带状态的函数，并且状态对外不可见

console.log('闭包 - 闭包就是携带状态的函数，并且状态对外不可见');

function create_counter(init) {
    var x = init || 0;

    return {
        inc: function () {
            x += 1;
            return x;
        }
    }
}

var c1 = create_counter();
console.log(c1.inc());
console.log(c1.inc());
console.log(c1.inc());

var c2 = create_counter(100);
console.log(c2.inc());
console.log(c2.inc());
console.log(c2.inc());

var c3 = create_counter(0);
console.log(c3.inc());
console.log(c3.inc());
console.log(c3.inc());

console.log('闭包还可以把多参数的函数变成单参数的函数');

function make_pow(n) {
    return function (x) {
        return Math.pow(x, n);
    }
}

var pow2 = make_pow(2);
var pow3 = make_pow(3);

console.log(pow2(5));
console.log(pow3(2));

console.log('箭头函数');
var t = x => x * x;
console.log(t(6));

var t2 = x => {
    if (x > 0) {
        return x * x;
    } else {
        return -x * x;
    }
}
console.log(t2(-6));


var arr = [10, 20, 1, 2];
arr.sort((x, y) => x - y);

//arr.sort((x, y) => {
//    return x - y;
//});

//arr.sort((x, y) => {
//    if (x > y) return 1;
//    else return -1;
//});


console.log(arr);


console.log('Generator');

function fib(n) {

    if (n <= 0) return [];
    if (n == 1) return [0];

    var
        a = 0,
        b = 1,
        arr = [0, 1];
    if (n == 2) return arr;

    while (arr.length < n) {
        [a, b] = [b, a + b];
        arr.push(b);
    }
    return arr;
}

console.log(fib(0));
console.log(fib(1));
console.log(fib(2));
console.log(fib(3));
console.log(fib(4));
console.log(fib(5));
console.log(fib(6));

function* fibx(n) {

    var
        a = 0,
        b = 1,
        i = 0;

    while (i < n) {
        yield a;
        [a, b] = [b, a + b];
        i++;
    }
    return;
}

for (var x of fibx(10)) {
    console.log(x);
}

console.log('练习 - 要生成一个自增的ID，可以编写一个next_id()函数');
function* next_id() {

    var i = 1;
    while (i > 0) {
        yield i;
        i++;
    }

    return;
}

// 测试:
var
    x,
    pass = true,
    g = next_id();
for (x = 1; x < 100; x++) {
    if (g.next().value !== x) {
        pass = false;
        console.log('测试失败!');
        break;
    }
}
if (pass) {
    console.log('测试通过!');
}

console.log('原型链');

console.log(Object.prototype);
console.log(Function.prototype);

function Student(n) {
    this.name = n;
    this.hello = () => console.log('Hello ' + this.name);
}

var xiaoming = new Student('小明');
xiaoming.hello();
// xiaoming.__proto__ = Student.prototype

//
//①__proto__和constructor属性是[对象]所独有的；
//② prototype属性是[函数]所独有的。
//JS中函数也是一种对象，所以函数也拥有__proto__和constructor属性

function Foo() {
    // do something...
}

var foo = new Foo();

//console.log(" : " + ()); 

// Foo 作为函数
console.log("foo.__proto__ === Foo.prototype : " + (foo.__proto__ === Foo.prototype)); // true
console.log("Foo.prototype.constructor === Foo : " + (Foo.prototype.constructor === Foo));
console.log("foo.__proto__.constructor === Foo.prototype.constructor : " + (foo.__proto__.constructor === Foo.prototype.constructor));
console.log("Foo.prototype.__proto__ === Object.prototype : " + (Foo.prototype.__proto__ === Object.prototype));
console.log("Object.prototype.__proto__ === null : " + (Object.prototype.__proto__ === null));

// Foo 作为对象
console.log("Foo.__proto__ === Function.prototype : " + (Foo.__proto__ === Function.prototype));
console.log("Foo.constructor === Function : " + (Foo.constructor === Function));

console.log(Object.prototype.constructor === Object);
console.log(Object.__proto__ === Function.prototype);   // ？？？



'use strict';
function Cat(name) {
    this.name = name;
}

Cat.prototype.say = function () {
    return 'Hello, ' + this.name + '!';
}


// 测试:
var kitty = new Cat('Kitty');
var doraemon = new Cat('哆啦A梦');
if (kitty
    && kitty.name === 'Kitty'
    && kitty.say
    && typeof kitty.say === 'function'
    && kitty.say() === 'Hello, Kitty!'
    && kitty.say === doraemon.say) {
    console.log('测试通过!');
} else {
    console.log('测试失败!');
}

console.log('原型继承...');

function inherits(Child, Parent) {
    var F = function () { };
    F.prototype = Parent.prototype;
    Child.prototype = new F();
    Child.prototype.constructor = Child;
}


console.log('class继承...');

class Employee {
    constructor(name) {
        this.name = name;
    }

    hello() {
        console.log('Hello ' + this.name + '！');
    }
}

var bob = new Employee('Bob');
bob.hello();

class RegularEmployee extends Employee {
    constructor(name, grade) {
        super(name); // 调用父类的构造函数
        this.grade = grade;
    }

    myGrade() {
        console.log('I am at grade : ' + this.grade);
    }
}

var tim = new RegularEmployee('Tim', 10);
tim.hello();
tim.myGrade();