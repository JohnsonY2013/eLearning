"use strict";
//https://www.typescriptlang.org/docs/handbook/gulp.html
Object.defineProperty(exports, "__esModule", { value: true });
function hello(compiler) {
    console.log("Hello from " + compiler);
}
hello("TypeScript");
var greet_1 = require("./greet");
console.log(greet_1.sayHello("TypeScript in greet.ts"));
