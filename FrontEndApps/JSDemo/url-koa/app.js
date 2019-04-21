const Koa = require('koa');
const bodyParser = require('koa-bodyparser');

const controller = require('./controller');


// 创建一个Koa对象表示web app本身:
const app = new Koa();

app.use(async (ctx, next) => {
    console.log(`${ctx.request.method} ${ctx.request.url}`); // 打印URL
    await next(); // 调用下一个middleware
});

// parse request body:
app.use(bodyParser());

// add controllers:
app.use(controller('controllers'));

// 在端口3000监听:
app.listen(3000);
console.log('app started at port 3000...');