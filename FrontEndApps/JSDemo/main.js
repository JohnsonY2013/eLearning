var hello = require('./hello');


// hello.greet('Jack');
// hello.hello();

// //如果想要在下一次事件响应中执行代码，可以调用process.nextTick()：
// process.nextTick(function () {
//     console.log('nextTick callback!');
// })
// console.log('nextTick was set!');

// //如果我们响应exit事件，就可以在程序即将退出时执行某个回调函数：
// process.on('exit', function (code) {
//     console.log('about to exit with code: ' + code);
// });

var fsTest = require('./demoFS');
// fsTest.readFileAsync();
// fsTest.readFileSync();

// fsTest.writeFileAsync();
// fsTest.readFileAsync();

// fsTest.writeFileSync();
// fsTest.readFileSync();

// fsTest.appendFileSync();
// fsTest.readFileSync();

// fsTest.appendFileAsync();
// fsTest.readFileAsync();

var rsTest = require('./demoRS');
// rsTest.writeStream();
// rsTest.readStream();

var httpTest = require('./demoHTTP');
// httpTest.run();

var cryptoTest = require('./demoCrypto');
cryptoTest.run();
