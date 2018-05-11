//https://www.typescriptlang.org/docs/handbook/gulp.html

// function hello(compiler: string) {
//     console.log(`Hello from ${compiler}`);
// }

// hello("TypeScript");

import { sayHello } from "./greet";
// console.log(sayHello("TypeScript in greet.ts"));
function showHello(divName: string, name: string) {
    const elt = document.getElementById(divName);
    elt.innerText = sayHello(name);
}

showHello("greeting", "TypeScript");

