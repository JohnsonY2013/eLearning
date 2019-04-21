'use strict';

var fs = require('fs');

// 异步读文件
function readFileAsync() {

    // 文本文件
    fs.readFile('sample.txt', 'utf-8', function (err, data) {
        if (err) {
            console.log(err);
        } else {
            console.log(data);
        }
    });

    // 二进制文件
    // fs.readFile('sample.png', function(err, data){
    //     if(err){
    //         console.log(err);
    //     }else{
    //         console.log(data);
    //         console.log(data.length + ' bytes');
    //     }
    // })
}

// 同步读文件
function readFileSync() {

    // 同步读问文件
    try {
        var data = fs.readFileSync('sample.txt', 'utf-8');
        console.log(data);
    } catch (err) { }

    // try {
    //     var data = fs.readFileSync('sample.png');
    //     console.log(data);
    // } catch (err) { }

}

// 异步写文件
function writeFileAsync() {

    var data = '新内容(异步写入) \r\n';
    fs.writeFile('sample.txt', data, function (err) {
        if (err) {
            console.log(err);
        } else {
            console.log('异步写文件 - 成功！');
        }
    });
}

// 异步添加新行
function appendFileAsync() {

    var data = '新行（异步写入） \r\n';
    fs.appendFile('sample.txt', data, function (err) {
        if (err) {
            console.log(err);
        } else {
            console.log('异步添加新行 - 成功！');
        }
    });
}

// 同步写文件
function writeFileSync() {
    try {
        var data = '新内容(同步写入) \r\n';
        fs.writeFileSync('sample.txt', data);
        console.log('同步写文件 - 成功！');
    } catch (err) {
        console.log(err);
    }
}

// 同步添加新行
function appendFileSync() {
    try {
        var data = '新行（同步写入） \r\n';
        fs.appendFileSync('sample.txt', data);
        console.log('同步添加新行 - 成功！');
    } catch (err) {
        console.log(err);
    }
}

module.exports = {
    readFileAsync: readFileAsync,
    readFileSync: readFileSync,
    writeFileAsync: writeFileAsync,
    writeFileSync: writeFileSync,
    appendFileAsync: appendFileAsync,
    appendFileSync: appendFileSync
}
