'use strict';

var http = require('http');
var url = require('url');
var path = require('path');
var fs = require('fs');

function run() {

    // 从命令行参数获取root目录，默认是当前目录:
    var root = path.resolve(process.argv[2] || '.');

    console.log('Static root dir: ' + root);

    // 创建服务器:
    var server = http.createServer(function (request, response) {
        // 获得URL的path，类似 '/css/bootstrap.css':
        var pathname = url.parse(request.url).pathname;
        // 获得对应的本地文件路径，类似 '/srv/www/css/bootstrap.css':
        var filepath = path.join(root, pathname);

        // 练习
        // 如果遇到请求的路径是目录，则自动在目录下依次搜索index.html、default.html，如果找到了，就返回HTML文件的内容。
        var defaultPaths = ['index.html', 'default.html'];

        if (pathname === '/') {

            var defaultPath;
            for (defaultPath of defaultPaths) {
                var defaultFilepath = path.join(root, defaultPath);
                if (fs.existsSync(defaultFilepath)) {
                    filepath = defaultFilepath;
                    break;
                }
            }
        }

        // 获取文件状态:
        fs.stat(filepath, function (err, stats) {
            // 没有出错并且文件存在:
            if (!err && stats.isFile()) {
                console.log('200' + request.url);
                // 发送200响应:
                response.writeHead(200);
                // 将文件流导向response:
                fs.createReadStream(filepath).pipe(response);
            } else {// 出错了或者文件不存在:
                console.log('404' + request.url);
                // 发送404响应:
                response.writeHead(404);
                response.end('404 Not Found');
            }
        });

    });

    server.listen(8080);
    console.log('Server is running at http://127.0.0.1:8080/');
}

module.exports = {
    run: run
};