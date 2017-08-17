const fs = require('fs');
const Koa = require('koa');
const bodyParser = require('koa-bodyparser')
const path = require('path')
const static = require('koa-static')
const views = require('koa-views')

let router = require('./routers/index')

let app = new Koa()

const staticPath = path.join(__dirname, './static')
const viewPath = path.join(__dirname, './view')

app.name = 'flow';
app.env = 'development';
app.proxy = true;
app.listen(3000);

app.on('error', function (err, ctx) {
    console.log('err:');
    console.log(err);
    console.log(ctx);
});

app.use(static(staticPath))

// 使用ctx.body解析中间件
app.use(bodyParser())

app.use(views(viewPath,{
    extension:'ejs'
}));

// 加载路由中间件
app.use(router.routes()).use(router.allowedMethods())