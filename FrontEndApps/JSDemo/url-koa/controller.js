const fs = require('fs');

// add url-route in /controllers:

// function addMapping(router, mapping) {
//     for (var url in mapping) {
//         if (url.startsWith('GET')) {
//             var path = url.substring(4);
//             router.get(path, mapping[url]);
//             console.log(`register URL mapping: GET ${path}`);
//         } else if (url.startsWith('POST')) {
//             var path = url.substring(5);
//             router.post(path, mapping[url]);
//             console.log(`register URL mapping: POST ${path}`);
//         } else if (url.startsWith('PUT')) {
//             var path = url.substring(4);
//             router.put(path, mapping[url]);
//             console.log(`register URL mapping: PUT ${path}`);
//         } else if (url.startsWith('DELETE')) {
//             var path = url.substring(7);
//             router.del(path, mapping[url]);
//             console.log(`register URL mapping: DELETE ${path}`);
//         } else { }
//         console.log(`invalid URL: ${url}`);
//     }
// }

function addMapping(router, mapping) {

    mapping.forEach(req => {
        switch (req.method) {
            case 'GET':
                router.get(req.path, req.func);
                console.log(`register URL mapping: GET ${req.path}`);
                break;
            case 'POST':
                router.post(req.path, req.func);
                console.log(`register URL mapping: POST ${req.path}`);
                break;
            case 'PUT':
                router.put(req.path, req.func);
                console.log(`register URL mapping: PUT ${req.path}`);
                break;
            case 'DELETE':
                router.del(req.path, req.func);
                console.log(`register URL mapping: DELETE ${req.path}`);
                break;
            default:
                console.log(`invalid URL: ${req.path}`);
                break;
        }
    });
}

function addController(router, dir) {
    fs.readdirSync(__dirname + '/' + dir).filter((f) => {
        // filter out only .js (JavaScript files)
        return f.endsWith('.js');
    }).forEach((f) => {
        console.log(`processs controller: ${f}...`);
        let mappings = require(__dirname + '/' + dir + '/' + f);
        addMapping(router, mappings);
    });
}

module.exports = function (dir) {
    let controllers_dir = dir || 'controllers',
        router = require('koa-router')();
    addController(router, controllers_dir);
    return router.routes();
};