'use strict';

const crypto = require('crypto');
// MD5和SHA1 指定哈希算法
const hash = crypto.createHash('md5');
// const hash = crypto.createHash('sha1');
// const hash = crypto.createHash('sha256');
// const hash = crypto.createHash('sha512');

// Hmac 指定哈希算法，并给定密钥
const hmac = crypto.createHmac('sha256', 'j');

function run() {
    hash.update('Hello, world！');
    hash.update('Hello, nodejs!');
    console.log(hash.digest('hex')); //9d0c6d315104c66d7997f4550983de46
    console.log(hmac.digest('hex')); //d7657c53fd0ffbb1fd442d380fecc593316365440fc19e75b33f233bad3f7f89

    var key = 'Johnson';

    var message = "This is the raw message";
    console.log('Raw text: ' + message);

    var encryptData = aesEncrypt(message, key);
    console.log('Encrypted: ' + encryptData);

    var decryptedData = aesDecrypt(encryptData, key);
    console.log('Decrypted: ' + decryptedData);
}

//aes192，aes-128-ecb，aes-256-cbc
function aesEncrypt(data, key) {
    const cipher = crypto.createCipher('aes192', key);
    var crypted = cipher.update(data, 'utf8', 'hex');
    crypted += cipher.final('hex');
    return crypted;
}

function aesDecrypt(encrypted, key) {
    const decipher = crypto.createDecipher('aes192', key);
    var decrypted = decipher.update(encrypted, 'hex', 'utf8');
    decrypted += decipher.final('utf8');
    return decrypted;
}

module.exports = {
    run: run
};