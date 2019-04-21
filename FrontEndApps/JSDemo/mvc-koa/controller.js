const fs = require('fs');

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