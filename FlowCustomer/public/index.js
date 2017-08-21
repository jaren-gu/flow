const Koa = require('koa');
const bodyParser = require('koa-bodyparser')
const path = require('path')
const static = require('koa-static')
const views = require('koa-views')

const router = require('../config/router')

let app = new Koa()

app.name = 'flow';
app.env = 'development';
app.proxy = true;
app.listen(3000);

//定义静态资源基准路径
const staticPath = path.join(__dirname, './static')
app.use(static(staticPath))

//定义页面基准路径
const viewPath = path.join(__dirname, './view')
app.use(views(viewPath,{
    extension:'ejs'
}));

// 使用ctx.body解析中间件
app.use(bodyParser())

//错误处理
app.on('error', function (err, ctx) {
    console.log('err:');
    console.log(err);
    console.log(ctx);
});

// 加载路由
app.use(router.routes()).use(router.allowedMethods())