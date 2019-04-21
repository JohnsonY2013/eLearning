'use strict';

var fs = require('fs');

function readStream() {

    // 打开一个流:
    var rs = fs.createReadStream('sample.txt', 'utf-8');

    rs.on('data', function (chunk) {
        console.log('DATA: ');
        console.log(chunk);
    });

    rs.on('end', function () {
        console.log('File END');
    });

    rs.on('error', function (err) {
        console.log('ERROR: ' + err);
    });
}

function writeStream() {
    var ws = fs.createWriteStream('sample.txt', 'utf-8');
    ws.write('使用Stream写入文本数据...\n');
    ws.write('Write END.', function () {
        fs.readFile('sample.txt', 'utf-8', function (err, data) {
            if (err) {
                console.log(err);
            } else {
                console.log(data);
            }
        });
    });
    ws.end();

    // var ws2 = fs.createWriteStream('sample.txt', 'utf-8');
    // ws2.write(new Buffer('使用Stream写入二进制数据...\n', 'utf-8'));
    // ws2.write(new Buffer('END.', 'utf-8'));
    // ws2.end();
}

function copyFile() {
    // 打开一个读取流:
    var rs = fs.createReadStream('sample.txt');
    // 打开一个写入流:
    var ws = fs.createWriteStream('sample.txt');

    rs.pipe(ws);
}

module.exports = {
    readStream: readStream,
    writeStream: writeStream,
    copyFile: copyFile
}
